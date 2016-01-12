using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Net.NetworkInformation;
using System.Text;
using System.Windows.Forms;
using System.IO;
using ChartBox;
using DevComponents.DotNetBar;
namespace Demo
{
    public partial class ChartForm:Office2007Form
    {
        private XTFFILEHEADER Header = new XTFFILEHEADER();
        private  XTFPINGCHANHEADER PingchanHeader = new XTFPINGCHANHEADER();
        private XTFPINGHEADER PingHeader = new XTFPINGHEADER();
        private BinaryReader playbackFileStream;
        private int block = 1024;
        private int tick = 64;
        private bool BinitailChart1 = false;
        private bool BinitailChart2 = false;
        private int pixellevel = 1;
        FileInfo fi=null;
        private long offset = 0;
        private string filename;
        public ChartForm()
        {
            InitializeComponent();
            
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            PlaybackTime.Enabled = false;
            //回放ToolStripMenuItem.Enabled = false;
            //暂停ToolStripMenuItem.Enabled = false;
            //重置ToolStripMenuItem.Enabled = false;
            //加速ToolStripMenuItem.Enabled = false;
            //减速ToolStripMenuItem.Enabled = false;
        }
        

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            PlaybackTime.Stop();
            if(playbackFileStream!=null)
                playbackFileStream.Close();
        }



