using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareInfo.HardwareBases
{
    public abstract class BaseRAM<T> : BaseHardware
    {
        public enum RAMField
        {
            Used = 1,
            Available = 2,
            Total = 3,
            UsedPercentage = 4,
        }

        public T Used { get; internal set; }
        public T Available { get; internal set; }
        public T Total { get; internal set; }
        public T UsedPercentage { get; internal set; }
    }
}
