using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareInfo.Analyzer
{
    public class CPUAnalyzerSettings
    {
        public SensorlessThresholdProperty CoresPowerThreshold { get; private set; }
        public SensorlessThresholdProperty DRAMPowerThreshold { get; private set; }
        public SensorlessThresholdProperty GraphicsPowerThreshold { get; private set; }
        public SensorlessThresholdProperty PackagePowerThreshold { get; private set; }
        public SensorlessThresholdProperty BusClockThreshold { get; private set; }
        public SensorlessThresholdProperty CoresThreshold { get; private set; }
        public SensorlessThresholdProperty PackageTemperatureThreshold { get; private set; }
        public SensorlessThresholdProperty TotalLoadThreshold { get; private set; }

        public CPUAnalyzerSettings(int coresPowerThresholdValue, int dRAMPowerThresholdValue, int graphicsPowerThresholdValue,
            int packagePowerThresholdValue, int busClockThresholdValue, int coresThresholdValue, int packageTemperatureThresholdValue, int totalLoadThresholdValue)
        {
            CoresPowerThreshold = new SensorlessThresholdProperty(coresPowerThresholdValue);
            DRAMPowerThreshold = new SensorlessThresholdProperty(dRAMPowerThresholdValue);
            GraphicsPowerThreshold = new SensorlessThresholdProperty(graphicsPowerThresholdValue);
            PackagePowerThreshold = new SensorlessThresholdProperty(packagePowerThresholdValue);
            BusClockThreshold = new SensorlessThresholdProperty(busClockThresholdValue);
            CoresThreshold = new SensorlessThresholdProperty(coresThresholdValue);
            PackageTemperatureThreshold = new SensorlessThresholdProperty(packageTemperatureThresholdValue);
            TotalLoadThreshold = new SensorlessThresholdProperty(totalLoadThresholdValue);
        }

        /// <summary>
        /// Gets the args and construct the Thresholds for every arg
        /// </summary>
        /// <param name="args">Format for every string is 'cpuAttributeName:thresholdValue'</param>
        public CPUAnalyzerSettings(params string[] args)
        {
            foreach (string arg in args)
            {
                string[] segments = arg.Split(':');
                if (segments.Length < 2)
                {
                    continue;
                }
                switch (segments[0].ToLower())
                {
                    case "corepower":
                    case "corespower": CoresPowerThreshold = new SensorlessThresholdProperty(float.Parse(segments[1])); break;
                    case "rampower":
                    case "drampower": DRAMPowerThreshold = new SensorlessThresholdProperty(float.Parse(segments[1])); break;
                    case "graphicpower":
                    case "graphicspower": GraphicsPowerThreshold = new SensorlessThresholdProperty(float.Parse(segments[1])); break;
                    case "power":
                    case "totalpower":
                    case "packagepower": PackagePowerThreshold = new SensorlessThresholdProperty(float.Parse(segments[1])); break;
                    case "bus":
                    case "busclock": BusClockThreshold = new SensorlessThresholdProperty(float.Parse(segments[1])); break;
                    case "core":
                    case "threads":
                    case "cores": CoresThreshold = new SensorlessThresholdProperty(float.Parse(segments[1])); break;
                    case "packagetemp":
                    case "temperature":
                    case "temp":
                    case "packagetemperature": PackageTemperatureThreshold = new SensorlessThresholdProperty(float.Parse(segments[1])); break;
                    case "load":
                    case "coresload":
                    case "totalload": TotalLoadThreshold = new SensorlessThresholdProperty(float.Parse(segments[1])); break;
                }
            }
        }

        public string AtrributeStringThreshold(CPU.CPUAttribute attr, float thresholdValue)
        {
            string result;
            switch (attr)
            {
                case CPU.CPUAttribute.BusClock: result = "busclock"; break;
                case CPU.CPUAttribute.CoresPower: result = "corespower"; break;
                case CPU.CPUAttribute.DRAMPower: result = "drampower"; break;
                case CPU.CPUAttribute.GraphicsPower: result = "graphicspower"; break;
                case CPU.CPUAttribute.PackagePower: result = "packagepower"; break;
                case CPU.CPUAttribute.PackageTemperature: result = "packagetemperature"; break;
                case CPU.CPUAttribute.TotalLoad: result = "totalload"; break;
                default:
                    throw new Exception("CPU AtrributeStringThreshold attribute not found");
            }
            return result + ":" + thresholdValue.ToString();
        }
    }
}
