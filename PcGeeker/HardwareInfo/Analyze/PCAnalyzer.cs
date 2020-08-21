using HardwareInfo.Analyze.CPUAnalyze;
using HardwareInfo.Analyze.DriveAnalyze;
using HardwareInfo.Analyze.GPUAnalyze;
using HardwareInfo.Analyze.MotherboardAnalyze;
using HardwareInfo.Analyze.RAMAnalyze;
using System.Collections.Generic;

namespace HardwareInfo.Analyze
{
    public class PCAnalyzer : IAnalyzer<PCAnalysis>
    {
        public PCAnalyzerSettings Settings { get; private set; }

        public CPUAnalyzer CPU;
        public List<GPUAnalyzer> GPU;
        public List<RAMAnalyzer> RAM;
        public List<DriveAnalyzer> Drive;
        public MotherboardAnalyzer Motherboard;

        public PCAnalyzer(PC pc, PCAnalyzerSettings settings)
        {
            if(pc.CPU != null && settings.CPU != null)
            {
                CPU = new CPUAnalyzer(pc.CPU, settings.CPU);
            }

            GPU = new List<GPUAnalyzer>();
            if(pc.GPU != null && settings.GPU != null)
            {
                for(int i = 0; i < pc.GPU.Count && i < settings.GPU.Count; i++)
                {
                    GPU.Add(new GPUAnalyzer(pc.GPU[i], settings.GPU[i]));
                }
            }

            RAM = new List<RAMAnalyzer>();
            if(pc.RAM != null && settings.RAM != null)
            {
                for(int i = 0; i < pc.RAM.Count && i < settings.RAM.Count; i++)
                {
                    RAM.Add(new RAMAnalyzer(pc.RAM[i], settings.RAM[i]));
                }
            }

            Drive = new List<DriveAnalyzer>();
            if(pc.Drive != null && settings.Drive != null)
            {
                for(int i = 0; i < pc.Drive.Count && i < settings.Drive.Count; i++)
                {
                    Drive.Add(new DriveAnalyzer(pc.Drive[i], settings.Drive[i]));
                }
            }

            if(pc.Motherboard != null && settings.Motherboard != null)
            {
                Motherboard = new MotherboardAnalyzer(pc.Motherboard, settings.Motherboard);
            }
        }

        public PCAnalysis Analyze()
        {

            PCAnalysis analysis = new PCAnalysis();

            if (CPU != null)
            {
                analysis.CPU = CPU.Analyze();
            }

            List<GPUAnalysis> gpuAnalysis = new List<GPUAnalysis>();
            foreach(GPUAnalyzer gpuAnalyzer in GPU)
            {
                gpuAnalysis.Add(gpuAnalyzer.Analyze());
            }
            analysis.GPU = gpuAnalysis;

            List<RAMAnalysis> ramAnalysis = new List<RAMAnalysis>();
            foreach(RAMAnalyzer ramAnalyzer in RAM)
            {
                ramAnalysis.Add(ramAnalyzer.Analyze());
            }
            analysis.RAM = ramAnalysis;

            List<DriveAnalysis> driveAnalysis = new List<DriveAnalysis>();
            foreach(DriveAnalyzer driveAnalyzer in Drive)
            {
                driveAnalysis.Add(driveAnalyzer.Analyze());
            }
            analysis.Drive = driveAnalysis;

            if(Motherboard != null)
            {
                analysis.Motherboard = Motherboard.Analyze();
            }

            return analysis;
        }
    }
}