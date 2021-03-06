﻿using HardwareInfo.HardwareClass;
using HardwareInfo.Sensor;
using OpenHardwareMonitor.Hardware;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace HardwareInfo
{
    public class CPU : BaseCPU<ISensor>, IHardwareable
    {
        public IHardware Hardware { get; private set; }

        public Dictionary<int, Core> Cores { get; private set; }

        public CPU(IHardware cpu)
        {
            Hardware = cpu;
            Cores = new Dictionary<int, Core>();
            Initialize();
            foreach(PropertyInfo prop in this.GetType().GetProperties())
            {
                if(prop.PropertyType == typeof(ISensor))
                {
                    prop.SetValue(this, SensorTool.NAIfNull((ISensor)prop.GetValue(this)));
                }
            }
        }

        public void Initialize()
        {
            foreach(ISensor sensor in Hardware.Sensors)
            {
                if(sensor.Name.Contains("Core #"))
                {
                    string[] splat = sensor.Name.Split(new string[1] { "Core #" }, StringSplitOptions.RemoveEmptyEntries);
                    int coreIndex = int.Parse(splat[1]);
                    if(!Cores.ContainsKey(coreIndex))
                    {
                        Cores.Add(coreIndex, new Core(coreIndex));
                    }
                    Cores[coreIndex].Initialize(sensor);
                }
                else // not a cpu core
                {
                    switch(sensor.SensorType)
                    {
                        case SensorType.Power:
                        {
                            if(sensor.Name.Contains("Package"))
                            {
                                PackagePower = sensor;
                                break;
                            }
                            if(sensor.Name.Contains("Cores"))
                            {
                                CoresPower = sensor;
                                break;
                            }
                            if(sensor.Name.Contains("Graphics"))
                            {
                                GraphicsPower = sensor;
                                break;
                            }
                            if(sensor.Name.Contains("DRAM"))
                            {
                                DRAMPower = sensor;
                                break;
                            }
                            Jsoner.ObjectSaver.AddObject(sensor);
                            break;
                        }
                        case SensorType.Load:
                        {
                            if(sensor.Name.Contains("Total"))
                            {
                                TotalLoad = sensor;
                                break;
                            }
                            Jsoner.ObjectSaver.AddObject(sensor);
                            break;
                        }
                        case SensorType.Temperature:
                        {
                            if(sensor.Name.Contains("Package"))
                            {
                                PackageTemperature = sensor;
                                break;
                            }
                            Jsoner.ObjectSaver.AddObject(sensor);
                            break;
                        }
                        case SensorType.Clock:
                        {
                            if(sensor.Name.Contains("Bus"))
                            {
                                BusClock = sensor;
                                break;
                            }
                            Jsoner.ObjectSaver.AddObject(sensor);
                            break;
                        }
                        default:
                        {
                            Jsoner.ObjectSaver.AddObject(sensor);
                            break;
                        }
                    }
                }
            }
        }

        public void Update(IVisitor visitor)
        {
            Hardware.Accept(visitor);
        }

        public ISensor GetCoreSensor(int coreIndex, SensorType sensorType)
        {
            if(Cores.ContainsKey(coreIndex))
            {
                return Cores[coreIndex].GetSensor(sensorType);
            }
            return null;
        }
    }

    public class Core : BaseCPUCore<ISensor>
    {
        public int Number { get; private set; }

        public Core(int number)
        {
            Number = number;
        }

        internal void Initialize(IEnumerable<ISensor> sensors)
        {
            foreach(ISensor sensor in sensors)
            {
                Initialize(sensor);
            }
        }

        internal void Initialize(ISensor sensor)
        {
            if(sensor.Index != this.Number || sensor.Value == null)
            {
                return;
            }
            switch(sensor.SensorType)
            {
                case SensorType.Load:
                    Load = sensor;
                    break;

                case SensorType.Temperature:
                    Temperature = sensor;
                    break;

                case SensorType.Clock:
                    Clock = sensor;
                    break;
                //case SensorType.Power: break;
                default:
                    Jsoner.ObjectSaver.AddObject(sensor);
                    break;
            }
        }

        public ISensor GetSensor(SensorType sensorType)
        {
            switch(sensorType)
            {
                case SensorType.Clock:
                    return Clock;

                case SensorType.Temperature:
                    return Temperature;

                case SensorType.Load:
                    return Load;

                default:
                    return null;
            }
        }
    }
}