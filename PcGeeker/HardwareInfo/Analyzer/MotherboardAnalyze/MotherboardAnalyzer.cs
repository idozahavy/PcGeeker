using HardwareInfo.HardwareBases;
using OpenHardwareMonitor.Hardware;
using System.Collections.Generic;
using System.Windows.Forms.VisualStyles;

namespace HardwareInfo.Analyzer.MotherboardAnalyze
{
    public class MotherboardAnalyzer : BaseMotherboard<SensoredThresholdProperty>, IAnalyzer<MotherboardAnalysis>
    {
        private MotherboardAnalyzerSettings settings;

        public MotherboardAnalyzer(Motherboard motherboard, MotherboardAnalyzerSettings settings)
        {
            this.settings = settings;

            CpuFanSpeed = new SensoredThresholdProperty(motherboard.CpuFanSpeed, settings.CpuFanSpeed);

            FanControls = new List<SensoredThresholdProperty>();
            foreach(ISensor sensor in motherboard.FanControls)
            {
                FanControls.Add(new SensoredThresholdProperty(sensor, settings.FanControls[0]));
            }

            FanSpeeds = new List<SensoredThresholdProperty>();
            foreach(ISensor sensor in motherboard.FanSpeeds)
            {
                FanSpeeds.Add(new SensoredThresholdProperty(sensor, settings.FanSpeeds[0]));
            }

            Temperatures = new List<SensoredThresholdProperty>();
            foreach(ISensor sensor in motherboard.Temperatures)
            {
                Temperatures.Add(new SensoredThresholdProperty(sensor, settings.Temperatures[0]));
            }

            VBat = new SensoredThresholdProperty(motherboard.VBat, settings.VBat);

            Voltage3p3 = new SensoredThresholdProperty(motherboard.Voltage3p3, settings.Voltage3p3);

            Voltages = new List<SensoredThresholdProperty>();
            foreach(ISensor sensor in motherboard.Voltages)
            {
                Voltages.Add(new SensoredThresholdProperty(sensor, settings.Voltages[0]));
            }
        }

        public MotherboardAnalysis Analyze()
        {
            List<bool> fanControlsThresholded = new List<bool>();
            foreach(SensoredThresholdProperty sensored in FanControls)
            {
                fanControlsThresholded.Add(sensored.IsSensorThresholded());
            }

            List<bool> fanSpeedsThresholded = new List<bool>();
            foreach(SensoredThresholdProperty sensored in FanSpeeds)
            {
                fanControlsThresholded.Add(sensored.IsSensorThresholded());
            }

            List<bool> temperaturesThresholded = new List<bool>();
            foreach(SensoredThresholdProperty sensored in Temperatures)
            {
                fanControlsThresholded.Add(sensored.IsSensorThresholded());
            }

            List<bool> voltagesThresholded = new List<bool>();
            foreach(SensoredThresholdProperty sensored in Voltages)
            {
                fanControlsThresholded.Add(sensored.IsSensorThresholded());
            }

            return new MotherboardAnalysis()
            {
                CpuFanSpeed = CpuFanSpeed.IsSensorThresholded(),
                FanControls = fanControlsThresholded,
                FanSpeeds = fanSpeedsThresholded,
                Temperatures = temperaturesThresholded,
                VBat = VBat.IsSensorThresholded(),
                Voltage3p3 = Voltage3p3.IsSensorThresholded(),
                Voltages = voltagesThresholded,
            };
        }
    }
}