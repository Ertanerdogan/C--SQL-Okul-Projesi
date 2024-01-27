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
    public partial class FrmBolumler : Form
    {
        public FrmBolumler()
        {
            InitializeComponent();
        }
        DbOkulProjeEntities db = new DbOkulProjeEntities();
        SqlConnection baglanti = new SqlConnection(@"Data Source=ERTAN\SQLEXPRESS;Initial Catalog=DbOkulProje;Integrated Security=True");

        private void listele()
        {
            var degerler = from x in db.TblBolum
                           select new
                           {
                               x.BolumID,
                               x.BolumFakulte,
                               x.TblFakulte.FakulteAd,
                               x.BolumAd,
                               x.BolumUcret
                           };
            dataGridView1.DataSource = degerler.ToList();
            dataGridView1.Columns["BolumFakulte"].Visible = false;
        }

        private void temizle()
        {
            TxtID.Text = "";
            TxtBolum.Text = "";
            TxtUcret.Text = "";
        }

        private void combobox()
        {
            SqlCommand komut = new SqlCommand("SELECT * From TblFakulte", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            comboBox1.ValueMember = "FakulteID";
            comboBox1.DisplayMember = "FakulteAd";
            comboBox1.DataSource = dt;
        }
        private void FrmBolumler_Load(object sender, EventArgs e)
        {
            listele();
            combobox();
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                TxtID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                comboBox1.SelectedValue = dataGridView1.Rows[e.RowIndex].Cells["BolumFakulte"].Value.ToString();
                TxtBolum.Text = dataGridView1.Rows[e.RowIndex].Cells["BolumAd"].Value.ToString();
                TxtUcret.Text = dataGridView1.Rows[e.RowIndex].Cells["BolumUcret"].Value.ToString();
            }
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
            if(TxtBolum.Text != "")
            {
                DialogResult a = MessageBox.Show("Bölümü eklemek istediğinize emin misiniz ?","Soru",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                if(a == DialogResult.Yes)
                {
                    TblBolum x = new TblBolum();
                    x.BolumFakulte = int.Parse(comboBox1.SelectedValue.ToString());
                    x.BolumAd = TxtBolum.Text;
                    x.BolumUcret = int.Parse(TxtUcret.Text);
                    db.TblBolum.Add(x);
                    db.SaveChanges();
                    MessageBox.Show("Bölüm başarıyla eklendi", "Bilgi");
                    listele();
                    temizle();
                }
                else
                {
                    MessageBox.Show("Bölüm eklenmedi", "Bilgi");
                }
            }
            else
            {
                MessageBox.Show("Lütfen eklemek istediğiniz bölümün adını giriniz", "Uyarı");
            }
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            if(TxtUcret.Text != "" && TxtBolum.Text != "" && TxtID.Text != "")
            {
                DialogResult a = MessageBox.Show("Bölümün bilgilerini değiştirmek istediğinize emin misiniz ?","Soru",MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (a == DialogResult.Yes)
                {
                    int secilen = int.Parse(TxtID.Text);
                    var x = db.TblBolum.Find(secilen);
                    x.BolumAd = TxtBolum.Text;
                    x.BolumUcret = int.Parse(TxtUcret.Text);
                    db.SaveChanges();
                    MessageBox.Show("Bölümün bilgileri başarıyla güncellendi");
                    listele();
                    temizle();
                }
                else
                {
                    MessageBox.Show("Bölümün bilgileri güncellenmedi","Bilgi");
                }
            }
            else
            {
                MessageBox.Show("Lütfen bilgilerini güncellemek istediğiniz bölümü seçiniz", "Uyarı");
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            FrmYonlendir ekran = new FrmYonlendir();
            ekran.Show();
            this.Dispose();
        }
    }
}
