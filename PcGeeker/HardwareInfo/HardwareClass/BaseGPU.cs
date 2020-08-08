namespace HardwareInfo.HardwareClass
{
    public abstract class BaseGPU<T> : BaseHardware
    {
        public enum GPUField
        {
            CoreTemperature = 1,
            CoreClock = 2,
            CoreLoad = 3,
            ShaderClock = 4,
            FrameBufferLoad = 5,
            VideoEngineLoad = 6,
            BusLoad = 7,
            FanSpeed = 8,
            MemoryTotal = 9,
            MemoryUsed = 10,
            MemoryFree = 11,
            MemoryLoad = 12,
            MemoryClock = 13
        }

        public T CoreTemperature { get; internal set; }
        public T CoreClock { get; internal set; }
        public T CoreLoad { get; internal set; }
        public T ShaderClock { get; internal set; }
        public T FrameBufferLoad { get; internal set; }
        public T VideoEngineLoad { get; internal set; }
        public T BusLoad { get; internal set; }
        public T FanSpeed { get; internal set; }
        public T MemoryTotal { get; internal set; }
        public T MemoryUsed { get; internal set; }
        public T MemoryFree { get; internal set; }
        public T MemoryLoad { get; internal set; }
        public T MemoryClock { get; internal set; }
    }
}