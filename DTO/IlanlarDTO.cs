using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class IlanlarDTO
    {
        public int ID { get; set; }
        public string SirketIsmi { get; set; }
        public string isverenid { get; set; }
        public string aciklama { get; set; }
        public string il { get; set; }
        public int ilce { get; set; }
        public string Sektor { get; set; }
        public Durum Durum { get; set; }
        public DateTime YayimlamaTarihi { get; set; }
    }
}
