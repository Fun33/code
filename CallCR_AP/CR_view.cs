using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;

namespace CallCR
{
    public partial class CR_view : Form
    {
        public CR_view()
        {
            InitializeComponent();
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            string cmd = System.IO.Path.Combine(System.Windows.Forms.Application.StartupPath, "CR.rpt");

             ReportDocument cryRpt = new ReportDocument();
            cryRpt.Load(cmd);
            crystalReportViewer1.ReportSource = cryRpt;
            crystalReportViewer1.Refresh();
        }
    }
}
