namespace HardwareInfo.Analyze
{
    public interface IAnalyzer<AnalysisType> where AnalysisType : IAnalysis
    {
        AnalysisType Analyze();
    }
}