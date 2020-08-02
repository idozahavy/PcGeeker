using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareInfo.PCanalyzer
{
    public class PCAnalyzerSettings
    {

        private int cpuTempThreshold = 90;
        private int cpuPowerThreshold = 20;

        public PCAnalyzerSettings(bool cpuPower, bool cpuCoreClock, bool cpuTemp, bool cpuLoad) 
        {

        }
    }
}
