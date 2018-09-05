using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 防止PrintScrn
{
    static class 　Program
    {
        /// <summary>
        /// 應用程式的主要進入點。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new  frm不給按PrintScrn());
            //Application.Run(new Timer.Timer22_f());
            //Application.Run(new Timer1_f());
            //Application.Run(new frm_delegate());
            //Application.Run(new MDIParent1());
         
            //Application.Run(new Form2());
        }
    }
}
