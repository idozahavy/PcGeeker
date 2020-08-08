using HardwareInfo.Analyzer.Threshold;
using HardwareInfo.HardwareBases;
using OpenHardwareMonitor.Hardware;
using System.Collections.Generic;

namespace HardwareInfo.Analyzer.MotherboardAnalyze
{
    public class MotherboardAnalyzerSettings : BaseMotherboard<SensorlessThresholdProperty>, IAnalyzerSettings<Motherboard, Motherboard.MotherboardField>
    {
        public MotherboardAnalyzerSettings(float? cpuFanSpeedThresholded, float? fanControlsThresholded, float? fanSpeedsThresholded,
            float? temperaturesThresholded, float? vBatThresholded, float? voltage3p3Thresholded, float? voltagesThresholded)
        {
            CpuFanSpeed = new SensorlessThresholdProperty(cpuFanSpeedThresholded);

            FanControls = new List<SensorlessThresholdProperty>
            {
                new SensorlessThresholdProperty(fanControlsThresholded)
            };

            FanSpeeds = new List<SensorlessThresholdProperty>
            {
                new SensorlessThresholdProperty(fanSpeedsThresholded)
            };

            Temperatures = new List<SensorlessThresholdProperty>
            {
                new SensorlessThresholdProperty(temperaturesThresholded)
            };

            VBat = new SensorlessThresholdProperty(vBatThresholded);

            Voltage3p3 = new SensorlessThresholdProperty(voltage3p3Thresholded);

            Voltages = new List<SensorlessThresholdProperty>
            {
                new SensorlessThresholdProperty(voltagesThresholded)
            };
        }

        /// <summary>
        /// Gets the args and construct the Thresholds for every arg
        /// </summary>
        /// <param name="args">Format for every string is 'gpuFieldName:thresholdValue'</param>
        public MotherboardAnalyzerSettings(params string[] args)
        {
            foreach(string arg in args)
            {
                string[] segments = arg.Split(':');
                if(segments.Length < 2)
                {
                    continue;
                }
                switch(segments[0].ToLower())
                {
                    case "cpufan":
                    case "cpufanspeed":
                        CpuFanSpeed = new SensorlessThresholdProperty(float.Parse(segments[1]));
                        break;
                    case "fancontrols":
                        FanControls = new List<SensorlessThresholdProperty>
                        {
                            new SensorlessThresholdProperty(float.Parse(segments[1]))
                        };
                        break;

                    case "fansspeed":
                    case "fansspeeds":
                    case "fanspeed":
                    case "fanspeeds":
                        FanSpeeds = new List<SensorlessThresholdProperty>
                        {
                            new SensorlessThresholdProperty(float.Parse(segments[1]))
                        };
                        break;

                    case "temps":
                    case "temperatures":
                        Temperatures = new List<SensorlessThresholdProperty>
                        {
                            new SensorlessThresholdProperty(float.Parse(segments[1]))
                        };
                        break;

                    case "bat":
                    case "battery":
                    case "vbat":
                        VBat = new SensorlessThresholdProperty(float.Parse(segments[1]));
                        break;

                    case "v3p3":
                    case "voltage3p3":
                        Voltage3p3 = new SensorlessThresholdProperty(float.Parse(segments[1]));
                        break;

                    case "voltage":
                    case "voltages":
                    case "volts":
                        Voltages = new List<SensorlessThresholdProperty>
                        {
                            new SensorlessThresholdProperty(float.Parse(segments[1]))
                        };
                        break;
                }
            }
        }

        public MotherboardAnalyzerSettings(params FieldThreshold[] args)
        {
            foreach(FieldThreshold arg in args)
            {
                this.GetType().GetProperty(arg.Field.ToString()).SetValue(this, arg.ThresholdValue);
                switch(arg.Field)
                {
                    case MotherboardField.CpuFanSpeed:
                        CpuFanSpeed = new SensorlessThresholdProperty(arg.ThresholdValue);
                        break;

                    case MotherboardField.FanControls:
                        FanControls = new List<SensorlessThresholdProperty>
                        {
                            new SensorlessThresholdProperty(arg.ThresholdValue)
                        };
                        break;

                    case MotherboardField.FanSpeeds:
                        FanSpeeds = new List<SensorlessThresholdProperty>
                        {
                            new SensorlessThresholdProperty(arg.ThresholdValue)
                        };
                        break;

                    case MotherboardField.Temperatures:
                        Temperatures = new List<SensorlessThresholdProperty>
                        {
                            new SensorlessThresholdProperty(arg.ThresholdValue)
                        };
                        break;

                    case MotherboardField.VBat:
                        VBat = new SensorlessThresholdProperty(arg.ThresholdValue);
                        break;

                    case MotherboardField.Voltage3p3:
                        Voltage3p3 = new SensorlessThresholdProperty(arg.ThresholdValue);
                        break;

                    case MotherboardField.Voltages:
                        Voltages = new List<SensorlessThresholdProperty>
                        {
                            new SensorlessThresholdProperty(arg.ThresholdValue)
                        };
                        break;
                }
            }
        }

        public string FieldStringThreshold(Motherboard.MotherboardField field, float thresholdValue)
        {
            return FieldThreshold.FieldStringThreshold(field, thresholdValue);
        }
    }
}