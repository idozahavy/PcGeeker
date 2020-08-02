using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareInfo.Analyzer
{
    public class PCAnalyzerSettings
    {

        public bool CPU
        {
            get;
            private set;
        }
        public bool GPU
        {
            get;
            private set;
        }
        public bool RAM
        {
            get;
            private set;
        }
        public bool Drive
        {
            get;
            private set;
        }
        public bool Motherboard
        {
            get;
            private set;
        }

        public PCAnalyzerSettings(bool cpu, bool gpu, bool ram, bool drive, bool motherboard) 
        {
            CPU = cpu;
            GPU = gpu;
            RAM = ram;
            Drive = drive;
            Motherboard = motherboard;
        }
    }
}
