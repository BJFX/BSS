using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Text;
using System.Threading;
using NMEA0183;
using System.Linq;
namespace Survey
{
    public abstract class SerialSerialServiceBase
    {
        #region 属性

        protected static SerialPort _serialPort;

        private List<byte> _recvQueue = new List<byte>();
        public string Status = "GPS端口未打开";
        #endregion

        #region 方法
        public bool Init(SerialPort serialPort)
        {
            try
            {
                _recvQueue.Clear();
                _serialPort = serialPort;
                if (SerialPort.GetPortNames().All(t => t != _serialPort.PortName.ToUpper()))
                {
                   return false;
                }
                if (!_serialPort.IsOpen) _serialPort.Open();
                if(_serialPort.IsOpen)
                    Status = "GPS端口已打开";
                return _serialPort.IsOpen;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
                Status = "打开GPS端口出错";
            }
            
        }

        public bool Stop()
        {
            _serialPort.DataReceived -= _SerialPort_DataReceived;
            try
            {
                if (_serialPort.IsOpen)
                    _serialPort.Close();
                Status = "GPS端口未打开";
            }
            catch (Exception)
            {
                Status = "关闭GPS端口出错";
                return false;
            }
            return true;
        }

        public virtual bool Start()
        {
            _serialPort.DataReceived -= _SerialPort_DataReceived;
            _serialPort.DataReceived += _SerialPort_DataReceived;
            return _serialPort.IsOpen;
        }

        public virtual SerialPort ReturnSerialPort()
        {
            return _serialPort;
        }
        private void _SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            var nCount = _serialPort.BytesToRead;
            if ( nCount < 16)
            {
                Thread.Sleep(50);
                return;
            }
            for (int i = nCount - 1; i >= 0; i--)
            {
                _recvQueue.Add((byte)_serialPort.ReadByte());
                CheckQueue(ref _recvQueue);
            }
            
        }

        protected abstract void CheckQueue(ref List<byte> lstBytes);

        
        #endregion
    }
    public class GPSSerialService:SerialSerialServiceBase
    {

        
        protected override void CheckQueue(ref List<byte> queue)
        {
            var bytes = new byte[queue.Count];
            queue.CopyTo(bytes);

            if (queue.Count > 2&&(bytes[queue.Count - 2] == '\r') && (bytes[queue.Count - 1] == '\n'))

            {
                var strcmd = Encoding.ASCII.GetString(bytes);
                queue.Clear();
                ParseGPSString(strcmd);
            }
        }

        private void ParseGPSString(string strcmd)
        {
            if (GPS.Parse(strcmd))
            {
                Status = "定位数据无效";
            }
            else
            {
                Status = "接收定位数据中……";
            }
        }

    }
}
