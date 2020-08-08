using HardwareInfo.Analyze.Threshold;
using HardwareInfo.HardwareClass;

namespace HardwareInfo.Analyze.RAMAnalyze
{
    public class RAMAnalyzerSettings : BaseRAM<SensorlessThresholdProperty>, IAnalyzerSettings<RAM, RAM.RAMField>
    {
        public RAMAnalyzerSettings(float? availableThresholdValue, float? totalThresholdValue, float? usedThresholdValue,
            float? usedPercentageThresholdValue)
        {
            Available = new SensorlessThresholdProperty(availableThresholdValue);
            Total = new SensorlessThresholdProperty(totalThresholdValue);
            Used = new SensorlessThresholdProperty(usedThresholdValue);
            UsedPercentage = new SensorlessThresholdProperty(usedPercentageThresholdValue);
        }

        /// <summary>
        /// Gets the args and construct the Thresholds for every arg
        /// </summary>
        /// <param name="args">Format for every string is 'gpuFieldName:thresholdValue'</param>
        public RAMAnalyzerSettings(params string[] args)
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
                    case "free":
                    case "available":
                        Available = new SensorlessThresholdProperty(float.Parse(segments[1]));
                        break;

                    case "total":
                        Total = new SensorlessThresholdProperty(float.Parse(segments[1]));
                        break;

                    case "used":
                        Used = new SensorlessThresholdProperty(float.Parse(segments[1]));
                        break;

                    case "usedpercentage":
                        UsedPercentage = new SensorlessThresholdProperty(float.Parse(segments[1]));
                        break;
                }
            }
        }

        public RAMAnalyzerSettings(params FieldThreshold[] args)
        {
            foreach(FieldThreshold arg in args)
            {
                this.GetType().GetProperty(arg.Field.ToString()).SetValue(this, arg.ThresholdValue);
                switch(arg.Field)
                {
                    case RAMField.Available:
                        Available = new SensorlessThresholdProperty(arg.ThresholdValue);
                        break;

                    case RAMField.Total:
                        Total = new SensorlessThresholdProperty(arg.ThresholdValue);
                        break;

                    case RAMField.Used:
                        Used = new SensorlessThresholdProperty(arg.ThresholdValue);
                        break;

                    case RAMField.UsedPercentage:
                        UsedPercentage = new SensorlessThresholdProperty(arg.ThresholdValue);
                        break;
                }
            }
        }

        public string FieldStringThreshold(RAM.RAMField field, float thresholdValue)
        {
            return FieldThreshold.FieldStringThreshold(field, thresholdValue);
        }
    }
}