namespace HardwareInfo.Analyzer
{
    public class GPUAnalyzer : IAnalyzer<GPUAnalysis>
    {
        private GPUAnalyzerSettings settings;
        public SensoredThresholdProperty BusLoadThreshold { get; private set; }
        public SensoredThresholdProperty CoreClockThreshold { get; private set; }
        public SensoredThresholdProperty CoreLoadThreshold { get; private set; }
        public SensoredThresholdProperty CoreTemperatureThreshold { get; private set; }
        public SensoredThresholdProperty FanSpeedThreshold { get; private set; }
        public SensoredThresholdProperty FrameBufferLoadThreshold { get; private set; }
        public SensoredThresholdProperty ShaderClockThreshold { get; private set; }
        public SensoredThresholdProperty VideoEngineLoadThreshold { get; private set; }

        public GPUAnalyzer(GPU gpu, GPUAnalyzerSettings settings)
        {
            this.settings = settings;
            BusLoadThreshold = new SensoredThresholdProperty(gpu.BusLoad, settings.BusLoadThreshold);
            CoreClockThreshold = new SensoredThresholdProperty(gpu.CoreClock, settings.CoreClockThreshold);
            CoreLoadThreshold = new SensoredThresholdProperty(gpu.CoreLoad, settings.CoreLoadThreshold);
            CoreTemperatureThreshold = new SensoredThresholdProperty(gpu.CoreTemperature, settings.CoreTemperatureThreshold);
            FanSpeedThreshold = new SensoredThresholdProperty(gpu.FanSpeed, settings.FanSpeedThreshold);
            FrameBufferLoadThreshold = new SensoredThresholdProperty(gpu.FrameBufferLoad, settings.FrameBufferLoadThreshold);
            ShaderClockThreshold = new SensoredThresholdProperty(gpu.ShaderClock, settings.ShaderClockThreshold);
            VideoEngineLoadThreshold = new SensoredThresholdProperty(gpu.VideoEngineLoad, settings.VideoEngineLoadThreshold);
        }

        public GPUAnalysis Analyze()
        {
            return new GPUAnalysis()
            {
                BusLoadThresholded = BusLoadThreshold.IsSensorThresholded(),
                CoreClockThresholded = CoreClockThreshold.IsSensorThresholded(),
                CoreLoadThresholded = CoreLoadThreshold.IsSensorThresholded(),
                CoreTemperatureThresholded = CoreTemperatureThreshold.IsSensorThresholded(),
                FanSpeedThresholded = FanSpeedThreshold.IsSensorThresholded(),
                FrameBufferLoadThresholded = FrameBufferLoadThreshold.IsSensorThresholded(),
                ShaderClockThresholded = ShaderClockThreshold.IsSensorThresholded(),
                VideoEngineLoadThresholded = VideoEngineLoadThreshold.IsSensorThresholded()
            };
        }
    }
}