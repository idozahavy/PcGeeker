using HardwareInfo.Analyzer.CPUAnalyze;
using HardwareInfo.Analyzer.GPUAnalyze;
using HardwareInfo.Analyzer.MotherboardAnalyze;
using HardwareInfo.HardwareClass;
using System.Collections.Generic;

namespace HardwareInfo.Analyzer
{
    public class PCAnalysis : BasePC<IAnalysis>, IAnalysis
    {
        internal PCAnalysis()
        {
        }

        public PCAnalysis(CPUAnalysis cpuAnalysis, GPUAnalysis gpuAnalysis,
            List<IAnalysis> ramAnalysis, List<IAnalysis> driveAnalysis,
            MotherboardAnalysis motherboardAnalysis)
        {
            CPU = cpuAnalysis;
            GPU = gpuAnalysis;
            RAM = ramAnalysis;
            Drive = driveAnalysis;
            Motherboard = motherboardAnalysis;
        }
    }
}