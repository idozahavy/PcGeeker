using HardwareInfo.HardwareBases;
using OpenHardwareMonitor.Hardware;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace HardwareInfo
{
    public class Motherboard : BaseMotherboard<ISensor>, IHardwareable
    {
        public IHardware Controller { get; private set; }

        public IHardware Hardware { get; private set; }

        public Motherboard(IHardware hardware)
        {
            Hardware = hardware;
            foreach(PropertyInfo prop in this.GetType().GetProperties())
            {
                if(prop.PropertyType == typeof(List<ISensor>))
                {
                    prop.SetValue(this, new List<ISensor>());
                }
            }
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
            Controller = Hardware;
            foreach(ISensor sensor in Hardware.Sensors)
            {
                this.Initialize(sensor);
                Console.WriteLine(sensor.Name);
            }
            foreach(IHardware subHardware in Hardware.SubHardware)
            {
                Controller = subHardware;
                foreach(ISensor sensor in subHardware.Sensors)
                {
                    this.Initialize(sensor);
                }
                if(Hardware.SubHardware.Length > 1)
                {
                    Jsoner.ObjectSaver.AddObject(subHardware);
                }
            }
        }

        private void Initialize(ISensor sensor)
        {
            switch(sensor.SensorType)
            {
                case SensorType.Temperature:
                    Temperatures.Add(sensor);
                    break;

                case SensorType.Voltage:
                    if(sensor.Name.Contains("+3.3V"))
                    { Voltage3p3 = sensor; }
                    else if(sensor.Name.Contains("VBat"))
                    { VBat = sensor; }
                    else
                    { Voltages.Add(sensor); }
                    break;

                case SensorType.Fan:
                    if(sensor.Name.EndsWith("#1"))
                    { CpuFanSpeed = sensor; }
                    else
                    { FanSpeeds.Add(sensor); }
                    break;

                case SensorType.Control:
                    FanControls.Add(sensor);
                    break;

                default:
                    Jsoner.ObjectSaver.AddObject(sensor);
                    break;
            }
        }

        public void Update(IVisitor visitor)
        {
            Hardware.Accept(visitor);
        }
    }
}