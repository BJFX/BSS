using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Survey
{
    public enum ComID
    {

        SetupHighBSS=0x11,
        SetupLowBSS = 0x12,
        ReadHighPara = 0x13,
        ReadLowPara = 0x14,
        HighParaAns = 0x15,
        LowParaAns = 0x16,
        SysStatus = 0x30,
        Start = 0x41,
        Stop = 0x42,
        SetupSensor = 0x43,
        Ans=0x50,
        BSSdata = 0x62,
        SensorData = 0x70,
    }
    public enum ObjectID
    {
        AD = 0x01,
        Reserved1 = 0x02,
        Reserved2 = 0x03,
        Reserved3 = 0x04,
        PortHighBssData = 0x10,
        StartboardHighBssData = 0x20,
        PortLowBssData = 0x40,
        StartboardLowBssData = 0x80,
    }
    public class BSSParameter
    {
        public UInt16 DeviceID;
        public UInt32 PortStartFq;
        public UInt32 StarBoardStartFq;
        public UInt16 Ls;
        public UInt32 PortFqRate;
        public UInt32 StarBoardFqRate;
        public UInt16 RcvDelay;
        public UInt16 Ts;
        public UInt16 Tt;
        public UInt16 ADSamples;
        public UInt16 Flag;
        public UInt16 TVGDelay;
        public UInt16 TVGReRate;
        public UInt16 TVGCtl;
        public UInt16 TvgBeta;
        public UInt16 TvgAlpha;
        public Int16 TvgG;
        public Int32 Com;
        public BitArray ComArray;
        public UInt16 RetID;
        public UInt32 FixedTVG;
        public UInt16 TVGLength;
        public UInt16 TVGMode;

        public BSSParameter()
        {
            DeviceID = 0x02;
            PortStartFq = 71250;
            StarBoardStartFq = 78750;
            Ls = 600;
            PortFqRate = 26045;
            StarBoardFqRate = 26045;
            RcvDelay = 1000;
            Ts = 36573;
            Tt = 9569;
            ADSamples = 16384;
            Flag = 0x0093;
            TVGDelay = 0;
            TVGReRate = 4369;
            TVGCtl = 0;
            TvgBeta = 300;
            TvgAlpha = 4400;
            TvgG = -400;
            Com = 0x00FB0084;
            ComArray = new BitArray(BitConverter.GetBytes(Com));
            RetID = 0x003F;
            FixedTVG = 0;
            TVGLength = 4000;
            TVGMode = 0;
        }

        public bool Parse(byte[] dataBytes)
        {
            if(dataBytes.Length!=56)
                return false;
            try
            {
                DeviceID = BitConverter.ToUInt16(dataBytes, 0);
                PortStartFq = BitConverter.ToUInt32(dataBytes, 2);
                StarBoardStartFq = BitConverter.ToUInt32(dataBytes, 6);
                Ls = BitConverter.ToUInt16(dataBytes, 10);
                PortFqRate = BitConverter.ToUInt32(dataBytes, 12);
                StarBoardFqRate = BitConverter.ToUInt32(dataBytes, 16);
                RcvDelay = BitConverter.ToUInt16(dataBytes, 20);
                Ts = BitConverter.ToUInt16(dataBytes, 22);
                Tt = BitConverter.ToUInt16(dataBytes, 24);
                ADSamples = BitConverter.ToUInt16(dataBytes, 26);
                Flag = BitConverter.ToUInt16(dataBytes, 28);
                TVGDelay = BitConverter.ToUInt16(dataBytes, 30);
                TVGReRate = BitConverter.ToUInt16(dataBytes, 32);
                TVGCtl = BitConverter.ToUInt16(dataBytes, 34);
                TvgBeta = BitConverter.ToUInt16(dataBytes, 36);
                TvgAlpha = BitConverter.ToUInt16(dataBytes, 38);
                TvgG = BitConverter.ToInt16(dataBytes, 40);
                Com = BitConverter.ToInt32(dataBytes, 42);
                ComArray = new BitArray(BitConverter.GetBytes(Com));
                RetID = BitConverter.ToUInt16(dataBytes, 46);
                FixedTVG = BitConverter.ToUInt32(dataBytes, 48);
                TVGLength = BitConverter.ToUInt16(dataBytes, 50);
                TVGMode = BitConverter.ToUInt16(dataBytes, 52);
            }
            catch (Exception)
            {
                return false;
            }
            
            return true;
        }

        public byte[] Pack()
        {
            byte[] pkg = new byte[56];
            Buffer.BlockCopy(BitConverter.GetBytes(DeviceID), 0, pkg, 0, 2);
            Buffer.BlockCopy(BitConverter.GetBytes(PortStartFq), 0, pkg, 2, 4);
            Buffer.BlockCopy(BitConverter.GetBytes(StarBoardStartFq), 0, pkg, 6, 4);
            Buffer.BlockCopy(BitConverter.GetBytes(Ls), 0, pkg, 10, 2);
            Buffer.BlockCopy(BitConverter.GetBytes(PortFqRate), 0, pkg, 12, 4);
            Buffer.BlockCopy(BitConverter.GetBytes(StarBoardFqRate), 0, pkg, 16, 4);
            Buffer.BlockCopy(BitConverter.GetBytes(RcvDelay), 0, pkg, 20, 2);
            Buffer.BlockCopy(BitConverter.GetBytes(Ts), 0, pkg, 22, 2);
            Buffer.BlockCopy(BitConverter.GetBytes(Tt), 0, pkg, 24, 2);
            Buffer.BlockCopy(BitConverter.GetBytes(ADSamples), 0, pkg, 26, 2);
            Buffer.BlockCopy(BitConverter.GetBytes(Flag), 0, pkg, 28, 2);
            Buffer.BlockCopy(BitConverter.GetBytes(TVGDelay), 0, pkg, 30, 2);
            Buffer.BlockCopy(BitConverter.GetBytes(TVGReRate), 0, pkg, 32, 2);
            Buffer.BlockCopy(BitConverter.GetBytes(TVGCtl), 0, pkg, 34, 2);
            Buffer.BlockCopy(BitConverter.GetBytes(TvgBeta), 0, pkg, 36, 2);
            Buffer.BlockCopy(BitConverter.GetBytes(TvgAlpha), 0, pkg, 38, 2);
            Buffer.BlockCopy(BitConverter.GetBytes(TvgG), 0, pkg, 40, 2);
            Buffer.BlockCopy(BitConverter.GetBytes(Com), 0, pkg, 42, 4);
            Buffer.BlockCopy(BitConverter.GetBytes(RetID), 0, pkg, 46, 2);
            Buffer.BlockCopy(BitConverter.GetBytes(FixedTVG), 0, pkg, 48, 4);
            Buffer.BlockCopy(BitConverter.GetBytes(TVGLength), 0, pkg, 50, 2);
            Buffer.BlockCopy(BitConverter.GetBytes(TVGMode), 0, pkg, 50, 2);
            return pkg;
        }
    }

    public class BssSensorData
    {
        
    }
    public class BSSResultData
    {
        public BSSParameter Parameter;
        public DtObject Data = null;

        public BSSResultData()
        {
            Parameter =new BSSParameter();
            Data = new DtObject();
        }

        public bool Parse(byte[] dataBytes)
        {
            try
            {
                byte[] b = new byte[56];
                byte[] d = new byte[dataBytes.Length-56];
                Buffer.BlockCopy(dataBytes,0,b,0,56);
                Buffer.BlockCopy(dataBytes, 56, d, 0, dataBytes.Length - 56);
                if(Parameter.Parse(b)==false)
                    return false;
                if (Data.Parse(d)==false)
                    return false;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }

    public class Command
    {
        public static Hashtable Ans = new Hashtable();
        public static int Version;
        public static Hashtable ErrorName = new Hashtable();
        public static Hashtable UWError = new Hashtable();
        public static Hashtable DSPError = new Hashtable();
        public static void Init()
        {
            Version = 0x02;
            Ans.Add(0x0000, "命令成功接受");
            Ans.Add(0x0001, "数据头版本不正确");
            Ans.Add(0x0002, "无效命令");
            Ans.Add(0x0004, "无效的工作参数配置");
            Ans.Add(0x0008, "非法Duty Cycle");
            Ans.Add(0x0010, "检查和错误");
            Ans.Add(0x0020, "非法脉冲时间");
            Ans.Add(0x0040, "非法测量间隔");
            Ans.Add(0x0080, "保留");
            Ans.Add(0x0100, "系统正处于工作状态");
            Ans.Add(0x0200, "没有设置工作参数");
            ErrorName.Add(0,"电压");
            ErrorName.Add(1,"电流");
            ErrorName.Add(2,"保留");
            ErrorName.Add(3,"ADC参考电压");
            ErrorName.Add(4,"模拟电压");
            ErrorName.Add(5,"左舷发射电压过高");
            ErrorName.Add(6,"左舷发射电流过低");
            ErrorName.Add(7,"左舷发射频率过高");
            ErrorName.Add(8,"左舷发射频率过低");
            ErrorName.Add(9,"水下控制软件错误");
            ErrorName.Add(10,"DSP软件错误");
            ErrorName.Add(11,"右舷发射电压过高");
            ErrorName.Add(12,"右舷发射电流过低");
            ErrorName.Add(13,"右舷发射频率过高");
            ErrorName.Add(14,"右舷发射频率过低");
            ErrorName.Add(15,"SIN转换出界");
            ErrorName.Add(16,"COS转换出界");
            UWError.Add(0,"缓冲区溢出");
            UWError.Add(1,"接收命令错误");
            UWError.Add(2,"FPGA打开错误");
            UWError.Add(3,"FPGA读写错误");
            UWError.Add(4,"命令回执错误");
            UWError.Add(5,"数据发送出错");
            UWError.Add(6,"线程同步出错");
            UWError.Add(7,"延时出错");
            UWError.Add(8,"线程创建出错");
            UWError.Add(9,"线程控制出错");
            DSPError.Add(0,"程序下载出错");
            DSPError.Add(1,"Dsp内存读写错误");

        }

        public static byte[] StartCMD()
        {
            byte[] pkg = new byte[9];
            Buffer.BlockCopy(BitConverter.GetBytes((int) ComID.Start), 0, pkg, 0, 2);
            Buffer.BlockCopy(BitConverter.GetBytes(Version), 0, pkg, 2, 2);
            Buffer.BlockCopy(BitConverter.GetBytes(9), 0, pkg, 4, 4);
            pkg[8] = 0;//校验
            return pkg;
        }
        public static byte[] StopCMD()
        {
            byte[] pkg = new byte[9];
            Buffer.BlockCopy(BitConverter.GetBytes((int) ComID.Stop), 0, pkg, 0, 2);
            Buffer.BlockCopy(BitConverter.GetBytes(Version), 0, pkg, 2, 2);
            Buffer.BlockCopy(BitConverter.GetBytes(9), 0, pkg, 4, 4);
            pkg[8] = 0;//校验
            return pkg;
        }
        public static byte[] GetHighParaCMD()
        {
            byte[] pkg = new byte[9];
            Buffer.BlockCopy(BitConverter.GetBytes((int)ComID.ReadHighPara), 0, pkg, 0, 2);
            Buffer.BlockCopy(BitConverter.GetBytes(Version), 0, pkg, 2, 2);
            Buffer.BlockCopy(BitConverter.GetBytes(9), 0, pkg, 4, 4);
            pkg[8] = 0;//校验
            return pkg;
        }
        public static byte[] GetLowParaCMD()
        {
            byte[] pkg = new byte[9];
            Buffer.BlockCopy(BitConverter.GetBytes((int)ComID.ReadLowPara), 0, pkg, 0, 2);
            Buffer.BlockCopy(BitConverter.GetBytes(Version), 0, pkg, 2, 2);
            Buffer.BlockCopy(BitConverter.GetBytes(9), 0, pkg, 4, 4);
            pkg[8] = 0;//校验
            return pkg;
        }
        public static byte[] SetupHighBSS(BSSParameter para)
        {
            byte[] pkg = new byte[65];
            Buffer.BlockCopy(BitConverter.GetBytes((int)ComID.SetupHighBSS), 0, pkg, 0, 2);
            Buffer.BlockCopy(BitConverter.GetBytes(Version), 0, pkg, 2, 2);
            Buffer.BlockCopy(BitConverter.GetBytes(65), 0, pkg, 4, 4);
            Buffer.BlockCopy(para.Pack(), 0, pkg, 8, 56);
            pkg[64] = 0;//校验
            return pkg;
        }
        public static byte[] SetupLowBSS(BSSParameter para)
        {
            byte[] pkg = new byte[65];
            Buffer.BlockCopy(BitConverter.GetBytes((int)ComID.SetupLowBSS), 0, pkg, 0, 2);
            Buffer.BlockCopy(BitConverter.GetBytes(Version), 0, pkg, 2, 2);
            Buffer.BlockCopy(BitConverter.GetBytes(9), 0, pkg, 4, 4);
            Buffer.BlockCopy(para.Pack(), 0, pkg, 8, 56);
            pkg[64] = 0;//校验
            return pkg;
        }
    }

    public class BSSObject
    {
        public uint ID;
        public int DataBytes;
        public uint FrameNo;
        public byte[] BssBytes;
        public BSSObject()
        {
            ID = (int) ObjectID.AD;
            DataBytes = 0;
            FrameNo = 0;
            BssBytes = null;
        }

        public int Parse(byte[] dataBytes,int idx)
        {
            try
            {
                ID = BitConverter.ToUInt16(dataBytes, idx);
                DataBytes = BitConverter.ToInt32(dataBytes, 2 + idx);
                FrameNo = BitConverter.ToUInt32(dataBytes, 6 + idx);
                BssBytes = new byte[DataBytes];
                Buffer.BlockCopy(dataBytes, idx+10, BssBytes,0, DataBytes);
                if ((ID == (uint)ObjectID.PortLowBssData) || (ID == (uint)ObjectID.PortHighBssData))//reverse port data
                {
                    Array.Reverse(BssBytes);
                }
                return DataBytes;
            }
            catch (Exception)
            {
                return 0;
            }
        }

    }
    public class DtObject
    {
        public Queue<BSSObject> ALLData = null;
        
        public DtObject()
        {
            ALLData = new Queue<BSSObject>();
        }
        public bool Parse(byte[] d)
        {
            
            int readlength = 0;
            do
            {
                BSSObject bssObject = new BSSObject();
                int n = bssObject.Parse(d, readlength);
                if (n == 0)
                    break;
                readlength += n+10;
                ALLData.Enqueue(bssObject);
            } while (readlength != d.Length);
            if(readlength!=d.Length)
                return false;
            return true;
        }
    }
}
