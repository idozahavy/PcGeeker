using OpenHardwareMonitor.Hardware;
using System.Reflection;

namespace HardwareInfo
{
    public class GPUMemory : Memory
    {
        public ISensor Load { get; private set; }
        public ISensor Clock { get; private set; }

        public GPUMemory() : base()
        {
            foreach(PropertyInfo prop in this.GetType().GetProperties())
            {
                if(prop.PropertyType == typeof(ISensor))
                {
                    prop.SetValue(this, Sensors.NAIfNull((ISensor)prop.GetValue(this)));
                }
            }
        }

        internal override void Initialize(ISensor sensor)
        {
            switch(sensor.SensorType)
            {
                case SensorType.Clock:
                    Clock = sensor;
                    break;

                case SensorType.Load:
                    Load = sensor;
                    break;

                case SensorType.SmallData:
                    base.Initialize(sensor);
                    break;

                default:
                    Jsoner.ObjectSaver.AddObject(sensor);
                    break;
            }
        }
    }
}