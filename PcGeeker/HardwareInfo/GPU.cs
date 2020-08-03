using OpenHardwareMonitor.Hardware;
using System;
using System.Reflection;
using System.Windows.Forms;

namespace HardwareInfo
{
    public class GPU : AHardware
    {

        public GPUMemory Memory { get; private set; }

        public ISensor CoreTemperature { get; private set; }
        public ISensor CoreClock { get; private set; }
        public ISensor CoreLoad { get; private set; }
        public ISensor ShaderClock { get; private set; }
        public ISensor FrameBufferLoad { get; private set; }
        public ISensor VideoEngineLoad { get; private set; }
        public ISensor BusLoad { get; private set; }
        public ISensor FanSpeed{ get; private set; }

        public override AHardwareType HardwareType { get => AHardwareType.GPU; }

        public GPU(IHardware hardware) : base(hardware)
        {
            Initialize();          
            foreach(PropertyInfo prop in this.GetType().GetProperties())
            {
                if (prop.PropertyType == typeof(ISensor))
                {
                    prop.SetValue(this, Sensors.NAIfNull((ISensor)prop.GetValue(this)));
                }
            }
        }

        internal override void Initialize()
        {
            Memory = null;
            foreach(ISensor sensor in hardware.Sensors)
            {
                if(sensor.Name.Contains("Memory"))
                {
                    if(Memory == null)
                    {
                        Memory = new GPUMemory();
                    }
                    Memory.Initialize(sensor);
                }
                else // not a memory sensor
                {
                    switch(sensor.SensorType)
                    {
                        case SensorType.Load:
                        {
                            if(sensor.Name.Contains("Core")) { CoreLoad = sensor; break; }
                            if(sensor.Name.Contains("Frame Buffer")) { FrameBufferLoad = sensor; break; }
                            if(sensor.Name.Contains("Video Engine")) { VideoEngineLoad = sensor; break; }
                            if(sensor.Name.Contains("Bus Interface")) { BusLoad = sensor; break; }
                                Jsoner.ObjectSaver.AddObject(sensor);
                                break;
                        }
                        case SensorType.Temperature:
                        {
                            if(sensor.Name.Contains("Core")) { CoreTemperature = sensor; break; }
                                Jsoner.ObjectSaver.AddObject(sensor);
                                break;
                        }
                        case SensorType.Clock:
                        {
                            if(sensor.Name.Contains("Shader")) { ShaderClock = sensor; break; }
                            if(sensor.Name.Contains("Core")) { CoreClock = sensor; break; }
                                Jsoner.ObjectSaver.AddObject(sensor);
                                break;
                        }
                        case SensorType.Control:
                        {
                            if(sensor.Name.Contains("Fan")) { FanSpeed = sensor; break; }
                                Jsoner.ObjectSaver.AddObject(sensor);
                                break;
                        }
                        default:
                        {
                                Jsoner.ObjectSaver.AddObject(sensor);
                                break;
                        }
                    }
                }
            }
        }

        public enum GPUAttribute
        {
            CoreTemperature = 1,
            CoreClock = 2,
            CoreLoad = 3,
            ShaderClock = 4,
            FrameBufferLoad = 5,
            VideoEngineLoad = 6,
            BusLoad = 7,
            FanSpeed = 8
        }
    }
}