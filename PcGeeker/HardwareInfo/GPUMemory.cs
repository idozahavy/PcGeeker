﻿using OpenHardwareMonitor.Hardware;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HardwareInfo
{
    public class GPUMemory : Memory
    {
        public ISensor Load
        {
            get;
            private set;
        }
        public ISensor Clock
        {
            get;
            private set;
        }

        public GPUMemory() : base()
        {
        }

        internal override void Initialize(ISensor sensor)
        {
            switch(sensor.SensorType)
            {
                case SensorType.Clock: Clock = sensor; break;
                case SensorType.Load: Load = sensor; break;
                case SensorType.SmallData: base.Initialize(sensor); break;
                default:
                    MessageBox.Show("Uncaught gpu memory type = " + sensor.SensorType); break;
            }
        }
    }
}
