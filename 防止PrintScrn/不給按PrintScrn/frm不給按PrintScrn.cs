using System;
using System.Windows.Forms;

namespace 防止PrintScrn
{
    public partial class frm不給按PrintScrn : Form
    {
        private StopPrinScrn t2;
        public frm不給按PrintScrn()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            t2 = t2 = new StopPrinScrn(this);
            this.Visible = false;
            
        }

        private void Form2_Activated(object sender, EventArgs e)
        {
            this.Visible = false;
            
        }
    }
}
