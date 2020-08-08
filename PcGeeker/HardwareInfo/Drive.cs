using HardwareInfo.HardwareClass;
using HardwareInfo.Sensor;
using OpenHardwareMonitor.Hardware;
using System.Reflection;

namespace HardwareInfo
{
    public class Drive : BaseDrive<ISensor>, IHardwareable
    {
        public IHardware Hardware { get; private set; }

        public Drive(IHardware hardware)
        {
            Hardware = hardware;
            Initialize();
            foreach(PropertyInfo prop in this.GetType().GetProperties())
            {
                if(prop.PropertyType == typeof(ISensor))
                {
                    prop.SetValue(this, SensorTool.NAIfNull((ISensor)prop.GetValue(this)));
                }
            }
        }

        public void Update(IVisitor visitor)
        {
            Hardware.Accept(visitor);
        }

        public void Initialize()
        {
            foreach(ISensor sensor in Hardware.Sensors)
            {
                switch(sensor.SensorType)
                {
                    case SensorType.Temperature:
                        Temperature = sensor;
                        break;

                    case SensorType.Load:
                        UsedPercentage = sensor;
                        break;

                    default:
                        Jsoner.ObjectSaver.AddObject(sensor);
                        break;
                }
            }
        }
    }
}