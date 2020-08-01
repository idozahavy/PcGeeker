using OpenHardwareMonitor.Collections;
using OpenHardwareMonitor.Hardware;
using System;
using System.Collections.Generic;

namespace HardwareInfo
{
    public class PC
    {
        private Computer computer;
        private IVisitor visitor;
        private ComputerVisitSetting visitSetting;

        public CPU CPU
        {
            get;
            private set;
        }
        public GPU GPU
        {
            get;
            private set;
        }
        public RAM RAM
        {
            get;
            private set;
        }

        public List<Drive> Drives
        {
            get;
            private set;
        }

        public Motherboard Motherboard
        {
            get;
            private set;
        }

        public PC(bool visitAll)
        {
            if(visitAll)
            {
                this.visitSetting = new ComputerVisitSetting(true, true, true, true, true, true);
            }
            else
            {
                this.visitSetting = new ComputerVisitSetting("");
            }
            Initialize();
        }

        public PC(ComputerVisitSetting setting)
        {
            this.visitSetting = setting;
            Initialize();
        }

        public void Initialize()
        {
            visitor = new VisitorUpdater();
            computer = new Computer();
            computer.Open();
            visitSetting.SetComputer(computer);
            this.Drives = new List<Drive>();
        }

        public void RefreshInfo()
        {
            computer.Accept(visitor);
        }

        public IHardware[] GetHardware()
        {
            computer.Accept(visitor);
            return computer.Hardware;
        }

        public List<Pair<string, object>> TestingFunc()
        {
            List<Pair<string, object>> ls = new List<Pair<string, object>>();
            if(visitSetting.CPU)
            {
                this.RefreshInfo();
                foreach(IHardware hard in computer.Hardware)
                {
                    if(hard.HardwareType == HardwareType.CPU)
                    {
                        Console.WriteLine("CPU");
                        this.CPU = new CPU(hard);
                    }
                    else if(hard.HardwareType == HardwareType.GpuNvidia)
                    {
                        Console.WriteLine("GpuNvidia");
                        this.GPU = new GPU(hard);
                    }
                    else if(hard.HardwareType == HardwareType.GpuAti)
                    {
                        Console.WriteLine("GpuAti");
                    }
                    else if(hard.HardwareType == HardwareType.HDD)
                    {
                        this.Drives.Add(new Drive(hard));
                        Console.WriteLine("HDD");
                    }
                    else if(hard.HardwareType == HardwareType.Heatmaster)
                    {
                        Console.WriteLine("Heatmaster");
                    }
                    else if(hard.HardwareType == HardwareType.Mainboard)
                    {
                        //this.Motherboard = new Motherboard(hard);
                        Console.WriteLine("Mainboard");
                        foreach (IHardware hard2 in hard.SubHardware)
                        {
                            Console.WriteLine(hard2.Name + ", " + hard2.HardwareType);
                            foreach (ISensor sensor in hard2.Sensors)
                            {
                                Console.WriteLine(sensor.Name + ", " + sensor.SensorType + " = " + sensor.Value);
                            }
                        }
                    }
                    else if(hard.HardwareType == HardwareType.RAM)
                    {
                        this.RAM = new RAM(hard);
                        Console.WriteLine("RAM");
                    }
                    else if(hard.HardwareType == HardwareType.SuperIO)
                    {
                        Console.WriteLine("SuperIO");
                    }
                    else if(hard.HardwareType == HardwareType.TBalancer)
                    {
                        Console.WriteLine("TBalancer");
                    }
                    foreach(ISensor sensor in hard.Sensors)
                    {
                        ls.Add(new Pair<string, object>(sensor.Name, sensor.Value));
                        Console.WriteLine(sensor.Name + ", " + sensor.SensorType + " = " + sensor.Value);
                        if(sensor.Value == null)
                        {
                        }
                    }
                }
            }
            return ls;
        }
    }
}