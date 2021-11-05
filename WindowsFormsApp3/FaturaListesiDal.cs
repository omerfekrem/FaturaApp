using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp3
{
    class FaturaListesiDal
    {
        public static List<FaturaListesi> KayitlariGetir(string Aranacak = "")
        {
            SqlConnection connection = VT.baglan();

            string SqlCumlesi = "SELECT * FROM FaturaListesi";

            if (Aranacak != "")
                SqlCumlesi += " WHERE M_Unvan LIKE @Aranacak";

            SqlCumlesi += " ORDER BY F_ID DESC";

            SqlCommand command = new SqlCommand(SqlCumlesi, connection);
            if (Aranacak != "")
                command.Parameters.AddWithValue("@Aranacak", "%" + Aranacak + "%");

            SqlDataReader reader = command.ExecuteReader();

            List<FaturaListesi> faturalar = new List<FaturaListesi>();

            while (reader.Read())
            {
                double ToplamTutar = -1;
                try
                {
                    ToplamTutar = Convert.ToDouble(reader["Toplam"].ToString());
                }
                catch (Exception)
                {
                    
                }
               
                FaturaListesi fatura = new FaturaListesi
                {
                    F_ID = Convert.ToInt32(reader["F_ID"].ToString()),
                    F_Tarih = Convert.ToDateTime(reader["F_Tarih"].ToString()),
                    M_Unvan = reader["M_Unvan"].ToString(),
                    Toplam = ToplamTutar
                };
                faturalar.Add(fatura);
            }

            reader.Close();
            connection.Close();

            return faturalar;
        }
    }
}
