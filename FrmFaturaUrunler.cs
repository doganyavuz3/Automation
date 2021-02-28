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
    public partial class FrmFaturaUrunler : Form
    {
        public FrmFaturaUrunler()
        {
            InitializeComponent();

        }
        public string id;
        sqlbaglatisi bgl = new sqlbaglatisi();
        void listele()
        {
            SqlDataAdapter da = new SqlDataAdapter("Select * From TBL_FATURADETAY where FaturaID='" + id + "'", bgl.baglanti());
            DataTable dt = new DataTable();
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }
        private void FrmFaturaUrunler_Load(object sender, EventArgs e)
        {

            listele();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            FrmFaturaUrunDuzenleme fr = new FrmFaturaUrunDuzenleme();
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr!=null)
            {
                fr.urunid = dr["FATURAURUNID"].ToString();

            }
            fr.Show();
        }
    }
}
