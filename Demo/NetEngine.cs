using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using NMEA0183;
using Survey.Forms;

namespace Survey
{
    public class NetEngine
    {
        public TcpListener _dataListener;
        public TcpListener _cmdListenert;
        protected Thread CmdThread;
        protected Thread DataThread;
        public static bool bConnect;
        public bool Initialed = false;
        string MyExecPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetModules()[0].FullyQualifiedName);
        public ADFile BssFile = new ADFile("BSS","raw");
        public ADFile XtfFile = new ADFile("BSS","xtf");
        private XTFFILEHEADER Header = new XTFFILEHEADER();
        private XTFPINGCHANHEADER PingchanHeader = new XTFPINGCHANHEADER();
        private XTFPINGHEADER PingHeader = new XTFPINGHEADER();
        public EventWaitHandle ACPacketHandle;//AC响应包同步事件句柄
        public bool hasRecv = false;
        public string Status;
        public int Ans;//应答包内容
        public TcpClient CmdClient { get; set; }
        public TcpClient DataClient { get; set; }
        public NetEngine()
        {
            Initialed = Init(5556, 5555);
        }
        //发送命令，false表示超时，true表示有返回值
        public bool SendCommand(byte[] dataBytes)
        {
            try
            {
                if (CmdClient != null && CmdClient.GetStream()!=null)
                {

                    if (CmdClient.GetStream().CanWrite)
                    {
                        if(ACPacketHandle==null)
                            ACPacketHandle = new EventWaitHandle(false, EventResetMode.AutoReset);
                        CmdClient.GetStream().Write(dataBytes, 0, dataBytes.Length);
                        if (!ACPacketHandle.WaitOne(1000))//等待信号超时
                        {
                            ACPacketHandle.Reset();
                            Exception MyEx = new Exception("接收应答超时！");
                            throw MyEx;
                        }
                        return true;
                    }

                }
                Status = "网络连接故障";
                return false;

            }
            catch (Exception MyEx)
            {
                Status = MyEx.Message;
                return false;
            }

        }
        public bool Init(int cmdport,int dataport)
        {
            try
            {
                var end = new IPEndPoint(IPAddress.Any, cmdport);
                _cmdListenert = new TcpListener(end);
                end = new IPEndPoint(IPAddress.Any, dataport);
                _dataListener = new TcpListener(end);
                return true;
            }
            catch (Exception exception)
            {
                MessageBox.Show("网络端口绑定失败：" + exception.Message);
                return false;
            }
        }

