using OpenHardwareMonitor.Hardware;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HardwareInfo
{
    public class Drive : AHardware
    {
        public ISensor Temperature
        {
            get;
            private set;
        }
        public ISensor UsedSpacePercentage
        {
            get;
            private set;
        }

        public Drive(IHardware hardware) : base(hardware)
        {
            Initialize();
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
                        MessageBox.Show("Uncaught ram sensor type " + sensor.SensorType.ToString()); break;
                }
            }
        }
    }
}
