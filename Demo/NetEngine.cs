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
        public AdFile BssFile = new AdFile("BSS");
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
                            MessageBox.Show(exception.Message);
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
                            MessageBox.Show(exception.Message);
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
        

        private void ParseNetworkPacket(byte[] myReadBuffer, int PacketLength)
        {
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
                    MainForm.mf.CmdWindow.DisplayAns(str);
                    break;
                case (int)ComID.LowParaAns:
                    if (ACPacketHandle != null)
                        ACPacketHandle.Set();
                    str = ParsePara(myReadBuffer);
                    MainForm.mf.CmdWindow.DisplayAns(str);
                    break;
                case (int)ComID.BSSdata:
                    if(!hasRecv)
                        {
                            BssFile.OpenFile(new DirectoryInfo(MyExecPath));
                            hasRecv = true;
                        }
                    BssFile.BinaryWrite(myReadBuffer);
                    if (BssFile.FileLen > 1024 * 1024 * 100)
                        {
                            BssFile.close();
                            BssFile.OpenFile(new DirectoryInfo(MyExecPath));
                        }
                    BSSResultData resultData = new BSSResultData();

                    if (ParseBssData(myReadBuffer, out resultData))
                    {
                        str = "收到侧扫数据，长度=" + myReadBuffer.Length+"字节\n";
                        var et = resultData.Data.ALLData.Keys.GetEnumerator();
                        while (et.MoveNext())
                        {
                            int key = (int) et.Current;
                            str += "数据:" + Enum.GetName(typeof (ObjectID), key)+"\n";
                        }
                        MainForm.mf.CmdWindow.DisplayAns(str);
                        MainForm.mf.DisplayRTBSS(resultData);
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

        private bool ParseSensorData(byte[] myReadBuffer, out BssSensorData sensorData)
        {
            throw new NotImplementedException();
        }

        private bool ParseBssData(byte[] myReadBuffer,out BSSResultData result)
        {
            int length = BitConverter.ToInt32(myReadBuffer, 4);
            byte[] resultBytes = new byte[length-10];
            Buffer.BlockCopy(myReadBuffer, 8, resultBytes, 0, length - 10);
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
                sb.AppendLine("左舷发射起始频率:" + p.PortStartFq);
                sb.AppendLine("右舷发射起始频率:" + p.StarBoardStartFq);
                sb.AppendLine("脉冲长度:" + p.Ls);
                sb.AppendLine("左舷发射扫频速率:" + p.PortFqRate);
                sb.AppendLine("右舷发射扫频速率:" + p.StarBoardFqRate);
                sb.AppendLine("接收延时:" + p.RcvDelay);
                sb.AppendLine("采样时间:" + p.Ts);
                sb.AppendLine("发射间隔时间:" + p.Tt);
                sb.AppendLine("AD数据采样率:" + p.ADSamples);
                sb.AppendLine("收发状态标识:" + p.Flag);
                sb.AppendLine("TVG延时:" + p.TVGDelay);
                sb.AppendLine("TVG更新速率:" + p.TVGReRate);
                sb.AppendLine("TVG控制:" + p.TVGCtl);
                sb.AppendLine("TVG比例因子:" + p.TvgBeta);
                sb.AppendLine("TVG吸收衰减:" + p.TvgAlpha);
                sb.AppendLine("TVG起始增益:" + p.TvgG);
                sb.AppendLine("命令标识:" + p.Com);
                sb.AppendLine("返回数据类型标识:" + p.RetID);
                sb.AppendLine("固定TVG:" + p.FixedTVG);
                sb.AppendLine("TVG发送长度:" + p.TVGLength);
                sb.AppendLine("TVG模式选择:" + p.TVGMode);
                return sb.ToString();
            }
            else
            {
                return @"参数解析不正确";
            }
        }
    }
}
