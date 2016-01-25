using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Metro;

namespace Demo
{
    public partial class MainForm : OfficeForm
    {
        private XTFFILEHEADER Header = new XTFFILEHEADER();
        private XTFPINGCHANHEADER PingchanHeader = new XTFPINGCHANHEADER();
        private XTFPINGHEADER PingHeader = new XTFPINGHEADER();
        public int pixellevel = 3;
        //used for file mode
        public BinaryReader playbackFileStream;
        public FileInfo fi = null;
        public long offset = 0;
        public string filename;
        public int tick = 64;
        //show flag of windows
        private bool bShowNavi = false;
        private bool bShowSensor = false;
        private bool bShowRaw = false;
        private bool bShowInfo = true;
        private int block = 1024;
        
        //windows collection
        private NavigationView NaviView = null;
        private SensorForm SensorView = null;
        private ChartForm BssView1 = null;
        private ChartForm BssView2 = null;
        private bool bPanel1triger;
        private bool bPanel2triger;

        private int rightpanelminwidth = 400;
        public static MainForm mf;
        public MainForm()
        {
            InitializeComponent();
        }

        public void ChildFormClose(Form child)
        {
            if (NaviView == child)
            {
                NaviView = null;
                bShowNavi = false;
                if (SensorView != null)
                    ShowSensorOnly();
                else
                    NoneNaviAndSensor();
                ShowNavi.Checked = false;
            }
            if (SensorView == child)
            {
                SensorView = null;
                bShowSensor = false;
                if (NaviView != null)
                    ShowNaviOnly();
                else
                    NoneNaviAndSensor();
                ShowSensor.Checked = false;
            }
            if (BssView1 == child)
            {
                BssView1.Close();
                BssView1 = null;
                if (BssView2 != null)
                    ShowView2Max();
                else
                    NoneBssView();
            }
            if (BssView2 == child)
            {
                BssView2.Close();
                BssView2 = null;
                if (BssView1 != null)
                        ShowView1Max();
               else
                        NoneBssView();
            }
            if (BssView1 == null && BssView2 == null)
            {
                PlaybackTime.Stop();
                if (playbackFileStream != null)
                    playbackFileStream.Close();
            }
        }
        private void Help_Click(object sender, EventArgs e)
        {
            AboutBox ab = new AboutBox();
            ab.Show();
        }

        private void DataSaveBox_Click(object sender, EventArgs e)
        {
            if (Configuration.bSaveXTF == false)
            {
                DataSaveBox.Text = "正在保存XTF数据";
                DataSaveBox.BackColor = Color.Green;
                Configuration.bSaveXTF = true;
            }
            else
            {
                DataSaveBox.Text = "XTF数据未保存";
                DataSaveBox.BackColor = Color.Red;
                Configuration.bSaveXTF = false;

            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            mf = this;
            PlaybackTime.Enabled = false;
            DataSaveBox.BackColor = Color.Red;
            ShowInfoRegion.Checked = bShowInfo;
            splitViewer.SplitterDistance = splitViewer.Width;
            NoneBssView();
            towFishToolStripMenuItem_Click(sender, e);
            StatusLabel.Text = "就绪";
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
            }
            

        }

