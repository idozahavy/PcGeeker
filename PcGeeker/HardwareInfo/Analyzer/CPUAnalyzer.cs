using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareInfo.Analyzer
{
    public class CPUAnalyzer
    {
        private CPUAnalyzerSettings settings;
        public SensoredThresholdProperty CoresPowerThreshold
        {
            get;
            private set;
        }
        public SensoredThresholdProperty DRAMPowerThreshold
        {
            get;
            private set;
        }
        public SensoredThresholdProperty GraphicsPowerThreshold
        {
            get;
            private set;
        }
        public SensoredThresholdProperty PackagePowerThreshold
        {
            get;
            private set;
        }
        public SensoredThresholdProperty BusClockThreshold
        {
            get;
            private set;
        }
        public SensoredThresholdProperty CoresThreshold
        {
            get;
            private set;
        }
        public SensoredThresholdProperty PackageTemperatureThreshold
        {
            get;
            private set;
        }
        public SensoredThresholdProperty TotalLoadThreshold
        {
            get;
            private set;
        }

        public CPUAnalyzer(CPU cpu, CPUAnalyzerSettings settings)
        {
            this.settings = settings;
            CoresPowerThreshold = new SensoredThresholdProperty(cpu.CoresPower, settings.CoresPowerThreshold);
            DRAMPowerThreshold = new SensoredThresholdProperty(cpu.DRAMPower, settings.DRAMPowerThreshold);
            GraphicsPowerThreshold = new SensoredThresholdProperty(cpu.GraphicsPower, settings.GraphicsPowerThreshold);
            PackagePowerThreshold = new SensoredThresholdProperty(cpu.PackagePower, settings.PackagePowerThreshold);
            BusClockThreshold = new SensoredThresholdProperty(cpu.BusClock, settings.BusClockThreshold);
            //CoresThreshold = new SensoredThresholdProperty(cpu.Cores, settings.CoresThreshold);
            PackageTemperatureThreshold = new SensoredThresholdProperty(cpu.PackageTemperature, settings.PackageTemperatureThreshold);
            TotalLoadThreshold = new SensoredThresholdProperty(cpu.TotalLoad, settings.TotalLoadThreshold);
        }

        public string Analyze()
        {
            string result = "";

            if (CoresPowerThreshold.IsSensorThresholded())
            {
                result += "Cores power threshold reached , ";
            }
            if (PackageTemperatureThreshold.IsSensorThresholded())
            {
                result += "Package temperature threshold reached , ";
            }

            return result;
        }
    }
}
