using HardwareInfo.HardwareClass;
using HardwareInfo.Sensor;
using OpenHardwareMonitor.Hardware;
using System.Reflection;

namespace HardwareInfo
{
    public class GPU : BaseGPU<ISensor>, IHardwareable
    {
        public IHardware Hardware { get; private set; }

        public GPU(IHardware hardware)
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

        public void Initialize()
        {
            foreach(ISensor sensor in Hardware.Sensors)
            {
                if(sensor.Name.Contains("Memory"))
                {
                    switch(sensor.SensorType)
                    {
                        case SensorType.Clock:
                        {
                            MemoryClock = sensor;
                        }
                        break;

                        case SensorType.Load:
                        {
                            MemoryLoad = sensor;
                        }
                        break;

                        case SensorType.SmallData:
                        {
                            if(sensor.Name.EndsWith("Total"))
                            { MemoryTotal = sensor; }
                            else if(sensor.Name.EndsWith("Used"))
                            { MemoryUsed = sensor; }
                            else if(sensor.Name.EndsWith("Free"))
                            { MemoryFree = sensor; }
                            else
                            { Jsoner.ObjectSaver.AddObject(sensor); }
                        }
                        break;

                        default:
                        {
                            Jsoner.ObjectSaver.AddObject(sensor);
                        }
                        break;
                    }
                }
                else // not a memory sensor
                {
                    switch(sensor.SensorType)
                    {
                        case SensorType.Load:
                        {
                            if(sensor.Name.Contains("Core"))
                            { CoreLoad = sensor; }
                            else if(sensor.Name.Contains("Frame Buffer"))
                            { FrameBufferLoad = sensor; }
                            else if(sensor.Name.Contains("Video Engine"))
                            { VideoEngineLoad = sensor; }
                            else if(sensor.Name.Contains("Bus Interface"))
                            { BusLoad = sensor; }
                            else
                            { Jsoner.ObjectSaver.AddObject(sensor); }
                        }
                        break;

                        case SensorType.Temperature:
                        {
                            if(sensor.Name.Contains("Core"))
                            { CoreTemperature = sensor; }
                            else
                            { Jsoner.ObjectSaver.AddObject(sensor); }
                        }
                        break;

                        case SensorType.Clock:
                        {
                            if(sensor.Name.Contains("Shader"))
                            { ShaderClock = sensor; }
                            else if(sensor.Name.Contains("Core"))
                            { CoreClock = sensor; }
                            else
                            { Jsoner.ObjectSaver.AddObject(sensor); }
                        }
                        break;

                        case SensorType.Control:
                        {
                            if(sensor.Name.Contains("Fan"))
                            { FanSpeed = sensor; break; }
                            Jsoner.ObjectSaver.AddObject(sensor);
                        }
                        break;

                        default:
                        {
                            Jsoner.ObjectSaver.AddObject(sensor);
                        }
                        break;
                    }
                }
            }
        }

        public void Update(IVisitor visitor)
        {
            Hardware.Accept(visitor);
        }
    }
}