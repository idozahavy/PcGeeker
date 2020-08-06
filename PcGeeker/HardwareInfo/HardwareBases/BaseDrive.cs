using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareInfo.HardwareBases
{
    public class BaseDrive<T> : BaseHardware
    {
        public enum DriveField
        {
            Temperature = 1,
            UsedPercentage = 2,
        }

        public T Temperature { get; internal set; }
        public T UsedPercentage { get; internal set; }
    }
}
