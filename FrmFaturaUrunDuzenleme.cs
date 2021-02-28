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
    public partial class FrmFaturaUrunDuzenleme : Form
    {
        public FrmFaturaUrunDuzenleme()
        {
            InitializeComponent();
        }
        public string urunid;
        sqlbaglatisi bgl = new sqlbaglatisi();
       
        private void FrmFaturaUrunDuzenleme_Load(object sender, EventArgs e)
        {
            TxtUrünID.Text=urunid;
            SqlCommand komut = new SqlCommand("Select * from TBL_FATURADETAY where FATURAURUNID=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", urunid);
            SqlDataReader dr = komut.ExecuteReader();
            while(dr.Read())
            {
                TxtUrünFiyat.Text = dr[3].ToString();
                TxtUrünMiktar.Text = dr[2].ToString();
                TxtUrünTutar.Text = dr[4].ToString();
                TxtUrünAd.Text = dr[1].ToString();
                bgl.baglanti().Close();

            }

        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Update TBL_FATURADETAY set URUNAD=@p1,MIKTAR=@p2,FIYAT=@p3,TUTAR=@p4 where FATURAURUNID=@p5", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", TxtUrünAd.Text);
            komut.Parameters.AddWithValue("@p2", TxtUrünMiktar.Text);
            komut.Parameters.AddWithValue("@p3",decimal.Parse( TxtUrünFiyat.Text));
            komut.Parameters.AddWithValue("@p4",decimal.Parse( TxtUrünTutar.Text));
            komut.Parameters.AddWithValue("@p5", TxtUrünID.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Değişiklikler başarıyla kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Delete from TBL_FATURADETAY where FATURAURUNID=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", TxtUrünID.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Ürün başarıyla silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
    }
}
