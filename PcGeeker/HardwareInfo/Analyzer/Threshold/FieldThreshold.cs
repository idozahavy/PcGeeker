using System;

namespace HardwareInfo.Analyzer.Threshold
{
    public class FieldThreshold
    {
        public static string FieldStringThreshold(Enum field, float thresholdValue)
        {
            return field.ToString() + ":" + thresholdValue.ToString();
        }

        public Enum Field { get; private set; }
        public float ThresholdValue { get; private set; }

        public FieldThreshold(Enum attribute, float thresholdValue)
        {
            Field = attribute;
            ThresholdValue = thresholdValue;
        }
    }
}