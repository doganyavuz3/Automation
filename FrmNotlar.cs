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
    public partial class FrmNotlar : Form
    {
        public FrmNotlar()
        {
            InitializeComponent();
        }
        sqlbaglatisi bgl = new sqlbaglatisi();
        void listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from TBL_NOTLAR", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }
        void temizle()
        {
            TxtBaslik.Text = "";
            TxtHitap.Text = "";
            TxtID.Text = "";
            TxtOlusturan.Text = "";
            MskTarih.Text = "";
            MskSaat.Text = "";
            RichDetay.Text = "";
        }
        private void FrmNotlar_Load(object sender, EventArgs e)
        {
            listele();
            temizle();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into TBL_NOTLAR (TARIH,SAAT,BASLIK,DETAY,OLUSTURAN,HITAP) values (@p1,@p2,@p3,@p4,@p5,@p6)", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", MskTarih.Text);
            komut.Parameters.AddWithValue("@p2", MskSaat.Text);
            komut.Parameters.AddWithValue("@p3", TxtBaslik.Text);
            komut.Parameters.AddWithValue("@p4", RichDetay.Text);
            komut.Parameters.AddWithValue("@p5", TxtOlusturan.Text);
            komut.Parameters.AddWithValue("@p6", TxtHitap.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            listele();
            MessageBox.Show("Not bilgisi sisteme başarıyla eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr !=null)
            {
                TxtID.Text = dr["ID"].ToString();
                TxtBaslik.Text = dr["BASLIK"].ToString();
                TxtOlusturan.Text = dr["OLUSTURAN"].ToString();
                TxtHitap.Text = dr["HITAP"].ToString();
                RichDetay.Text = dr["DETAY"].ToString();
                MskSaat.Text = dr["SAAT"].ToString();
                MskTarih.Text = dr["TARIH"].ToString();
            }
        }
        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Delete From  TBL_NOTLAR where ID=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", TxtID.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Not sistemden başarı bir şekilde silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            listele();
        }
        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Update TBL_NOTLAR set TARIH=@p1,SAAT=@p2,BASLIK=@p3,DETAY=@p4,OLUSTURAN=@p5,HITAP=@p6 where ID=@p7", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", MskTarih.Text);
            komut.Parameters.AddWithValue("@p2", MskSaat.Text);
            komut.Parameters.AddWithValue("@p3", TxtBaslik.Text);
            komut.Parameters.AddWithValue("@p4", RichDetay.Text);
            komut.Parameters.AddWithValue("@p5", TxtOlusturan.Text);
            komut.Parameters.AddWithValue("@p6", TxtHitap.Text);
            komut.Parameters.AddWithValue("@p7", TxtID.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            listele();
            MessageBox.Show("Not bilgisi sistemde başarıyla güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            FrmNotDetay fr = new FrmNotDetay();
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr!=null)
            {
                fr.metin = dr["DETAY"].ToString();
            }
            fr.Show();
        }
    }
}
