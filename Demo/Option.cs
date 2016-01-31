using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Demo
{
    public enum ShowSide
    {
        Starboard,
        Port,
        Both
    }

    public enum Frequence
    {
        High,
        Low
    }
    public class ChartOption
    {
        public Frequence Fq = Frequence.High;
        public ShowSide Side= ShowSide.Both;
        public bool AutoTVG;
        public bool FreezeTVG;
        public float TVG;
        public int PortA;
        public int PortB;
        public int PortC;
        public int StarboardA;
        public int StarboardB;
        public int StarboardC;
        public Color StartColor;
        public Color EndColor;
        public float Gamma;

        public ChartOption()
        {
            Fq = Frequence.High;
            Side = ShowSide.Both;
            AutoTVG = true;
            FreezeTVG =true;
            TVG = 1;
            Gamma = 1;
            PortA =50;
            PortB = 50;
            PortC = 50;
            StarboardA = 50;
            StarboardB = 50;
            StarboardC = 50;
            StartColor = Color.Black;
            EndColor = Color.White;
        }
    }

    public class NaviOption
    {
        
    }
}
