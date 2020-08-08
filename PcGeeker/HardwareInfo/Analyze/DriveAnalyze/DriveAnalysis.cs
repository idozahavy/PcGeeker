using HardwareInfo.HardwareClass;

namespace HardwareInfo.Analyze.DriveAnalyze
{
    public class DriveAnalysis : BaseDrive<bool>, IAnalysis
    {
        internal DriveAnalysis()
        {
        }

        public DriveAnalysis(bool temperatureThresholded, bool usedSpacePercentageThresholded)
        {
            this.Temperature = temperatureThresholded;
            this.UsedPercentage = usedSpacePercentageThresholded;
        }
    }
}