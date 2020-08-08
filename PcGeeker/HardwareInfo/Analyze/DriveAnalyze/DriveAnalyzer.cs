using HardwareInfo.Analyze.Threshold;
using HardwareInfo.HardwareClass;

namespace HardwareInfo.Analyze.DriveAnalyze
{
    public class DriveAnalyzer : BaseDrive<SensoredThresholdProperty>, IAnalyzer<DriveAnalysis>
    {
        private DriveAnalyzerSettings settings;

        public DriveAnalyzer(Drive drive, DriveAnalyzerSettings settings)
        {
            this.settings = settings;
            Temperature = new SensoredThresholdProperty(drive.Temperature, settings.Temperature);
            UsedPercentage = new SensoredThresholdProperty(drive.UsedPercentage, settings.UsedPercentage);
        }

        public DriveAnalysis Analyze()
        {
            return new DriveAnalysis()
            {
                Temperature = Temperature.IsSensorThresholded(),
                UsedPercentage = UsedPercentage.IsSensorThresholded(),
            };
        }
    }
}