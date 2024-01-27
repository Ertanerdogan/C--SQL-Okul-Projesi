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
using WindowsFormsApp1.DbOkulProjeDataSetTableAdapters;

namespace WindowsFormsApp1
{
    public partial class FrmYonetim : Form
    {
        public FrmYonetim()
        {
            InitializeComponent();
        }
        DbOkulProjeEntities db = new DbOkulProjeEntities();
        SqlConnection baglanti = new SqlConnection(@"Data Source=ERTAN\SQLEXPRESS;Initial Catalog=DbOkulProje;Integrated Security=True");
        private void listele()
        {
            var degerler = from x in db.TblOgr
                           select new
                           {
                               x.OgrID,
                               x.OgrNumara,
                               x.OgrAd,
                               x.OgrSoyad,
                               x.OgrFakulte,
                               x.TblFakulte.FakulteAd,
                               x.OgrBolum,
                               x.TblBolum.BolumAd,
                               x.OgrBurs,
                               x.TblBolum.BolumUcret,
                           };
            
            dataGridView1.DataSource = degerler.ToList();
            dataGridView1.Columns["BolumUcret"].Visible = false;
            dataGridView1.Columns["OgrID"].Visible = false;
            dataGridView1.Columns["OgrFakulte"].Visible = false;
            dataGridView1.Columns["OgrBolum"].Visible = false;
        }

        private void bolumliste()
        {
            var degerler = from x in db.TblOgr
                           select new
                           {
                               x.OgrID,
                               x.OgrNumara,
                               x.OgrAd,
                               x.OgrSoyad,
                               x.OgrFakulte,
                               x.TblFakulte.FakulteAd,
                               x.OgrBolum,
                               x.TblBolum.BolumAd,
                               x.OgrBurs,
                               x.TblBolum.BolumUcret,
                           };

            dataGridView1.DataSource = degerler.Where(x => x.BolumAd == TxtAra.Text).ToList();
            dataGridView1.Columns["BolumUcret"].Visible = false;
            dataGridView1.Columns["OgrID"].Visible = false;
            dataGridView1.Columns["OgrFakulte"].Visible = false;
            dataGridView1.Columns["OgrBolum"].Visible = false;
        }

        private void numliste()
        {
            var degerler = from x in db.TblOgr
                           select new
                           {
                               x.OgrID,
                               x.OgrNumara,
                               x.OgrAd,
                               x.OgrSoyad,
                               x.OgrFakulte,
                               x.TblFakulte.FakulteAd,
                               x.OgrBolum,
                               x.TblBolum.BolumAd,
                               x.OgrBurs,
                               x.TblBolum.BolumUcret,
                           };

            dataGridView1.DataSource = degerler.Where(x => x.OgrNumara.ToString() == TxtAra.Text).ToList();
            dataGridView1.Columns["BolumUcret"].Visible = false;
            dataGridView1.Columns["OgrID"].Visible = false;
            dataGridView1.Columns["OgrFakulte"].Visible = false;
            dataGridView1.Columns["OgrBolum"].Visible = false;
        }

        private void combobox()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT * FROM TblFakulte",baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            comboBox1.DisplayMember = "FakulteAd";
            comboBox1.ValueMember = "FakulteID";
            comboBox1.DataSource = dt;
            baglanti.Close();
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("SELECT * FROM TblBolum where BolumFakulte = @p1", baglanti);
            komut2.Parameters.AddWithValue("@p1",comboBox1.SelectedValue);
            SqlDataAdapter da2 = new SqlDataAdapter (komut2);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            comboBox2.DisplayMember = "BolumAd";
            comboBox2.ValueMember = "BolumID";
            comboBox2.DataSource = dt2;
            baglanti.Close();
        }

        private void FrmYonetim_Load(object sender, EventArgs e)
        {
            listele();
            combobox();
        }

        private void temizle()
        {
            TxtID.Text = "";
            TxtNum.Text = "";
            TxtAd.Text = "";
            TxtSoyad.Text = "";
            //TxtFak.Text = "";
            //TxtBolum.Text = "";
            TxtBurs.Text = "";
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                TxtID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                TxtNum.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                TxtAd.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                TxtSoyad.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                comboBox1.SelectedValue = dataGridView1.Rows[e.RowIndex].Cells["OgrFakulte"].Value.ToString();
                comboBox2.SelectedValue = dataGridView1.Rows[e.RowIndex].Cells["OgrBolum"].Value.ToString();
                TxtBurs.SelectedItem = dataGridView1.Rows[e.RowIndex].Cells["OgrBurs"].Value.ToString();
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

        private void BtnYenile_Click(object sender, EventArgs e)
        {
            listele();
            temizle();
        }

        private void BtnEkle_MouseEnter(object sender, EventArgs e)
        {
            BtnEkle.BackColor = Color.Turquoise;
        }

        private void BtnEkle_MouseLeave(object sender, EventArgs e)
        {
            BtnEkle.BackColor = Color.Aquamarine;
        }

        private int num_kontrol()
        {
            int num = int.Parse(TxtNum.Text);
            int sayac = 0;
            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT OgrNumara From TblOgr where OgrNumara = @p1",baglanti);
            komut.Parameters.AddWithValue("@p1", num);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                sayac ++;
            }
            baglanti.Close();
            return sayac;
        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            int kont = num_kontrol();
            if(kont >= 1)
            {
                MessageBox.Show("Numara zaten kullanılıyor","Uyarı",MessageBoxButtons.OK, MessageBoxIcon.Error);
                listele();
                temizle();
            }
            else
            {
                baglanti.Open();
                TblOgr x = new TblOgr();
                x.OgrNumara = int.Parse(TxtNum.Text);
                x.OgrAd = TxtAd.Text;
                x.OgrSoyad = TxtSoyad.Text;
                x.OgrFakulte = int.Parse(comboBox1.SelectedValue.ToString());
                x.OgrBolum = int.Parse(comboBox2.SelectedValue.ToString());
                x.OgrBurs = int.Parse(TxtBurs.Text);
                SqlCommand komut = new SqlCommand("SELECT BolumUcret From TblBolum where BolumID = @p1", baglanti);
                komut.Parameters.AddWithValue("@p1", comboBox2.SelectedValue);
                SqlDataReader dr = komut.ExecuteReader();
                string ucret;
                if (dr.Read())
                {
                    ucret = dr.GetValue(0).ToString();
                    int borc = borc_hesapla(int.Parse(ucret),int.Parse(TxtBurs.SelectedItem.ToString()));
                    x.OgrBorc = borc;
                }
                db.TblOgr.Add(x);
                db.SaveChanges();
                baglanti.Close();
                MessageBox.Show("Öğrenci başarıyla eklendi","Bilgilendirme",MessageBoxButtons.OK,MessageBoxIcon.Information);
                listele();
                temizle();
            }
        }

