using OpenHardwareMonitor.Hardware;
using System;
using System.Windows.Forms;

namespace HardwareInfo
{
    public class GPU : AHardware
    {

        public GPUMemory Memory
        {
            get;
            private set;
        }

        public ISensor CoreTemperature
        {
            get;
            private set;
        }
        public ISensor CoreClock
        {
            get;
            private set;
        }
        public ISensor CoreLoad
        {
            get;
            private set;
        }
        public ISensor ShaderClock
        {
            get;
            private set;
        }
        public ISensor FrameBufferLoad
        {
            get;
            private set;
        }
        public ISensor VideoEngineLoad
        {
            get;
            private set;
        }
        public ISensor BusLoad
        {
            get;
            private set;
        }
        public ISensor FanSpeed
        {
            get;
            private set;
        }

        public GPU(IHardware hardware) : base(hardware)
        {
            Initialize();
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
                            MessageBox.Show("Uncaught sensor type Load sensor name = " + sensor.Name);
                            break;
                        }
                        case SensorType.Temperature:
                        {
                            if(sensor.Name.Contains("Core")) { CoreTemperature = sensor; break; }
                            MessageBox.Show("Uncaught sensor type Temperature sensor name = " + sensor.Name);
                            break;
                        }
                        case SensorType.Clock:
                        {
                            if(sensor.Name.Contains("Shader")) { ShaderClock = sensor; break; }
                            if(sensor.Name.Contains("Core")) { CoreClock = sensor; break; }
                            MessageBox.Show("Uncaught sensor type Clock sensor name = " + sensor.Name);
                            break;
                        }
                        case SensorType.Control:
                        {
                            if(sensor.Name.Contains("Fan")) { FanSpeed = sensor; break; }
                            MessageBox.Show("Uncaught sensor type Control sensor name = " + sensor.Name);
                            break;
                        }
                        default:
                        {
                            MessageBox.Show("Uncaught sensor type " + sensor.SensorType.ToString());
                            break;
                        }
                    }
                }
            }
        }
    }
}