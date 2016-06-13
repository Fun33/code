using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace callexe
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        { 
            string target = @"D:\UnaTADC\una_work\sample\exe\bin\Debug\exe.exe";
            //way1 
            
            Process.Start(target, "a,b");

            //way2
            //ProcessStartInfo pInfo = new ProcessStartInfo(target);
            //pInfo.Arguments = "a,b";

            //using (Process p = new Process())
            //{

            //    p.StartInfo = pInfo;

            //    p.Start();

            //}
        }
    }
}