        private int borc_hesapla(int ucret , int burs)
        {
            if(burs == 25)
            {
                ucret =  3 *(ucret / 4);
            }
            else if(burs == 50)
            {
                ucret = ucret / 2;
            }
            else if(burs == 75)
            {
                ucret = ucret / 4;
            }
            else if(burs == 100)
            {
                ucret = 0;
            }
            return ucret;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int secilen = int.Parse(comboBox1.SelectedValue.ToString());
            SqlCommand komut = new SqlCommand("SELECT * FROM TblBolum where BolumFakulte = @p1",baglanti);
            komut.Parameters.AddWithValue("@p1", secilen);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            comboBox2.DisplayMember = "BolumAd";
            comboBox2.ValueMember = "BolumID";
            comboBox2.DataSource = dt;
        }

        private void BtnSil_MouseEnter(object sender, EventArgs e)
        {
            BtnSil.BackColor = Color.Turquoise;
        }

        private void BtnSil_MouseLeave(object sender, EventArgs e)
        {
            BtnSil.BackColor = Color.Aquamarine;
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            if(TxtNum.Text != "")
            {
                DialogResult a = MessageBox.Show("Silmek istediğinize emin misiniz ?","Soru",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                if(a == DialogResult.Yes)
                {
                    int secilen = int.Parse(TxtID.Text);
                    var x = db.TblOgr.Find(secilen);
                    db.TblOgr.Remove(x);
                    db.SaveChanges();
                    MessageBox.Show("Öğrenci başarıyla silindi","Bilgi");
                    listele();
                    temizle();
                }
                else
                {
                    MessageBox.Show("Öğrenci silinmedi", "Bilgi");
                }
            }
            else
            {
                MessageBox.Show("Lütfen silmek istediğiniz öğrencinin numarasını giriniz","Uyarı",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            
        }

        private void BtnGuncelle_MouseEnter(object sender, EventArgs e)
        {
            BtnGuncelle.BackColor = Color.Turquoise;
        }

        private void BtnGuncelle_MouseLeave(object sender, EventArgs e)
        {
            BtnGuncelle.BackColor = Color.Aquamarine;
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            if(TxtAd.Text != "" && TxtID.Text != "" && TxtSoyad.Text != "" && TxtNum.Text != "")
            {
                int secilen = int.Parse(TxtID.Text);
                var x = db.TblOgr.Find(secilen);
                int kontrol = num_kontrol();
                if(kontrol == 0)
                {
                    MessageBox.Show("Öğrenci bulunamıyor", "Uyarı");
                }
                else if (kontrol == 1)
                {
                    DialogResult a = MessageBox.Show("Öğrencinin bilgilerini güncellemek istediğinize emin misiniz ?", "Soru",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if(a == DialogResult.Yes)
                    {
                        x.OgrNumara = int.Parse(TxtNum.Text);
                        x.OgrAd = TxtAd.Text;
                        x.OgrSoyad = TxtSoyad.Text;
                        db.SaveChanges();
                        MessageBox.Show("Öğrencinin bilgileri başarıyla güncellendi", "Bilgi");
                        listele();
                        temizle();

                    }
                    else
                    {
                        MessageBox.Show("Öğrencinin bilgileri güncellenmdi", "Bilgi");
                        listele();
                        temizle();
                    }
                    
                }
            }
            else
            {
                MessageBox.Show("Lütfen bilgilerini güncellemek istediğiniz öğrenciyi seçiniz", "Uyarı");
            }
        }

        private void BtnAra_MouseEnter(object sender, EventArgs e)
        {
            BtnAra.BackColor = Color.Turquoise;
        }

        private void BtnAra_MouseLeave(object sender, EventArgs e)
        {
            BtnAra.BackColor = Color.Aquamarine;
        }

        private void BtnAra_Click(object sender, EventArgs e)
        {
            
            if (RdbBolum.Checked)
            {
                bolumliste();
            }
            else if (RdbNum.Checked)
            {
                numliste();
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
