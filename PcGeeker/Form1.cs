using HardwareInfo;
using HardwareInfo.Analyze;
using HardwareInfo.Analyze.CPUAnalyze;
using HardwareInfo.Analyze.CPUAnalyze.CPUCoreAnalyze;
using HardwareInfo.Analyze.Threshold;
using HardwareInfo.HardwareClass;
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
using System.Windows.Forms.VisualStyles;
using static HardwareInfo.HardwareClass.BaseHardware;

namespace PcGeeker
{
    public partial class Form1 : Form
    {
        private PC pc;
        private CPUAnalyzer cpuAnalyzer;
        ProcessUtilizationCollection utils;

        public Form1()
        {
            InitializeComponent();

            pc = new PC(true);
            pc.Update();
            cpuAnalyzer = new CPUAnalyzer(pc.CPU, new CPUAnalyzerSettings(null,
                new FieldThreshold(CPU.CPUField.CoresPower, 25),
                new FieldThreshold(CPU.CPUField.PackagePower, 40),
                new FieldThreshold(CPU.CPUField.PackageTemperature, 60),
                new FieldThreshold(CPU.CPUField.TotalLoad, 70)
                )
            );
            utils = new ProcessUtilizationCollection();
            utils.UpdateProcesses();
            Timer1.Start();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            List<FieldThreshold> fields = new List<FieldThreshold>
            {
                new FieldThreshold(Core.CPUCoreField.Load, 80)
            };
            pc.Update();
            allTabListBox.Items.Clear();
            CPUAnalysis analysis = cpuAnalyzer.Analyze();
            analysis.Where<bool>(www);
            label1.Text = utils.UpdateGetTotalUtilization().ToString();
        }

        private void www(object self, PropertyInfo prop, bool value)
        {
            if(value)
            {
                allTabListBox.Items.Add(prop.Name + " thresholded");
            }
        }
    }
}