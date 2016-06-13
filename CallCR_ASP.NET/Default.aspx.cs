using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using CrystalDecisions.Shared;

using CrystalDecisions.CrystalReports.Engine;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnReport_Click(object sender, EventArgs e)
    {
        ReportDocument crystalReport = new ReportDocument();

        //Load crystal report made in design view
        string a = Server.MapPath("CR_CHAR.rpt");
        crystalReport.Load(Server.MapPath("CR_CHAR.rpt"));

        ////Set DataBase Login Info
        crystalReport.SetDatabaseLogon
            ("sa", "sapb1TADC", @"192.168.33.101", "genetex_us_20131015");

        //Provide parameter values
        crystalReport.SetParameterValue("ItemCode", txtProductID.Text);
        CrystalReportViewer1.ReportSource = crystalReport;
    }
}
