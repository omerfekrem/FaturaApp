using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace WindowsFormsApp3
{
    class MusteriDal
    {
        public static Musteri MusteriyiGetir(int M_ID)
        {
            SqlConnection connection = VT.baglan();
            SqlCommand command = new SqlCommand("SELECT * FROM Musteri WHERE M_ID=@M_ID", connection);
            command.Parameters.AddWithValue("M_ID", M_ID);

            SqlDataReader reader = command.ExecuteReader();
            
            Musteri musteri = new Musteri();

            if (reader.Read())
            {
                musteri.M_ID = Convert.ToInt32(reader["M_ID"].ToString());
                musteri.M_Unvan = reader["M_Unvan"].ToString();
                musteri.M_VergiDairesi = reader["M_VergiDairesi"].ToString();
                musteri.M_VergiNo = reader["M_VergiNo"].ToString();
            }

            return musteri;
        }
        public static List<Musteri> KayitlariGetir(string Aranacak="")
        {
            SqlConnection connection = VT.baglan();

            string SqlCumlesi = "SELECT * FROM Musteri";

            if (Aranacak != "")
                SqlCumlesi += " WHERE M_Unvan LIKE @Aranacak OR M_VergiDairesi LIKE @Aranacak OR M_VergiNo LIKE @Aranacak";

            SqlCommand command = new SqlCommand(SqlCumlesi, connection);
            if (Aranacak != "")
                command.Parameters.AddWithValue("@Aranacak", "%"+Aranacak+"%");

            SqlDataReader reader = command.ExecuteReader();

            List<Musteri> musteriler = new List<Musteri>();

            while(reader.Read())
            {
                Musteri musteri = new Musteri
                {
                    M_ID = Convert.ToInt32(reader["M_ID"].ToString()),
                    M_Unvan = reader["M_Unvan"].ToString(),
                    M_VergiDairesi = reader["M_VergiDairesi"].ToString(),
                    M_VergiNo = reader["M_VergiNo"].ToString()
                };
                musteriler.Add(musteri);
            }

            reader.Close();
            connection.Close();

            return musteriler;
        }
        public static void EkleGuncele(Musteri musteri)
        {
            SqlConnection connection = VT.baglan();

            string SqlCumlesi;

            if (musteri.M_ID > 0)
                SqlCumlesi = "UPDATE Musteri SET M_Unvan=@M_Unvan, M_VergiDairesi=@M_VergiDairesi, M_VergiNo=@M_VergiNo " +
                    "WHERE M_ID=@M_ID";
            else
                SqlCumlesi = "INSERT INTO Musteri(M_Unvan,M_VergiDairesi,M_VergiNo) VALUES (@M_Unvan,@M_VergiDairesi,@M_VergiNo)";

            SqlCommand command = new SqlCommand(SqlCumlesi, connection);

            command.Parameters.AddWithValue("@M_Unvan", musteri.M_Unvan);
            command.Parameters.AddWithValue("@M_VergiDairesi", musteri.M_VergiDairesi);
            command.Parameters.AddWithValue("@M_VergiNo", musteri.M_VergiNo);
            
            if (musteri.M_ID > 0)
                command.Parameters.AddWithValue("@M_ID", musteri.M_ID);

            command.ExecuteNonQuery();
        }

        public static void KaydiSil(int M_ID)
        {
            SqlConnection connection = VT.baglan();

            SqlCommand command = new SqlCommand("DELETE FROM Musteri WHERE M_ID=@M_ID", connection);
            command.Parameters.AddWithValue("@M_ID", M_ID);
            command.ExecuteNonQuery();
        }
    }
}
