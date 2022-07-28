using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBL
{
    public class AdminBBL
    {
        AdminDAL kullaniciDAL = new AdminDAL();
        public AdminDTO Login(AdminDTO model)
        {
            AdminDTO dto = new AdminDTO();
            dto = kullaniciDAL.Login(model);
            return dto;
        }
        public bool KayitOl(KayitDTO model)
        {
            bool dto = kullaniciDAL.KayitOl(model);
            return dto;
        }

        public bool Register()
        {
            bool dto = kullaniciDAL.Register();
            return dto;
        }

        public bool RolRegister()
        {
            bool dto = kullaniciDAL.RolRegister();
            return dto;
        }

        public RolDTO getRoles(string username)
        {
            var x = kullaniciDAL.getRoles(username);
            return x;
        }
        public List<IsilaniDTO> adminis()
        {
            List<IsilaniDTO> dto = kullaniciDAL.adminis();
            return dto;
        }

        public void Kaldir(int id)
        {
             kullaniciDAL.Kaldir(id);
        }
    }
}
