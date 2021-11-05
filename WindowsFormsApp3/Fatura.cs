using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp3
{
    class Fatura
    {
        public int F_ID { get; set; }
        public int F_M_ID { get; set; }
        public DateTime F_Tarih { get; set; }
        public Musteri musteri { get; set; }
        public List<Kalem> kalems { get; set; }
        public double ToplamTutar { get; set; }

    }
}
