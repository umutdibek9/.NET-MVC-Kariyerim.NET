using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class BasvuruDTO
    {

        public int ID { get; set; }
        public string SirketIsmi { get; set; }
        public string ilanadi { get; set; }
        public int isverenid { get; set; }
        [DataType(DataType.MultilineText)]
        public string aciklama { get; set; }
        [DataType(DataType.MultilineText)]
        public string adres { get; set; }
        public string il { get; set; }
        public string ilce { get; set; }
        public string Sektor { get; set; }
        public string logo { get; set; }
        public Durum Durum { get; set; }
        public DateTime? YayimlamaTarihi { get; set; }
        public int cvid { get; set; }
        public int kullaniciid { get; set; }
        public List<int> ids { get; set; }
        public List<int> cvids { get; set; }

        public List<int?> cvler { get; set; }

        public List<string> adsoyad { get; set; }
        public string isim { get; set; }
        public int? idler { get; set; }
        public string kullaniciresmi { get; set; }
        public List<string> kullaniciresim { get; set; }
        public List<int> sayac { get; set; }

    }
}
