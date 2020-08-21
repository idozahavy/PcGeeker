using OpenHardwareMonitor.Hardware;

namespace HardwareInfo
{
    public class PCSettings
    {
        public bool CPU { get; private set; }
        public bool GPU { get; private set; }
        public bool RAM { get; private set; }
        public bool Drive { get; private set; }
        public bool Motherboard { get; private set; }
        public bool Fan { get; private set; }

        public PCSettings(bool cpu, bool gpu, bool ram, bool drive, bool motherboard, bool fan)
        {
            CPU = cpu;
            GPU = gpu;
            RAM = ram;
            Drive = drive;
            Motherboard = motherboard;
            Fan = fan;
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
                        CPU = true;
                        break;

                    case "graphic":
                    case "graphics":
                    case "gpu":
                        GPU = true;
                        break;

                    case "memory":
                    case "ram":
                        RAM = true;
                        break;

                    case "mb":
                    case "mainboard":
                    case "motherboard":
                        Motherboard = true;
                        break;

                    case "ssd":
                    case "hdd":
                    case "drive":
                        Drive = true;
                        break;

                    case "fans":
                    case "fan":
                        Fan = true;
                        break;
                }
            }
        }

        public void SetComputerSettings(Computer computer)
        {
            computer.CPUEnabled = CPU;
            computer.GPUEnabled = GPU;
            computer.RAMEnabled = RAM;
            computer.MainboardEnabled = Motherboard;
            computer.HDDEnabled = Drive;
            computer.FanControllerEnabled = Fan;
        }
    }
}