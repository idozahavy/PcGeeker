using OpenHardwareMonitor.Hardware;
using System.Reflection;

namespace HardwareInfo
{
    public class Memory
    {
        public ISensor Total { get; protected set; }
        public ISensor Used { get; protected set; }
        public ISensor Free { get; protected set; }

        public Memory()
        {
            foreach(PropertyInfo prop in this.GetType().GetProperties())
            {
                if(prop.PropertyType == typeof(ISensor))
                {
                    prop.SetValue(this, Sensors.NAIfNull((ISensor)prop.GetValue(this)));
                }
            }
        }

        internal virtual void Initialize(ISensor sensor)
        {
            switch(sensor.SensorType)
            {
                case SensorType.SmallData:
                {
                    string[] splat = sensor.Name.Split(new string[] { "Memory" }, System.StringSplitOptions.RemoveEmptyEntries);
                    if(splat.Length < 2)
                    {
                        Jsoner.ObjectSaver.AddObject(sensor);
                        break;
                    }
                    switch(splat[1])
                    {
                        case " Total":
                            Total = sensor;
                            break;

                        case " Used":
                            Used = sensor;
                            break;

                        case " Free":
                            Free = sensor;
                            break;

                        default:
                            Jsoner.ObjectSaver.AddObject(sensor);
                            break;
                    }
                }
                break;

                case SensorType.Data:
                {
                    if(sensor.Name.StartsWith("Used"))
                    {
                        Used = sensor;
                    }
                    else if(sensor.Name.StartsWith("Available"))
                    {
                        Free = sensor;
                    }
                    else
                    {
                        Jsoner.ObjectSaver.AddObject(sensor);
                    }
                }
                break;

                default:
                    Jsoner.ObjectSaver.AddObject(sensor);
                    break;
            }
        }
    }
}