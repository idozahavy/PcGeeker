using HardwareInfo.Analyzer.CPUAnalyze;
using HardwareInfo.Analyzer.DriveAnalyze;
using HardwareInfo.Analyzer.GPUAnalyze;
using HardwareInfo.Analyzer.MotherboardAnalyze;
using HardwareInfo.Analyzer.RAMAnalyze;
using HardwareInfo.HardwareBases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
