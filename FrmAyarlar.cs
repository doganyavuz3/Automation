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
    public partial class FrmAyarlar : Form
    {
        public FrmAyarlar()
        {
            InitializeComponent();
        }
        sqlbaglatisi bgl = new sqlbaglatisi();
        void listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from TBL_ADMIN", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }
        private void FrmAyarlar_Load(object sender, EventArgs e)
        {
            listele();
            TxtKullaniciad.Text = "";
            TxtSifre.Text = "";

        }

        private void BtnIslem_Click(object sender, EventArgs e)
        {
            if (BtnIslem.Text == "Kaydet")
            {

                SqlCommand komut = new SqlCommand("insert into TBL_ADMIN values(@p1,@p2)", bgl.baglanti());
                komut.Parameters.AddWithValue("@p1", TxtKullaniciad.Text);
                komut.Parameters.AddWithValue("@p2", TxtSifre.Text);
                komut.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Yeni kullanıcı sisteme başarıyla kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                listele();
            }
            if(BtnIslem.Text =="Güncelle")
            {
                SqlCommand komut1 = new SqlCommand("update TBL_ADMIN set Sifre=@p2 where KullaniciAd=@p1", bgl.baglanti());
                komut1.Parameters.AddWithValue("@p1", TxtKullaniciad.Text);
                komut1.Parameters.AddWithValue("@p2", TxtSifre.Text);
                komut1.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Kayıt başarıyla güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                listele();
            }

        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr !=null)
            {
                TxtKullaniciad.Text = dr["KullaniciAd"].ToString();
                TxtSifre.Text = dr["Sifre"].ToString();
            }
        }

        private void TxtKullaniciad_TextChanged(object sender, EventArgs e)
        {
            if(TxtKullaniciad.Text !="")
            {
                BtnIslem.Text = "Güncelle";
                BtnIslem.BackColor = Color.GreenYellow;
            }
            else
            {
                BtnIslem.Text = "Kaydet";
                BtnIslem.BackColor = Color.LemonChiffon;
            }
        }
    }
}
