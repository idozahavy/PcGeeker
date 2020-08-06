using HardwareInfo;
using OpenHardwareMonitor.Hardware;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareInfo.HardwareBases
{
    public interface IHardwareable
    {
        IHardware Hardware { get; }
        void Update(IVisitor visitor);
        void Initialize();

    }
}
