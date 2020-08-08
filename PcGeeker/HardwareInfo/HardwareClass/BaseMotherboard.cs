using System.Collections.Generic;

namespace HardwareInfo.HardwareClass
{
    public abstract class BaseMotherboard<T> : BaseHardware
    {
        public enum MotherboardField
        {
            FanControls = 1,
            Voltages = 2,
            Voltage3p3 = 3,
            VBat = 4,
            Temperatures = 5,
            CpuFanSpeed = 6,
            FanSpeeds = 7,
        }

        public List<T> FanControls { get; internal set; }
        public List<T> Voltages { get; internal set; }
        public T Voltage3p3 { get; internal set; }
        public T VBat { get; internal set; }
        public List<T> Temperatures { get; internal set; }
        public T CpuFanSpeed { get; internal set; }
        public List<T> FanSpeeds { get; internal set; }
    }
}