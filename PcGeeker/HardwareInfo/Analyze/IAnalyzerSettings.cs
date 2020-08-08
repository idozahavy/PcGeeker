using System;

namespace HardwareInfo.Analyze
{
    public interface IAnalyzerSettings<HardwareType, FieldType> where FieldType : Enum
    {
        string FieldStringThreshold(FieldType field, float thresholdValue);
    }
}