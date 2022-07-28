using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class AdminDAL:DatabaseContext
    {
        public AdminDTO Login(AdminDTO model)
        {
            AdminDTO dto = new AdminDTO();
            Admin kullanici = db.Admins.Where(x=>x.Eposta==model.Email && x.Sifre==model.Sifre).FirstOrDefault();
            if(kullanici!=null && kullanici.id != 0)
            {
                dto.ID = kullanici.id;
                dto.Email = kullanici.Eposta;
                dto.Ad = kullanici.Ad;
                dto.Soyad = kullanici.Soyad;
                dto.Sifre = kullanici.Sifre;

            }
            return dto;
        }
        public bool Register()
        {
            AdminDTO dto = new AdminDTO();
            Admin kullanici = db.Admins.Where(x => x.Eposta == "Admin" && x.Sifre == "1234").FirstOrDefault();
            Admin yeni_kullanici = new Admin();
            if (kullanici == null)
            {
                yeni_kullanici.Eposta= "Admin";
                yeni_kullanici.Sifre= "1234";
                yeni_kullanici.Rol = "Admin";
                db.Admins.Add(yeni_kullanici);
                db.SaveChanges();
                return true;
            }
            return false;
        }
        public bool RolRegister()
        {
            RolDTO dto = new RolDTO();
            Rol_Table rol = db.Rol_Table.Where(x => x.Rol == "Admin" ).FirstOrDefault();
            Rol_Table yeni_rol = new Rol_Table();
            if (rol == null)
            {
                yeni_rol.Rol = "Admin";
                db.Rol_Table.Add(yeni_rol);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public bool KayitOl(KayitDTO model)
        {
            if (model.Rol == "Kullanici") { 
            Kullanici kullanici = db.Kullanicis.Where(x => x.Eposta == model.Email).FirstOrDefault();

                Kullanici yeni_kullanici = new Kullanici();
                if (kullanici == null)
                {
                    yeni_kullanici.Eposta = model.Email;
                    yeni_kullanici.Sifre = model.Sifre;
                    yeni_kullanici.Ad = model.Ad;
                    yeni_kullanici.Soyad = model.Soyad;
                    yeni_kullanici.Rol = "Kullanici";
                db.Kullanicis.Add(yeni_kullanici);
                db.SaveChanges();
                return true;
            }
            return false;
            }
            else
            {
                Isveren kullanici = db.Isverens.Where(x => x.Eposta == model.Email).FirstOrDefault();
                Isveren yeni_kullanici = new Isveren();
                if (kullanici == null)
                {
                    yeni_kullanici.Eposta = model.Email;
                    yeni_kullanici.Sifre = model.Sifre;
                    yeni_kullanici.Ad = model.Ad;
                    yeni_kullanici.Soyad = model.Soyad;
                    yeni_kullanici.Rol = "Isveren";
                    db.Isverens.Add(yeni_kullanici);
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
            
        }
        public RolDTO getRoles(string username)
        {
            var user = db.Admins.FirstOrDefault(y => y.Eposta == username); 
            var user1 = db.Kullanicis.FirstOrDefault(y => y.Eposta == username);
            var user2= db.Isverens.FirstOrDefault(y => y.Eposta == username);


            RolDTO dto = new RolDTO();
            if (user != null) { 
                dto.email = user.Eposta;
                dto.Rol = user.Rol;
            }
            else if (user1 != null)
            {
                dto.email = user1.Eposta;
                dto.Rol = user1.Rol;
            }
            else if (user2 != null)
            {
                dto.email = user2.Eposta;
                dto.Rol = user2.Rol;
            }
            return dto;

        }
        public List<IsilaniDTO> adminis()
        {
            List<IsilaniDTO> dto = new List<IsilaniDTO>();
            List<IsIlani> model=db.IsIlanis.ToList();
            for(var i = 0; i < model.Count(); i++)
            {
                if (model[i].Durum == 1) { 
                IsilaniDTO isDTO = new IsilaniDTO();
                isDTO.ilanadi=model[i].IlanAdi;
                isDTO.ID = model[i].id;
                dto.Add(isDTO);
                }
            }
            return dto;

        }
        public void Kaldir(int id)
        {
            IsIlani model=db.IsIlanis.Find(id);
            model.Durum = 3;
            db.SaveChanges();
        }
    }
}
