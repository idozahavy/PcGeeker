using HardwareInfo.Analyzer.Threshold;
using HardwareInfo.HardwareBases;

namespace HardwareInfo.Analyzer.CPUAnalyze.CPUCoreAnalyze
{
    public class CPUCoreAnalyzer : BaseCPUCore<SensoredThresholdProperty>, IAnalyzer<CPUCoreAnalysis>
    {
        private CPUCoreAnalyzerSettings settings;

        public CPUCoreAnalyzer(Core core, CPUCoreAnalyzerSettings settings)
        {
            this.settings = settings;
            Temperature = new SensoredThresholdProperty(core.Temperature, settings.Temperature);
            Load = new SensoredThresholdProperty(core.Load, settings.Load);
            Clock = new SensoredThresholdProperty(core.Clock, settings.Clock);
        }

        public CPUCoreAnalysis Analyze()
        {
            return new CPUCoreAnalysis()
            {
                Temperature = Temperature.IsSensorThresholded(),
                Load = Load.IsSensorThresholded(),
                Clock = Clock.IsSensorThresholded(),
            };
        }
    }
}