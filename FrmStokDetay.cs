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
    public partial class FrmStokDetay : Form
    {
        public FrmStokDetay()
        {
            InitializeComponent();
        }
        public string ad;
        sqlbaglatisi bgl = new sqlbaglatisi();
        private void FrmStokDetay_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from TBL_URUNLER where URUNAD='" + ad +"'", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }
    }
}