        public bool Start()
        {
            _cmdListenert.Start();
            CmdThread = new Thread(RecvAnsThread);
            CmdThread.Start(this);
            _dataListener.Start();
            DataThread = new Thread(RecvDataThread);
            DataThread.Start(this);
            return true;
        }
        public void Stop()
        {
            if (CmdClient != null)
                CmdClient.Close();
            if (_cmdListenert != null)
                _cmdListenert.Stop();
            if (CmdThread != null)
            {
                if (CmdThread.IsAlive)
                {
                    CmdThread.Abort();
                }
            }
            if (DataClient != null)
                DataClient.Close();
            if (_dataListener != null)
                _dataListener.Stop();
            if (DataThread != null)
            {
                if (DataThread.IsAlive)
                {
                    DataThread.Abort();
                }
            }
            if(BssFile.Opened)
                BssFile.Close();
        }
        public void RecvAnsThread(object obj)
        {
            NetEngine server = null;
            server = obj as NetEngine;
            if (server != null)
            {
                var myReadBuffer = new byte[1024];
                while (true)
                {
                    try
                    {
                        server.CmdClient = server._cmdListenert.AcceptTcpClient();
                        NetworkStream stream = server.CmdClient.GetStream();
                        while (stream.CanRead)
                        {
                            Array.Clear(myReadBuffer, 0, 1024);//置零
                            int numberOfBytesRead = 0;
                            stream.Read(myReadBuffer, 0, 8);//先读包头
                            Int32 PacketLength = BitConverter.ToInt32(myReadBuffer, 4) - 8;//减去包头，不减校验和
                            // Incoming message may be larger than the buffer size.
                            do
                            {
                                int n = stream.Read(myReadBuffer, 8 + numberOfBytesRead, PacketLength - numberOfBytesRead);
                                numberOfBytesRead += n;

                            }
                            while (PacketLength>0&&numberOfBytesRead < PacketLength);
                            if (numberOfBytesRead == PacketLength)
                                ParseNetworkPacket(myReadBuffer, PacketLength);
                            else
                            {
                                stream.Flush();
                                continue;
                            }
                        }
                    }
                    catch (Exception exception)
                    {
                        if (MainForm.Closeing == false)
                            MessageBox.Show("命令端口断开");
                    }
                    finally
                    {
                        if (server.CmdClient != null)
                            server.CmdClient.Close();
                        server.CmdClient = null;
                    }
                }

            }

        }
        public void RecvDataThread(object obj)
        {
            NetEngine server = null;
            server = obj as NetEngine;
            if (server != null)
            {
                var myReadBuffer = new byte[1024000];
                while (true)
                {
                    try
                    {
                        hasRecv = false;
                        server.DataClient = server._dataListener.AcceptTcpClient();
                        NetworkStream stream = server.DataClient.GetStream();
                        while (stream.CanRead)
                        {
                            Array.Clear(myReadBuffer, 0, 1024000);//置零
                            int numberOfBytesRead = 0;
                            stream.Read(myReadBuffer, 0, 8);//先读包头
                            Int32 PacketLength = BitConverter.ToInt32(myReadBuffer, 4) - 8;//减去包头，不减校验和
                            // Incoming message may be larger than the buffer size.
                            do
                            {
                                int n = stream.Read(myReadBuffer, 8 + numberOfBytesRead, PacketLength - numberOfBytesRead);
                                numberOfBytesRead += n;

                            }
                            while (PacketLength>0&&numberOfBytesRead < PacketLength);
                            if (numberOfBytesRead == PacketLength)
                                ParseNetworkPacket(myReadBuffer, PacketLength);
                            else
                            {
                                stream.Flush();
                                continue;
                            }
                        }
                    }
                    catch (Exception exception)
                    {
                        if(MainForm.Closeing==false)
                            MessageBox.Show("数据端口断开");
                    }
                    finally
                    {
                        if (server.DataClient != null)
                            server.DataClient.Close();
                        server.DataClient = null;
                    }
                }

            }

        }
        

