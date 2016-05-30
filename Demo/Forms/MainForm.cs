using System;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Net;
using System.Net.NetworkInformation;
using System.Threading;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using NMEA0183;

namespace Survey.Forms
{
    public partial class MainForm : OfficeForm
    {
        public string Title = "Version 2.01 BSS Sonar Processing System –UAI（北京联合声信海洋技术有限公司）";
        private XTFFILEHEADER Header = new XTFFILEHEADER();
        private XTFPINGCHANHEADER PingchanHeader = new XTFPINGCHANHEADER();
        private XTFPINGHEADER PingHeader = new XTFPINGHEADER();
        //used for file mode
        public BinaryReader playbackFileStream;
        public FileInfo fi = null;
        public long offset = 0;
        public string filename;
        public int tick = 64;
        //show flag of windows
        public bool bShowNavi = false;
        public bool bShowSensor = false;
        public bool bShowRaw = false;
        public bool bShowInfo = true;
        private int block = 1024;
        public static bool Closeing = false;
        //windows collection
        private NavigationView NaviView = null;
        private SensorForm SensorView = null;
        private ChartForm BssView1 = null;
        private ChartForm BssView2 = null;
        public CommandLineForm CmdWindow = new CommandLineForm();
        public BasicOption option = new BasicOption();
        public ParaForm para = new ParaForm();
        private bool bPanel1triger;
        private bool bPanel2triger;
        public static MainForm mf;
        public NetEngine netcore;
        public GPSSerialService gpscore;
        public MainForm()
        {
            InitializeComponent();
            netcore = new NetEngine();
            gpscore = new GPSSerialService();
            
            NetworkAvailabilityChangedEventHandler e =new NetworkAvailabilityChangedEventHandler(AvailabilityChangedCallback);
            Command.Init();
            if (
                gpscore.Init(new SerialPort(BasicConf.GetInstance().GetCommGPS(),
                    int.Parse(BasicConf.GetInstance().GetGPSDataRate()))))
            {
                gpscore.Start();
            }
        }
        private void AvailabilityChangedCallback(object sender, EventArgs e)
        {
            NetworkAvailabilityEventArgs myEg = (NetworkAvailabilityEventArgs)e;
            if (!myEg.IsAvailable)
            {

                netcore.Stop();
                
                MessageBox.Show("网络出错，请检查！");

                NetEngine.bConnect = false;
            }

        }
        public void ChildFormClose(Form child)
        {
            if (NaviView == child)
            {
                NaviView.Hide();
                //NaviView = null;
                bShowNavi = false;
                if (SensorView!=null&&SensorView.Visible)
                    ShowSensorOnly();
                else
                    NoneNaviAndSensor();
                ShowNavi.Checked = false;
            }
            else if (SensorView == child)
            {
                SensorView.Hide();
                bShowSensor = false;
                if (NaviView != null && NaviView.Visible)
                    ShowNaviOnly();
                else
                    NoneNaviAndSensor();
                ShowSensor.Checked = false;
            }
            else if (BssView1 == child)
            {
                BssView1.Hide();
                if (BssView2 != null && BssView2.Visible)
                    ShowView2Max();
                else
                {
                    NoneBssView();
                }
            }
            else if (BssView2 == child)
            {
                BssView2.Hide();
                if (BssView1 != null && BssView1.Visible)
                    ShowView1Max();
                else
                {
                    NoneBssView();
                }
            }
        }
        private void Help_Click(object sender, EventArgs e)
        {
            var ab = new AboutBox();
            ab.Show();
        }

        private void DataSaveBox_Click(object sender, EventArgs e)
        {
            if (Configuration.bSaveXTF == false)
            {
                DataSaveBox.Text = "正在保存XTF数据";
                DataSaveBox.BackColor = Color.Green;
                Configuration.bSaveXTF = true;
                Configuration.bNewXTF = true;
            }
            else
            {
                DataSaveBox.Text = "XTF数据未保存";
                DataSaveBox.BackColor = Color.Red;
                Configuration.bSaveXTF = false;
                Configuration.bNewXTF = false;
                if(netcore.XtfFile.WriteOpened)
                    netcore.XtfFile.Close();
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            mf = this;
            bShowRaw = true;
            PlaybackTime.Enabled = false;
            DataSaveBox.BackColor = Color.Red;
            ShowInfoRegion.Checked = bShowInfo;
            splitViewer.SplitterDistance = splitViewer.Width;
            NoneBssView();
            NoneNaviAndSensor();
            
            StatusLabel.Text = "就绪";
            StatusLabel.ForeColor = Color.White;
            LongLabel.ForeColor = Color.White;
            LatLabel.ForeColor = Color.White;
            InitConfigure();
            CmdWindow.Visible = false;
            if (netcore.Initialed)
            {
                netcore.Start();
            }
            OpenBssView.PerformClick();
            //OpenBssView.PerformClick();
            if (BssView1!=null)
            {
                BssView1.option.Fq = Frequence.High;
            }
            if (BssView2!=null)
            {
                BssView2.option.Fq = Frequence.Low;
            }
            SetWorkingState();
            DataSaveBox.PerformClick();
        }

        private void InitConfigure()
        {
            Configuration.PanelMinWidth = 400;
        }
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            string message = "是否退出程序？";
            string caption = "消息";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            MessageBoxIcon icon = MessageBoxIcon.Question;
            MessageBoxDefaultButton defaultResult = MessageBoxDefaultButton.Button2;
            // Show message box
            DialogResult result = MessageBox.Show(message, caption, buttons, icon, defaultResult);
            e.Cancel = true;
            if (result == DialogResult.OK)
            {
                PlaybackTime.Stop();
                if (playbackFileStream!=null)
                    playbackFileStream.Close();
                e.Cancel = false;
                Closeing = true;
                if(netcore!=null)
                    netcore.Stop();
                netcore.XtfFile.Close();
            }
            

        }

        private void Playback_Tick(object sender, EventArgs e)
        {
            float persentage = offset * 100 / fi.Length;
            //playpercent.Value = (int)persentage;
            this.Text = Title + "-回放" + " - " + filename + "(" + persentage.ToString("F01") + "%)";
            
            GetOnePingData();
        }

