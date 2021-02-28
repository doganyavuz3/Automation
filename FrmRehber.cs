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
    public partial class FrmRehber : Form
    {
        public FrmRehber()
        {
            InitializeComponent();
        }
        sqlbaglatisi bgl = new sqlbaglatisi();

        private void FrmRehber_Load(object sender, EventArgs e)
        {
            //Müşteri Bilgileri
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select AD,SOYAD,TELEFON,TELEFON2,MAIL From TBL_MUSTERILER Order By ID Asc", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("Select AD,YETKILIADSOYAD,TELEFON1,TELEFON2,TELEFON3,MAIL,FAX,SEKTOR From TBL_FIRMALAR Order By ID Asc", bgl.baglanti());
            da2.Fill(dt2);
            gridControl2.DataSource = dt2;
        }
        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            FrmMail frm = new FrmMail();
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr!=null)
            {
                frm.mail = dr["MAIL"].ToString();               
            }
            frm.Show();
        }
       private void gridView2_DoubleClick(object sender, EventArgs e)
        {
            FrmMail frm = new FrmMail();
            DataRow dr = gridView2.GetDataRow(gridView2.FocusedRowHandle);
            if (dr != null)
            {
                frm.mail = dr["MAIL"].ToString();
            }
            frm.Show();
        }
    }
}
