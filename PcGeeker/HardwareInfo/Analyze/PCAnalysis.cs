using HardwareInfo.Analyze.CPUAnalyze;
using HardwareInfo.Analyze.DriveAnalyze;
using HardwareInfo.Analyze.GPUAnalyze;
using HardwareInfo.Analyze.MotherboardAnalyze;
using HardwareInfo.Analyze.RAMAnalyze;
using HardwareInfo.HardwareClass;
using System.Collections.Generic;

namespace HardwareInfo.Analyze
{
    public class PCAnalysis : IAnalysis 
    {
        public CPUAnalysis CPU;
        public List<GPUAnalysis> GPU;
        public List<RAMAnalysis> RAM;
        public List<DriveAnalysis> Drive;
        public MotherboardAnalysis Motherboard;

        internal PCAnalysis()
        {
        }

        public PCAnalysis(CPUAnalysis cpuAnalysis, List<GPUAnalysis> gpuAnalysis,
            List<RAMAnalysis> ramAnalysis, List<DriveAnalysis> driveAnalysis,
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