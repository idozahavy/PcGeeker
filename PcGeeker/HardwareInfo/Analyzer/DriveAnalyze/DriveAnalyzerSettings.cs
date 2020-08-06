using HardwareInfo.HardwareBases;
using OpenHardwareMonitor.Hardware;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareInfo.Analyzer.DriveAnalyze
{
    public class DriveAnalyzerSettings : BaseDrive<SensorlessThresholdProperty>, IAnalyzerSettings<Drive, Drive.DriveField>
    {
        public DriveAnalyzerSettings(float? temperetureThreshold, float? usedPercentageThreshold)
        {
            Temperature = new SensorlessThresholdProperty(temperetureThreshold);
            UsedPercentage = new SensorlessThresholdProperty(usedPercentageThreshold);
        }

        /// <summary>
        /// Gets the args and construct the Thresholds for every arg
        /// </summary>
        /// <param name="args">Format for every string is 'cpuFieldName:thresholdValue'</param>
        public DriveAnalyzerSettings(params string[] args)
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
                    case "temp":
                    case "temperature":
                        Temperature = new SensorlessThresholdProperty(float.Parse(segments[1]));
                        break;

                    case "used":
                    case "usedpercentage":
                        UsedPercentage = new SensorlessThresholdProperty(float.Parse(segments[1]));
                        break;
                }
            }
        }

        public DriveAnalyzerSettings(IEnumerable<FieldThreshold> args): this(args.ToArray())
        {
        }
        public DriveAnalyzerSettings(params FieldThreshold[] args)
        {
            foreach(FieldThreshold arg in args)
            {
                switch(arg.Field)
                {
                    case Drive.DriveField.Temperature:
                        Temperature = new SensorlessThresholdProperty(arg.ThresholdValue);
                        break;

                    case Drive.DriveField.UsedPercentage:
                        UsedPercentage = new SensorlessThresholdProperty(arg.ThresholdValue);
                        break;
                }
            }
        }

        public string FieldStringThreshold(BaseDrive<ISensor>.DriveField field, float thresholdValue)
        {
            return FieldThreshold.FieldStringThreshold(field, thresholdValue);
        }
    }
}
