using HardwareInfo.Analyzer.Threshold;
using HardwareInfo.HardwareBases;

namespace HardwareInfo.Analyzer.GPUAnalyze
{
    public class GPUAnalyzer : BaseGPU<SensoredThresholdProperty>, IAnalyzer<GPUAnalysis>
    {
        private GPUAnalyzerSettings settings;

        public GPUAnalyzer(GPU gpu, GPUAnalyzerSettings settings)
        {
            this.settings = settings;
            BusLoad = new SensoredThresholdProperty(gpu.BusLoad, settings.BusLoad);
            CoreClock = new SensoredThresholdProperty(gpu.CoreClock, settings.CoreClock);
            CoreLoad = new SensoredThresholdProperty(gpu.CoreLoad, settings.CoreLoad);
            CoreTemperature = new SensoredThresholdProperty(gpu.CoreTemperature, settings.CoreTemperature);
            FanSpeed = new SensoredThresholdProperty(gpu.FanSpeed, settings.FanSpeed);
            FrameBufferLoad = new SensoredThresholdProperty(gpu.FrameBufferLoad, settings.FrameBufferLoad);
            ShaderClock = new SensoredThresholdProperty(gpu.ShaderClock, settings.ShaderClock);
            VideoEngineLoad = new SensoredThresholdProperty(gpu.VideoEngineLoad, settings.VideoEngineLoad);
        }

        public GPUAnalysis Analyze()
        {
            return new GPUAnalysis()
            {
                BusLoad= BusLoad.IsSensorThresholded(),
                CoreClock= CoreClock.IsSensorThresholded(),
                CoreLoad= CoreLoad.IsSensorThresholded(),
                CoreTemperature= CoreTemperature.IsSensorThresholded(),
                FanSpeed= FanSpeed.IsSensorThresholded(),
                FrameBufferLoad= FrameBufferLoad.IsSensorThresholded(),
                ShaderClock= ShaderClock.IsSensorThresholded(),
                VideoEngineLoad= VideoEngineLoad.IsSensorThresholded()
            };
        }
    }
}