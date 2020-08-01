﻿using OpenHardwareMonitor.Collections;
using OpenHardwareMonitor.Hardware;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

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
            this.Drives = new List<Drive>();
            visitor = new VisitorUpdater();
            computer = new Computer();
            visitSetting.SetComputerSettings(computer);
            computer.Open();
            Update();
            InitializeComputerHardwares();
        }

        private void InitializeComputerHardwares()
        {
            foreach (IHardware hard in computer.Hardware)
            {
                switch (hard.HardwareType)
                {
                    case HardwareType.CPU: this.CPU = new CPU(hard); break;
                    case HardwareType.GpuAti:
                    case HardwareType.GpuNvidia: this.GPU = new GPU(hard); break;
                    case HardwareType.HDD: this.Drives.Add(new Drive(hard)); break;
                    case HardwareType.Mainboard: this.Motherboard = new Motherboard(hard); break;
                    case HardwareType.RAM: this.RAM = new RAM(hard); break;
                    case HardwareType.SuperIO:
                    case HardwareType.Heatmaster:
                    case HardwareType.TBalancer:
                    default:
                        MessageBox.Show("Uncaught computer hardware type " + hard.HardwareType); break;
                }
            }
        }

        public void Update()
        {
            computer.Accept(visitor);
        }

        public IHardware[] GetHardware()
        {
            return computer.Hardware;
        }
    }
}