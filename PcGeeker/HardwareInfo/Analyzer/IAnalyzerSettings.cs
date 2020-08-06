using HardwareInfo.HardwareBases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareInfo.Analyzer
{
    public interface IAnalyzerSettings<HardwareType,FieldType> where FieldType : Enum
    {
        string FieldStringThreshold(FieldType field, float thresholdValue);
    }
}
