using HardwareInfo.Analyzer.CPUAnalyze;
using HardwareInfo.HardwareBases;

namespace HardwareInfo.Analyzer
{
    public class PCAnalyzer : IAnalyzer<PCAnalysis>
    {
        public PCAnalyzerSettings Settings { get; private set; }

        public CPUAnalyzer CPU;

        public PCAnalyzer(PC pc, string savePath, PCAnalyzerSettings settings)
        {
            CPU = new CPUAnalyzer(pc.CPU, (CPUAnalyzerSettings)settings.CPU);
        }

        public PCAnalysis Analyze()
        {
            throw new System.NotImplementedException();
        }
    }
}