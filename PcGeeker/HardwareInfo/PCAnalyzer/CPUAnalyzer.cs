using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareInfo.PCAnalyzer
{
    class CPUAnalyzer
    {
        private List<SensorThresholdProperty> thresholds;
        private SensorThresholdProperty powerThreshold;
        private SensorThresholdProperty tempThreshold;

        public CPUAnalyzer()
        {
            powerThreshold = new SensorThresholdProperty(20);
            tempThreshold = new SensorThresholdProperty(56);
            thresholds = new List<SensorThresholdProperty>();
            thresholds.Add(powerThreshold);
            thresholds.Add(tempThreshold);
        }

        public string Analyze(CPU cpu)
        {
            string result = "";

                if (powerThreshold.isThresholded(cpu.PackagePower))
            {
                result += "Power threshold reached , ";
            }
            if (tempThreshold.isThresholded(cpu.PackageTemperature))
            {
                result += "Temperature threshold reached , ";
            }

            return result;
        }
    }
}
