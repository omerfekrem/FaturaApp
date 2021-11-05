using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp3
{
    class UrunDal
    {
        public static List<Urun> KalemleriGetir()
        {
            SqlConnection connection = VT.baglan();
            SqlCommand command = new SqlCommand("SELECT * FROM Urun ORDER BY U_Adi", connection);

            SqlDataReader reader = command.ExecuteReader();

            List<Urun> uruns = new List<Urun>();

            while (reader.Read())
            {
                Urun urun = new Urun
                {
                    U_ID = Convert.ToInt32(reader["U_ID"].ToString()),
                    U_Kodu =reader["U_Kodu"].ToString(),
                    U_Adi = reader["U_Adi"].ToString(),
                    U_Birim = reader["U_Birim"].ToString(),
                    U_Fiyat = Convert.ToDouble(reader["U_Fiyat"].ToString()),
                    U_Stok = Convert.ToInt32(reader["U_Stok"].ToString())
                };

                uruns.Add(urun);
            }

            reader.Close();
            connection.Close();

            return uruns;
        }
    }
}