        private void 打开文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openXtfFileDialog.ShowDialog() == DialogResult.OK)
            {
                filename = openXtfFileDialog.SafeFileName;
                fi = new FileInfo(openXtfFileDialog.FileName);
                if (playbackFileStream!=null)
                    playbackFileStream.Close();
                playbackFileStream = new BinaryReader(openXtfFileDialog.OpenFile());
                this.Text = "XTF回放" + " - " + filename;
                //回放ToolStripMenuItem.Enabled = false;
                //暂停ToolStripMenuItem.Enabled = true;
                //重置ToolStripMenuItem.Enabled = true;
                //加速ToolStripMenuItem.Enabled = true;
                //减速ToolStripMenuItem.Enabled = true;
                PlaybackTime.Enabled = true;
                PlaybackTime.Interval = tick;
                PlaybackTime.Start();
                offset = 0;
                chartG1.Clear();
                chartG2.Clear();
                BinitailChart1 = false;
                BinitailChart2 = false;
                pixellevel=1;
                //Level.Text = pixellevel.ToString();

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
            if(offset<1024||playbackFileStream.BaseStream.Position>=fi.Length)
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
                if(playbackFileStream.BaseStream.Position>=fi.Length)
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
                if(offset<0)
                    return;
                if (PingHeader.HeaderType == 0) //测扫
                {
                    while (true)
                    {
                        
                        if (ReadPingchanHeader() < 0)
                            return;
                        uint DataNeedToRead = Header.ChanInfo[PingchanHeader.ChannelNumber].bytesPerSample*PingchanHeader.NumSamples;
                        byte[] buf = playbackFileStream.ReadBytes((int)DataNeedToRead);
                        offset = playbackFileStream.BaseStream.Position;
                        if (PingchanHeader.ChannelNumber == 0)
                        {
                            if(!BinitailChart1)
                                chartG1.Initialize(2, (int)DataNeedToRead/2, 4096, 100);
                            BinitailChart1 = true;
                            chartG1.SetLevel(pixellevel);
                            
                            chartG1.Display(buf,false);
                        }
                        if (PingchanHeader.ChannelNumber == 1)
                        {
                            if (!BinitailChart2)
                                chartG2.Initialize(2, (int)DataNeedToRead / 2, 4096, 100);
                            BinitailChart2 = true;
                            chartG2.SetLevel(pixellevel);
                            chartG2.Display(buf,false);
                        }
                        if(offset>=fi.Length)
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
                    PingTimeLabel.Text = PingHeader.Year.ToString("D") + "//" + PingHeader.Month.ToString("D2") + "//" +
                                     PingHeader.Day.ToString("d2")
                                     + " " + PingHeader.Hour.ToString("D2") + ":" + PingHeader.Minute.ToString("D2") +
                                     ":" +
                                     PingHeader.Second.ToString("D2") + "." + PingHeader.HSeconds.ToString("D2");
                PingHeader.JulianDay = playbackFileStream.ReadUInt16();
                PingHeader.EventNumber = playbackFileStream.ReadUInt32();
                PingHeader.PingNumber = playbackFileStream.ReadUInt32();
                PingHeader.SoundVelocity = playbackFileStream.ReadSingle();
                PingHeader.OceanTide = playbackFileStream.ReadSingle();
                PingHeader.Reserved2 = playbackFileStream.ReadUInt32();
                PingHeader.ConductivityFreq = playbackFileStream.ReadSingle();
                PingHeader.TemperatureFreq = playbackFileStream.ReadSingle();
                PingHeader.PressureFreq = playbackFileStream.ReadSingle();
                PingHeader.PressureTemp = playbackFileStream.ReadSingle();
                PingHeader.Conductivity = playbackFileStream.ReadSingle();
                PingHeader.WaterTemperature = playbackFileStream.ReadSingle();
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
                    if (PingHeader.ShipYcoordinate>0)
                        Lat.Text = PingHeader.ShipYcoordinate.ToString("F06")+"°" +"N";
                    else
                    {
                        Lat.Text = PingHeader.ShipYcoordinate.ToString("F06") + "°" + "S";
                    }
                }

                PingHeader.ShipXcoordinate = playbackFileStream.ReadDouble();
                if (show)
                {
                    if(PingHeader.ShipXcoordinate>0)
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
                PingHeader.SensorPrimaryAltitude = playbackFileStream.ReadSingle();
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
                    HeaveLabel.Text = PingHeader.Heave.ToString("F2");
                PingHeader.Yaw = playbackFileStream.ReadSingle();
                if (show) 
                    YawLabel.Text = PingHeader.Yaw.ToString("F2");
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
                return (int) playbackFileStream.BaseStream.Position;
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
        
        #region menu
        private void 退出程序ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string message = "是否退出？";
            string caption = "消息";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            MessageBoxIcon icon = MessageBoxIcon.Question;
            MessageBoxDefaultButton defaultResult = MessageBoxDefaultButton.Button2;
            // Show message box
            DialogResult result = MessageBox.Show(message, caption, buttons, icon, defaultResult);
            if (result == DialogResult.OK)
            {
                PlaybackTime.Stop();
                playbackFileStream.Close();
                Application.Exit();
            }
            
        }
        
        /*
        private void 回放ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PlaybackTime.Enabled = true;
            PlaybackTime.Interval = tick;
            PlaybackTime.Start();
            回放ToolStripMenuItem.Enabled = false;
            暂停ToolStripMenuItem.Enabled = true;
            重置ToolStripMenuItem.Enabled = true;
            加速ToolStripMenuItem.Enabled = true;
            减速ToolStripMenuItem.Enabled = true;
        }

        private void 暂停ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PlaybackTime.Stop();
            回放ToolStripMenuItem.Enabled = true;
            暂停ToolStripMenuItem.Enabled = false;
            重置ToolStripMenuItem.Enabled = false;
            加速ToolStripMenuItem.Enabled = false;
            减速ToolStripMenuItem.Enabled = false;
        }

        private void 重置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PlaybackTime.Stop();
            tick = 16;
            playbackFileStream.BaseStream.Position = 0;
            offset = 0;
            chartG1.Clear();
            chartG2.Clear();
            回放ToolStripMenuItem.Enabled = true;
            暂停ToolStripMenuItem.Enabled = false;
            重置ToolStripMenuItem.Enabled = false;
            加速ToolStripMenuItem.Enabled = false;
            减速ToolStripMenuItem.Enabled = false;
        }
        
        private void 加速ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PlaybackTime.Stop();

            if (tick > 1)
            {
                tick = tick / 2;
                减速ToolStripMenuItem.Enabled = true;
            }
            else
            {
                加速ToolStripMenuItem.Enabled = false;
            }
            PlaybackTime.Interval = tick;
            PlaybackTime.Start();
        }

        private void 减速ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PlaybackTime.Stop();

            if (tick < 256)
            {
                tick = tick * 2;
                加速ToolStripMenuItem.Enabled = true;
            }
            else
            {
                减速ToolStripMenuItem.Enabled = false;
            }
            PlaybackTime.Interval = tick;
            PlaybackTime.Start();
        }*/
        #endregion

        private void AddLevel_Click(object sender, EventArgs e)
        {
            pixellevel++;
            //Level.Text = pixellevel.ToString();
            chartG1.SetLevel(pixellevel);
            chartG2.SetLevel(pixellevel);
        }

        private void SubLevel_Click(object sender, EventArgs e)
        {
            if (pixellevel > 1)
            {
                pixellevel--;
                //Level.Text = pixellevel.ToString();
                chartG1.SetLevel(pixellevel);
                chartG2.SetLevel(pixellevel);
            }
        }

    }
}
