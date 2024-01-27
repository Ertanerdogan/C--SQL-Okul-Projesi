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
    public partial class FrmYonlendir : Form
    {
        public FrmYonlendir()
        {
            InitializeComponent();
        }

        private void BtnOgrYonetim_MouseEnter(object sender, EventArgs e)
        {
            BtnOgrYonetim.BackColor = Color.RoyalBlue;
        }

        private void BtnOgrYonetim_MouseLeave(object sender, EventArgs e)
        {
            BtnOgrYonetim.BackColor = Color.CornflowerBlue;
        }

        private void BtnBorcYonetim_MouseEnter(object sender, EventArgs e)
        {
            BtnBorcYonetim.BackColor = Color.RoyalBlue;
        }

        private void BtnBorcYonetim_MouseLeave(object sender, EventArgs e)
        {
            BtnBorcYonetim.BackColor = Color.CornflowerBlue;
        }

        private void BtnHazirlayan_MouseEnter(object sender, EventArgs e)
        {
            BtnHazirlayan.BackColor = Color.RoyalBlue;
        }

        private void BtnHazirlayan_MouseLeave(object sender, EventArgs e)
        {
            BtnHazirlayan.BackColor = Color.CornflowerBlue;
        }

        private void BtnCikis_MouseEnter(object sender, EventArgs e)
        {
            BtnCikis.BackColor = Color.RoyalBlue;
        }

        private void BtnCikis_MouseLeave(object sender, EventArgs e)
        {
            BtnCikis.BackColor = Color.CornflowerBlue;
        }

        private void BtnOgrYonetim_Click(object sender, EventArgs e)
        {
            FrmYonetim ekran = new FrmYonetim();
            ekran.Show();
            this.Dispose();
        }

        private void BtnBorcYonetim_Click(object sender, EventArgs e)
        {
            FrmBorclar ekran = new FrmBorclar();
            ekran.Show();
            this.Dispose();
        }

        private void BtnHazirlayan_Click(object sender, EventArgs e)
        {
            MessageBox.Show("ERTAN ERDOĞAN\n220403775\nBilgisayar Mühendisliği\nGithub Profilim : https://github.com/Ertanerdogan", "Bilgi");
        }

        private void BtnCikis_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void BtnBolumYonetim_MouseEnter(object sender, EventArgs e)
        {
            BtnBolumYonetim.BackColor = Color.RoyalBlue;
        }

        private void BtnBolumYonetim_MouseLeave(object sender, EventArgs e)
        {
            BtnBolumYonetim.BackColor = Color.CornflowerBlue;
        }

        private void BtnBolumYonetim_Click(object sender, EventArgs e)
        {
            FrmBolumler ekran = new FrmBolumler();
            ekran.Show();
            this.Dispose();
        }

        private void BtnFakulteYonetim_MouseEnter(object sender, EventArgs e)
        {
            BtnFakulteYonetim.BackColor = Color.RoyalBlue;
        }

        private void BtnFakulteYonetim_MouseLeave(object sender, EventArgs e)
        {
            BtnFakulteYonetim.BackColor = Color.CornflowerBlue;
        }

        private void BtnFakulteYonetim_Click(object sender, EventArgs e)
        {
            FrmFakulteler ekran = new FrmFakulteler();
            ekran.Show();
            this.Dispose();
        }
    }
}
