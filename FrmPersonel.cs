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
    public partial class FrmPersonel : Form
    {
        public FrmPersonel()
        {
            InitializeComponent();
        }
        sqlbaglatisi bgl = new sqlbaglatisi();

        void personelliste()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from TBL_PERSONELLER", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }
        void sehirlistesi()
        {
            SqlCommand komut = new SqlCommand("Select SEHIR from TBL_ILLER", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                CmbIl.Properties.Items.Add(dr[0]);
            }
            bgl.baglanti().Close();
        }
        private void FrmPersonel_Load(object sender, EventArgs e)
        {
            personelliste();
            sehirlistesi();
            temizle();
        }
        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into TBL_PERSONELLER(AD,SOYAD,TELEFON,TC,MAIL,IL,ILCE,ADRES,GOREV) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9) ", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", TxtAd.Text);
            komut.Parameters.AddWithValue("@p2", TxtSoyad.Text);
            komut.Parameters.AddWithValue("@p3", MskTelefon1.Text);
            komut.Parameters.AddWithValue("@p4", MskTc.Text);
            komut.Parameters.AddWithValue("@p5", TxtMail.Text);
            komut.Parameters.AddWithValue("@p6", CmbIl.Text);
            komut.Parameters.AddWithValue("@p7", CmbIlce.Text);
            komut.Parameters.AddWithValue("@p8", RichAdres.Text);
            komut.Parameters.AddWithValue("@p9", TxtGorev.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Personel bilgileri başarıyla kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            personelliste();          
        }
        private void CmbIl_SelectedIndexChanged(object sender, EventArgs e)
        {
            CmbIlce.Properties.Items.Clear();
            SqlCommand komut = new SqlCommand("Select ILCE from TBL_ILCELER where SEHIR=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", CmbIl.SelectedIndex + 1);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                CmbIlce.Properties.Items.Add(dr[0]);
            }
            bgl.baglanti().Close();
        }
        void temizle()
        {
            TxtID.Text = "";
            TxtAd.Text = "";
            TxtGorev.Text = "";
            TxtSoyad.Text = "";
            TxtMail.Text = "";
            MskTc.Text = "";
            MskTelefon1.Text = "";
            CmbIl.Text = "";
            CmbIlce.Text = "";
            RichAdres.Text = "";
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr!=null)
            {
                TxtID.Text = dr["ID"].ToString();
                TxtAd.Text = dr["AD"].ToString();
                TxtSoyad.Text = dr["SOYAD"].ToString();
                MskTelefon1.Text = dr["TELEFON"].ToString();
                MskTc.Text = dr["TC"].ToString();
                TxtMail.Text = dr["MAIL"].ToString();
                CmbIl.Text = dr["IL"].ToString();
                CmbIlce.Text = dr["ILCE"].ToString();
                RichAdres.Text = dr["ADRES"].ToString();
                TxtGorev.Text = dr["GOREV"].ToString();
            }
        }
        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }
        private void BtnSil_Click(object sender, EventArgs e)
        {
            SqlCommand komutsil = new SqlCommand("delete from TBL_PERSONELLER where ID=@p1", bgl.baglanti());
            komutsil.Parameters.AddWithValue("@p1", TxtID.Text);
            komutsil.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Personel başarıyla silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            personelliste();
            temizle();
        }
        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Update TBL_PERSONELLER set AD=@p1,SOYAD=@p2,TELEFON=@p3,TC=@p4,MAIL=@p5,IL=@p6,ILCE=@p7,ADRES=@p8,GOREV=@p9 where ID=@p10", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", TxtAd.Text);
            komut.Parameters.AddWithValue("@p2", TxtSoyad.Text);
            komut.Parameters.AddWithValue("@p3", MskTelefon1.Text);
            komut.Parameters.AddWithValue("@p4", MskTc.Text);
            komut.Parameters.AddWithValue("@p5", TxtMail.Text);
            komut.Parameters.AddWithValue("@p6", CmbIl.Text);
            komut.Parameters.AddWithValue("@p7", CmbIlce.Text);
            komut.Parameters.AddWithValue("@p8", RichAdres.Text);
            komut.Parameters.AddWithValue("@p9", TxtGorev.Text);
            komut.Parameters.AddWithValue("@p10", TxtID.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Personel bilgileri başarıyla güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            personelliste();
        }
    }
}
