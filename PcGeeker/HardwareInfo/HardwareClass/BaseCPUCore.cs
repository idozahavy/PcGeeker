namespace HardwareInfo.HardwareClass
{
    public abstract class BaseCPUCore<T> : BaseHardware
    {
        public enum CPUCoreField
        {
            Temperature = 1,
            Load = 2,
            Clock = 3
        }

        public T Temperature { get; internal set; }
        public T Load { get; internal set; }
        public T Clock { get; internal set; }
    }
}