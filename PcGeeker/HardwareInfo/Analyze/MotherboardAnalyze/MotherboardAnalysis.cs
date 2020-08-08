using HardwareInfo.HardwareClass;
using System.Collections.Generic;

namespace HardwareInfo.Analyze.MotherboardAnalyze
{
    public class MotherboardAnalysis : BaseMotherboard<bool>, IAnalysis
    {
        internal MotherboardAnalysis()
        {
        }

        public MotherboardAnalysis(bool cpuFanSpeedThresholded, List<bool> fanControlsThresholded, List<bool> fanSpeedsThresholded,
            List<bool> temperaturesThresholded, bool vBatThresholded, bool voltage3p3Thresholded, List<bool> voltagesThresholded)
        {
            CpuFanSpeed = cpuFanSpeedThresholded;
            FanControls = fanControlsThresholded;
            FanSpeeds = fanSpeedsThresholded;
            Temperatures = temperaturesThresholded;
            VBat = vBatThresholded;
            Voltage3p3 = voltage3p3Thresholded;
            Voltages = voltagesThresholded;
        }
    }
}