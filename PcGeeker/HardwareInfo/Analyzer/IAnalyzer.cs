using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareInfo.Analyzer
{
    public interface IAnalyzer<AnalysisType> where AnalysisType : Analysis
    {
        AnalysisType Analyze();
    }
}
