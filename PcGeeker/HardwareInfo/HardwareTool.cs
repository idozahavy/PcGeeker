using System;

namespace HardwareInfo
{
    public class HardwareTool
    {
        public enum HardwareType
        {
            CPU = 1,
            GPU = 2,
            RAM = 3,
            Drive = 4,
            Motherboard = 5
        }

        public static Type HardwareClassRedirect(HardwareType type)
        {
            switch(type)
            {
                case HardwareType.CPU:
                    return typeof(CPU);

                case HardwareType.GPU:
                    return typeof(GPU);

                case HardwareType.RAM:
                    return typeof(RAM);

                case HardwareType.Drive:
                    return typeof(Drive);

                case HardwareType.Motherboard:
                    return typeof(Motherboard);
            }
            return null;
        }
    }
}