using System;

namespace HardwareInfo.Analyzer
{
    public class GPUAnalyzerSettings
    {
        public SensorlessThresholdProperty BusLoadThreshold { get; private set; }
        public SensorlessThresholdProperty CoreClockThreshold { get; private set; }
        public SensorlessThresholdProperty CoreLoadThreshold { get; private set; }
        public SensorlessThresholdProperty CoreTemperatureThreshold { get; private set; }
        public SensorlessThresholdProperty FanSpeedThreshold { get; private set; }
        public SensorlessThresholdProperty FrameBufferLoadThreshold { get; private set; }
        public SensorlessThresholdProperty ShaderClockThreshold { get; private set; }
        public SensorlessThresholdProperty VideoEngineLoadThreshold { get; private set; }

        /// <summary>
        /// Gets the args and construct the Thresholds for every arg
        /// </summary>
        /// <param name="args">Format for every string is 'gpuAttributeName:thresholdValue'</param>
        public GPUAnalyzerSettings(params string[] args)
        {
            foreach(string arg in args)
            {
                string[] segments = arg.Split(':');
                if(segments.Length < 2)
                {
                    continue;
                }
                switch(segments[0].ToLower())
                {
                    case "bus":
                    case "busload":
                        BusLoadThreshold = new SensorlessThresholdProperty(float.Parse(segments[1]));
                        break;

                    case "coreclock":
                        CoreClockThreshold = new SensorlessThresholdProperty(float.Parse(segments[1]));
                        break;

                    case "coreload":
                        CoreLoadThreshold = new SensorlessThresholdProperty(float.Parse(segments[1]));
                        break;

                    case "temp":
                    case "coretemperature":
                        CoreTemperatureThreshold = new SensorlessThresholdProperty(float.Parse(segments[1]));
                        break;

                    case "fan":
                    case "fanspeed":
                        FanSpeedThreshold = new SensorlessThresholdProperty(float.Parse(segments[1]));
                        break;

                    case "shaderbuffer":
                    case "framebufferload":
                        FrameBufferLoadThreshold = new SensorlessThresholdProperty(float.Parse(segments[1]));
                        break;

                    case "shaderclock":
                        ShaderClockThreshold = new SensorlessThresholdProperty(float.Parse(segments[1]));
                        break;

                    case "engineload":
                    case "video":
                    case "videoengineload":
                        VideoEngineLoadThreshold = new SensorlessThresholdProperty(float.Parse(segments[1]));
                        break;
                }
            }
        }

        public string AtrributeStringThreshold(GPU.GPUAttribute attr, float thresholdValue)
        {
            string result;
            switch(attr)
            {
                case GPU.GPUAttribute.BusLoad:
                    result = "busload";
                    break;

                case GPU.GPUAttribute.CoreClock:
                    result = "coreclock";
                    break;

                case GPU.GPUAttribute.CoreLoad:
                    result = "coreload";
                    break;

                case GPU.GPUAttribute.CoreTemperature:
                    result = "coretemperature";
                    break;

                case GPU.GPUAttribute.FanSpeed:
                    result = "fanspeed";
                    break;

                case GPU.GPUAttribute.FrameBufferLoad:
                    result = "framebufferload";
                    break;

                case GPU.GPUAttribute.ShaderClock:
                    result = "shaderclock";
                    break;

                case GPU.GPUAttribute.VideoEngineLoad:
                    result = "videoengineload";
                    break;

                default:
                    throw new Exception("GPU AtrributeStringThreshold attribute not found");
            }
            return result + ":" + thresholdValue.ToString();
        }
    }
}