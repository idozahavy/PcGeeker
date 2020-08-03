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
                
                if (pcProp.GetValue(pc) is AHardware pcHardware)
                {
                    foreach (PropertyInfo pcHardwareProp in pcHardware.GetType().GetProperties())
                    {
                        if (pcHardwareProp.GetValue(pcHardware) is ISensor sensor)
                        {
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
                else if (pcProp.GetValue(pc) is List<Drive> drives)
                {
                    foreach (Drive drive in drives)
                    {
                        Jsoner.ObjectSaver.AddObject(drive);
                        foreach (PropertyInfo driveProp in drive.GetType().GetProperties())
                        {
                            if (driveProp.GetValue(drive) is ISensor sensor)
                            {
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
            Timer1.Start();

            ProcessUtilitationCollection utils = new ProcessUtilitationCollection();
            utils.UpdateProcesses();

        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            pc.Update();
            CPUAnalyzer analyzer = new CPUAnalyzer(pc.CPU, new CPUAnalyzerSettings("packagepower:15","temp:60"));
            label1.Text = analyzer.Analyze().PackagePowerThresholded? "POWER!!!": "";
        }
    }
}
