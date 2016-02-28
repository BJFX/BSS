using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Survey
{
    public enum ComID
    {
        Start=0x41,
        Stop=0x42,
        SetupHighBSS=0x11,
        SetupLowBSS = 0x12,
        SetupSBP = 0x13,
        SetupSensor = 0x14,
        SetupSysControl = 0x15,
        SetupWorkPara = 0x16,
        SysStatus = 0x30,
        Ans=0x50,
    }
    public class BSSParameter
    {
        public int DeviceID;
        public int Ls;
        public int Ts;
        public BSSParameter()
        {
            
        }
    }
    
    public class Command
    {
        public static Hashtable Ans = new Hashtable();
        public static int Version;
    }
}
