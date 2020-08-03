namespace HardwareInfo.Analyzer
{
    public interface IAnalyzer<AnalysisType> where AnalysisType : Analysis
    {
        AnalysisType Analyze();
    }
}