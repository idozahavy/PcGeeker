using OpenHardwareMonitor.Hardware;
using System.Reflection;

namespace HardwareInfo.Analyze.Threshold
{
    public class SensorlessThresholdProperty
    {
        public float ThresholdValue { get; protected set; }
        public PropertyInfo Property { get; protected set; }

        public SensorlessThresholdProperty(SensorlessThresholdProperty prop)
        {
            if(prop == null)
            {
                return;
            }
            this.Property = prop.Property;
            this.ThresholdValue = prop.ThresholdValue;
        }

        public SensorlessThresholdProperty(string FloatPropertyName, float? thresholdValue)
        {
            if(thresholdValue is float value)
            {
                if(FloatPropertyName == null)
                {
                    return;
                }
                this.Property = typeof(ISensor).GetProperty(FloatPropertyName, typeof(float?));
                this.ThresholdValue = value;
            }
        }

        /// <summary>
        /// Threshold the sensor Value
        /// </summary>
        public SensorlessThresholdProperty(float? thresholdValue) : this("Value", thresholdValue) { }

        public bool IsSensorThresholded(ISensor sensor)
        {
            if(sensor == null || Property == null)
            {
                return false;
            }
            object sensorValue = Property.GetValue(sensor);
            if(sensorValue != null)
            {
                return (float)Property.GetValue(sensor) >= ThresholdValue;
            }
            return false;
        }
    }
}