        private void GetOnePingData()
        {
            if (offset == 0) //文件头
                offset = ReadFileHeader();
            if (offset < 1024 || playbackFileStream.BaseStream.Position >= fi.Length)
                return;
        ReadMagic:
            //读数据包
            if (offset >= fi.Length)//end
            {
                
                PlaybackTime.Enabled = false;
                float persentage = offset * 100 / fi.Length;
                this.Text = Title + "-回放" + " - " + filename + "(" + persentage.ToString("F01") + "%)";
                offset = 0;
                playbackFileStream.BaseStream.Seek(offset, SeekOrigin.Begin);
                SetReplayState();
                return;
            }
            var magic = playbackFileStream.ReadUInt16();
            while (magic != 0xFACE)
            {
                playbackFileStream.BaseStream.Position--;//后退一字节
                magic = playbackFileStream.ReadUInt16();
                if (playbackFileStream.BaseStream.Position >= fi.Length)
                    break;
            }
            if (magic == 0xFACE)//找到包头
            {
                if (playbackFileStream.PeekChar() == 3) //姿态数据
                {
                    playbackFileStream.BaseStream.Position += 64 - 2;//跳过这个姿态包
                    offset = playbackFileStream.BaseStream.Position;
                    goto ReadMagic;
                }
                playbackFileStream.BaseStream.Position -= 2;//回到包头前
                offset = ReadPingHeader();
                if (offset < 0)
                    return;
                if (PingHeader.HeaderType == 0) //测扫
                {
                    string highrange = "";
                    string lowrange = "";
                    while (true)
                    {

                        if (ReadPingchanHeader() < 0)
                            return;
                        uint DataNeedToRead = Header.ChanInfo[PingchanHeader.ChannelNumber].bytesPerSample * PingchanHeader.NumSamples;
                        byte[] buf = playbackFileStream.ReadBytes((int)DataNeedToRead);
                        offset = playbackFileStream.BaseStream.Position;

                        //display
                        if (BssView1 != null )
                        {
                            BssView1.DisplayChart((int)PingchanHeader.ChannelNumber, (int) DataNeedToRead, buf);
                            
                        }
                        if (BssView2 != null )
                        {
                            BssView2.DisplayChart((int)PingchanHeader.ChannelNumber, (int)DataNeedToRead, buf);
                            
                        }
                        if (PingchanHeader.ChannelNumber == 0 || PingchanHeader.ChannelNumber == 1)
                            lowrange = PingchanHeader.SlantRange.ToString("F0");
                        if (PingchanHeader.ChannelNumber == 2 || PingchanHeader.ChannelNumber == 3)
                            highrange = PingchanHeader.SlantRange.ToString("F0");
                        DisplayRTRange(highrange, lowrange);
                        if (offset >= fi.Length)
                            goto ReadMagic;//file end 
                    }
                    

                }
                else//测深包
                {
                    playbackFileStream.BaseStream.Position += PingHeader.NumbytesThisRecord - 256;//读完包头，再跳过不要的内容
                    offset = playbackFileStream.BaseStream.Position;
                    return;
                }
            }
        }

        /// <summary>
        /// 读取XTF文件头
        /// </summary>
        /// <returns>文件头大小</returns>
        private int ReadFileHeader()
        {
            Header.FileFormat = playbackFileStream.ReadByte();
            if (Header.FileFormat != 0x7B)
                return -1;
            try
            {
                Header.SystemType = playbackFileStream.ReadByte();
                Buffer.BlockCopy(playbackFileStream.ReadChars(8), 0, Header.RecordingProgramName, 0, 8);
                Buffer.BlockCopy(playbackFileStream.ReadChars(8), 0, Header.RecordingProgramVersion, 0, 8);
                Buffer.BlockCopy(playbackFileStream.ReadChars(16), 0, Header.SonarName, 0, 16);
                Header.SonarType = playbackFileStream.ReadUInt16();
                Buffer.BlockCopy(playbackFileStream.ReadChars(64), 0, Header.NoteString, 0, 64);
                Buffer.BlockCopy(playbackFileStream.ReadChars(64), 0, Header.ThisFileName, 0, 64);
                Header.NavUnits = playbackFileStream.ReadUInt16();
                Header.NumberOfSonarChannels = playbackFileStream.ReadUInt16();
                Header.NumberOfBathymetryChannels = playbackFileStream.ReadUInt16();
                Header.NumberOfForwardLookArrays = playbackFileStream.ReadUInt16();
                Header.NumberOfEchoStrengthChannels = playbackFileStream.ReadUInt16();
                Header.NumberOfInterferometryChannels = playbackFileStream.ReadByte();
                playbackFileStream.ReadBytes(29);//not used
                Header.NavigationLatency = playbackFileStream.ReadUInt32();
                playbackFileStream.ReadBytes(8);//not used
                Header.NavOffsetY = playbackFileStream.ReadSingle();
                Header.NavOffsetX = playbackFileStream.ReadSingle();
                Header.NavOffsetZ = playbackFileStream.ReadSingle();
                Header.NavOffsetYaw = playbackFileStream.ReadSingle();
                Header.MRUOffsetY = playbackFileStream.ReadSingle();
                Header.MRUOffsetX = playbackFileStream.ReadSingle();
                Header.MRUOffsetZ = playbackFileStream.ReadSingle();
                Header.MRUOffsetYaw = playbackFileStream.ReadSingle();
                Header.MRUOffsetPitch = playbackFileStream.ReadSingle();
                Header.MRUOffsetRoll = playbackFileStream.ReadSingle();
                for (int i = 0; i < 6; i++)//应该不会大于6
                {
                    Header.ChanInfo[i].TypeOfChannel = playbackFileStream.ReadByte();
                    Header.ChanInfo[i].SubChannelNumber = playbackFileStream.ReadByte();
                    Header.ChanInfo[i].CorrectionFlags = playbackFileStream.ReadUInt16();
                    Header.ChanInfo[i].UniPolar = playbackFileStream.ReadUInt16();
                    Header.ChanInfo[i].bytesPerSample = playbackFileStream.ReadUInt16();
                    playbackFileStream.ReadBytes(4);
                    Buffer.BlockCopy(playbackFileStream.ReadChars(16), 0, Header.ChanInfo[i].ChannelName, 0, 16);
                    Header.ChanInfo[i].VoltScale = playbackFileStream.ReadSingle();
                    Header.ChanInfo[i].Frequency = playbackFileStream.ReadSingle();
                    Header.ChanInfo[i].HorizBeamAngle = playbackFileStream.ReadSingle();
                    Header.ChanInfo[i].TiltAngle = playbackFileStream.ReadSingle();
                    Header.ChanInfo[i].BeamWidth = playbackFileStream.ReadSingle();
                    Header.ChanInfo[i].OffsetX = playbackFileStream.ReadSingle();
                    Header.ChanInfo[i].OffsetY = playbackFileStream.ReadSingle();
                    Header.ChanInfo[i].OffsetZ = playbackFileStream.ReadSingle();
                    Header.ChanInfo[i].OffsetYaw = playbackFileStream.ReadSingle();
                    Header.ChanInfo[i].OffsetPitch = playbackFileStream.ReadSingle();
                    Header.ChanInfo[i].OffsetRoll = playbackFileStream.ReadSingle();
                    Header.ChanInfo[i].BeamsPerArray = playbackFileStream.ReadUInt16();
                    Header.ChanInfo[i].SampleFormat = playbackFileStream.ReadByte();
                    playbackFileStream.ReadBytes(53);
                }
                return (int)playbackFileStream.BaseStream.Position;
            }
            catch (Exception e)
            {
                return -2;
            }


        }

