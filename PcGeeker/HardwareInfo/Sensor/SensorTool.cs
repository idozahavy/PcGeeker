using OpenHardwareMonitor.Collections;
using OpenHardwareMonitor.Hardware;
using System;
using System.Collections.Generic;

namespace HardwareInfo
{
    internal class SensorTool
    {
        public static ISensor NAIfNull(ISensor sensor)
        {
            if(sensor == null)
            {
                return new NASensor();
            }
            return sensor;
        }

        public static bool IsNull(ISensor sensor)
        {
            return sensor == null || sensor.GetType() == typeof(NASensor);
        }

        private class NASensor : ISensor
        {
            public NASensor()
            {
            }

            public IHardware Hardware => null;

            public SensorType SensorType => SensorType.SmallData;

            public Identifier Identifier => new Identifier(String.Empty);

            public string Name { get => null; set { } }

            public int Index => -1;

            public bool IsDefaultHidden => false;

            public IReadOnlyArray<IParameter> Parameters => null;

            public float? Value => null;

            public float? Min => null;

            public float? Max => null;

            public IEnumerable<SensorValue> Values => new List<SensorValue>();

            public IControl Control => null;

            public void Accept(IVisitor visitor)
            {
            }

            public void ResetMax()
            {
            }

            public void ResetMin()
            {
            }

            public void Traverse(IVisitor visitor)
            {
            }
        }
    }
}