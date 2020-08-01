using OpenHardwareMonitor.Hardware;

namespace HardwareInfo
{
    public abstract class AHardware
    {
        public IHardware hardware
        {
            get;
            private set;
        }

        public abstract AHardwareType HardwareType { get; }

        public AHardware(IHardware hardware)
        {
            this.hardware = hardware;
        }

        public void Update(IVisitor visitor)
        {
            hardware.Accept(visitor);
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
    }
}