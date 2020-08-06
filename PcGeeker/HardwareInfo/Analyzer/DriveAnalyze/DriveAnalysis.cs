using HardwareInfo.HardwareBases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareInfo.Analyzer.DriveAnalyze
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