        private void Playback_Tick(object sender, EventArgs e)
        {
            float persentage = offset * 100 / fi.Length;
            //playpercent.Value = (int)persentage;
            this.Text = "XTF回放" + " - " + filename + "(" + persentage.ToString("F01") + "%)";
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
                playbackFileStream.Close();
                PlaybackTime.Enabled = false;
                float persentage = offset * 100 / fi.Length;
                this.Text = "XTF回放" + " - " + filename + "(" + persentage.ToString("F01") + "%)";
                //playpercent.Value = (int)persentage;
                tick = 512;
                offset = 0;
                //回放ToolStripMenuItem.Enabled = true;
                //暂停ToolStripMenuItem.Enabled = false;
                //重置ToolStripMenuItem.Enabled = false;
                //加速ToolStripMenuItem.Enabled = false;
                //减速ToolStripMenuItem.Enabled = false;
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
                    while (true)
                    {

                        if (ReadPingchanHeader() < 0)
                            return;
                        uint DataNeedToRead = Header.ChanInfo[PingchanHeader.ChannelNumber].bytesPerSample * PingchanHeader.NumSamples;
                        byte[] buf = playbackFileStream.ReadBytes((int)DataNeedToRead);
                        offset = playbackFileStream.BaseStream.Position;
                        //display

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
                if (show)
                    SpeedLabel.Text = PingHeader.ShipSpeed.ToString("f2") + "节";
                PingHeader.ShipGyro = playbackFileStream.ReadSingle();
                PingHeader.ShipYcoordinate = playbackFileStream.ReadDouble();
                if (show)
                {
                    if (PingHeader.ShipYcoordinate > 0)
                        Lat.Text = PingHeader.ShipYcoordinate.ToString("F06") + "°" + "N";
                    else
                    {
                        Lat.Text = PingHeader.ShipYcoordinate.ToString("F06") + "°" + "S";
                    }
                }

                PingHeader.ShipXcoordinate = playbackFileStream.ReadDouble();
                if (show)
                {
                    if (PingHeader.ShipXcoordinate > 0)
                        Long.Text = PingHeader.ShipXcoordinate.ToString("F06") + "°" + "E";
                    else
                        Long.Text = PingHeader.ShipXcoordinate.ToString("F06") + "°" + "W";
                }

                PingHeader.ShipAltitude = playbackFileStream.ReadUInt16();

                PingHeader.ShipDepth = playbackFileStream.ReadUInt16();
                PingHeader.FixTimeHour = playbackFileStream.ReadByte();
                PingHeader.FixTimeMinute = playbackFileStream.ReadByte();
                PingHeader.FixTimeSecond = playbackFileStream.ReadByte();
                PingHeader.FixTimeHSecond = playbackFileStream.ReadByte();
                PingHeader.SensorSpeed = playbackFileStream.ReadSingle();
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
                if (show)
                    PressLabel.Text = PingHeader.Heave.ToString("F2");
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
        private void towFishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hardDiskToolStripMenuItem.Checked = false;
            towFishToolStripMenuItem.Checked = true;
            Configuration.DiskMode = false;
            OpenBtn.Enabled = Configuration.DiskMode;
            SpeedBtn.Enabled = Configuration.DiskMode;
            SlowBtn.Enabled = Configuration.DiskMode;
            ResetBtn.Enabled = Configuration.DiskMode;
            Open2Btn.Enabled = Configuration.DiskMode;
            Speed2Btn.Enabled = Configuration.DiskMode;
            Slow2Btn.Enabled = Configuration.DiskMode;
            Reset2Btn.Enabled = Configuration.DiskMode;
        }

        private void hardDiskToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hardDiskToolStripMenuItem.Checked = true;
            towFishToolStripMenuItem.Checked = false;
            Configuration.DiskMode = true;
            OpenBtn.Enabled = Configuration.DiskMode;
            SpeedBtn.Enabled = Configuration.DiskMode;
            SlowBtn.Enabled = Configuration.DiskMode;
            ResetBtn.Enabled = Configuration.DiskMode;
            Open2Btn.Enabled = Configuration.DiskMode;
            Speed2Btn.Enabled = Configuration.DiskMode;
            Slow2Btn.Enabled = Configuration.DiskMode;
            Reset2Btn.Enabled = Configuration.DiskMode;
        }
        private void ShowBss_Click(object sender, EventArgs e)
        {
            if (BssView1 == null)//没有侧扫1窗口
            {
                BssView1 = new ChartForm();
                //BssView1.TopLevel = false;
                BssView1.MdiParent =this ;
                BssView1.Parent = Bss1Panel;
                
                BssView1.WindowState = FormWindowState.Normal;
                BssView1.Show();
                InitMenu1();
                if (BssView2 == null)//没有view2
                    ShowView1Max();
                else
                    ShowAllBssView();
            }
            else if (BssView2 == null)//没有侧扫2窗口
            {
                BssView2 = new ChartForm();
                //BssView2. TopLevel = false;
                BssView2.MdiParent =this ;
                BssView2.Parent = Bss2Panel;
                
                BssView2.WindowState = FormWindowState.Normal;
                BssView2.Show();
                InitMenu2();
                //BssView2.Update();
                
                ShowAllBssView();
            }
            else//2个BSS
            {

            }
            
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
                if(SensorView==null)
                    ShowNaviOnly();
                else
                    ShowNaviAndSensor();
            }
            else
            {
                if (NaviView != null)
                {
                    NaviView.Close();
                }
                if (SensorView == null)
                    NoneNaviAndSensor();
                else
                    ShowSensorOnly();
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
                if(NaviView==null)
                    ShowSensorOnly();
                else
                    ShowNaviAndSensor();
            }
            else
            {
                if(SensorView!=null)
                    SensorView.Close();
                bShowSensor = false;
                if (NaviView == null)
                    NoneNaviAndSensor();
                else
                    ShowNaviOnly();
            }
        }

