using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class KayitDTO
    {
        [Required(ErrorMessage = "Lutfen Email Alanini Doldurunuz")]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Lutfen Sifre Alanini Doldurunuz")]
        public string Sifre { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Rol { get; set; }
    }
}
