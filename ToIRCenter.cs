using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdgeModels.ToIRCenter
{
    /// <summary>
    /// K6PM控制器
    /// </summary>
    public class clsK6PMController
    {
        public clsK6PMController()
        {
            for (int i = 0; i < Sensors.Length; i++)
            {
                Sensors[i] = new clsK6PMSensor()
                {
                    Index = i,
                };
            }
        }

        public clsK6PMSensor[] Sensors { get; set; } = new clsK6PMSensor[31];
        /// <summary>
        /// 用於modbus tcp 連接的IP
        /// </summary>
        public string IP { get; set; } = "127.0.0.1";
        /// <summary>
        /// 用於modbus tcp 連接的Port
        /// </summary>
        public int Port { get; set; } = 502;
        public int ConnectedSensorNum { get; set; } = 0;
        public string Version { get; set; } = "V1.00";
        public bool ControllerAbnormal { get; set; } = true;
        public bool AnySensorAbnormal { get; set; } = true;
        public int RunPercent { get; set; } = 0;
    }

    /// <summary>
    /// 連接於K6PM控制器上的Sensor
    /// </summary>
    public class clsK6PMSensor
    {
        public clsK6PMSensor()
        {
            for (int i = 0; i < Segments.Length; i++)
            {
                Segments[i] = new clsSensorSegment()
                {
                    Index = i,
                };
            }
        }

        public int Index { set; get; }

        private string _MonitorLineName = "Line1";
        private string _MonitorECBName = "ECB1";

        public string MonitorLineName
        {
            get => _MonitorLineName;
            set
            {
                _MonitorLineName = value;
                foreach (var segment in Segments)
                    segment.MonitorLineName = value;
            }
        }

        public string MonitorECBName
        {
            get => _MonitorECBName;
            set
            {
                _MonitorECBName = value;
                foreach (var segment in Segments)
                    segment.MonitorECBName = value;
            }
        }

        public DateTime UpdateTime { get; set; } = DateTime.MinValue;
        public bool Active { get; set; } = true;
        public bool Abnormal { get; set; } = false;
        public bool DownloadPixelData { get; set; } = false;
        public clsSensorSegment[] Segments { get; set; } = new clsSensorSegment[16];


        /// <summary>
        /// Segments平均溫度
        /// </summary>
        public double AvgTemperauter
        {
            get
            {
                return Segments.Select(s => s.AvgTemperature).Average();
            }
        }

    }

    /// <summary>
    /// Sensor的段(Segment)資料
    /// </summary>

    public class clsSensorSegment
    {
        public int Index { set; get; }
        public string MonitorLineName { get; set; } = "Line1";
        public string MonitorECBName { get; set; } = "ECB1";
        public string MonitorCompoentName { get; set; } = "Breaker1";//customize
        public double MaxTemperature { get; set; }
        public double AvgTemperature { get; set; }
        public double[] pixelTemperatureList { get; set; } = new double[64];
        public double[,] Pixel2DTemperatuers { get; set; } = new double[32, 32];
    }



}