        private void ParseNetworkPacket(byte[] ReadBuffer, int PacketLength)
        {
            byte[] myReadBuffer = new byte[PacketLength+8];
            Buffer.BlockCopy(ReadBuffer,0,myReadBuffer,0,PacketLength+8);
            switch (BitConverter.ToUInt16(myReadBuffer,0))
            {
                case (int)ComID.Ans:
                    if (ACPacketHandle!=null)
                        ACPacketHandle.Set();
                    Ans = BitConverter.ToInt32(myReadBuffer, 8);
                    if (Command.Ans.ContainsKey(Ans))
                        MainForm.mf.CmdWindow.DisplayAns(Command.Ans[Ans].ToString());
                    else
                    {
                        MainForm.mf.CmdWindow.DisplayAns("返回未知ID错误码");
                    }
                    break;
                case (int)ComID.HighParaAns:
                    if (ACPacketHandle != null)
                        ACPacketHandle.Set();
                    string str = ParsePara(myReadBuffer);
                    byte[] b = new byte[56];
                    Buffer.BlockCopy(myReadBuffer,8,b,0,56);
                    MainForm.mf.para.Highpara.Parse(b);
                    MainForm.mf.CmdWindow.DisplayAns(str);
                    break;
                case (int)ComID.LowParaAns:
                    if (ACPacketHandle != null)
                        ACPacketHandle.Set();
                    str = ParsePara(myReadBuffer);
                    b = new byte[56];
                    Buffer.BlockCopy(myReadBuffer,8,b,0,56);
                    MainForm.mf.para.Lowpara.Parse(b);
                    MainForm.mf.CmdWindow.DisplayAns(str);
                    break;
                case (int)ComID.BSSdata:
                    if(!hasRecv)
                        {
                            BssFile.SetPath(new DirectoryInfo(MyExecPath));
                        
                            XtfFile.SetPath(new DirectoryInfo(MyExecPath));
                            hasRecv = true;
                        }
                    BssFile.Write(myReadBuffer);
                    BSSResultData resultData = new BSSResultData();

                    if (ParseBssData(myReadBuffer, out resultData))
                    {
                        BSSObject data = null;
                        List<BSSObject> datalist = new List<BSSObject>();
                        str = "";
                        while (resultData.Data.ALLData.Count>0)
                        {
                            data = resultData.Data.ALLData.Dequeue();
                            str +=  "收到侧扫数据，长度=" + data.DataBytes.ToString()+"字节,类型:" + Enum.GetName(typeof (ObjectID), data.ID)+"\n";
                            MainForm.mf.DisplayRTBSS(data);
                            datalist.Add(data);
                        }
                        //save to xtf file 
                        if (Configuration.bSaveXTF)
                        {
                            SaveXTF(datalist, resultData.Parameter);
                        }
                        datalist.Clear();
                        var highrange = resultData.Parameter.Range ;//
                        var Lowrange = resultData.Parameter.Range;//
                        MainForm.mf.DisplayRTRange(highrange.ToString(), Lowrange.ToString());
                        MainForm.mf.CmdWindow.DisplayAns(str);
                        
                    }
                    break;
                case (int)ComID.SensorData:
                    BssSensorData sensorData = new BssSensorData();
                    if (ParseSensorData(myReadBuffer, out sensorData))
                    {
                        str = "收到传感器数据，长度=" + myReadBuffer.Length + "字节";
                        MainForm.mf.CmdWindow.DisplayAns(str);
                        //MainForm.mf.DisplayRTBSS(resultData);
                    }
                    break;
                default:
                    break;
            }
        }

        private void SaveXTF(List<BSSObject> datalist, BSSParameter parameter)
        {
            if (XtfFile.WriteOpened == false)
            {
                XtfFile.Create();
                XtfFile.Write(Header.pack());
            }
            DateTime dt = DateTime.Now;
            PingHeader.Year = (ushort)dt.Year;
            PingHeader.Month = (byte)dt.Month;
            PingHeader.Day = (byte)dt.Day;
            PingHeader.Hour = (byte)dt.Hour;
            PingHeader.Minute = (byte)dt.Minute;
            PingHeader.Second = (byte)dt.Second;
            PingHeader.HSeconds = (byte)(dt.Millisecond/ 10);
            PingHeader.PingNumber = datalist[0].FrameNo;
            PingHeader.NumbytesThisRecord = 256;
            foreach (var bssObject in datalist)
            {
                if (bssObject.DataBytes == 0)
                    continue;
                PingHeader.NumbytesThisRecord += 64;//pingchannel header length
                PingHeader.NumbytesThisRecord += (uint)bssObject.DataBytes;
            }
            PingHeader.SensorSpeed = GPS.Speed;
            PingHeader.SensorHeading = GPS.Heading;
            PingHeader.ShipXcoordinate = GPS.Longitude;
            PingHeader.ShipYcoordinate = GPS.Latitude;
            XtfFile.Write(PingHeader.pack());
            foreach (var bssObject in datalist)
            {
                if (bssObject.DataBytes==0)
                    continue;
                if (bssObject.ID == (uint) ObjectID.PortLowBssData)
                {
                    PingchanHeader.ChannelNumber = 0;
                    PingchanHeader.SlantRange = parameter.Range;
                    PingchanHeader.NumSamples = (uint)bssObject.DataBytes/Header.ChanInfo[0].bytesPerSample;
                    XtfFile.Write(PingchanHeader.Pack());
                    
                }
                else if (bssObject.ID == (uint)ObjectID.StartboardLowBssData)
                {
                    PingchanHeader.ChannelNumber = 1;
                    PingchanHeader.SlantRange = parameter.Range;
                    PingchanHeader.NumSamples = (uint)bssObject.DataBytes / Header.ChanInfo[1].bytesPerSample;
                    XtfFile.Write(PingchanHeader.Pack());
                    
                }
                else if (bssObject.ID == (uint)ObjectID.PortHighBssData)
                {
                    PingchanHeader.ChannelNumber = 2;
                    PingchanHeader.SlantRange = parameter.Range;
                    PingchanHeader.NumSamples = (uint)bssObject.DataBytes / Header.ChanInfo[2].bytesPerSample;
                    XtfFile.Write(PingchanHeader.Pack());

                }
                else if (bssObject.ID == (uint)ObjectID.StartboardHighBssData)
                {
                    PingchanHeader.ChannelNumber = 3;
                    PingchanHeader.SlantRange = parameter.Range;
                    PingchanHeader.NumSamples = (uint)bssObject.DataBytes / Header.ChanInfo[3].bytesPerSample;
                    XtfFile.Write(PingchanHeader.Pack());
                }
                XtfFile.Write(bssObject.BssBytes);
            }
        }

