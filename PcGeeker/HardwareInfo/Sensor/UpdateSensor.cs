using OpenHardwareMonitor.Collections;
using OpenHardwareMonitor.Hardware;
using System.Collections.Generic;

namespace HardwareInfo.Sensor
{
    public class UpdateSensor : ISensor
    {
        public IHardware Hardware { get; set; }

        public SensorType SensorType { get; set; }

        public Identifier Identifier { get; set; }

        public string Name { get; set; }

        public int Index { get; set; }

        public bool IsDefaultHidden { get; set; }

        public IReadOnlyArray<IParameter> Parameters { get; set; }

        public float? Value { get; set; }

        public float? Min { get; set; }

        public float? Max { get; set; }

        public IEnumerable<SensorValue> Values { get; set; }

        public IControl Control { get; set; }

        public delegate void UpdateDelegate(UpdateSensor self);

        private UpdateDelegate Update;

        public void InvokeUpdate()
        {
            Update.Invoke(this);
        }

        public UpdateSensor(UpdateDelegate update)
        {
            Update = update;
        }

        public void Accept(IVisitor visitor)
        {
            InvokeUpdate();
        }

        public void ResetMax()
        {
            Max = null;
        }

        public void ResetMin()
        {
            Min = null;
        }

        public void Traverse(IVisitor visitor)
        {
            InvokeUpdate();
        }
    }
}