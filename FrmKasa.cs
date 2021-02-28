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
using DevExpress.Charts;

namespace ticari_otomasyon
{
    public partial class FrmKasa : Form
    {
        public FrmKasa()
        {
            InitializeComponent();
        }
        sqlbaglatisi bgl = new sqlbaglatisi();
        void musterihareket()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Execute MusteriHareketler", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }
        void firmahareket()
        {
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("Execute FirmaHareketler", bgl.baglanti());
            da2.Fill(dt2);
            gridControl3.DataSource = dt2;
        }
        void faturahareket()
        {
            DataTable dt3 = new DataTable();
            SqlDataAdapter da3 = new SqlDataAdapter("Select * From TBL_GIDERLER", bgl.baglanti());
            da3.Fill(dt3);
            gridControl2.DataSource = dt3;
        }
        public string adi; 
        private void FrmKasa_Load(object sender, EventArgs e)
        {
            musterihareket();
            firmahareket();
            LblAktifKullanici.Text = adi;
            faturahareket();


            //Toplam Tutarı Hesaplama
            SqlCommand komut1 = new SqlCommand("Select Sum(TUTAR) From TBL_FATURADETAY", bgl.baglanti());
            SqlDataReader dr1 = komut1.ExecuteReader();
            while (dr1.Read())
            {
                LblKasaToplam.Text = dr1[0].ToString()+" TL";
                bgl.baglanti().Close();
                //Son ayın Faturaları
                SqlCommand komut2 = new SqlCommand("Select (ELEKTRIK+SU+DOGALGAZ+INTERNET+EKSTRA) From TBL_GIDERLER ORDER BY ID ASC", bgl.baglanti());
                SqlDataReader dr2 = komut2.ExecuteReader();
                while(dr2.Read())
                {
                    LblOdemeler.Text = dr2[0].ToString() + " TL";

                }
                bgl.baglanti().Close();

                // Son Ayın Personel Maaşları
                SqlCommand komut3 = new SqlCommand("Select MAASLAR From TBL_GIDERLER", bgl.baglanti());
                SqlDataReader dr3 = komut3.ExecuteReader();
                while (dr3.Read())
                {
                    LblPersonelMaas.Text = dr3[0].ToString() + " TL";
                }
                bgl.baglanti().Close();

                //Toplam Müşteri Sayısı
                SqlCommand komut4 = new SqlCommand("Select Count (*) From TBL_MUSTERILER", bgl.baglanti());
                SqlDataReader dr4 = komut4.ExecuteReader();
                while (dr4.Read())
                {
                    LblMusteriSayisi.Text = dr4[0].ToString();
                }
                bgl.baglanti().Close();
            }
            //Toplam Firma Sayısı
            SqlCommand komut5 = new SqlCommand("Select Count (*) From TBL_FIRMALAR", bgl.baglanti());
            SqlDataReader dr5 = komut5.ExecuteReader();
            while (dr5.Read())
            {
                LblFirmaSayisi.Text = dr5[0].ToString();
            }
            bgl.baglanti().Close();

            //Toplam Firma Şehir Sayısı

            SqlCommand komut6 = new SqlCommand("Select Count (Distinct(IL)) From TBL_FIRMALAR", bgl.baglanti());
            SqlDataReader dr6 = komut6.ExecuteReader();
            while (dr6.Read())
            {
                LblSehirSayisi.Text = dr6[0].ToString();
            }
            bgl.baglanti().Close();
            //Toplam Firma Şehir Sayısı

            SqlCommand komut7 = new SqlCommand("Select Count (Distinct(IL)) From TBL_MUSTERILER", bgl.baglanti());
            SqlDataReader dr7 = komut7.ExecuteReader();
            while (dr7.Read())
            {
                LblSehirSayisi2.Text = dr7[0].ToString();
            }
            bgl.baglanti().Close();

            //Toplam Personel Sayısı
            SqlCommand komut8 = new SqlCommand("Select Count(*) From TBL_PERSONELLER", bgl.baglanti());
            SqlDataReader dr8 = komut8.ExecuteReader();
            while (dr8.Read())
            {
               LblPersonelSayisi.Text = dr8[0].ToString();
            }
            bgl.baglanti().Close();

            //Toplam Ürün Sayısı

            SqlCommand komut9 = new SqlCommand("Select Sum(ADET) From TBL_URUNLER", bgl.baglanti());
            SqlDataReader dr9 = komut9.ExecuteReader();
            while (dr9.Read())
            {
                LblStokSayisi.Text = dr9[0].ToString();
            }
            bgl.baglanti().Close();          
        }
        int sayac = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            sayac++;
            if(sayac>0 && sayac<=5)//ELEKTRIK
            {

                groupControl19.Text = "Elektrik";
                chartControl2.Series["Aylar"].Points.Clear();
                SqlCommand komut10 = new SqlCommand("Select top 4 AY,ELEKTRIK From TBL_GIDERLER ORDER BY ID DESC", bgl.baglanti());
                SqlDataReader dr10 = komut10.ExecuteReader();
                while (dr10.Read())
                {
                    chartControl2.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr10[0], dr10[1]));
                }
                bgl.baglanti().Close();
            }
            if(sayac > 5 && sayac <=10)//SU
            {
                groupControl19.Text = "Su";
                chartControl2.Series["Aylar"].Points.Clear();
                SqlCommand komut11 = new SqlCommand("Select top 4 AY,SU From TBL_GIDERLER ORDER BY ID DESC", bgl.baglanti());
                SqlDataReader dr11 = komut11.ExecuteReader();
                while (dr11.Read())
                {
                    chartControl2.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr11[0], dr11[1]));
                }
                bgl.baglanti().Close();
            }
            if (sayac > 10 && sayac <= 15)//DOĞALGAZ
            {
                groupControl19.Text = "Doğalgaz";
                chartControl2.Series["Aylar"].Points.Clear();
                SqlCommand komut11 = new SqlCommand("Select top 4 AY,DOGALGAZ From TBL_GIDERLER ORDER BY ID DESC", bgl.baglanti());
                SqlDataReader dr11 = komut11.ExecuteReader();
                while (dr11.Read())
                {
                    chartControl2.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr11[0], dr11[1]));
                }
                bgl.baglanti().Close();
            }
            if (sayac > 15 && sayac <= 20)//INTERNET
            {
                groupControl19.Text = "Internet";
                chartControl2.Series["Aylar"].Points.Clear();
                SqlCommand komut11 = new SqlCommand("Select top 4 AY,INTERNET From TBL_GIDERLER ORDER BY ID DESC", bgl.baglanti());
                SqlDataReader dr11 = komut11.ExecuteReader();
                while (dr11.Read())
                {
                    chartControl2.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr11[0], dr11[1]));
                }
                bgl.baglanti().Close();
            }
            if (sayac > 20 && sayac <= 25)
            {
                groupControl19.Text = "Ekstra";
                chartControl2.Series["Aylar"].Points.Clear();
                SqlCommand komut11 = new SqlCommand("Select top 4 AY,EKSTRA From TBL_GIDERLER ORDER BY ID DESC", bgl.baglanti());
                SqlDataReader dr11 = komut11.ExecuteReader();
                while (dr11.Read())
                {
                    chartControl2.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr11[0], dr11[1]));
                }
                bgl.baglanti().Close();
            }
            if(sayac==26)
            {
                sayac = 0;
            }
        }
        int sayac2;
        private void timer2_Tick(object sender, EventArgs e)
        {
            sayac2++;
            if (sayac2 > 0 && sayac2 <= 5)//ELEKTRIK
            {

                groupControl20.Text = "Elektrik";
                chartControl1.Series["Aylar"].Points.Clear();

                SqlCommand komut10 = new SqlCommand("Select top 4 AY,ELEKTRIK From TBL_GIDERLER ORDER BY ID DESC", bgl.baglanti());
                SqlDataReader dr10 = komut10.ExecuteReader();
                while (dr10.Read())
                {
                    chartControl1.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr10[0], dr10[1]));
                }
                bgl.baglanti().Close();
            }
            if (sayac2 > 5 && sayac2 <= 10)//SU
            {
                groupControl20.Text = "Su";
                chartControl1.Series["Aylar"].Points.Clear();
                SqlCommand komut11 = new SqlCommand("Select top 4 AY,SU From TBL_GIDERLER ORDER BY ID DESC", bgl.baglanti());
                SqlDataReader dr11 = komut11.ExecuteReader();
                while (dr11.Read())
                {
                    chartControl1.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr11[0], dr11[1]));

                }
                bgl.baglanti().Close();
            }
            if (sayac2 > 10 && sayac2 <= 15)//DOĞALGAZ
            {
                groupControl20.Text = "Doğalgaz";
                chartControl1.Series["Aylar"].Points.Clear();
                SqlCommand komut11 = new SqlCommand("Select top 4 AY,DOGALGAZ From TBL_GIDERLER ORDER BY ID DESC", bgl.baglanti());
                SqlDataReader dr11 = komut11.ExecuteReader();
                while (dr11.Read())
                {
                    chartControl1.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr11[0], dr11[1]));

                }
                bgl.baglanti().Close();
            }
            if (sayac2 > 15 && sayac2 <= 20)//INTERNET
            {
                groupControl20.Text = "Internet";
                chartControl1.Series["Aylar"].Points.Clear();
                SqlCommand komut11 = new SqlCommand("Select top 4 AY,INTERNET From TBL_GIDERLER ORDER BY ID DESC", bgl.baglanti());
                SqlDataReader dr11 = komut11.ExecuteReader();
                while (dr11.Read())
                {
                    chartControl1.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr11[0], dr11[1]));

                }
                bgl.baglanti().Close();
            }
            if (sayac2 > 20 && sayac2 <= 25)
            {
                groupControl20.Text = "Ekstra";
                chartControl1.Series["Aylar"].Points.Clear();
                SqlCommand komut11 = new SqlCommand("Select top 4 AY,EKSTRA From TBL_GIDERLER ORDER BY ID DESC", bgl.baglanti());
                SqlDataReader dr11 = komut11.ExecuteReader();
                while (dr11.Read())
                {
                    chartControl1.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr11[0], dr11[1]));
                }
                bgl.baglanti().Close();
            }
            if (sayac2 == 26)
            {
                sayac2 = 0;
            }

        }
    }
}
