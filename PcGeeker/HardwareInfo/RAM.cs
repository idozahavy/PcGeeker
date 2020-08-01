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
    public class RAM : AHardware
    {
        private Memory _memory;

        public ISensor Used
        {
            get => this._memory.Used;
        }
        public ISensor Free
        {
            get => this._memory.Free;
        }
        public ISensor UsedPercentage
        {
            get;
            private set;
        }

        public RAM(IHardware hardware) : base(hardware)
        {
            Initialize();
            foreach (PropertyInfo prop in this.GetType().GetProperties())
            {
                if (prop.PropertyType == typeof(ISensor) && prop.SetMethod != null)
                {
                    prop.SetValue(this, Sensors.NAIfNull((ISensor)prop.GetValue(this)));
                }
            }
        }

        internal override void Initialize()
        {
            _memory = new Memory();
            foreach (ISensor sensor in hardware.Sensors)
            {
                switch(sensor.SensorType)
                {
                    case SensorType.Load: UsedPercentage = sensor; break;
                    case SensorType.Data: _memory.Initialize(sensor); break;
                    default:
                        MessageBox.Show("Uncaught ram sensor type " + sensor.SensorType.ToString()); break;
                }
            }
        }
    }
}
