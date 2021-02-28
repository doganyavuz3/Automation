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
    public partial class FrmUrunler : Form
    {
        public FrmUrunler()
        {
            InitializeComponent();
        }
        sqlbaglatisi bgl = new sqlbaglatisi();
        void listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from TBL_URUNLER Order By ID Asc", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }
        void temizle()
        {
            TxtAd.Text = "";
            TxtAlis.Text="";
            TxtMarka.Text="";
            TxtSatis.Text = "";
            TxtModel.Text="";
            MskYil.Text = "";
            RichDetay.Text = "";
            TxtID.Text = "";           
        }
        private void FrmUrunler_Load(object sender, EventArgs e)
        {
            listele();
            temizle();
        }
        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            // Verileri kaydetme
            SqlCommand komut = new SqlCommand("insert into TBL_URUNLER" +
                " (URUNAD,MARKA,MODEL,YIL,ADET,ALISFIYAT,SATISFIYAT,DETAY) values " +
                "(@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8)", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", TxtAd.Text);
            komut.Parameters.AddWithValue("@p2", TxtMarka.Text);
            komut.Parameters.AddWithValue("@p3", TxtModel.Text);
            komut.Parameters.AddWithValue("@p4", MskYil.Text);
            komut.Parameters.AddWithValue("@p5", int.Parse((NudAdet.Value).ToString()));
            komut.Parameters.AddWithValue("@p6", decimal.Parse(TxtAlis.Text));
            komut.Parameters.AddWithValue("@p7", decimal.Parse(TxtSatis.Text));
            komut.Parameters.AddWithValue("@p8", RichDetay.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Ürün sisteme başarılı bir şekilde eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
            temizle();
        }
        private void BtnSil_Click(object sender, EventArgs e)
        {
            SqlCommand komutsil = new SqlCommand("Delete from TBL_URUNLER where ID=@p1", bgl.baglanti());
            komutsil.Parameters.AddWithValue("@p1", TxtID.Text);
            komutsil.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Ürün başarıyla silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            listele();
            temizle();
        }
       private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            TxtID.Text = dr["ID"].ToString();
            TxtAd.Text = dr["URUNAD"].ToString();
            TxtMarka.Text = dr["MARKA"].ToString();
            TxtModel.Text = dr["MODEL"].ToString();
            MskYil.Text = dr["YIL"].ToString();
            NudAdet.Value =decimal.Parse( dr["ADET"].ToString());
            TxtAlis.Text = dr["ALISFIYAT"].ToString();
            TxtSatis.Text = dr["SATISFIYAT"].ToString();
            RichDetay.Text = dr["DETAY"].ToString();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update TBL_URUNLER set  URUNAD=@p1,MARKA=@p2,MODEL=@p3,YIL=@p4,ADET=@p5,ALISFIYAT=@p6,SATISFIYAT=@p7,DETAY=@p8 where ID=@p9", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", TxtAd.Text);
            komut.Parameters.AddWithValue("@p2", TxtMarka.Text);
            komut.Parameters.AddWithValue("@p3", TxtModel.Text);
            komut.Parameters.AddWithValue("@p4", MskYil.Text);
            komut.Parameters.AddWithValue("@p5", int.Parse((NudAdet.Value).ToString()));
            komut.Parameters.AddWithValue("@p6", decimal.Parse(TxtAlis.Text));
            komut.Parameters.AddWithValue("@p7", decimal.Parse(TxtSatis.Text));
            komut.Parameters.AddWithValue("@p8", RichDetay.Text);
            komut.Parameters.Add("@p9", TxtID.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Ürün başarılı bir şekilde güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            listele();
            temizle();
        }
        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }
    }
}