        /// <summary>
        /// 读取ping/bath header，更新界面
        /// </summary>
        /// <returns></returns>
        private int ReadPingHeader()
        {
            PingHeader.MagicNumber = playbackFileStream.ReadUInt16();
            if (PingHeader.MagicNumber != 0xFACE)
                return -1;
            try
            {
                bool show = false;
                PingHeader.HeaderType = playbackFileStream.ReadByte();
                PingHeader.SubChannelNumber = playbackFileStream.ReadByte();
                PingHeader.NumChansToFollow = playbackFileStream.ReadUInt16();
                PingHeader.Reserved1[0] = playbackFileStream.ReadUInt16();
                PingHeader.Reserved1[1] = playbackFileStream.ReadUInt16();
                PingHeader.NumbytesThisRecord = playbackFileStream.ReadUInt32();
                PingHeader.Year = playbackFileStream.ReadUInt16();
                PingHeader.Month = playbackFileStream.ReadByte();
                PingHeader.Day = playbackFileStream.ReadByte();
                PingHeader.Hour = playbackFileStream.ReadByte();
                PingHeader.Minute = playbackFileStream.ReadByte();
                PingHeader.Second = playbackFileStream.ReadByte();
                PingHeader.HSeconds = playbackFileStream.ReadByte();
                if (PingHeader.Year != 0)
                    show = true;
                if (show)
                    PingTimeLabel.Text = PingHeader.Hour.ToString("D2") + ":" + PingHeader.Minute.ToString("D2") +
                                     ":" +
                                     PingHeader.Second.ToString("D2") + "." + PingHeader.HSeconds.ToString("D2");
                if (show)
                    DateLabel.Text = PingHeader.Year.ToString("D") + "//" + PingHeader.Month.ToString("D2") + "//" +
                                     PingHeader.Day.ToString("d2");
                PingHeader.JulianDay = playbackFileStream.ReadUInt16();
                PingHeader.EventNumber = playbackFileStream.ReadUInt32();
                PingHeader.PingNumber = playbackFileStream.ReadUInt32();
                if (show)
                    PingNo.Text = PingHeader.PingNumber.ToString();
                PingHeader.SoundVelocity = playbackFileStream.ReadSingle();
                PingHeader.OceanTide = playbackFileStream.ReadSingle();
                PingHeader.Reserved2 = playbackFileStream.ReadUInt32();
                PingHeader.ConductivityFreq = playbackFileStream.ReadSingle();
                PingHeader.TemperatureFreq = playbackFileStream.ReadSingle();
                PingHeader.PressureFreq = playbackFileStream.ReadSingle();
                PingHeader.PressureTemp = playbackFileStream.ReadSingle();
                PingHeader.Conductivity = playbackFileStream.ReadSingle();
                PingHeader.WaterTemperature = playbackFileStream.ReadSingle();
                Templabel.Text = PingHeader.WaterTemperature.ToString("F01") + "°C";
                PingHeader.Pressure = playbackFileStream.ReadSingle();
                if (show)
                    PressLabel.Text = PingHeader.Pressure.ToString("F2")+"Pa";
                PingHeader.ComputedSoundVelocity = playbackFileStream.ReadSingle();
                PingHeader.MagX = playbackFileStream.ReadSingle();
                PingHeader.MagY = playbackFileStream.ReadSingle();
                PingHeader.MagZ = playbackFileStream.ReadSingle();
                PingHeader.AuxVal1 = playbackFileStream.ReadSingle();
                PingHeader.AuxVal2 = playbackFileStream.ReadSingle();
                PingHeader.AuxVal3 = playbackFileStream.ReadSingle();
                PingHeader.AuxVal4 = playbackFileStream.ReadSingle();
                PingHeader.AuxVal5 = playbackFileStream.ReadSingle();
                PingHeader.AuxVal6 = playbackFileStream.ReadSingle();
                PingHeader.SpeedLog = playbackFileStream.ReadSingle();
                PingHeader.Turbidity = playbackFileStream.ReadSingle();
                PingHeader.ShipSpeed = playbackFileStream.ReadSingle();
                
                PingHeader.ShipGyro = playbackFileStream.ReadSingle();
                Courselabel.Text = PingHeader.ShipGyro.ToString("F2") + "°";

                PingHeader.ShipYcoordinate = playbackFileStream.ReadDouble();
                if (show)
                {
                    if (PingHeader.ShipYcoordinate > 0)
                        Lat.Text = PingHeader.ShipYcoordinate.ToString("F06") + "°" + "N";
                    else
                    {
                        Lat.Text = PingHeader.ShipYcoordinate.ToString("F06") + "°" + "S";
                    }
                    LatLabel.Text = Lat.Text;
                }

                PingHeader.ShipXcoordinate = playbackFileStream.ReadDouble();
                if (show)
                {
                    if (PingHeader.ShipXcoordinate > 0)
                    {
                        Long.Text = PingHeader.ShipXcoordinate.ToString("F06") + "°" + "E";
                    }
                    else
                    {
                        Long.Text = PingHeader.ShipXcoordinate.ToString("F06") + "°" + "W";
                    }
                    LongLabel.Text = Long.Text;
                }

                PingHeader.ShipAltitude = playbackFileStream.ReadUInt16();

                PingHeader.ShipDepth = playbackFileStream.ReadUInt16();
                PingHeader.FixTimeHour = playbackFileStream.ReadByte();
                PingHeader.FixTimeMinute = playbackFileStream.ReadByte();
                PingHeader.FixTimeSecond = playbackFileStream.ReadByte();
                PingHeader.FixTimeHSecond = playbackFileStream.ReadByte();
                PingHeader.SensorSpeed = playbackFileStream.ReadSingle();
                if (show)
                    SpeedLabel.Text = PingHeader.SensorSpeed.ToString("f2") + "knot";
                PingHeader.KP = playbackFileStream.ReadSingle();
                PingHeader.SensorYcoordinate = playbackFileStream.ReadDouble();
                PingHeader.SensorXcoordinate = playbackFileStream.ReadDouble();
                PingHeader.SonarStatus = playbackFileStream.ReadUInt16();
                PingHeader.RangeToFish = playbackFileStream.ReadUInt16();
                PingHeader.BearingToFish = playbackFileStream.ReadUInt16();
                PingHeader.CableOut = playbackFileStream.ReadUInt16();
                PingHeader.Layback = playbackFileStream.ReadSingle();
                PingHeader.CableTension = playbackFileStream.ReadSingle();
                PingHeader.SensorDepth = playbackFileStream.ReadSingle();
                Depthlabel.Text = PingHeader.SensorDepth.ToString("F03") + "m";
                PingHeader.SensorPrimaryAltitude = playbackFileStream.ReadSingle();
                if (show)
                    SonarHeightBox.Text = PingHeader.SensorPrimaryAltitude.ToString("F01");
                PingHeader.SensorAuxAltitude = playbackFileStream.ReadSingle();
                PingHeader.SensorPitch = playbackFileStream.ReadSingle();
                if (show)
                    PitchLabel.Text = PingHeader.SensorPitch.ToString("F2");
                PingHeader.SensorRoll = playbackFileStream.ReadSingle();
                if (show)
                    RollLabel.Text = PingHeader.SensorRoll.ToString("F02");
                PingHeader.SensorHeading = playbackFileStream.ReadSingle();
                if (show)
                    HeadLabel.Text = PingHeader.SensorHeading.ToString("F2");
                PingHeader.Heave = playbackFileStream.ReadSingle();
                
                PingHeader.Yaw = playbackFileStream.ReadSingle();

                PingHeader.AttitudeTimeTag = playbackFileStream.ReadUInt32();
                PingHeader.DOT = playbackFileStream.ReadSingle();
                PingHeader.NavFixMilliseconds = playbackFileStream.ReadUInt32();
                PingHeader.ComputerClockHour = playbackFileStream.ReadByte();
                PingHeader.ComputerClockMinute = playbackFileStream.ReadByte();
                PingHeader.ComputerClockSecond = playbackFileStream.ReadByte();
                PingHeader.ComputerClockHsec = playbackFileStream.ReadByte();
                PingHeader.FishPositionDeltaX = playbackFileStream.ReadInt16();
                PingHeader.FishPositionDeltaY = playbackFileStream.ReadInt16();
                PingHeader.FishPositionErrorCode = playbackFileStream.ReadByte();
                Buffer.BlockCopy(playbackFileStream.ReadChars(11), 0, PingHeader.ReservedSpace2, 0, 11);
                if (SensorView != null&&show)
                {
                    SensorView.Display(DataType.Altitude, PingHeader.SensorPrimaryAltitude);
                    SensorView.Display(DataType.Depth, PingHeader.SensorDepth);
                    SensorView.Display(DataType.Heading, PingHeader.SensorHeading);
                    SensorView.Display(DataType.Pitch, PingHeader.SensorPitch);
                    SensorView.Display(DataType.Pressure, PingHeader.Pressure);
                    SensorView.Display(DataType.Roll, PingHeader.SensorRoll);
                    SensorView.Display(DataType.Speed, PingHeader.SensorSpeed);
                    SensorView.Display(DataType.Temperature, PingHeader.WaterTemperature);
                }
                if (NaviView != null && show)
                {
                    NaviView.AddLocation(PingHeader.ShipYcoordinate, PingHeader.ShipXcoordinate, PingHeader.SensorHeading);
                }
                return (int)playbackFileStream.BaseStream.Position;
            }
            catch (Exception e)
            {
                return -2;
            }
        }

