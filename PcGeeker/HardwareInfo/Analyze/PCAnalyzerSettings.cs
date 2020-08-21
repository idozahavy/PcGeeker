using HardwareInfo.Analyze.CPUAnalyze;
using HardwareInfo.Analyze.DriveAnalyze;
using HardwareInfo.Analyze.GPUAnalyze;
using HardwareInfo.Analyze.MotherboardAnalyze;
using HardwareInfo.Analyze.RAMAnalyze;
using HardwareInfo.Analyze.Threshold;
using HardwareInfo.HardwareClass;
using System.Collections.Generic;

namespace HardwareInfo.Analyze
{
    public class PCAnalyzerSettings : IAnalyzerSettings<PC, PC.PCField>
    {
        public CPUAnalyzerSettings CPU;
        public List<GPUAnalyzerSettings> GPU;
        public List<RAMAnalyzerSettings> RAM;
        public List<DriveAnalyzerSettings> Drive;
        public MotherboardAnalyzerSettings Motherboard;

        internal PCAnalyzerSettings()
        {
        }

        public PCAnalyzerSettings(CPUAnalyzerSettings cPU, List<GPUAnalyzerSettings> gPU,
            List<RAMAnalyzerSettings> rAM, List<DriveAnalyzerSettings> drive,
            MotherboardAnalyzerSettings motherboard)
        {
            CPU = cPU;
            GPU = gPU;
            RAM = rAM;
            Drive = drive;
            Motherboard = motherboard;
        }

        public string FieldStringThreshold(BasePC<IHardwareable>.PCField field, float thresholdValue)
        {
            return FieldThreshold.FieldStringThreshold(field, thresholdValue);
        }
    }
}