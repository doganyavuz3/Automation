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
using System.Xml;

namespace ticari_otomasyon
{
    public partial class FrmAnasayfa : Form
    {
        public FrmAnasayfa()
        {
            InitializeComponent();
        }
        sqlbaglatisi bgl = new sqlbaglatisi();
        void stoklar()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select URUNAD,SUM(ADET) AS 'ADET' FROM TBL_URUNLER GROUP BY URUNAD HAVING SUM(ADET)<=30 ORDER BY SUM(ADET)", bgl.baglanti());
            da.Fill(dt);
            GridControlStoklar.DataSource = dt;
        }
        void ajanda()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select TOP 9 TARIH,SAAT,BASLIK FROM TBL_NOTLAR ORDER BY ID DESC", bgl.baglanti());
            da.Fill(dt);
            GridControlAjanda.DataSource = dt;
        }
        void FirmaHareketleri()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Exec FirmaHareket2", bgl.baglanti());
            da.Fill(dt);
           GridControlFirmaHareket.DataSource = dt;

        }
        void fihrist()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select AD,TELEFON1 From TBL_FIRMALAR", bgl.baglanti());
            da.Fill(dt);
            GridControlFihrist.DataSource = dt;
        }
        void haberler()
        {
            XmlTextReader xmloku = new XmlTextReader("https://www.hurriyet.com.tr/rss/anasayfa");
            while(xmloku.Read())
            {
                if(xmloku.Name=="title")
                {
                    listBox1.Items.Add(xmloku.ReadString());
                }
            }
        }
        private void FrmAnasayfa_Load(object sender, EventArgs e)
        {
            stoklar();
            ajanda();
            FirmaHareketleri();
            fihrist();
            haberler();
            webBrowser1.Navigate("https://www.tcmb.gov.tr/kurlar/today.xml");
        }
    }
}
