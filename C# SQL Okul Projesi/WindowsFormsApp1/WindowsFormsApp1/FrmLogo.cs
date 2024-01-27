using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class FrmLogo : Form
    {
        public FrmLogo()
        {
            InitializeComponent();
        }
        int sayac = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if(sayac == 3)
            {
                timer1.Stop();
                FrmYonlendir ekran = new FrmYonlendir();
                ekran.Show();
                this.Hide();
            }
            sayac++;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }
    }
}
