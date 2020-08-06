namespace HardwareInfo.Analyzer
{
    public interface IAnalyzer<AnalysisType> where AnalysisType : IAnalysis
    {

        AnalysisType Analyze();
    }
}