        private void ShowRaw_Click(object sender, EventArgs e)
        {

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
            chartmenubar1.Visible = true;
            chartmenubar2.Visible = false;
            LeftTable.RowStyles[0].Height = 30;
            LeftTable.RowStyles[1].SizeType = SizeType.Percent;
            LeftTable.RowStyles[1].Height = 100;
            LeftTable.RowStyles[2].Height = 0;
            LeftTable.RowStyles[3].SizeType = SizeType.Percent;
            LeftTable.RowStyles[3].Height = 0;
        }
        //第二个图放大（第一个图关闭）
        private void ShowView2Max()
        {
            chartmenubar1.Visible = false;
            chartmenubar2.Visible = true;
            LeftTable.RowStyles[2].Height = 30;
            LeftTable.RowStyles[3].SizeType = SizeType.Percent;
            LeftTable.RowStyles[3].Height = 100;
            LeftTable.RowStyles[0].Height = 0;
            LeftTable.RowStyles[1].SizeType = SizeType.Percent;
            LeftTable.RowStyles[1].Height = 0;
        }
        //有两个图一起出现
        private void ShowAllBssView()
        {
            chartmenubar1.Visible = true;
            chartmenubar2.Visible = true;
            LeftTable.RowStyles[0].Height = 30;
            LeftTable.RowStyles[1].SizeType = SizeType.Percent;
            LeftTable.RowStyles[1].Height = 50;
            LeftTable.RowStyles[2].Height = 30;
            LeftTable.RowStyles[3].SizeType = SizeType.Percent;
            LeftTable.RowStyles[3].Height = 50;
        }
        private void NoneBssView()
        {
            chartmenubar1.Visible = false;
            chartmenubar2.Visible = false;
            LeftTable.RowStyles[0].Height = 0;
            LeftTable.RowStyles[1].SizeType = SizeType.Percent;
            LeftTable.RowStyles[1].Height = 50;
            LeftTable.RowStyles[2].Height = 0;
            LeftTable.RowStyles[3].SizeType = SizeType.Percent;
            LeftTable.RowStyles[3].Height = 50;
        }

