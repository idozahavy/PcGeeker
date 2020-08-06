using HardwareInfo.Analyzer.CPUAnalyze.CPUCoreAnalyze;
using HardwareInfo.HardwareBases;
using System.Collections.Generic;
using System.Reflection;

namespace HardwareInfo.Analyzer.CPUAnalyze
{
    public class CPUAnalysis : BaseCPU<bool>, IAnalysis
    {
        public List<CPUCoreAnalysis> Cores { get; internal set; }

        internal CPUAnalysis()
        {
        }

        public CPUAnalysis(bool coresPowerThresholded, bool dRAMPowerThresholded, bool graphicsPowerThresholded,
            bool packagePowerThresholded, bool busClockThresholded, List<CPUCoreAnalysis> coresThresholded,
            bool packageTemperatureThresholded, bool totalLoadThresholded)
        {
            CoresPower = coresPowerThresholded;
            DRAMPower = dRAMPowerThresholded;
            GraphicsPower = graphicsPowerThresholded;
            PackagePower = packagePowerThresholded;
            BusClock = busClockThresholded;
            Cores = coresThresholded;
            PackageTemperature = packageTemperatureThresholded;
            TotalLoad = totalLoadThresholded;
        }
    }
}