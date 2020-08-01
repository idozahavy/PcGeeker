using HardwareInfo;
using OpenHardwareMonitor.Collections;
using OpenHardwareMonitor.Hardware;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace PcGeeker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //PC pc = new PC(new ComputerVisitSetting("cpu", "gpu"));
            PC pc = new PC(true);
            pc.Update();
            foreach(PropertyInfo pcProp in pc.GetType().GetProperties())
            {
                if (pcProp.GetValue(pc) is AHardware)
                {
                    AHardware pcHardware = (AHardware)pcProp.GetValue(pc);
                    foreach (PropertyInfo pcHardwareProp in pcHardware.GetType().GetProperties())
                    {
                        if (pcHardwareProp.GetValue(pcHardware) is ISensor)
                        {
                            ISensor sensor = (ISensor)pcHardwareProp.GetValue(pcHardware);
                            if (!Sensors.IsNull(sensor))
                            {
                                allTabListBox.Items.Add(pcHardwareProp.Name + " = " + sensor.Value);
                            }
                            else
                            {
                                allTabListBox.Items.Add(pcHardwareProp.Name + " is empty ");
                            }
                        }
                    }
                }
            }
        }
    }
}
