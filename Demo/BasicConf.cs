namespace Survey
{
    public class BasicConf
    {
        private static readonly object SyncObject = new object();
        private static BasicConf _basicConf;

        //配置文件
        private string xmldoc = "BasicConf.xml"; //const
        public static string MyExecPath;
        public static BasicConf GetInstance()
        {
            lock (SyncObject)
            {
                return _basicConf ?? (_basicConf = new BasicConf());
            }
        }

        protected BasicConf()
        {
            MyExecPath = System.IO.Path.GetDirectoryName(
                System.Reflection.Assembly.GetExecutingAssembly().GetModules()[0].FullyQualifiedName);
            xmldoc = MyExecPath + "\\" + xmldoc;

        }

        protected string GetValue(string[] str)
        {
            return XmlHelper.GetConfigValue(xmldoc, str);
        }
        protected bool SetValue(string[] str,string value)
        {
            return XmlHelper.SetConfigValue(xmldoc, str,value);
        }

        public string GetCommGPS()
        {
            string[] str = {"GPS", "ComPort"};
            return GetValue(str);
        }
        public bool SetCommGPS(string newgpscomm)
        {
            string[] str = {"GPS", "ComPort" };
            return SetValue(str, newgpscomm);
        }
        public string GetGPSDataRate()
        {
            string[] str = {"GPS", "DataRate" };
            return GetValue(str);
        }
        public bool SetGPSDataRate(string datarate)
        {
            string[] str = {"GPS", "DataRate" };
            return SetValue(str, datarate);
        }
        
    }
}