        private void ShowNaviOnly()
        {
            if (splitViewer.SplitterDistance + rightpanelminwidth > splitViewer.Width)
                splitViewer.SplitterDistance = splitViewer.Width - rightpanelminwidth - 7;
            splitViewer.Panel2MinSize = 400;
            RightTable.RowStyles[0].SizeType = SizeType.Percent;
            RightTable.RowStyles[0].Height = 100;
            RightTable.RowStyles[1].SizeType = SizeType.Percent;
            RightTable.RowStyles[1].Height = 0;
        }
        private void ShowSensorOnly()
        {
            if (splitViewer.SplitterDistance + rightpanelminwidth > splitViewer.Width)
                splitViewer.SplitterDistance = splitViewer.Width - rightpanelminwidth - 7;
            splitViewer.Panel2MinSize = 400;
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

        private void InitMenu1()
        {
            Chart1Title.Text = "----------";
            RangeSelectBox.Text = "150";
            OpenBtn.Enabled = Configuration.DiskMode;
            SpeedBtn.Enabled = Configuration.DiskMode;
            SlowBtn.Enabled = Configuration.DiskMode;
            ResetBtn.Enabled = Configuration.DiskMode;
            CableOutInput.Value = 5;
            StartInput.Value = 1;
            EndInput.Value = 70;
        }
        private void InitMenu2()
        {
            Chart2Title.Text = "----------";
            Range2SelectBox.Text = "150";
            Open2Btn.Enabled = Configuration.DiskMode;
            Speed2Btn.Enabled = Configuration.DiskMode;
            Slow2Btn.Enabled = Configuration.DiskMode;
            Reset2Btn.Enabled = Configuration.DiskMode;
            CableOutInput2.Value = 5;
            StartInput2.Value = 1;
            EndInput2.Value = 70;
        }
        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
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
            }
        }

        private void Panel1_Scroll(object sender, ScrollEventArgs e)
        {
            bPanel1triger = true;
            if (!bPanel2triger&&BssView2!=null)
            {
                if(e.ScrollOrientation == ScrollOrientation.VerticalScroll)
                    Bss2Panel.VerticalScroll.Value = e.NewValue;
                if (e.ScrollOrientation == ScrollOrientation.HorizontalScroll)
                    Bss2Panel.HorizontalScroll.Value = e.NewValue;
            }
            bPanel1triger = false;
        }

        private void Panel2_Scroll(object sender, ScrollEventArgs e)
        {

            bPanel2triger = true;
            if (!bPanel1triger&&BssView1!=null)
            {
                if (e.ScrollOrientation == ScrollOrientation.VerticalScroll)
                    Bss1Panel.VerticalScroll.Value = e.NewValue;
                if (e.ScrollOrientation == ScrollOrientation.HorizontalScroll)
                    Bss1Panel.HorizontalScroll.Value = e.NewValue;
            }
            bPanel2triger = false;
        }

        private void HideView1_Click(object sender, EventArgs e)
        {
            ChildFormClose(BssView1);
        }

        private void HideView2_Click(object sender, EventArgs e)
        {
            ChildFormClose(BssView2);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
            
        }
        #endregion

        #region tool button
        private void TaskWizard_Click(object sender, EventArgs e)
        {
            ConnectForm cf  =new ConnectForm();
            cf.ShowDialog();
        }

        private void OpenBssView_Click(object sender, EventArgs e)
        {
            ShowBss_Click(sender, e);
        }

        private void OpenNaviView_Click(object sender, EventArgs e)
        {
            ShowNavi_Click(sender,e);
            ShowNavi.Checked = (NaviView!=null);
        }
        private void OpenSensorView_Click(object sender, EventArgs e)
        {
            ShowSensor_Click(sender,e);
            ShowSensor.Checked = (SensorView!=null);
        }
        private void NaviTrackSet_Click(object sender, EventArgs e)
        {

        }

        private void SensorSetup_Click(object sender, EventArgs e)
        {

        }

        private void SystemSetup_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region menu event
        private void OpenBtn_Click(object sender, EventArgs e)
        {
            if (openXtfFileDialog.ShowDialog() == DialogResult.OK)
            {
                MainForm.mf.filename = openXtfFileDialog.SafeFileName;
                MainForm.mf.fi = new FileInfo(openXtfFileDialog.FileName);
                if (MainForm.mf.playbackFileStream != null)
                    MainForm.mf.playbackFileStream.Close();
                MainForm.mf.playbackFileStream = new BinaryReader(openXtfFileDialog.OpenFile());
                this.Text += "-回放" + " - " + filename;

                MainForm.mf.PlaybackTime.Enabled = true;
                MainForm.mf.PlaybackTime.Interval = MainForm.mf.tick;
                MainForm.mf.PlaybackTime.Start();
                MainForm.mf.offset = 0;
                BssView1.Initial();

            }
        }
        private void Open2Btn_Click(object sender, EventArgs e)
        {
            if (openXtfFileDialog.ShowDialog() == DialogResult.OK)
            {
               filename = openXtfFileDialog.SafeFileName;
               fi = new FileInfo(openXtfFileDialog.FileName);
                if (playbackFileStream != null)
                    playbackFileStream.Close();
                playbackFileStream = new BinaryReader(openXtfFileDialog.OpenFile());
                this.Text += "-回放" + " - " + filename;

                PlaybackTime.Enabled = true;
                PlaybackTime.Interval = MainForm.mf.tick;
                PlaybackTime.Start();
                offset = 0;
                BssView2.Initial();

            }
        }
        #endregion


    }
}