        private bool ParseSensorData(byte[] myReadBuffer, out BssSensorData sensorData)
        {
            throw new NotImplementedException();
        }

        private bool ParseBssData(byte[] myReadBuffer,out BSSResultData result)
        {
            int length = BitConverter.ToInt32(myReadBuffer, 4);
            byte[] resultBytes = new byte[length-8];
            Buffer.BlockCopy(myReadBuffer, 8, resultBytes, 0, length - 8);
            BSSResultData resultData = new BSSResultData();
            if (resultData.Parse(resultBytes))
            {
                result = resultData;
                return true;
            }
            else
            {
                result = null;
                return false;
            }
        }

        private string ParsePara(byte[] myReadBuffer)
        {
            BSSParameter p =new BSSParameter();
            byte[] b = new byte[56];
            Buffer.BlockCopy(myReadBuffer,8,b,0,56);
            if (p.Parse(b))
            {
                
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("设备序列号:"+p.DeviceID);
                sb.AppendLine("左舷发射中心频率:" + p.PortCentralFq);
                sb.AppendLine("右舷发射中心频率:" + p.StarBoardCentralFq);
                sb.AppendLine("脉冲长度:" + p.Ls);
                sb.AppendLine("左舷发射信号带宽:" + p.PortBandWidth);
                sb.AppendLine("右舷发射信号带宽:" + p.StarBoardBandWidth);
                sb.AppendLine("接收延时:" + p.RcvDelay);
                sb.AppendLine("探测距离:" + p.Range);
                sb.AppendLine("工作周期:" + p.Period);
                sb.AppendLine("AD数据采样率:" + p.ADSamples);
                sb.AppendLine("控制标识:" + p.Flag);
                sb.AppendLine("TVG延时:" + p.TVGDelay);
                sb.AppendLine("TVG更新速率:" + p.TVGReRate);
                sb.AppendLine("TVG比例因子:" + p.TvgBeta);
                sb.AppendLine("TVG吸收衰减:" + p.TvgAlpha);
                sb.AppendLine("TVG起始增益:" + p.TvgG);
                sb.AppendLine("命令标识:" + p.Com);
                sb.AppendLine("返回数据类型标识:" + p.RetID);
                sb.AppendLine("固定TVG:" + p.FixedTVG);
                return sb.ToString();
            }
            else
            {
                return @"参数解析不正确";
            }
        }
    }
}
