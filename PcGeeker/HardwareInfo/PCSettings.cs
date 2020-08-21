using OpenHardwareMonitor.Hardware;

namespace HardwareInfo
{
    public class PCSettings
    {
        public bool CPU { get; private set; }
        public bool GPU { get; private set; }
        public bool RAM { get; private set; }
        public bool Drive { get; private set; }
        public bool MOTHERBOARD { get; private set; }
        public bool FAN { get; private set; }

        public PCSettings(bool cPU, bool gPU, bool rAM, bool drive, bool mOTHERBOARD, bool fAN)
        {
            CPU = cPU;
            GPU = gPU;
            RAM = rAM;
            Drive = drive;
            MOTHERBOARD = mOTHERBOARD;
            FAN = fAN;
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
                        this.Drive = true;
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
            computer.HDDEnabled = Drive;
            computer.FanControllerEnabled = FAN;
        }
    }
}