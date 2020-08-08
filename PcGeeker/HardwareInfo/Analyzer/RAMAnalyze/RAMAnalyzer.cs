using HardwareInfo.Analyzer.Threshold;
using HardwareInfo.HardwareClass;

namespace HardwareInfo.Analyzer.RAMAnalyze
{
    public class RAMAnalyzer : BaseRAM<SensoredThresholdProperty>, IAnalyzer<RAMAnalysis>
    {
        private RAMAnalyzerSettings settings;

        public RAMAnalyzer(RAM ram, RAMAnalyzerSettings settings)
        {
            this.settings = settings;
            Available = new SensoredThresholdProperty(ram.Available, settings.Available);
            Total = new SensoredThresholdProperty(ram.Total, settings.Total);
            Used = new SensoredThresholdProperty(ram.Used, settings.Used);
            UsedPercentage = new SensoredThresholdProperty(ram.UsedPercentage, settings.UsedPercentage);
        }

        public RAMAnalysis Analyze()
        {
            return new RAMAnalysis()
            {
                Available = Available.IsSensorThresholded(),
                Total = Total.IsSensorThresholded(),
                Used = Used.IsSensorThresholded(),
                UsedPercentage = UsedPercentage.IsSensorThresholded(),
            };
        }
    }
}