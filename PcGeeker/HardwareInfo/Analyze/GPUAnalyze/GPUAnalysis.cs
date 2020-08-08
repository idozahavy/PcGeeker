using HardwareInfo.HardwareClass;

namespace HardwareInfo.Analyze.GPUAnalyze
{
    public class GPUAnalysis : BaseGPU<bool>, IAnalysis
    {
        internal GPUAnalysis()
        {
        }

        public GPUAnalysis(bool busLoadThresholded, bool coreClockThresholded, bool coreLoadThresholded,
            bool coreTemperatureThresholded, bool fanSpeedThresholded, bool frameBufferLoadThresholded,
            bool shaderClockThresholded, bool videoEngineLoadThresholded, bool memoryClockThresholded,
            bool memoryLoadThresholded, bool memoryFreeThresholded, bool memoryTotalThresholded,
            bool memoryUsedThresholded)
        {
            BusLoad = busLoadThresholded;
            CoreClock = coreClockThresholded;
            CoreLoad = coreLoadThresholded;
            CoreTemperature = coreTemperatureThresholded;
            FanSpeed = fanSpeedThresholded;
            FrameBufferLoad = frameBufferLoadThresholded;
            ShaderClock = shaderClockThresholded;
            VideoEngineLoad = videoEngineLoadThresholded;
            MemoryClock = memoryClockThresholded;
            MemoryLoad = memoryLoadThresholded;
            MemoryFree = memoryFreeThresholded;
            MemoryTotal = memoryTotalThresholded;
            MemoryUsed = memoryUsedThresholded;
        }
    }
}