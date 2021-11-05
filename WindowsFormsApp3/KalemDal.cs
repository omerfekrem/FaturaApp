using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp3
{
    class KalemDal
    {
        public static List<Kalem> KalemleriGetir(int K_F_ID)
        {
            SqlConnection connection = VT.baglan();
            SqlCommand command = new SqlCommand("SELECT * FROM Kalem WHERE K_F_ID=@K_F_ID", connection);
            command.Parameters.AddWithValue("K_F_ID", K_F_ID);

            SqlDataReader reader = command.ExecuteReader();

            List<Kalem> kalems = new List<Kalem>();

            while(reader.Read())
            {
                Kalem kalem = new Kalem
                {
                    K_ID = Convert.ToInt32(reader["K_ID"].ToString()),
                    K_F_ID = Convert.ToInt32(reader["K_F_ID"].ToString()),
                    K_U_ID = Convert.ToInt32(reader["K_U_ID"].ToString()),
                    K_Miktar = Convert.ToInt32(reader["K_Miktar"].ToString()),
                    K_Fiyat = Convert.ToDouble(reader["K_Fiyat"].ToString())
                };

                kalem.K_Tutar = kalem.K_Miktar * kalem.K_Fiyat;

                kalems.Add(kalem);
            }

            reader.Close();
            connection.Close();

            return kalems;
        }
    }
}
