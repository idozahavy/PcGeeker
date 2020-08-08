using HardwareInfo.Analyze.Threshold;
using HardwareInfo.HardwareClass;

namespace HardwareInfo.Analyze.GPUAnalyze
{
    public class GPUAnalyzerSettings : BaseGPU<SensorlessThresholdProperty>, IAnalyzerSettings<GPU, GPU.GPUField>
    {
        public GPUAnalyzerSettings(float? busLoadThresholdValue, float? coreClockThresholdValue, float? coreLoadThresholdValue,
            float? coreTemperatureThresholdValue, float? fanSpeedThresholdValue, float? frameBufferLoadThresholdValue,
            float? shaderClockThresholdValue, float? videoEngineLoadThresholdValue, float? memoryClockThresholdValue,
            float? memoryFreeThresholdValue, float? memoryLoadThresholdValue, float? memoryTotalThresholdValue,
            float? memoryUsedThresholdValue)
        {
            BusLoad = new SensorlessThresholdProperty(busLoadThresholdValue);
            CoreClock = new SensorlessThresholdProperty(coreClockThresholdValue);
            CoreLoad = new SensorlessThresholdProperty(coreLoadThresholdValue);
            CoreTemperature = new SensorlessThresholdProperty(coreTemperatureThresholdValue);
            FanSpeed = new SensorlessThresholdProperty(fanSpeedThresholdValue);
            FrameBufferLoad = new SensorlessThresholdProperty(frameBufferLoadThresholdValue);
            ShaderClock = new SensorlessThresholdProperty(shaderClockThresholdValue);
            VideoEngineLoad = new SensorlessThresholdProperty(videoEngineLoadThresholdValue);
            MemoryClock = new SensorlessThresholdProperty(memoryClockThresholdValue);
            MemoryFree = new SensorlessThresholdProperty(memoryFreeThresholdValue);
            MemoryLoad = new SensorlessThresholdProperty(memoryLoadThresholdValue);
            MemoryTotal = new SensorlessThresholdProperty(memoryTotalThresholdValue);
            MemoryUsed = new SensorlessThresholdProperty(memoryUsedThresholdValue);
        }

        /// <summary>
        /// Gets the args and construct the Thresholds for every arg
        /// </summary>
        /// <param name="args">Format for every string is 'gpuFieldName:thresholdValue'</param>
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
                        BusLoad = new SensorlessThresholdProperty(float.Parse(segments[1]));
                        break;

                    case "coreclock":
                        CoreClock = new SensorlessThresholdProperty(float.Parse(segments[1]));
                        break;

                    case "coreload":
                        CoreLoad = new SensorlessThresholdProperty(float.Parse(segments[1]));
                        break;

                    case "temp":
                    case "coretemperature":
                        CoreTemperature = new SensorlessThresholdProperty(float.Parse(segments[1]));
                        break;

                    case "fan":
                    case "fanspeed":
                        FanSpeed = new SensorlessThresholdProperty(float.Parse(segments[1]));
                        break;

                    case "shaderbuffer":
                    case "framebufferload":
                        FrameBufferLoad = new SensorlessThresholdProperty(float.Parse(segments[1]));
                        break;

                    case "shaderclock":
                        ShaderClock = new SensorlessThresholdProperty(float.Parse(segments[1]));
                        break;

                    case "engineload":
                    case "video":
                    case "videoengineload":
                        VideoEngineLoad = new SensorlessThresholdProperty(float.Parse(segments[1]));
                        break;

                    case "memoryclock":
                        MemoryClock = new SensorlessThresholdProperty(float.Parse(segments[1]));
                        break;

                    case "memoryavailable":
                    case "memoryfree":
                        MemoryFree = new SensorlessThresholdProperty(float.Parse(segments[1]));
                        break;

                    case "memoryload":
                        MemoryLoad = new SensorlessThresholdProperty(float.Parse(segments[1]));
                        break;

                    case "memorytotal":
                        MemoryTotal = new SensorlessThresholdProperty(float.Parse(segments[1]));
                        break;

                    case "memoryused":
                        MemoryUsed = new SensorlessThresholdProperty(float.Parse(segments[1]));
                        break;
                }
            }
        }

        public GPUAnalyzerSettings(params FieldThreshold[] args)
        {
            foreach(FieldThreshold arg in args)
            {
                this.GetType().GetProperty(arg.Field.ToString()).SetValue(this, arg.ThresholdValue);
                switch(arg.Field)
                {
                    case GPUField.BusLoad:
                        BusLoad = new SensorlessThresholdProperty(arg.ThresholdValue);
                        break;

                    case GPUField.CoreClock:
                        CoreClock = new SensorlessThresholdProperty(arg.ThresholdValue);
                        break;

                    case GPUField.CoreLoad:
                        CoreLoad = new SensorlessThresholdProperty(arg.ThresholdValue);
                        break;

                    case GPUField.CoreTemperature:
                        CoreTemperature = new SensorlessThresholdProperty(arg.ThresholdValue);
                        break;

                    case GPUField.FanSpeed:
                        FanSpeed = new SensorlessThresholdProperty(arg.ThresholdValue);
                        break;

                    case GPUField.FrameBufferLoad:
                        FrameBufferLoad = new SensorlessThresholdProperty(arg.ThresholdValue);
                        break;

                    case GPUField.MemoryClock:
                        MemoryClock = new SensorlessThresholdProperty(arg.ThresholdValue);
                        break;

                    case GPUField.MemoryFree:
                        MemoryFree = new SensorlessThresholdProperty(arg.ThresholdValue);
                        break;

                    case GPUField.MemoryLoad:
                        MemoryLoad = new SensorlessThresholdProperty(arg.ThresholdValue);
                        break;

                    case GPUField.MemoryTotal:
                        MemoryTotal = new SensorlessThresholdProperty(arg.ThresholdValue);
                        break;

                    case GPUField.MemoryUsed:
                        MemoryUsed = new SensorlessThresholdProperty(arg.ThresholdValue);
                        break;

                    case GPUField.ShaderClock:
                        ShaderClock = new SensorlessThresholdProperty(arg.ThresholdValue);
                        break;

                    case GPUField.VideoEngineLoad:
                        VideoEngineLoad = new SensorlessThresholdProperty(arg.ThresholdValue);
                        break;
                }
            }
        }

        public string FieldStringThreshold(GPU.GPUField field, float thresholdValue)
        {
            return FieldThreshold.FieldStringThreshold(field, thresholdValue);
        }
    }
}