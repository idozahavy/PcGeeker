using OpenHardwareMonitor.Hardware;
using System;

namespace HardwareInfo
{
    public abstract class AHardware
    {
        public IHardware Hardware { get; private set; }

        public abstract AHardwareType HardwareType { get; }

        public AHardware(IHardware hardware)
        {
            Hardware = hardware;
        }

        public void Update(IVisitor visitor)
        {
            Hardware.Accept(visitor);
        }

        internal abstract void Initialize();

        public enum AHardwareType
        {
            CPU = 1,
            GPU = 2,
            RAM = 3,
            Drive = 4,
            Motherboard = 5
        }

        public Type AHardwareTypeRedirect(AHardwareType type)
        {
            switch(type)
            {
                case AHardwareType.CPU:
                    return typeof(CPU);

                case AHardwareType.GPU:
                    return typeof(GPU);

                case AHardwareType.RAM:
                    return typeof(RAM);

                case AHardwareType.Drive:
                    return typeof(Drive);

                case AHardwareType.Motherboard:
                    return typeof(Motherboard);
            }
            return null;
        }
    }
}