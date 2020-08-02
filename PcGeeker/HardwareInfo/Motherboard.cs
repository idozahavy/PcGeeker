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
    public class Motherboard : AHardware
    {
        public IHardware Controller
        {
            get;
            private set;
        }

        public List<ISensor> FanControls 
        {
            get;
            private set;
        }
        public List<ISensor> Voltages
            {
            get;
            private set;
        }
        public ISensor Voltage3p3
        {
            get;
            private set;
        }
        public ISensor VBat
        {
            get;
            private set;
        }
        public List<ISensor> Temperatures
        {
            get;
            private set;
        }
        public ISensor CpuFanSpeed
        {
            get;
            private set;
        }
        public List<ISensor> FanSpeeds
        {
            get;
            private set;
        }

        public override AHardwareType HardwareType { get => AHardwareType.Motherboard; }

        public Motherboard(IHardware hardware) : base(hardware)
        {
            Initialize();
            foreach (PropertyInfo prop in this.GetType().GetProperties())
            {
                if (prop.PropertyType == typeof(ISensor))
                {
                    prop.SetValue(this, Sensors.NAIfNull((ISensor)prop.GetValue(this)));
                }
                else if (prop.PropertyType == typeof(List<ISensor>))
                {
                    prop.SetValue(this, new List<ISensor>());
                }
            }
        }

        internal override void Initialize()
        {
            Controller = hardware;
            foreach (ISensor sensor in hardware.Sensors)
            {
                this.Initialize(sensor);
                Console.WriteLine(sensor.Name);
            }
            foreach (IHardware subHardware in hardware.SubHardware)
            {
                Controller = subHardware;
                foreach (ISensor sensor in subHardware.Sensors)
                {
                    this.Initialize(sensor);
                }
            }
        }

        private void Initialize(ISensor sensor)
        {
            switch (sensor.SensorType)
            {
                case SensorType.Temperature: Temperatures.Add(sensor); break;
                case SensorType.Voltage: if (sensor.Name.Contains("+3.3V")) { Voltage3p3 = sensor; }
                    else if (sensor.Name.Contains("VBat")) { VBat = sensor; }
                    else { Voltages.Add(sensor); }
                    break;
                case SensorType.Fan:
                    if (sensor.Name.EndsWith("#1")) { CpuFanSpeed = sensor;  }
                    else { FanSpeeds.Add(sensor); }
                    break;
                case SensorType.Control: FanControls.Add(sensor); break;
                default:
                    Jsoner.ObjectSaver.AddObject(sensor); break;
            }
        }
    }
}
