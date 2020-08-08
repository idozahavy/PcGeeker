using HardwareInfo;
using HardwareInfo.Analyzer;
using HardwareInfo.Analyzer.CPUAnalyze;
using HardwareInfo.Analyzer.CPUAnalyze.CPUCoreAnalyze;
using HardwareInfo.Analyzer.Threshold;
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
            Timer1.Start();


            ProcessUtilitationCollection utils = new ProcessUtilitationCollection();
            utils.UpdateProcesses();

            PCAnalyzerSettings settings = new PCAnalyzerSettings();
            settings.CPU = new CPUAnalyzerSettings(new CPUCoreAnalyzerSettings(""),
                new FieldThreshold(CPU.CPUField.CoresPower, 20));
            new PCAnalyzer(pc, "", new PCAnalyzerSettings());

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