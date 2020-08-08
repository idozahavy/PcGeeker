using HardwareInfo.Analyzer.Threshold;
using HardwareInfo.HardwareClass;
using System.Collections.Generic;
using System.Linq;

namespace HardwareInfo.Analyzer.CPUAnalyze.CPUCoreAnalyze
{
    public class CPUCoreAnalyzerSettings : BaseCPUCore<SensorlessThresholdProperty>, IAnalyzerSettings<Core, Core.CPUCoreField>
    {
        public CPUCoreAnalyzerSettings(float? temperetureThreshold, float? loadThreshold, float? clockThreshold)
        {
            Temperature = new SensorlessThresholdProperty(temperetureThreshold);
            Load = new SensorlessThresholdProperty(loadThreshold);
            Clock = new SensorlessThresholdProperty(clockThreshold);
        }

        /// <summary>
        /// Gets the args and construct the Thresholds for every arg
        /// </summary>
        /// <param name="args">Format for every string is 'cpuFieldName:thresholdValue'</param>
        public CPUCoreAnalyzerSettings(params string[] args)
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

                    case "load":
                        Load = new SensorlessThresholdProperty(float.Parse(segments[1]));
                        break;

                    case "freq":
                    case "frequency":
                    case "clock":
                        Clock = new SensorlessThresholdProperty(float.Parse(segments[1]));
                        break;
                }
            }
        }

        public CPUCoreAnalyzerSettings(IEnumerable<FieldThreshold> args) : this(args.ToArray())
        {
        }

        public CPUCoreAnalyzerSettings(params FieldThreshold[] args)
        {
            foreach(FieldThreshold arg in args)
            {
                switch(arg.Field)
                {
                    case Core.CPUCoreField.Temperature:
                        Temperature = new SensorlessThresholdProperty(arg.ThresholdValue);
                        break;

                    case Core.CPUCoreField.Load:
                        Load = new SensorlessThresholdProperty(arg.ThresholdValue);
                        break;

                    case Core.CPUCoreField.Clock:
                        Clock = new SensorlessThresholdProperty(arg.ThresholdValue);
                        break;
                }
            }
        }

        public string FieldStringThreshold(Core.CPUCoreField field, float thresholdValue)
        {
            return FieldThreshold.FieldStringThreshold(field, thresholdValue);
        }
    }
}