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

        public CPUAnalyzer(CPU cpu)
        {
            powerThreshold = new SensorThresholdProperty(cpu.PackagePower, 20);
            tempThreshold = new SensorThresholdProperty(cpu.PackageTemperature, 56);

            thresholds = new List<SensorThresholdProperty>();
            thresholds.Add(powerThreshold);
            thresholds.Add(tempThreshold);
        }

        public string Analyze()
        {
            string result = "";

            if (powerThreshold.IsSensorThresholded())
            {
                result += "Power threshold reached , ";
            }
            if (tempThreshold.IsSensorThresholded())
            {
                result += "Temperature threshold reached , ";
            }

            return result;
        }
    }
}
