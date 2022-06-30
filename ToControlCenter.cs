using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdgeModels.ToControlCenter
{
    public class cls_SensorInfo_Mqtt
    {
        public string SensorName { get; set; } = "";
        public string IP { get; set; } = "";
        public int Port { get; set; } = 0;
        public string SensorType { get; set; } = "";
        public string DataUnit { get; set; } = "";
        public bool IsOnlySaveData { get; set; } = false;
    }

    public class cls_SensorStatus_Mqtt
    {
        public string SensorName { get; set; } = "";
        public bool ConnectStatus { get; set; } = false;
        public DateTime LastUpdateTime { get; set; }

    }

    public class cls_SensorData_Mqtt
    {
        public string SensorName { get; set; } = "";
        public DateTime TimeLog { get; set; }
        public Dictionary<string, double> Dict_RawData { get; set; } = new Dictionary<string, double>();
        public bool IsArrayData { get; set; }
        public Dictionary<string, List<double>> Dict_ListRawData { get; set; } = new Dictionary<string, List<double>>();
        public List<DateTime> List_TimeLog { get; set; }
    }

}
