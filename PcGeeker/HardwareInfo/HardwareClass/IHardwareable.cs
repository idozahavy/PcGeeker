using OpenHardwareMonitor.Hardware;

namespace HardwareInfo.HardwareClass
{
    public interface IHardwareable
    {
        IHardware Hardware { get; }

        void Update(IVisitor visitor);

        void Initialize();
    }
}