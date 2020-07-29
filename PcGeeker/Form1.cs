using HardwareInfo;
using OpenHardwareMonitor.Collections;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
            List<Pair<string, object>> ls = pc.TestingFunc();
            foreach(Pair<string, object> pair in ls)
            {
                if(pair.Second != null)
                {
                    allTabListBox.Items.Add(pair.First + " = " + pair.Second.ToString());
                }
                else
                {
                    allTabListBox.Items.Add(pair.First + " is empty");
                }
            }
        }
    }
}
