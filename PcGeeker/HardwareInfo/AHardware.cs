using OpenHardwareMonitor.Hardware;

namespace HardwareInfo
{
    public abstract class AHardware
    {
        protected IHardware hardware;

        public AHardware(IHardware hardware)
        {
            this.hardware = hardware;
        }

        public void Initialize(IVisitor visitor)
        {
            hardware.Accept(visitor);
            Initialize();
        }

        internal abstract void Initialize();
    }
}