using HardwareInfo.Analyze.CPUAnalyze;
using HardwareInfo.Analyze.GPUAnalyze;
using HardwareInfo.Analyze.MotherboardAnalyze;
using HardwareInfo.HardwareClass;
using System.Collections.Generic;

namespace HardwareInfo.Analyze
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