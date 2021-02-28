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
    public partial class FrmFaturalar : Form
    {
        public FrmFaturalar()
        {
            InitializeComponent();
        }
        sqlbaglatisi bgl = new sqlbaglatisi();
        void listele()
        {
            SqlDataAdapter da = new SqlDataAdapter("Select * from TBL_FATURABILGI Order By ID Asc", bgl.baglanti());
            DataTable dt = new DataTable();
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }
        void temizle()
        {
            TxtAlici.Text = "";
            TxtID.Text = "";
            TxtSeri.Text = "";
            TxtSiraNo.Text = "";
            TxtTeslimAlan.Text = "";
            TxtTeslimEden.Text = "";
            TxtVergiDairesi.Text = "";
            MskSaat.Text = "";
            MskTarih.Text = "";
        }
        private void FrmFaturalar_Load(object sender, EventArgs e)
        {
            listele();
            temizle();

        }
        private void BtnKaydet_Click_1(object sender, EventArgs e)
        {
            //Firma Carisi
            if (TxtFatura.Text == "")
            {
                SqlCommand komut = new SqlCommand("insert into TBL_FATURABILGI (SERI,SIRANO,TARIH,SAAT,VERGIDAIRESI,ALICI,TESLIMEDEN,TESLIMALAN) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8)", bgl.baglanti());
                komut.Parameters.AddWithValue("@p1", TxtSeri.Text);
                komut.Parameters.AddWithValue("@p2", TxtSiraNo.Text);
                komut.Parameters.AddWithValue("@p3", MskTarih.Text);
                komut.Parameters.AddWithValue("@p4", MskSaat.Text);
                komut.Parameters.AddWithValue("@p5", TxtVergiDairesi.Text);
                komut.Parameters.AddWithValue("@p6", TxtAlici.Text);
                komut.Parameters.AddWithValue("@p7", TxtTeslimEden.Text);
                komut.Parameters.AddWithValue("@p8", TxtTeslimAlan.Text);
                komut.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Fatura bilgisi sisteme başarıyla kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                listele();
            }
            if (TxtFatura.Text != "" && comboBoxEdit1.Text == "Firma")
            {
                double miktar, tutar, fiyat;
                fiyat = Convert.ToDouble(TxtUrünFiyat.Text);
                miktar = Convert.ToDouble(TxtUrünMiktar.Text);
                tutar = miktar * fiyat;
                TxtUrünTutar.Text = tutar.ToString();
                SqlCommand komut2 = new SqlCommand("insert into TBL_FATURADETAY (URUNAD,MIKTAR,FIYAT,TUTAR,FATURAID) values (@p1,@p2,@p3,@p4,@p5)", bgl.baglanti());
                komut2.Parameters.AddWithValue("@p1", TxtUrünAd.Text);
                komut2.Parameters.AddWithValue("@p2", TxtUrünMiktar.Text);
                komut2.Parameters.AddWithValue("@p3", decimal.Parse(TxtUrünFiyat.Text));
                komut2.Parameters.AddWithValue("@p4", decimal.Parse(TxtUrünTutar.Text));
                komut2.Parameters.AddWithValue("@p5", TxtFatura.Text);
                komut2.ExecuteNonQuery();
                bgl.baglanti().Close();

                //Hareket Tablosuna Veri Girişi
                SqlCommand komut3 = new SqlCommand("insert into TBL_FIRMAHAREKETLER (URUNID,ADET,PERSONEL,FIRMA,FIYAT,TOPLAM,FATURAID,TARIH) values (@h1,@h2,@h3,@h4,@h5,@h6,@h7,@h8)", bgl.baglanti());
                komut3.Parameters.AddWithValue("@h1", TxtUrünID.Text);
                komut3.Parameters.AddWithValue("@h2", TxtUrünMiktar.Text);
                komut3.Parameters.AddWithValue("@h3", TxtPersonel.Text);
                komut3.Parameters.AddWithValue("@h4", TxtFirma.Text);
                komut3.Parameters.AddWithValue("@h5", decimal.Parse(TxtUrünFiyat.Text));
                komut3.Parameters.AddWithValue("@h6", decimal.Parse(TxtUrünTutar.Text));
                komut3.Parameters.AddWithValue("@h7", TxtFatura.Text);
                komut3.Parameters.AddWithValue("@h8", MskTarih.Text);
                komut3.ExecuteNonQuery();
                bgl.baglanti().Close();
                //Stok Sayısını Azaltma
                SqlCommand komut4 = new SqlCommand("update TBL_URUNLER set ADET=ADET-@s1 where ID=@s2", bgl.baglanti());
                komut4.Parameters.AddWithValue("@s1", TxtUrünMiktar.Text);
                komut4.Parameters.AddWithValue("@s2", TxtUrünID.Text);
                komut4.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Faturaya ait ürün başarıyla kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
            }

            //Müşteri Carisi

            if (TxtFatura.Text != "" && comboBoxEdit1.Text == "Müşteri")
            {
                double miktar, tutar, fiyat;
                fiyat = Convert.ToDouble(TxtUrünFiyat.Text);
                miktar = Convert.ToDouble(TxtUrünMiktar.Text);
                tutar = miktar * fiyat;
                TxtUrünTutar.Text = tutar.ToString();
                SqlCommand komut2 = new SqlCommand("insert into TBL_FATURADETAY (URUNAD,MIKTAR,FIYAT,TUTAR,FATURAID) values (@p1,@p2,@p3,@p4,@p5)", bgl.baglanti());
                komut2.Parameters.AddWithValue("@p1", TxtUrünAd.Text);
                komut2.Parameters.AddWithValue("@p2", TxtUrünMiktar.Text);
                komut2.Parameters.AddWithValue("@p3", decimal.Parse(TxtUrünFiyat.Text));
                komut2.Parameters.AddWithValue("@p4", decimal.Parse(TxtUrünTutar.Text));
                komut2.Parameters.AddWithValue("@p5", TxtFatura.Text);
                komut2.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Fatura bilgisi sisteme başarıyla kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                

                //Hareket Tablosuna Veri Girişi
                SqlCommand komut3 = new SqlCommand("insert into TBL_MUSTERIHAREKETLER (URUNID,ADET,PERSONEL,MUSTERI,FIYAT,TOPLAM,FATURAID,TARIH) values (@h1,@h2,@h3,@h4,@h5,@h6,@h7,@h8)", bgl.baglanti());
                komut3.Parameters.AddWithValue("@h1", TxtUrünID.Text);
                komut3.Parameters.AddWithValue("@h2", TxtUrünMiktar.Text);
                komut3.Parameters.AddWithValue("@h3", TxtPersonel.Text);
                komut3.Parameters.AddWithValue("@h4", TxtFirma.Text);
                komut3.Parameters.AddWithValue("@h5", decimal.Parse(TxtUrünFiyat.Text));
                komut3.Parameters.AddWithValue("@h6", decimal.Parse(TxtUrünTutar.Text));
                komut3.Parameters.AddWithValue("@h7", TxtFatura.Text);
                komut3.Parameters.AddWithValue("@h8", MskTarih.Text);
                komut3.ExecuteNonQuery();
                bgl.baglanti().Close();

                //Stok Sayısını Azaltma
                SqlCommand komut4 = new SqlCommand("update TBL_URUNLER set ADET=ADET-@s1 where ID=@s2", bgl.baglanti());
                komut4.Parameters.AddWithValue("@s1", TxtUrünMiktar.Text);
                komut4.Parameters.AddWithValue("@s2", TxtUrünID.Text);
                komut4.ExecuteNonQuery();
                bgl.baglanti().Close();
            }
        }
        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {
                TxtID.Text = dr["ID"].ToString();
                TxtSiraNo.Text = dr["SIRANO"].ToString();
                TxtSeri.Text = dr["SERI"].ToString();
                MskTarih.Text = dr["TARIH"].ToString();
                MskSaat.Text = dr["SAAT"].ToString();
                TxtAlici.Text = dr["ALICI"].ToString();
                TxtTeslimEden.Text = dr["TESLIMEDEN"].ToString();
                TxtTeslimAlan.Text = dr["TESLIMALAN"].ToString();
                TxtVergiDairesi.Text = dr["VERGIDAIRESI"].ToString();
            }
           
        }
        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }
      
        private void BtnTemizle_Click_1(object sender, EventArgs e)
        {
            temizle();
        }
        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Update TBL_FATURABILGI set SERI=@p1,SIRANO=@p2,TARIH=@p3,SAAT=@p4,VERGIDAIRESI=@p5,ALICI=@p6,TESLIMEDEN=@p7,TESLIMALAN=@p8 where ID=@p9", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", TxtSeri.Text);
            komut.Parameters.AddWithValue("@p2", TxtSiraNo.Text);
            komut.Parameters.AddWithValue("@p3", MskTarih.Text);
            komut.Parameters.AddWithValue("@p4", MskSaat.Text);
            komut.Parameters.AddWithValue("@p5", TxtVergiDairesi.Text);
            komut.Parameters.AddWithValue("@p6", TxtAlici.Text);
            komut.Parameters.AddWithValue("@p7", TxtTeslimEden.Text);
            komut.Parameters.AddWithValue("@p8", TxtTeslimAlan.Text);
            komut.Parameters.AddWithValue("@p9", TxtID.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Fatura bilgisi sistemde başarıyla güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
        }
        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            FrmFaturaUrunler fr = new FrmFaturaUrunler();
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr!=null)
            {
                fr.id = dr["ID"].ToString();
                fr.Show();
            }
        }
        private void BtnBul_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Select URUNAD,SATISFIYAT FROM TBL_URUNLER where ID=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", TxtUrünID.Text);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                TxtUrünAd.Text = dr[0].ToString();
                TxtUrünFiyat.Text = dr[1].ToString();
         }
            bgl.baglanti().Close();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Delete from TBL_FATURABILGI where ID=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", TxtID.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Fatura başarıyla silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            listele();
        }
    }
}
