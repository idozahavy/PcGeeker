using HardwareInfo;
using HardwareInfo.Analyzer;
using OpenHardwareMonitor.Collections;
using OpenHardwareMonitor.Hardware;
using ProcessInfo;
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
        private PC pc;

        public Form1()
        {
            InitializeComponent();
            
            //PC pc = new PC(new ComputerVisitSetting("cpu", "gpu"));
            pc = new PC(true);
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
                else if (pcProp.GetValue(pc) is List<Drive>)
                {
                    List<Drive> drives = (List<Drive>)pcProp.GetValue(pc);
                    foreach (Drive drive in drives)
                    {
                        Jsoner.ObjectSaver.AddObject(drive);
                        foreach (PropertyInfo driveProp in drive.GetType().GetProperties())
                        {
                            if (driveProp.GetValue(drive) is ISensor)
                            {
                                ISensor sensor = (ISensor)driveProp.GetValue(drive);
                                if (!Sensors.IsNull(sensor))
                                {
                                    allTabListBox.Items.Add(driveProp.Name + " = " + sensor.Value);
                                }
                                else
                                {
                                    allTabListBox.Items.Add(driveProp.Name + " is empty ");
                                }
                            }
                        }
                    }
                }
            }
            timer1.Start();

            ProcessUtilitationCollection utils = new ProcessUtilitationCollection();
            utils.UpdateProcesses();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            pc.Update();
            CPUAnalyzer analyzer = new CPUAnalyzer(pc.CPU, new CPUAnalyzerSettings("corespower:10","temp:60"));
            label1.Text = analyzer.Analyze();
        }
    }
}
