using HardwareInfo.HardwareClass;

namespace HardwareInfo.Analyze.RAMAnalyze
{
    public class RAMAnalysis : BaseRAM<bool>, IAnalysis
    {
        internal RAMAnalysis()
        {
        }

        public RAMAnalysis(bool availableThresholded, bool totalThresholded, bool usedThresholded,
            bool usedPercentageThresholded)
        {
            Available = availableThresholded;
            Total = totalThresholded;
            Used = usedThresholded;
            UsedPercentage = usedPercentageThresholded;
        }
    }
}