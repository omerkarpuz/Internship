using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Proje_Hastane
{
    internal class sqlbaglantisi
    {
        public SqlConnection baglanti()
        {
            SqlConnection baglanti = new SqlConnection("Data Source=OMERKARPUZ\\MSSQL2022;Initial Catalog=omrstaj_HastaneProje;Integrated Security=True;");
            baglanti.Open();
            return baglanti;
        }
    }
}
