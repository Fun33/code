using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Thead
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }
      

        private void button9_Click(object sender, EventArgs e)
        {
            new Form0().Show();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            new Form1().Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new Form2().Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            new Form3().Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            new Form4().Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            new Form5().Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            new Form6().Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
              new Form7_傳參數到thread().Show ();
             
        }

        private void button11_Click(object sender, EventArgs e)
        {
          
        }

        private void button12_Click(object sender, EventArgs e)
        {
            new Form7_傳2個參數到thread().Show();
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }
 

     
    }
}
