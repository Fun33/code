using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms; 

namespace Timer_S
{
    public partial class Form1 : Form
    {
        private  Timer clock = new  Timer(); 
        public Form1()
        { 
            InitializeComponent();
            clock.Interval = 60000;//一千是一秒
            clock.Start();
            clock.Enabled = true;
            clock.Tick += new EventHandler(clock_Tick);
        }
        public void clock_Tick(object sender, EventArgs e)
        {
            try
            {
               
            }
            catch (Exception ex)
            {
               
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
