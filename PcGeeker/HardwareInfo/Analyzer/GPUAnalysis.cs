namespace HardwareInfo.Analyzer
{
    public class GPUAnalysis : Analysis
    {
        public bool BusLoadThresholded { get; internal set; }
        public bool CoreClockThresholded { get; internal set; }
        public bool CoreLoadThresholded { get; internal set; }
        public bool CoreTemperatureThresholded { get; internal set; }
        public bool FanSpeedThresholded { get; internal set; }
        public bool FrameBufferLoadThresholded { get; internal set; }
        public bool ShaderClockThresholded { get; internal set; }
        public bool VideoEngineLoadThresholded { get; internal set; }

        internal GPUAnalysis()
        {
        }

        public GPUAnalysis(bool busLoadThresholded, bool coreClockThresholded, bool coreLoadThresholded,
            bool coreTemperatureThresholded, bool fanSpeedThresholded, bool frameBufferLoadThresholded,
            bool shaderClockThresholded, bool videoEngineLoadThresholded)
        {
            BusLoadThresholded = busLoadThresholded;
            CoreClockThresholded = coreClockThresholded;
            CoreLoadThresholded = coreLoadThresholded;
            CoreTemperatureThresholded = coreTemperatureThresholded;
            FanSpeedThresholded = fanSpeedThresholded;
            FrameBufferLoadThresholded = frameBufferLoadThresholded;
            ShaderClockThresholded = shaderClockThresholded;
            VideoEngineLoadThresholded = videoEngineLoadThresholded;
        }
    }
}