        private int ReadPingchanHeader()
        {
            PingchanHeader.ChannelNumber = playbackFileStream.ReadUInt16();
            if (PingchanHeader.ChannelNumber > 3)//可能是0xface
            {
                playbackFileStream.BaseStream.Position -= 2;//退回开始读的位置，可能是下一个包头
                return -1;
            }

            try
            {
                PingchanHeader.DownsampleMethod = playbackFileStream.ReadUInt16();
                PingchanHeader.SlantRange = playbackFileStream.ReadSingle();
                Rangelabel.Text = PingchanHeader.SlantRange.ToString("F0") + "m";
                PingchanHeader.GroundRange = playbackFileStream.ReadSingle();
                PingchanHeader.TimeDelay = playbackFileStream.ReadSingle();
                PingchanHeader.TimeDuration = playbackFileStream.ReadSingle();
                PingchanHeader.SecondsPerPing = playbackFileStream.ReadSingle();
                PingchanHeader.ProcessingFlags = playbackFileStream.ReadUInt16();
                PingchanHeader.Frequency = playbackFileStream.ReadUInt16();
                PingchanHeader.InitialGainCode = playbackFileStream.ReadUInt16();
                PingchanHeader.GainCode = playbackFileStream.ReadUInt16();
                PingchanHeader.BandWidth = playbackFileStream.ReadUInt16();
                PingchanHeader.ContactNumber = playbackFileStream.ReadUInt32();
                PingchanHeader.ContactClassification = playbackFileStream.ReadUInt16();
                PingchanHeader.ContactSubNumber = playbackFileStream.ReadByte();
                PingchanHeader.ContactType = playbackFileStream.ReadByte();
                PingchanHeader.NumSamples = playbackFileStream.ReadUInt32();
                PingchanHeader.MillivoltScale = playbackFileStream.ReadUInt16();
                PingchanHeader.ContactTimeOffTrack = playbackFileStream.ReadSingle();
                PingchanHeader.ContactCloseNumber = playbackFileStream.ReadByte();
                PingchanHeader.Reserved2 = playbackFileStream.ReadByte();
                PingchanHeader.FixedVSOP = playbackFileStream.ReadSingle();
                PingchanHeader.Weight = playbackFileStream.ReadUInt16();
                Buffer.BlockCopy(playbackFileStream.ReadChars(4), 0, PingchanHeader.ReservedSpace, 0, 4);
                return (int)playbackFileStream.BaseStream.Position;
            }
            catch (Exception e)
            {
                return -2;
            }
        }
        
    
        #region system Menu
        
        
        private void ShowBss_Click(object sender, EventArgs e)
        {
            if (BssView1 == null)//没有侧扫1窗口
            {
                BssView1 = new ChartForm(this);
                
                BssView1.MdiParent =this ;
                
                BssView1.Dock = DockStyle.Fill;
                BssView1.Parent = Bss1Panel;
                BssView1.WindowState = FormWindowState.Normal;
              
                BssView1.ShowRaw(bShowRaw);
                BssView1.Show();
                
            }
            else
            {
                if(!BssView1.Visible)
                    BssView1.Show();
            }
            if (BssView2 == null)//没有侧扫2窗口
            {
                BssView2 = new ChartForm(this);

                BssView2.MdiParent = this;
                BssView2.Dock = DockStyle.Fill;
                BssView2.Parent = Bss2Panel;

                BssView2.WindowState = FormWindowState.Normal;
                //BssView2.ShowRaw(bShowRaw);
                BssView2.Show();
            }
            else
            {
                if (!BssView2.Visible)
                    BssView2.Show();
            }
                ShowAllBssView();
            声纳图像ToolStripMenuItem.Checked = true;
        }
        private void ShowNavi_Click(object sender, EventArgs e)
        {
            if (!bShowNavi)
            {
                if(NaviView==null)
                    NaviView = new NavigationView(this);
                NaviView.MdiParent = this;
                NaviView.Parent = Navipanel;
                NaviView.Dock = DockStyle.Fill;
                NaviView.Show();
                bShowNavi = true;
                if (SensorView!=null&&SensorView.Visible)
                    ShowNaviAndSensor();
                else
                    ShowNaviOnly();
            }
            else
            {
                if (NaviView != null)
                {
                    NaviView.Hide();
                }
                if (SensorView != null && SensorView.Visible)
                    ShowSensorOnly();
                else
                    NoneNaviAndSensor();
                bShowNavi = false;
            }
        }
        

