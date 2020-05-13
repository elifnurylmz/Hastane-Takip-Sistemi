using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Hastane_Randevu_Sistem
{
    class ClassSQLBaglantisi
    {
        public SqlConnection baglanti()
        {
            SqlConnection baglan = new SqlConnection("Data Source=LAPTOP-4QR1NNEL\\SQLEXPRESS;Initial Catalog=HastaneRandevu;Integrated Security=True");
            baglan.Open();
            return baglan;
        }
    }
}
