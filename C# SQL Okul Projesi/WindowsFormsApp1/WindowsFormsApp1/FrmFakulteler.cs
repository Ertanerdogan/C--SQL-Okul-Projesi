using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1
{
    public partial class FrmFakulteler : Form
    {
        public FrmFakulteler()
        {
            InitializeComponent();
        }
        DbOkulProjeEntities db = new DbOkulProjeEntities();
        SqlConnection baglanti = new SqlConnection(@"Data Source=ERTAN\SQLEXPRESS;Initial Catalog=DbOkulProje;Integrated Security=True");
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            FrmYonlendir ekran = new FrmYonlendir();
            ekran.Show();
            this.Dispose();
        }

        private void listele()
        {
            var degerler = from x in db.TblFakulte
                           select new
                           {
                               x.FakulteID,
                               x.FakulteAd
                           };
            dataGridView1.DataSource = degerler.ToList();
        }

        private void temizle()
        {
            TxtAd.Text = "";
            TxtID.Text = "";
        }
        private void FrmFakulteler_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void BtnYenile_MouseEnter(object sender, EventArgs e)
        {
            BtnYenile.BackColor = Color.Turquoise;
        }

        private void BtnYenile_MouseLeave(object sender, EventArgs e)
        {
            BtnYenile.BackColor = Color.Aquamarine;
        }

        private void BtnEkle_MouseEnter(object sender, EventArgs e)
        {
            BtnEkle.BackColor = Color.Turquoise;
        }

        private void BtnEkle_MouseLeave(object sender, EventArgs e)
        {
            BtnEkle.BackColor = Color.Aquamarine;
        }

        private void BtnGuncelle_MouseEnter(object sender, EventArgs e)
        {
            BtnGuncelle.BackColor = Color.Turquoise;
        }

        private void BtnGuncelle_MouseLeave(object sender, EventArgs e)
        {
            BtnGuncelle.BackColor = Color.Aquamarine;
        }

        private void BtnYenile_Click(object sender, EventArgs e)
        {
            listele();
            temizle();
        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            if (TxtAd.Text != "")
            {
                DialogResult a = MessageBox.Show("Fakülteyi eklemek istediğinize emin misiniz ?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (a == DialogResult.Yes)
                {
                   TblFakulte x = new TblFakulte();
                    x.FakulteAd = TxtAd.Text;
                    db.TblFakulte.Add(x);
                    db.SaveChanges();
                    MessageBox.Show("Fakülte başarıyla eklendi","Bilgi");
                    listele();
                    temizle();
                }
                else
                {
                    MessageBox.Show("Fakülte eklenmedi", "Bilgi");
                }
            }
            else
            {
                MessageBox.Show("Lütfen eklemek istediğiniz fakültenin adını giriniz", "Uyarı");
            }
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            if (TxtAd.Text != "" && TxtID.Text != "")
            {
                DialogResult a = MessageBox.Show("Fakültenin bilgilerini değiştirmek istediğinize emin misiniz ?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (a == DialogResult.Yes)
                {
                    int secilen = int.Parse(TxtID.Text);
                    var x = db.TblFakulte.Find(secilen);
                    x.FakulteAd = TxtAd.Text;
                    db.SaveChanges();
                    MessageBox.Show("Fakültenin bilgileri başarıyla güncellendi");
                    listele();
                    temizle();
                }
                else
                {
                    MessageBox.Show("Fakültenin bilgileri güncellenmedi", "Bilgi");
                }
            }
            else
            {
                MessageBox.Show("Lütfen bilgilerini güncellemek istediğiniz fakülteyi seçiniz", "Uyarı");
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                TxtID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                TxtAd.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            }
        }
    }
}
