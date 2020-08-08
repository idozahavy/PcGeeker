namespace HardwareInfo.HardwareClass
{
    public abstract class BaseCPU<T> : BaseHardware
    {
        public enum CPUField
        {
            PackageTemperature = 1,
            PackagePower = 2,
            TotalLoad = 3,
            CoresPower = 4,
            GraphicsPower = 5,
            DRAMPower = 6,
            BusClock = 7
        }

        public T PackageTemperature { get; internal set; }

        public T PackagePower { get; internal set; }

        public T TotalLoad { get; internal set; }

        public T CoresPower { get; internal set; }

        public T GraphicsPower { get; internal set; }

        public T DRAMPower { get; internal set; }

        public T BusClock { get; internal set; }
    }
}