        private void ShowSensor_Click(object sender, EventArgs e)
        {
            if (!bShowSensor)
            {
                if(SensorView==null)
                    SensorView = new SensorForm(this);
                SensorView.MdiParent = this;
                SensorView.Parent = Sensorpanel;
                SensorView.Dock = DockStyle.Fill;
                SensorView.Show();
                bShowSensor = true;
                if (NaviView!=null&&NaviView.Visible)
                    ShowNaviAndSensor();
                else
                    ShowSensorOnly();
            }
            else
            {
                if(SensorView!=null)
                    SensorView.Hide();
                bShowSensor = false;
                if (NaviView != null && NaviView.Visible)
                    ShowNaviOnly();
                else
                    NoneNaviAndSensor();
            }
        }

        private void ShowRaw_Click(object sender, EventArgs e)
        {
            if (bShowRaw == true)
            {
                bShowRaw = false;
            }
            else
            {
                bShowRaw = true;
            }
            if (BssView1 != null)
            {
                BssView1.ShowRaw(bShowRaw);
            }
            if (BssView2 != null)
            {
                BssView2.ShowRaw(bShowRaw);
            }
        }
        private void ShowInfoRegion_Click(object sender, EventArgs e)
        {
            if (bShowInfo == true)
            {
                DataPanel.Height = 0;
                bShowInfo = false;
                ShowInfoRegion.Checked = bShowInfo;
            }
            else
            {
                DataPanel.Height = 107;
                bShowInfo = true;
                ShowInfoRegion.Checked = bShowInfo;
            }

        }
        #endregion

        #region layout
        //第一个图放大（第二图关闭或创建第一个图）
        private void ShowView1Max()
        {
            LeftTable.RowStyles[0].Height = 0;
            LeftTable.RowStyles[1].SizeType = SizeType.Percent;
            LeftTable.RowStyles[1].Height = 100;
            LeftTable.RowStyles[2].Height = 0;
            LeftTable.RowStyles[3].SizeType = SizeType.Percent;
            LeftTable.RowStyles[3].Height = 0;
        }
        //第二个图放大（第一个图关闭）
        private void ShowView2Max()
        {

            LeftTable.RowStyles[0].Height = 0;
            LeftTable.RowStyles[1].SizeType = SizeType.Percent;
            LeftTable.RowStyles[1].Height = 0;
            LeftTable.RowStyles[2].Height = 0;
            LeftTable.RowStyles[3].SizeType = SizeType.Percent;
            LeftTable.RowStyles[3].Height = 100;
        }
        //有两个图一起出现
        private void ShowAllBssView()
        {
            LeftTable.RowStyles[0].Height = 0;
            LeftTable.RowStyles[1].SizeType = SizeType.Percent;
            LeftTable.RowStyles[1].Height = 50;
            LeftTable.RowStyles[2].Height = 0;
            LeftTable.RowStyles[3].SizeType = SizeType.Percent;
            LeftTable.RowStyles[3].Height = 50;
        }
        private void NoneBssView()
        {
            LeftTable.RowStyles[0].Height = 0;
            LeftTable.RowStyles[1].SizeType = SizeType.Percent;
            LeftTable.RowStyles[1].Height = 50;
            LeftTable.RowStyles[2].Height = 0;
            LeftTable.RowStyles[3].SizeType = SizeType.Percent;
            LeftTable.RowStyles[3].Height = 50;
        }

