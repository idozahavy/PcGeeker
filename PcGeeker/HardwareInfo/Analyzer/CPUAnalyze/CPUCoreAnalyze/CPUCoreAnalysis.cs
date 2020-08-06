﻿
using HardwareInfo.HardwareBases;

namespace HardwareInfo.Analyzer.CPUAnalyze.CPUCoreAnalyze
{
    public class CPUCoreAnalysis : BaseCPUCore<bool>
    {
        internal CPUCoreAnalysis()
        {
        }
        
        public CPUCoreAnalysis(bool temperatureThresholded, bool loadThresholded, bool clockThresholded)
        {
            Temperature = temperatureThresholded;
            Load = loadThresholded;
            Clock = clockThresholded;
        }
    }
}
