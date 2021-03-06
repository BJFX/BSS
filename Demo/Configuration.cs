﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Survey
{
    public class Configuration
    {
        public static bool bSaveXTF;
        public static bool bNewXTF = false;//保存XTF时是否是新文件标志位
        public static bool DiskMode;
        public static string SlnName;
        public static string DataPath;
        public static string prefix;
        public static int Interval;
        public static int SaveOption;//0,1,2
        public static string TargetCatalogFile;
        public static string SurveyRouteFile;
        public static string StateFile;
        public static bool SaveStateFileAfterSurveyFinish;
        public static bool UsePress;
        public static float ScaleFactor;
        public static float PressOffset;
        public static int PanelMinWidth;
    }
}
