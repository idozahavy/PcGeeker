using HardwareInfo.Analyzer.CPUAnalyze.CPUCoreAnalyze;
using HardwareInfo.HardwareBases;
using System.Collections.Generic;

namespace HardwareInfo.Analyzer.CPUAnalyze
{
    public class CPUAnalyzer : BaseCPU<SensoredThresholdProperty>, IAnalyzer<CPUAnalysis>
    {
        private CPUAnalyzerSettings settings;

        public List<CPUCoreAnalyzer> CoreAnalyzers { get; private set; }

        public CPUAnalyzer(CPU cpu, CPUAnalyzerSettings settings)
        {
            this.settings = settings;
            CoresPower = new SensoredThresholdProperty(cpu.CoresPower, settings.CoresPower);
            DRAMPower = new SensoredThresholdProperty(cpu.DRAMPower, settings.DRAMPower);
            GraphicsPower = new SensoredThresholdProperty(cpu.GraphicsPower, settings.GraphicsPower);
            PackagePower = new SensoredThresholdProperty(cpu.PackagePower, settings.PackagePower);
            BusClock = new SensoredThresholdProperty(cpu.BusClock, settings.BusClock);
            CoreAnalyzers = new List<CPUCoreAnalyzer>();
            if(settings.CoreAnalyzerSettings != null)
            {
                foreach(Core core in cpu.Cores.Values)
                {
                    CoreAnalyzers.Add(new CPUCoreAnalyzer(core, settings.CoreAnalyzerSettings));
                }
            }
            PackageTemperature = new SensoredThresholdProperty(cpu.PackageTemperature, settings.PackageTemperature);
            TotalLoad = new SensoredThresholdProperty(cpu.TotalLoad, settings.TotalLoad);
        }

        public CPUAnalysis Analyze()
        {
            return new CPUAnalysis()
            {
                CoresPower = CoresPower.IsSensorThresholded(),
                DRAMPower = DRAMPower.IsSensorThresholded(),
                GraphicsPower = GraphicsPower.IsSensorThresholded(),
                PackagePower = PackagePower.IsSensorThresholded(),
                BusClock = BusClock.IsSensorThresholded(),
                Cores = GetCoresAnalysis(),
                PackageTemperature = PackageTemperature.IsSensorThresholded(),
                TotalLoad = TotalLoad.IsSensorThresholded()
            };
        }
        private List<CPUCoreAnalysis> GetCoresAnalysis()
        {
            List<CPUCoreAnalysis> ls = new List<CPUCoreAnalysis>();
            foreach (CPUCoreAnalyzer analyzer in CoreAnalyzers)
            {
                ls.Add(analyzer.Analyze());
            }
            return ls;
        }
    }
}