        private void ShowNaviOnly()
        {
            if (splitViewer.Panel2.Width < Configuration.PanelMinWidth) //未创建右边窗口
            {
                splitViewer.Panel2MinSize = Configuration.PanelMinWidth;
                splitViewer.SplitterDistance = splitViewer.Width - splitViewer.Panel2MinSize - 7;
            }

            RightTable.RowStyles[0].SizeType = SizeType.Percent;
            RightTable.RowStyles[0].Height = 100;
            RightTable.RowStyles[1].SizeType = SizeType.Percent;
            RightTable.RowStyles[1].Height = 0;
        }
        private void ShowSensorOnly()
        {
            if (splitViewer.Panel2.Width < Configuration.PanelMinWidth) //未创建右边窗口
            {
                splitViewer.Panel2MinSize = Configuration.PanelMinWidth;
                splitViewer.SplitterDistance = splitViewer.Width - splitViewer.Panel2MinSize - 7;
            }
            RightTable.RowStyles[0].Height = 0;
            RightTable.RowStyles[0].SizeType = SizeType.Percent;

            RightTable.RowStyles[1].Height = 100;
            RightTable.RowStyles[1].SizeType = SizeType.Percent;
        }
        private void ShowNaviAndSensor()
        {
            RightTable.RowStyles[0].SizeType = SizeType.Percent;
            RightTable.RowStyles[0].Height = 50;
            RightTable.RowStyles[1].SizeType = SizeType.Percent;
            RightTable.RowStyles[1].Height = 50;
        }
        private void NoneNaviAndSensor()
        {
            splitViewer.Panel2MinSize = 0;
            splitViewer.SplitterDistance = splitViewer.Width + 7;
        }

        private void MainForm_SizeChanged(object sender, EventArgs e)
        {/*
            Point last1, last2, newp;
            last1 = new Point(-1,-1);
            last2 = new Point(-1, -1);
            newp = new Point(0, 0);
            if (BssView1 != null)
            {
                if (Bss1Panel.Width > BssView1.Width)
                {
                    newp.X = last1.X + (Bss1Panel.Width - BssView1.Width)/2;
                    newp.Y = last1.Y;
                    BssView1.Location = newp;
                    BssView1.Update();
                }
                else
                {
                    BssView1.Location = last1;
                    BssView1.Update();
                }
            }
            if (BssView2 != null)
            {
                if (Bss2Panel.Width > BssView2.Width)
                {

                    newp.X = last2.X + (Bss2Panel.Width - BssView2.Width) / 2;
                    newp.Y = last2.Y;
                    BssView2.Location = newp;
                    BssView2.Update();
                }
                else
                {
                    BssView2.Location = last2;
                    BssView2.Update();
                }
            }*/
        }

        private void Panel1_Scroll(object sender, ScrollEventArgs e)
        {

        }

        private void Panel2_Scroll(object sender, ScrollEventArgs e)
        {

        }

        

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close(); 
        }
        #endregion

        #region tool button
        

        private void OpenBssView_Click(object sender, EventArgs e)
        {
            ShowBss_Click(sender, e);
        }

        private void OpenNaviView_Click(object sender, EventArgs e)
        {
            ShowNavi_Click(sender,e);
            ShowNavi.Checked = (NaviView.Visible);
        }
        private void OpenSensorView_Click(object sender, EventArgs e)
        {
            ShowSensor_Click(sender,e);
            ShowSensor.Checked = (SensorView.Visible);
        }
        #endregion

        #region menu event
        private void OpenBtn_Click(object sender, EventArgs e)
        {
            if (openXtfFileDialog.ShowDialog() == DialogResult.OK)
            {
                filename = openXtfFileDialog.SafeFileName;
                fi = new FileInfo(openXtfFileDialog.FileName);
                if (playbackFileStream != null)
                    playbackFileStream.Close();
                playbackFileStream = new BinaryReader(openXtfFileDialog.OpenFile());
                offset = 0;
                this.Text = Title + "-回放" + " - " + filename + "(" + offset.ToString("F01") + "%)";

                PlaybackTime.Enabled = true;
                PlaybackTime.Interval = tick;
                PlaybackTime.Start();
                OpenToolStripMenuItem.Enabled = false;
                SetReplayingState();
            }
        }

        private void ApplyBtn_Click(object sender, EventArgs e)
        {
            
           
        }

        
        #endregion

