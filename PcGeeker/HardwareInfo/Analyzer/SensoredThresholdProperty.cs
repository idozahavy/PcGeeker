using OpenHardwareMonitor.Hardware;

namespace HardwareInfo.Analyzer
{
    public class SensoredThresholdProperty : SensorlessThresholdProperty
    {
        public ISensor Sensor { get; private set; }

        public SensoredThresholdProperty(ISensor sensor, SensorlessThresholdProperty prop) : base(prop)
        {
            Sensor = sensor;
        }

        public SensoredThresholdProperty(ISensor sensor, string FloatPropertyName, float thresholdValue) : base(FloatPropertyName, thresholdValue)
        {
            this.Sensor = sensor;
        }

        public SensoredThresholdProperty(ISensor sensor, float thresholdValue) : this(sensor, "Value", thresholdValue)
        {
        }

        public bool IsSensorThresholded()
        {
            return base.IsSensorThresholded(Sensor);
        }
    }
}