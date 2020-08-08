using HardwareInfo.Analyzer.Threshold;
using HardwareInfo.HardwareBases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareInfo.Analyzer.DriveAnalyze
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