        #region test
        private void 开始工作ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            if (NetEngine.bConnect)
            {
                CmdWindow.Show();
                CmdWindow.DisplayCommand("下发命令：开始工作");
                if (netcore.SendCommand(Command.StartCMD()) == false)
                {
                    CmdWindow.DisplayAns("下发命令不成功："+netcore.Status);
                }

            }
            else
            {
                MessageBox.Show("网络未连接，请检查网络");
            }
        }

        private void 停止工作ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (NetEngine.bConnect)
            {
                CmdWindow.Show();
                CmdWindow.DisplayCommand("下发命令：停止工作");
                if (netcore.SendCommand(Command.StopCMD()) == false)
                {
                    CmdWindow.DisplayAns("下发命令不成功：" + netcore.Status);
                }

            }
            else
            {
                MessageBox.Show("网络未连接，请检查网络");
            }
        }

        private void 设置高频工作参数ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (NetEngine.bConnect)
            {
                CmdWindow.Show();
                CmdWindow.DisplayCommand("下发命令：设置高频声纳工作参数");
                BSSParameter para = new BSSParameter();
                if (netcore.SendCommand(Command.SetupHighBSS(para)) == false)
                {
                    CmdWindow.DisplayAns("下发命令不成功：" + netcore.Status);
                }

            }
            else
            {
                MessageBox.Show("网络未连接，请检查网络");
            }
        }

        private void 设置低频工作参数ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (NetEngine.bConnect)
            {
                CmdWindow.Show();
                CmdWindow.DisplayCommand("下发命令：设置低频声纳工作参数");
                BSSParameter para = new BSSParameter();
                if (netcore.SendCommand(Command.SetupLowBSS(para)) == false)
                {
                    CmdWindow.DisplayAns("下发命令不成功：" + netcore.Status);
                }

            }
            else
            {
                MessageBox.Show("网络未连接，请检查网络");
            }
        }

        private void 读取高频参数ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (NetEngine.bConnect)
            {
                CmdWindow.Show();
                CmdWindow.DisplayCommand("下发命令：读取高频声纳工作参数");
                //BSSParameter para = new BSSParameter();
                if (netcore.SendCommand(Command.GetHighParaCMD()) == false)
                {
                    CmdWindow.DisplayAns("下发命令不成功：" + netcore.Status);
                }

            }
            else
            {
                MessageBox.Show("网络未连接，请检查网络");
            }
        }

        private void 读取低频参数ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (NetEngine.bConnect)
            {
                CmdWindow.Show();
                CmdWindow.DisplayCommand("下发命令：读取低频声纳工作参数");
                //BSSParameter para = new BSSParameter();
                if (netcore.SendCommand(Command.GetLowParaCMD()) == false)
                {
                    CmdWindow.DisplayAns("下发命令不成功：" + netcore.Status);
                }

            }
            else
            {
                MessageBox.Show("网络未连接，请检查网络");
            }
        }
        private void 显示窗口ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CmdWindow.Show();
        }
        #endregion
        private void NetWorkTimer_Tick(object sender, EventArgs e)
        {
            if (!netcore.Initialed)
                LinkStatusLabel.Text = "";
            if (netcore.CmdClient!=null&&netcore.DataClient!=null)
            {
                NetEngine.bConnect = true;
                LinkStatusLabel.Text = "终端节点已连接";
            }
            else if (netcore.CmdClient != null)
            {
                LinkStatusLabel.Text = "命令端口已连接";
            }
            else if (netcore.DataClient != null)
            {
                LinkStatusLabel.Text = "数据端口已连接";
            }
            else
            {
                LinkStatusLabel.Text = "等待网络连接";
            }
            if (Configuration.DiskMode != true && gpscore.ReturnSerialPort() != null && gpscore.ReturnSerialPort().IsOpen) //live & gps port is open
            {
                GpsStatusLabel.Text = gpscore.Status;
                if (GPS.Latitude > 0)
                    Lat.Text = GPS.Latitude.ToString("F06") + "°" + "N";
                else
                {
                    Lat.Text = GPS.Latitude.ToString("F06") + "°" + "S";
                }
                LatLabel.Text = Lat.Text;
                if (GPS.Longitude > 0)
                    Long.Text = GPS.Longitude.ToString("F06") + "°" + "E";
                else
                {
                    Long.Text = GPS.Longitude.ToString("F06") + "°" + "W";
                }
                LongLabel.Text = Long.Text;
                HeadLabel.Text = GPS.Heading.ToString("F2");
                SpeedLabel.Text = GPS.Speed.ToString("F2") + "knot";
                PingTimeLabel.Text = GPS.UTCTime.ToLongTimeString();
                if (NaviView != null)
                {
                    NaviView.AddLocation(GPS.Latitude, GPS.Longitude, GPS.Heading);
                }
            }
        }

        internal void DisplayRTBSS(BSSObject resultData)
        {
            if (playbackFileStream != null) //replay mode
            {
                return;
            }
            int ChannelNumber = 0;//xtf顺序0，左低，1，右低，2，左高，3右高
            if (resultData.ID == (uint) ObjectID.PortLowBssData)
            {
                ChannelNumber = 0;
            }
            if (resultData.ID == (uint) ObjectID.PortHighBssData)
            {
                ChannelNumber = 2;
                
            }
            if (resultData.ID == (uint) ObjectID.StartboardHighBssData)
            {
                ChannelNumber = 3;
                
            }
            if (resultData.ID == (uint) ObjectID.StartboardLowBssData)
            {
                ChannelNumber = 1;
                
            }
            if (resultData.DataBytes>0)
                DisplayChart(ChannelNumber, resultData.BssBytes);
        }

        private void DisplayChart(int ChannelNumber, byte[] buf)
        {
            //display
            if (BssView1 != null )
            {
                BssView1.DisplayChart(ChannelNumber, buf.Length, buf);
                
            }
            if (BssView2 != null )
            {
                BssView2.DisplayChart(ChannelNumber, buf.Length, buf);
                
            }
        }

        

        private void 回放ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PlaybackTime.Start();
            SetReplayingState();
        }

        private void 暂停ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PlaybackTime.Stop();
            SetPauseState();
        }

        private void 重置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PlaybackTime.Interval = tick;
            PlaybackTime.Stop();
            offset = 0;
            if (BssView1 != null)
                BssView1.Initial();
            if (BssView2 != null)
                BssView2.Initial();
            playbackFileStream.BaseStream.Seek(offset, SeekOrigin.Begin);
            this.Text = Title + "-回放" + " - " + filename + "(" + offset.ToString("F01") + "%)";
            SetReplayState();
        }

        private void 退出回放ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string message = "是否关闭回放文件？";
            string caption = "消息";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            MessageBoxIcon icon = MessageBoxIcon.Question;
            MessageBoxDefaultButton defaultResult = MessageBoxDefaultButton.Button2;
            // Show message box
            DialogResult result = MessageBox.Show(message, caption, buttons, icon, defaultResult);
            if (result == DialogResult.OK)
            {
                PlaybackTime.Stop();
                if (playbackFileStream != null)
                    playbackFileStream.Close();
                this.Text = Title;
                if (BssView1 != null)
                    BssView1.Initial();
                if (BssView2 != null)
                    BssView2.Initial();
                SetWorkingState();
            }
        }
        private void SpeedBtn_Click(object sender, EventArgs e)
        {
            PlaybackTime.Enabled = false;
            PlaybackTime.Interval /= 2;
            PlaybackTime.Enabled = true;
            SlowBtn.Enabled = true;
            if (PlaybackTime.Interval == 1)
            {
                SpeedBtn.Enabled = false;
            }

        }

        private void SlowBtn_Click(object sender, EventArgs e)
        {
            PlaybackTime.Enabled = false;
            PlaybackTime.Interval *= 2;
            PlaybackTime.Enabled = true;
            SpeedBtn.Enabled = true;
            if (PlaybackTime.Interval == 128)
            {
                SlowBtn.Enabled = false;
            }
        }
        private void SetReplayingState()
        {
            回放控制ToolStripMenuItem.Enabled = true;
            回放ToolStripMenuItem.Enabled = false;
            暂停ToolStripMenuItem.Enabled = true;
            重置ToolStripMenuItem.Enabled = true;
            退出回放ToolStripMenuItem.Enabled = true;
            SlowBtn.Enabled = true;
            SpeedBtn.Enabled = true;
            if (PlaybackTime.Interval == 1)
            {
                SpeedBtn.Enabled = false;
            }
            if (PlaybackTime.Interval == 1024)
            {
                SlowBtn.Enabled = false;
            }
            ResetToolStripMenuItem.Enabled = true;
            ExitReplayToolStripMenuItem.Enabled = true;
            StartWorkToolStripMenuItem.Enabled = false;
            StopWorkToolStripMenuItem.Enabled = false;
            StatusLabel.Text = "正在回放...";
            Configuration.DiskMode = true;
        }
        private void SetPauseState()
        {
            回放控制ToolStripMenuItem.Enabled = true;
            回放ToolStripMenuItem.Enabled = true;
            暂停ToolStripMenuItem.Enabled = false;
            重置ToolStripMenuItem.Enabled = true;
            退出回放ToolStripMenuItem.Enabled = true;
            ResetToolStripMenuItem.Enabled = true;
            ExitReplayToolStripMenuItem.Enabled = true;
            SlowBtn.Enabled = false;
            SpeedBtn.Enabled = false;
            StartWorkToolStripMenuItem.Enabled = false;
            StopWorkToolStripMenuItem.Enabled = false;
            StatusLabel.Text = "暂停回放";
            Configuration.DiskMode = true;
        }
        private void SetReplayState()
        {
            回放控制ToolStripMenuItem.Enabled = true;
            回放ToolStripMenuItem.Enabled = true;
            暂停ToolStripMenuItem.Enabled = false;
            重置ToolStripMenuItem.Enabled = false;
            退出回放ToolStripMenuItem.Enabled = true;
            ResetToolStripMenuItem.Enabled = false;
            ExitReplayToolStripMenuItem.Enabled = true;
            SlowBtn.Enabled = false;
            SpeedBtn.Enabled = false;
            StartWorkToolStripMenuItem.Enabled = false;
            StopWorkToolStripMenuItem.Enabled = false;
            StatusLabel.Text = "准备回放";
            Configuration.DiskMode = true;
        }
        private void SetWorkingState()
        {
            回放控制ToolStripMenuItem.Enabled = false;
            ResetToolStripMenuItem.Enabled = false;
            ExitReplayToolStripMenuItem.Enabled = false;
            OpenToolStripMenuItem.Enabled = true;
            StatusLabel.Text = "监听实时数据中...";
            Configuration.DiskMode = false;
        }

        private void toolStripStopBtn_Click(object sender, EventArgs e)
        {
            if (NetEngine.bConnect)
            {
                CmdWindow.Show();
                CmdWindow.DisplayCommand("下发命令：停止工作");
                if (netcore.SendCommand(Command.StopCMD()) == false)
                {
                    CmdWindow.DisplayAns("下发命令不成功：" + netcore.Status);
                }

            }
            else
            {
                MessageBox.Show("网络未连接，请检查网络");
            }
        }

        private void toolStripStartBtn_Click(object sender, EventArgs e)
        {
            if (NetEngine.bConnect)
            {
                CmdWindow.Show();
                CmdWindow.DisplayCommand("下发命令：开始工作");
                if (netcore.SendCommand(Command.StartCMD()) == false)
                {
                    CmdWindow.DisplayAns("下发命令不成功：" + netcore.Status);
                    
                }
            }
            else
            {
                MessageBox.Show("网络未连接，请检查网络");
            }
        }

        private void ResetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PlaybackTime.Interval = tick;
            PlaybackTime.Stop();
            offset = 0;
            if (BssView1 != null)
                BssView1.Initial();
            if (BssView2 != null)
                BssView2.Initial();
            playbackFileStream.BaseStream.Seek(offset, SeekOrigin.Begin);
            this.Text = Title + "-回放" + " - " + filename + "(" + offset.ToString("F01") + "%)";
            SetReplayState();
        }

        private void ExitReplayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string message = "是否关闭回放文件？";
            string caption = "消息";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            MessageBoxIcon icon = MessageBoxIcon.Question;
            MessageBoxDefaultButton defaultResult = MessageBoxDefaultButton.Button2;
            // Show message box
            DialogResult result = MessageBox.Show(message, caption, buttons, icon, defaultResult);
            if (result == DialogResult.OK)
            {
                PlaybackTime.Stop();
                if (playbackFileStream != null)
                    playbackFileStream.Close();
                this.Text = Title;
                if (BssView1 != null)
                    BssView1.Initial();
                if (BssView2 != null)
                    BssView2.Initial();
                SetWorkingState();
            }
        }

        private void StopWorkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripStopBtn.PerformClick();
        }

        private void StartWorkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripStartBtn.PerformClick();
        }

        private void 高频参数设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            para.Show(true);
        }

        private void 低频参数设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            para.Show(false);
        }

        private void 基本设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            option.Show();
        }

        internal void DisplayRTRange(string highrange, string Lowrange)
        {
            //display
            string title = "";
            if (BssView1 != null && BssView1.option.Fq == Frequence.High)
            {
                //BssView1.DisplayChart(ChannelNumber, buf.Length, buf);
                title = ((Configuration.DiskMode==true)?"回放,":"实时,") + "高频, " + highrange + "米";
                if (highrange!="")
                    BssView1.SetTitle(title, int.Parse(highrange));
            }
            if (BssView1 != null && BssView1.option.Fq == Frequence.Low)
            {
                //BssView1.DisplayChart(ChannelNumber, buf.Length, buf);
                title = ((Configuration.DiskMode == true) ? "回放," : "实时,") + "低频, " + Lowrange + "米";
                if (Lowrange != "")
                    BssView1.SetTitle(title, int.Parse(Lowrange));
            }
            if (BssView2 != null && BssView2.option.Fq == Frequence.High)
            {
                //BssView2.DisplayChart(ChannelNumber, buf.Length, buf);
                title = ((Configuration.DiskMode == true) ? "回放," : "实时,") + "高频, " + highrange + "米";
                if (highrange != "")
                    BssView2.SetTitle(title, int.Parse(highrange));
            }
            if (BssView2 != null && BssView2.option.Fq == Frequence.Low)
            {
                //BssView2.DisplayChart(ChannelNumber, buf.Length, buf);
                title = ((Configuration.DiskMode == true) ? "回放," : "实时,") + "低频, " + Lowrange + "米";
                if (Lowrange != "")
                    BssView2.SetTitle(title, int.Parse(Lowrange));
            }

        }
    }
}
