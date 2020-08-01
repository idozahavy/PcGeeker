using OpenHardwareMonitor.Hardware;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareInfo
{
    public class Motherboard : AHardware
    {


        public Motherboard(IHardware hardware) : base(hardware)
        {
            Initialize();
        }

        internal override void Initialize()
        {
            throw new NotImplementedException();
        }
    }
}
