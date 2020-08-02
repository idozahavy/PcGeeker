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
        public float Value
        {
            get;
            private set;
        }
        public PropertyInfo Property
        {
            get;
            private set;
        }

        public SensorThresholdProperty(string FloatPropertyName, float thresholdValue)
        {
            this.Property = typeof(ISensor).GetProperty(FloatPropertyName, typeof(float?));
            this.Value = thresholdValue;
        }
        public SensorThresholdProperty(float thresholdValue): this("Value", thresholdValue) { }

        public bool isThresholded(ISensor sensor)
        {
            return (float)Property.GetValue(sensor) >= Value;
        }
    }
}
