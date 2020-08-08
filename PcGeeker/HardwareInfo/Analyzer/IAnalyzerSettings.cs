using System;

namespace HardwareInfo.Analyzer
{
    public interface IAnalyzerSettings<HardwareType, FieldType> where FieldType : Enum
    {
        string FieldStringThreshold(FieldType field, float thresholdValue);
    }
}