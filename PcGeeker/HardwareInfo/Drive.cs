using OpenHardwareMonitor.Hardware;
using System.Reflection;

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
            foreach(PropertyInfo prop in this.GetType().GetProperties())
            {
                if(prop.PropertyType == typeof(ISensor))
                {
                    prop.SetValue(this, Sensors.NAIfNull((ISensor)prop.GetValue(this)));
                }
            }
        }

        internal override void Initialize()
        {
            foreach(ISensor sensor in Hardware.Sensors)
            {
                switch(sensor.SensorType)
                {
                    case SensorType.Temperature:
                        Temperature = sensor;
                        break;

                    case SensorType.Load:
                        UsedSpacePercentage = sensor;
                        break;

                    default:
                        Jsoner.ObjectSaver.AddObject(sensor);
                        break;
                }
            }
        }
    }
}