﻿using HardwareInfo.HardwareBases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareInfo.Analyzer.CPUAnalyze.CPUCoreAnalyze
{
    public class CPUCoreAnalyzer : BaseCPUCore<SensoredThresholdProperty>
    {
        private CPUCoreAnalyzerSettings settings;

        public CPUCoreAnalyzer(Core core, CPUCoreAnalyzerSettings settings)
        {
            this.settings = settings;
            Temperature = new SensoredThresholdProperty(core.Temperature, settings.Temperature);
            Load = new SensoredThresholdProperty(core.Load, settings.Load);
            Clock = new SensoredThresholdProperty(core.Clock, settings.Clock);
        }

        public CPUCoreAnalysis Analyze()
        {
            return new CPUCoreAnalysis()
            {
                Temperature = Temperature.IsSensorThresholded(),
                Load = Load.IsSensorThresholded(),
                Clock = Clock.IsSensorThresholded(),
            };
        }
    }
}
