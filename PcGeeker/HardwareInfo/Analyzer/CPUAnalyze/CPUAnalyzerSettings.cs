using HardwareInfo.Analyzer.CPUAnalyze.CPUCoreAnalyze;
using HardwareInfo.HardwareBases;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HardwareInfo.Analyzer.CPUAnalyze
{
    public class CPUAnalyzerSettings : BaseCPU<SensorlessThresholdProperty>, IAnalyzerSettings<CPU, CPU.CPUField>
    {
        public CPUCoreAnalyzerSettings CoreAnalyzerSettings { get; private set; }

        public CPUAnalyzerSettings(float? coresPowerThresholdValue, float? dRAMPowerThresholdValue, float? graphicsPowerThresholdValue,
            float? packagePowerThresholdValue, float? busClockThresholdValue, CPUCoreAnalyzerSettings coresAnalyzerSettings,
            float? packageTemperatureThresholdValue, float? totalLoadThresholdValue)
        {
            CoresPower = new SensorlessThresholdProperty(coresPowerThresholdValue);
            DRAMPower = new SensorlessThresholdProperty(dRAMPowerThresholdValue);
            GraphicsPower = new SensorlessThresholdProperty(graphicsPowerThresholdValue);
            PackagePower = new SensorlessThresholdProperty(packagePowerThresholdValue);
            BusClock = new SensorlessThresholdProperty(busClockThresholdValue);
            CoreAnalyzerSettings = coresAnalyzerSettings;
            PackageTemperature = new SensorlessThresholdProperty(packageTemperatureThresholdValue);
            TotalLoad = new SensorlessThresholdProperty(totalLoadThresholdValue);
        }

        public CPUAnalyzerSettings(CPUCoreAnalyzerSettings coreAnalyzerSettings)
        {
            CoreAnalyzerSettings = coreAnalyzerSettings;
        }

        /// <summary>
        /// Gets the args and construct the Thresholds for every arg
        /// </summary>
        /// <param name="args">Format for every string is 'cpuFieldName:thresholdValue'</param>
        public CPUAnalyzerSettings(CPUCoreAnalyzerSettings coreAnalyzerSettings, params string[] args) : this (coreAnalyzerSettings)
        {
            foreach(string arg in args)
            {
                string[] segments = arg.Split(':');
                if(segments.Length < 2)
                {
                    continue;
                }
                switch(segments[0].ToLower())
                {
                    case "corepower":
                    case "corespower":
                        CoresPower = new SensorlessThresholdProperty(float.Parse(segments[1]));
                        break;

                    case "rampower":
                    case "drampower":
                        DRAMPower = new SensorlessThresholdProperty(float.Parse(segments[1]));
                        break;

                    case "graphicpower":
                    case "graphicspower":
                        GraphicsPower = new SensorlessThresholdProperty(float.Parse(segments[1]));
                        break;

                    case "power":
                    case "totalpower":
                    case "packagepower":
                        PackagePower = new SensorlessThresholdProperty(float.Parse(segments[1]));
                        break;

                    case "bus":
                    case "busclock":
                        BusClock = new SensorlessThresholdProperty(float.Parse(segments[1]));
                        break;

                    case "packagetemp":
                    case "temperature":
                    case "temp":
                    case "packagetemperature":
                        PackageTemperature = new SensorlessThresholdProperty(float.Parse(segments[1]));
                        break;

                    case "load":
                    case "coresload":
                    case "totalload":
                        TotalLoad = new SensorlessThresholdProperty(float.Parse(segments[1]));
                        break;
                }
            }
        }

        public CPUAnalyzerSettings(CPUCoreAnalyzerSettings coreAnalyzerSettings, IEnumerable<FieldThreshold> args): this(coreAnalyzerSettings, args.ToArray())
        {

        }

        public CPUAnalyzerSettings(CPUCoreAnalyzerSettings coreAnalyzerSettings, params FieldThreshold[] args) : this(coreAnalyzerSettings)
        {
            foreach(FieldThreshold arg in args)
            {
                switch(arg.Field)
                {
                    case CPU.CPUField.BusClock:
                        BusClock = new SensorlessThresholdProperty(arg.ThresholdValue);
                        break;
                    case CPU.CPUField.CoresPower:
                        CoresPower = new SensorlessThresholdProperty(arg.ThresholdValue);
                        break;
                    case CPU.CPUField.DRAMPower:
                        DRAMPower = new SensorlessThresholdProperty(arg.ThresholdValue);
                        break;
                    case CPU.CPUField.GraphicsPower:
                        GraphicsPower = new SensorlessThresholdProperty(arg.ThresholdValue);
                        break;
                    case CPU.CPUField.PackagePower:
                        PackagePower = new SensorlessThresholdProperty(arg.ThresholdValue);
                        break;
                    case CPU.CPUField.PackageTemperature:
                        PackageTemperature = new SensorlessThresholdProperty(arg.ThresholdValue);
                        break;
                    case CPU.CPUField.TotalLoad:
                        TotalLoad = new SensorlessThresholdProperty(arg.ThresholdValue);
                        break;
                }
            }
        }
        public string FieldStringThreshold(CPU.CPUField field, float thresholdValue)
        {
            return FieldThreshold.FieldStringThreshold(field, thresholdValue);
        }
    }
}