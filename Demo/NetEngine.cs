using System;
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
        public TcpClient Tclient, Dclient;
        public NetworkStream Tstream, Dstream;
        public static bool bConnect;
        public bool hasRecv = false;
        string MyExecPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetModules()[0].FullyQualifiedName);

        public EventWaitHandle ACPacketHandle;//AC响应包同步事件句柄
        public BackgroundWorker NodeReceiver = new BackgroundWorker();
        public BackgroundWorker NodeLinker = new BackgroundWorker();
        public BackgroundWorker CommAnsReceiver = new BackgroundWorker();
        public string Status;
        public int Ans;//应答包内容
        public NetEngine()
        {
            // 
            // NodeLinker
            // 
            NodeLinker.WorkerSupportsCancellation = true;
            NodeLinker.DoWork += new System.ComponentModel.DoWorkEventHandler(NodeLinker_DoWork);
            NodeLinker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(NodeLinker_RunWorkerCompleted);
            // 
            // NodeReceiver
            // 
            NodeReceiver.WorkerSupportsCancellation = true;
            NodeReceiver.DoWork += new System.ComponentModel.DoWorkEventHandler(NodeReceiver_DoWork);
            NodeReceiver.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(NodeReceiver_RunWorkerCompleted);
            // 
            // CommAnsReceiver
            // 
            CommAnsReceiver.WorkerSupportsCancellation = true;
            CommAnsReceiver.DoWork += new System.ComponentModel.DoWorkEventHandler(CommAnsReceiver_DoWork);
            CommAnsReceiver.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(CommAnsReceiver_RunWorkerCompleted);
        }
        //发送命令，false表示超时，true表示有返回值
        public bool SendCommand(byte[] dataBytes)
        {
            try
            {
                if (Tstream != null)
                {
                    
                    if (Tstream.CanWrite)
                    {
                        if(ACPacketHandle==null)
                            ACPacketHandle = new EventWaitHandle(false, EventResetMode.AutoReset);
                        Tstream.Write(dataBytes, 0, dataBytes.Length);
                        if (!ACPacketHandle.WaitOne(2000))//等待信号超时
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

        #region 连接节点操作
        /// <summary>
        /// 连接节点，使用nodelinker在后台连接
        /// </summary>

        public void ConnectNode(IPAddress Nodeip)
        {
           
                try
                {

                    Tclient = new TcpClient();//每次close后都要重写new一个新的对象，因为close后源对象已释放

                    Tclient.SendTimeout = 2000;
                    Dclient = new TcpClient();//每次close后都要重写new一个新的对象，因为close后源对象已释放

                    Dclient.SendTimeout = 2000;
                    if (NodeLinker.IsBusy)
                    {
                       
                        NodeLinker.CancelAsync();
                        Thread.Sleep(300);
                            
                    }
                    
                    NodeLinker.RunWorkerAsync(Nodeip);
                    Status = "连接节点中……";
                    
                }

                catch (Exception MyEx)
                {
                    Status ="连接失败！-" +MyEx.Message;
                }


        }
        private static void ConnnectCallBack(IAsyncResult ar)
        {
            try
            {
                TcpClient t = (TcpClient)ar.AsyncState;
                t.EndConnect(ar);
            }
            catch(Exception ex)
            {
                bConnect = false;
            }

        }
        private void connect(IPAddress ipaddr, BackgroundWorker MyWorker, DoWorkEventArgs e)
        {
            if (MyWorker.CancellationPending)
            {
                e.Cancel = true;
            }
            try
            {
                Status="连接命令端口……";
                Tclient.BeginConnect(ipaddr, 8080,new AsyncCallback(ConnnectCallBack), Tclient);
                while (true)
                {
                    Thread.Sleep(50);
                    if (MyWorker.CancellationPending == false)
                    {
                        if ((Tclient.Client != null) && (Tclient.Connected == true))
                        {
                            Tstream = Tclient.GetStream();
                            Status =  "命令端口已连接";
                            break;
                        }
                    }
                    else
                    {
                        e.Cancel = true;
                        return;
                    }
                }
                
            }
            catch (SocketException myEx)
            {
                e.Result = myEx.ErrorCode;
                bConnect = false;
                Status = "命令端口连接失败。错误码=" + e.Result.ToString();
                return;

            }
            Thread.Sleep(200);
            try
            {
                Status =  "连接数据命令端口……";
                Dclient.BeginConnect(ipaddr, 8081, new AsyncCallback(ConnnectCallBack), Dclient);
                while (true)
                {
                    Thread.Sleep(50);
                    if (MyWorker.CancellationPending == false)
                    {
                        if ((Dclient.Client != null) && (Dclient.Connected == true))
                        {
                            Dstream = Dclient.GetStream();
                            Status="数据端口已连接";
                            break;
                        }
                    }
                    else
                    {
                        e.Cancel = true;
                        return;
                    }
                }  
                bConnect = true;

            }
            catch (SocketException myEx)
            {
                e.Result = myEx.ErrorCode;
                bConnect = false;
                Status = "数据端口连接失败。错误码=" + e.Result.ToString();
                return;
            }

        }
        private void NodeLinker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            connect((IPAddress)e.Argument, worker, e);
        }

        private void NodeLinker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            if (e.Cancelled)
            {
                Status = "连接已被取消！";
                
                bConnect = false;
                Tclient.Close();
                Dclient.Close();
            }
            else if (e.Result != null)
            {
                bConnect = false;
                Tclient.Close();
                Dclient.Close();

            }
            else
            {
                bConnect = true;

                Status= "已连接节点";
                if (Tclient.Connected)
                {
                    CommAnsReceiver.RunWorkerAsync();
                }
                if (Dclient.Connected)
                {
                    NodeReceiver.RunWorkerAsync();
                }


            }
        }
        #endregion

        #region 接收应答
        private void CommAnsReceiver_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;

            
                while ((Tclient.Connected) && (!worker.CancellationPending))
                {
                    try
                    {
                        byte[] myReadBuffer = new byte[1024];
                        int numberOfBytesRead = 0;
                        Tstream.Read(myReadBuffer, 0, 8);
                        
                        numberOfBytesRead = 8;
                        int length = BitConverter.ToInt32(myReadBuffer, 4);
                        do
                        {

                            int n = Tstream.Read(myReadBuffer, numberOfBytesRead, length - numberOfBytesRead);
                            numberOfBytesRead += n;
                        } while (numberOfBytesRead < length);
                        if (numberOfBytesRead == length)
                            ParseNetworkPacket(myReadBuffer, length);
                        else
                        {
                            Tstream.Flush();
                            continue;
                        }
                            
                    }
                    catch (SocketException MyEx)
                    {
                        if (bConnect)
                        {
                            e.Result = MyEx.ErrorCode;
                            Status = "接收应答包错误，错误码=" + e.Result.ToString();
                            bConnect = false;
                            return;
                        }

                    }
                    catch (IOException IOEx)
                    {
                        bConnect = false;
                        return;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message + ":" + ex.StackTrace);
                    }
                }
                if (worker.CancellationPending)
                    e.Cancel = true;
            
            
        }

        private void CommAnsReceiver_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            if (e.Cancelled)
            {
                bConnect = false;
                MessageBox.Show("网络连接被取消");
            }
            else if (!bConnect)
            {
                Tclient.Close();
                Dclient.Close();
                MessageBox.Show("网络已关闭");
            }
        }
        #endregion

        #region 接收数据线程
        private void NodeReceiver_DoWork(object sender, DoWorkEventArgs e)
        {
            
            BackgroundWorker worker = sender as BackgroundWorker;
            try
            {
                if (Dclient.Connected)
                {
                    byte[] myReadBuffer = new byte[8100];
                    while ((Dstream.CanRead) && (!worker.CancellationPending))
                    {
                        Array.Clear(myReadBuffer, 0, 8100);//置零
                        int numberOfBytesRead = 0;
                        Dstream.Read(myReadBuffer, 0, 8);//先读包头
                        Int32 PacketLength = BitConverter.ToInt32(myReadBuffer, 4)-8;//减去包头，不减校验和
                        // Incoming message may be larger than the buffer size.
                        do
                        {
                            int n = Dstream.Read(myReadBuffer, 8 + numberOfBytesRead, PacketLength - numberOfBytesRead);
                            numberOfBytesRead += n;

                        }
                        while (numberOfBytesRead != PacketLength);
                        ParseNetworkPacket(myReadBuffer, PacketLength);
                    }
                    if (worker.CancellationPending)
                        e.Cancel = true;
                }
            }
            catch (SocketException MyEx)
            {
                if (bConnect)
                {
                    e.Result = MyEx.ErrorCode;
                    
                    
                    bConnect = false;
                }

            }
            catch (IOException IOEx)
            {
                bConnect = false;
                //AddtoBox(Color.Black,"IO错误!\r\n/>");
                //SendStatusLabel("IO错误！网络连接关闭");
            }

        }

        private void NodeReceiver_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            if (e.Cancelled)
            {
                bConnect = false;
                Tclient.Close();
                Dclient.Close();
                Status = "数据接收取消!";
            }
            else if (e.Error != null)
            {
                Status = "数据接收中断!"+"错误码=" + e.Result.ToString();
                Dclient.Close();
                Tclient.Close();
                
            }
            else
            {
                Status = "停止接收数据!";
                Dclient.Close();
                Tclient.Close();
            }
        }
        #endregion

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
                    BSSResultData resultData = new BSSResultData();
                    if (ParseBssData(myReadBuffer, out resultData))
                    {
                        MainForm.mf.DisplayRTBSS(resultData);
                    }
                    break;
                case (int)ComID.SensorData:

                    break;
                default:
                    break;
            }
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
                sb.AppendLine("相对增益选择:" + p.ReltG);
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
                sb.AppendLine("AD数据采样率:" + p.ADSamples);
                return sb.ToString();
            }
            else
            {
                return @"参数解析不正确";
            }
        }
    }
}
