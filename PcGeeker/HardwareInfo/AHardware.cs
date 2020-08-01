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

        public void Update(IVisitor visitor)
        {
            hardware.Accept(visitor);
        }

        internal abstract void Initialize();
    }
}