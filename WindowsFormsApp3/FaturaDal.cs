using System;
using System.Data.SqlClient;

namespace WindowsFormsApp3
{
    class FaturaDal
    {
        public static Fatura FaturayiGetir(int F_ID)
        {
            SqlConnection connection = VT.baglan();
            SqlCommand command = new SqlCommand("SELECT * FROM Fatura WHERE F_ID=@F_ID", connection);
            command.Parameters.AddWithValue("F_ID", F_ID);

            SqlDataReader reader = command.ExecuteReader();

            Fatura fatura = new Fatura();

            if(reader.Read())
            {
                fatura.F_ID = Convert.ToInt32(reader["F_ID"].ToString());
                fatura.F_M_ID = Convert.ToInt32(reader["F_M_ID"].ToString());
                fatura.F_Tarih = Convert.ToDateTime(reader["F_Tarih"].ToString());

                fatura.musteri = MusteriDal.MusteriyiGetir(fatura.F_M_ID);
                fatura.kalems = KalemDal.KalemleriGetir(F_ID);

                fatura.ToplamTutar = 0;
                foreach (Kalem kalem in fatura.kalems)
                    fatura.ToplamTutar += kalem.K_Tutar;
            }

            return fatura;
        }
    }
}
