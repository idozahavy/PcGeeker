using HardwareInfo.Analyze.CPUAnalyze;
using HardwareInfo.Analyze.Threshold;
using HardwareInfo.HardwareClass;

namespace HardwareInfo.Analyze
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