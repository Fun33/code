using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AP_C
{
    public partial class FTest : Form
    {
        public FTest()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Issue avgrpice become zero,occure can't issue.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnIssueAvgPrice_Click(object sender, EventArgs e)
        {
            tx01.Text = "";
            //AvgPrice = onhand-issue / onhand*avgprice - qty*avgprice
            double AvgPrice = 0.007692;
            double Onhand = 702.845;
            double Qty;
            double qty2 = 0.455;
            double i0, i11, i12, i125, i2, i3, i4, i5;
            //double sumAvgPrice;// = onhand -qty /Math.Round(onhand *AvgPrice,2) 
            //    -Math.Round(qty *AvgPrice,2) ;//減多了
            for (int i = 1; i < 10; i++)
            {
                Qty = qty2;
                i0 = Onhand - Qty;
                i11 = Math.Round(Onhand * AvgPrice, 2, MidpointRounding.AwayFromZero);//如果是要我們一般認知的4捨5入的話，要加上第3個參數(MidpointRounding.AwayFromZer)哦!
                i12 = Math.Round(Qty * AvgPrice, 2, MidpointRounding.AwayFromZero);
                if (i12 == 0)
                    tx02.Text += i.ToString() + " : i5 : " + i12.ToString() + Environment.NewLine;
                i125 = i12 / Qty;


                i2 = i11 - i12;
                i3 = i2 / i0;
                i4 = i3 * Qty;
                i5 = Math.Round(i4 / Qty, 4, MidpointRounding.AwayFromZero);
                Onhand = Onhand - Qty;
                //AvgPrice = (
                //             (
                //                ((Onhand * AvgPrice) - (Qty * AvgPrice))//1-1=2
                //            /
                //                (Onhand - Qty)//0
                //              ) * Qty//4=3*Qty
                //        ) / Qty;//5=4/Qty 

                //tx01.Text += i.ToString() + " : i0 : " + i0.ToString() + Environment.NewLine;
                //tx01.Text += i.ToString() + " : i11 : " + i11.ToString() + Environment.NewLine;
                //tx01.Text += i.ToString() + " : i11 : " + i11.ToString() + Environment.NewLine;
                //tx01.Text += i.ToString() + " : i2 : " + i2.ToString() + Environment.NewLine;
                //tx01.Text += i.ToString() + " : i3 : " + i3.ToString() + Environment.NewLine;
                //tx01.Text += i.ToString() + " : i4 : " + i4.ToString() + Environment.NewLine;
                tx01.Text += i.ToString() + " : i5 : " + i5.ToString() + Environment.NewLine;

            }
            MessageBox.Show("OK");

        }
        private void BtnIssueAvgPrice_S2_Click(object sender, EventArgs e)
        {
            tx01.Text = "";
            //AvgPrice = onhand-issue / onhand*avgprice - qty*avgprice
            double AvgPrice = 0.007692;
            double Onhand = 702.845;
            double Qty;
            double qty2 = 0.455;
            double i0, i11, i12
                , i125//issue price
                , i2, i3, i4, i5;
            //double sumAvgPrice;// = onhand -qty /Math.Round(onhand *AvgPrice,2) 
            //    -Math.Round(qty *AvgPrice,2) ;//減多了
            for (int i = 1; i < 10; i++)
            {
                Qty = qty2;
                i0 = Onhand - Qty;
                i11 = Math.Round(Onhand * AvgPrice, 2, MidpointRounding.AwayFromZero);//如果是要我們一般認知的4捨5入的話，要加上第3個參數(MidpointRounding.AwayFromZer)哦!
                i12 = Math.Round(Qty * AvgPrice, 2, MidpointRounding.AwayFromZero);
                if (i12 == 0)
                    tx02.Text += i.ToString() + " : i5 : " + i12.ToString() + Environment.NewLine;
                i125 = i12 / Qty;

                if (i125 == 0)
                    tx02.Text += i.ToString() + " : i5 : " + i12.ToString() + Environment.NewLine;


            }
            MessageBox.Show("OK");

        }

    
            
    }
}
