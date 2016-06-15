using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ReadExcel
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string excelPosition = textBox1.Text;
                string sheetName = textBox2.Text;
                dataGridView1.DataSource = new func_excel_read_ole(func_excel_read_ole.ExcelVersion.e2007).GetDataSource(excelPosition, sheetName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message );
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string excelPosition = textBox1.Text;
                string sheetName = textBox2.Text;
                dataGridView1.DataSource = new func_excel_read_ole().GetDataSource(excelPosition, sheetName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
