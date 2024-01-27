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
using System.Windows.Forms.VisualStyles;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1
{
    public partial class FrmBorclar : Form
    {
        public FrmBorclar()
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
                               x.OgrBorc
                           };

            dataGridView1.DataSource = degerler.ToList();
        }

        private void temizle()
        {
            TxtID.Text = "";
            TxtAd.Text = "";
            TxtSoyad.Text = "";
            TxtBorc.Text = "";
            TxtOde.Text = "";
        }
        private void FrmBorclar_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void BtnYenile_Click(object sender, EventArgs e)
        {
            listele();
            temizle();
        }

        private void BtnYenile_MouseEnter(object sender, EventArgs e)
        {
            BtnYenile.BackColor = Color.Turquoise;
        }

        private void BtnYenile_MouseLeave(object sender, EventArgs e)
        {
            BtnYenile.BackColor = Color.Aquamarine;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                TxtID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                TxtNum.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                TxtAd.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                TxtSoyad.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                TxtBorc.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            }
        }

        private void BtnOde_MouseEnter(object sender, EventArgs e)
        {
            BtnOde.BackColor = Color.Turquoise;
        }

        private void BtnOde_MouseLeave(object sender, EventArgs e)
        {
            BtnOde.BackColor = Color.Aquamarine;
        }

        private void BtnOde_Click(object sender, EventArgs e)
        {
            if(TxtID.Text != "")
            {
                if (TxtOde.Text != "")
                {
                    int borc = int.Parse(TxtBorc.Text);
                    int odenecek = int.Parse(TxtOde.Text);
                    if (odenecek > 0)
                    {
                        int yeniborc = 0;
                        int paraustu = 0;
                        if (borc > odenecek)
                        {
                            paraustu = 0;
                            yeniborc = borc - odenecek;
                        }
                        else
                        {
                            paraustu = odenecek - borc;
                            yeniborc = 0;
                        }
                        int secilen = int.Parse(TxtID.Text);
                        var x = db.TblOgr.Find(secilen);
                        x.OgrBorc = yeniborc;
                        db.SaveChanges();
                        MessageBox.Show("Borç başarıyla ödendi\nYeni borcunuz :" + yeniborc.ToString() + "\nPara üstü : " + paraustu.ToString());
                        listele();
                        temizle();
                    }
                    else
                    {
                        MessageBox.Show("0 TL ve altında ödeme yapamazsınız", "Uyarı");
                    }
                }
                else
                {
                    MessageBox.Show("Lütfen ödenecek miktarı giriniz", "Uyarı");
                }
            }
            else
            {
                MessageBox.Show("Lütfen ödeme yapacak öğrenciyi seçiniz");
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
