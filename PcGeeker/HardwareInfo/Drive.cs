using OpenHardwareMonitor.Hardware;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HardwareInfo
{
    public class Drive : AHardware
    {
        public ISensor Temperature { get; private set; }
        public ISensor UsedSpacePercentage { get; private set; }

        public override AHardwareType HardwareType { get => AHardwareType.Drive; }

        public Drive(IHardware hardware) : base(hardware)
        {
            Initialize();
            foreach (PropertyInfo prop in this.GetType().GetProperties())
            {
                if (prop.PropertyType == typeof(ISensor))
                {
                    prop.SetValue(this, Sensors.NAIfNull((ISensor)prop.GetValue(this)));
                }
            }
        }

        internal override void Initialize()
        {
            foreach(ISensor sensor in hardware.Sensors)
            {
                switch(sensor.SensorType)
                {
                    case SensorType.Temperature: Temperature = sensor; break;
                    case SensorType.Load: UsedSpacePercentage = sensor; break;
                    default:
                        Jsoner.ObjectSaver.AddObject(sensor); break;
                }
            }
        }
    }
}
