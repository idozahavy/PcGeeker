namespace HardwareInfo.HardwareClass
{
    public abstract class BaseDrive<T> : BaseHardware
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