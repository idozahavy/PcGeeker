using HardwareInfo.Analyzer.CPUAnalyze;

namespace HardwareInfo.Analyzer
{
    public class PCAnalyzer
    {
        public CPUAnalyzer CPU { get; private set; }

        public PCAnalyzerSettings Settings { get; private set; }

        public PCAnalyzer(PC pc, string savePath, PCAnalyzerSettings settings)
        {
            if(settings.CPU)
            {
                CPU = new CPUAnalyzer(pc.CPU, settings.CPUSettings);
            }
        }
    }
}