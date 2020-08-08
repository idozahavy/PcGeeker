using HardwareInfo.Analyzer.CPUAnalyze;
using HardwareInfo.Analyzer.Threshold;
using HardwareInfo.HardwareClass;

namespace HardwareInfo.Analyzer
{
    public class PCAnalyzerSettings : IAnalyzerSettings<PC, PC.PCField>
    {
        public CPUAnalyzerSettings CPU;

        internal PCAnalyzerSettings()
        {
        }

        public string FieldStringThreshold(BasePC<IHardwareable>.PCField field, float thresholdValue)
        {
            return FieldThreshold.FieldStringThreshold(field, thresholdValue);
        }
    }
}