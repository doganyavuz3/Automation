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
    public partial class FrmMusteriler : Form
    {
        public FrmMusteriler()
        {
            InitializeComponent();
        }
        sqlbaglatisi bgl = new sqlbaglatisi();
        void listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from TBL_MUSTERILER Order By ID Asc", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }
        void temizle()
        {
            TxtAd.Text = "";
            TxtID.Text = "";
            TxtMail.Text = "";
            TxtSoyad.Text = "";
            TxtVergiD.Text = "";
            MskTc.Text = "";
            MskTelefon1.Text = "";
            MskTelefon2.Text = "";
            RichAdres.Text = "";
            CmbIl.Text = "";
            CmbIlce.Text = "";
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
        private void FrmMusteriler_Load(object sender, EventArgs e)
        {
            listele();
            sehirlistesi();
            temizle();
        }

        private void CmbIl_SelectedIndexChanged(object sender, EventArgs e)
        {
            CmbIlce.Properties.Items.Clear();
            SqlCommand komut = new SqlCommand("Select ILCE from TBL_ILCELER where SEHIR=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", CmbIl.SelectedIndex+1);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                CmbIlce.Properties.Items.Add(dr[0]);               
            }
            bgl.baglanti().Close();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into TBL_MUSTERILER (AD,SOYAD,TELEFON,TELEFON2,TC,MAIL,IL,ILCE,ADRES,VERGIDAIRESI) values " +
                "(@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10)", bgl.baglanti());

            komut.Parameters.AddWithValue("@p1", TxtAd.Text);
            komut.Parameters.AddWithValue("@p2", TxtSoyad.Text);
            komut.Parameters.AddWithValue("@p3", MskTelefon1.Text);
            komut.Parameters.AddWithValue("@p4", MskTelefon2.Text);
            komut.Parameters.AddWithValue("@p5", MskTc.Text);
            komut.Parameters.AddWithValue("@p6", TxtMail.Text);
            komut.Parameters.AddWithValue("@p7", CmbIl.Text);
            komut.Parameters.AddWithValue("@p8", CmbIlce.Text);
            komut.Parameters.AddWithValue("@p9", RichAdres.Text);
            komut.Parameters.AddWithValue("@p10", TxtVergiD.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Müşteri sisteme başarılı bir şekilde eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
            temizle();
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
                MskTelefon2.Text = dr["TELEFON2"].ToString();
                MskTc.Text = dr["TC"].ToString();
                TxtMail.Text = dr["MAIL"].ToString();
                CmbIl.Text = dr["IL"].ToString();
                CmbIlce.Text = dr["ILCE"].ToString();
                RichAdres.Text = dr["ADRES"].ToString();
                TxtVergiD.Text = dr["VERGIDAIRESI"].ToString();               
            }
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Delete from TBL_MUSTERILER where ID=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", TxtID.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Müşteri başarıyla silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            listele();
            temizle();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update TBL_MUSTERILER set " +
                "AD=@p1,SOYAD=@p2,TELEFON=@p3,TELEFON2=@p4,TC=@p5,MAIL=@p6,IL=@p7,ILCE=@p8,ADRES=@p9,VERGIDAIRESI=@p10 where ID=@p11",bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", TxtAd.Text);
            komut.Parameters.AddWithValue("@p2", TxtSoyad.Text);
            komut.Parameters.AddWithValue("@p3", MskTelefon1.Text);
            komut.Parameters.AddWithValue("@p4", MskTelefon2.Text);
            komut.Parameters.AddWithValue("@p5", MskTc.Text);
            komut.Parameters.AddWithValue("@p6", TxtMail.Text);
            komut.Parameters.AddWithValue("@p7", CmbIl.Text);
            komut.Parameters.AddWithValue("@p8", CmbIlce.Text);
            komut.Parameters.AddWithValue("@p9", RichAdres.Text);
            komut.Parameters.AddWithValue("@p10", TxtVergiD.Text);
            komut.Parameters.AddWithValue("@p11", TxtID.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Müşteri sistemde başarılı bir şekilde güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            listele();
            temizle();
        }
        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }
    }
}
