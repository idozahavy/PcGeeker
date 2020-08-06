using HardwareInfo.HardwareBases;
using HardwareInfo.Sensor;
using OpenHardwareMonitor.Hardware;
using System.Reflection;

namespace HardwareInfo
{
    public class RAM : BaseRAM<ISensor>, IHardwareable
    {
        public IHardware Hardware { get; private set; }

        public RAM(IHardware hardware)
        {
            Hardware = hardware;
            Initialize();
            foreach(PropertyInfo prop in this.GetType().GetProperties())
            {
                if(prop.PropertyType == typeof(ISensor) && prop.SetMethod != null)
                {
                    prop.SetValue(this, SensorTool.NAIfNull((ISensor)prop.GetValue(this)));
                }
            }
        }

        public void Update(IVisitor visitor)
        {
            Hardware.Accept(visitor);
            if (Total is UpdateSensor total)
            {
                total.InvokeUpdate();
            }
        }

        public void Initialize()
        {
            Total = new UpdateSensor(ValueSensorUpdate);
            foreach(ISensor sensor in Hardware.Sensors)
            {
                switch(sensor.SensorType)
                {
                    case SensorType.Load:
                        UsedPercentage = sensor;
                        break;

                    case SensorType.Data:
                    {
                        if(sensor.Name.StartsWith("Used"))
                        {
                            Used = sensor;
                        }
                        else if(sensor.Name.StartsWith("Avail"))
                        {
                            Available = sensor;
                        }
                        else
                        {
                            Jsoner.ObjectSaver.AddObject(sensor);
                        }
                    }
                        break;

                    default:
                        Jsoner.ObjectSaver.AddObject(sensor);
                        break;
                }
            }
        }

        private void ValueSensorUpdate(UpdateSensor self)
        {
            if (Used != null && Available !=null)
            {
                self.SensorType = SensorType.Data;
                self.Value = Used.Value + Available.Value;
                self.Min = Used.Min + Available.Min;
                self.Max = Used.Max + Available.Max;
                self.Name = "Total Memory";
                self.Hardware = Hardware;
                self.IsDefaultHidden = true;
            }
        }

        
    }
}