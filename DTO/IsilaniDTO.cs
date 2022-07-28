using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public enum Durum
    {
        Aktif,
        Kaldirilmis,
        Revize
    }
    public class IsilaniDTO
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
       
   

    }
}
