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
        private PCAnalyzer pcAnalyzer;
        ProcessUtilizationCollection utils;

        public Form1()
        {
            InitializeComponent();

            pc = new PC(true);
            pc.Update();
            pcAnalyzer = new PCAnalyzer(pc, new PCAnalyzerSettings(new CPUAnalyzerSettings(null,
                new FieldThreshold(CPU.CPUField.CoresPower, 25),
                new FieldThreshold(CPU.CPUField.PackagePower, 40),
                new FieldThreshold(CPU.CPUField.PackageTemperature, 60),
                new FieldThreshold(CPU.CPUField.TotalLoad, 70)
                ), null, null, null, null));
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
            PCAnalysis pcAnalysis = pcAnalyzer.Analyze();

            pc.Update();
            allTabListBox.Items.Clear();
            CPUAnalysis analysis = pcAnalysis.CPU;
            analysis.Where<bool>((object self, PropertyInfo prop, bool value) =>
            {
                if(value)
                {
                    allTabListBox.Items.Add(prop.Name + " thresholded");
                }
            });
            label1.Text = String.Format("{0:N2}",utils.UpdateGetTotalUtilization());
        }
    }
}