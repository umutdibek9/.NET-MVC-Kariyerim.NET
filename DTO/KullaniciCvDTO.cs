using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public enum CvDurum
    {
        Aktif,
        Kaldirilmis,
        Revize
    }
    public class KullaniciCvDTO
    {
        public int ID { get; set; }
        public string Email { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string il { get; set; }
        public string ilce { get; set; }
        public string Okul { get; set; }
        [DataType(DataType.MultilineText)]
        public string Adres { get; set; }
        public double? AGNO { get; set; }
        public  string Resim { get; set; }
        public string YerS { get; set; }
        public string YerD { get; set; }
        public string Bolum { get; set; }
        public string BeklenenUcret { get; set; }
        [DataType(DataType.MultilineText)]
        public string Onyazi { get; set; }
        public CvDurum CvDurum { get; set; }

        public List<String> YerSecenek { get; set; }
        public List<String> YerDegiskeni { get; set; }
        public int kullaniciid { get; set; }
        public string a { get; set; }
        public string b { get; set; }
        public DateTime? tarih { get; set; }

    }
}
