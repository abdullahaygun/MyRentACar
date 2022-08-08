using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjeKullanıcı
{
    public partial class LoadingScreen : Form
    {
        int sayac = 3;
        public LoadingScreen()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            sayac--;
            if (sayac == 0)
            {
                this.Dispose();

                System.GC.Collect();
                System.GC.WaitForPendingFinalizers();

            }
        }
    }
}
