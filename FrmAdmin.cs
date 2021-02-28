using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ticari_otomasyon
{
    public partial class FrmAdmin : Form
    {
        public FrmAdmin()
        {
            InitializeComponent();
        }
        sqlbaglatisi bgl = new sqlbaglatisi();
        private void button1_MouseHover(object sender, EventArgs e)
        {
            BtnGiris.BackColor = Color.AliceBlue;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            BtnGiris.BackColor = Color.Gray;
        }

        private void BtnGiris_Click(object sender, EventArgs e)
        {
            
            SqlCommand komut = new SqlCommand("Select * From TBL_ADMIN where KullaniciAd=@p1 and Sifre=@p2", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", TxtKullaniciAd.Text);
            komut.Parameters.AddWithValue("@p2", TxtSifre.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                FrmAnaModul fr = new FrmAnaModul();
                fr.kullanici = TxtKullaniciAd.Text;
                fr.Show();
                this.Hide();

            }
            else
            {
                MessageBox.Show("Hatalı Kullanıcı Adı veya Şifre","", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }

            bgl.baglanti().Close();
        }
    }
}
