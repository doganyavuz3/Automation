using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ticari_otomasyon
{
    class sqlbaglatisi
    {
        public SqlConnection baglanti()
        { 
            SqlConnection baglan = new SqlConnection(@"Data Source=LAPTOP-5445REC6;Initial Catalog=DboTicariOtomasyon;Integrated Security=True");
                baglan.Open();
            return baglan;

            }
    }
}
