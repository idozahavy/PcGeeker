using OpenHardwareMonitor.Hardware;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HardwareInfo.PCAnalyzer
{
    public class SensorThresholdProperty
    {
        public ISensor Sensor
        {
            get;
            private set;
        }
        public float ThresholdValue
        {
            get;
            private set;
        }
        public PropertyInfo Property
        {
            get;
            private set;
        }

        public SensorThresholdProperty(ISensor sensor, string FloatPropertyName, float thresholdValue)
        {
            this.Sensor = sensor;
            this.Property = typeof(ISensor).GetProperty(FloatPropertyName, typeof(float?));
            this.ThresholdValue = thresholdValue;
        }
        /// <summary>
        /// Threshold the sensor Value
        /// </summary>
        public SensorThresholdProperty(ISensor sensor, float thresholdValue) : this(sensor, "Value", thresholdValue) { }

        public bool IsSensorThresholded()
        {
            object sensorValue = Property.GetValue(Sensor);
            if (sensorValue != null)
            {
                return (float)Property.GetValue(Sensor) >= ThresholdValue;
            }
            return false;
        }
    }
}
