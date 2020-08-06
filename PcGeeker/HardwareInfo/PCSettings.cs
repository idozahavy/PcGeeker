using OpenHardwareMonitor.Hardware;

namespace HardwareInfo
{
    public class PCSettings
    {
        public bool CPU { get; private set; }
        public bool GPU { get; private set; }
        public bool RAM { get; private set; }
        public bool MOTHERBOARD { get; private set; }
        public bool HDD { get; private set; }
        public bool FAN { get; private set; }

        public PCSettings(bool cpu, bool gpu, bool ram, bool motherboard, bool hdd, bool fan)
        {
            this.CPU = cpu;
            this.GPU = gpu;
            this.RAM = ram;
            this.MOTHERBOARD = motherboard;
            this.HDD = hdd;
            this.FAN = fan;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="args"></param>
        public PCSettings(params string[] args)
        {
            SetSettings(args);
        }

        public void SetSettings(params string[] args)
        {
            foreach(string arg in args)
            {
                switch(arg.ToLower())
                {
                    case "cpu":
                        this.CPU = true;
                        break;

                    case "graphic":
                    case "graphics":
                    case "gpu":
                        this.GPU = true;
                        break;

                    case "memory":
                    case "ram":
                        this.RAM = true;
                        break;

                    case "mb":
                    case "mainboard":
                    case "motherboard":
                        this.MOTHERBOARD = true;
                        break;

                    case "ssd":
                    case "hdd":
                    case "drive":
                        this.HDD = true;
                        break;

                    case "fans":
                    case "fan":
                        this.FAN = true;
                        break;
                }
            }
        }

        public void SetComputerSettings(Computer computer)
        {
            computer.CPUEnabled = CPU;
            computer.GPUEnabled = GPU;
            computer.RAMEnabled = RAM;
            computer.MainboardEnabled = MOTHERBOARD;
            computer.HDDEnabled = HDD;
            computer.FanControllerEnabled = FAN;
        }
    }
}