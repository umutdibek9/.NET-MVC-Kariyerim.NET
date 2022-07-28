using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBL
{
    public class KullaniciBBL
    {
        KullaniciDAL kullaniciDAL = new KullaniciDAL();
        public KullaniciDTO KullaniciLogin(KullaniciDTO model)
        {
            KullaniciDTO dto = new KullaniciDTO();
            dto = kullaniciDAL.KullaniciLogin(model);
            return dto;
        }
        public bool KullaniciRegister()
        {
            bool dto = kullaniciDAL.KullaniciRegister();
            return dto;
        }

        public bool KullaniciRol()
        {
            bool dto = kullaniciDAL.KullaniciRol();
            return dto;
        }
        public void KaydetCV(KullaniciCvDTO model)
        {
            kullaniciDAL.CvKaydet(model);
            
        }
        public List<IsilaniDTO> sliders()
        {
            List<IsilaniDTO> dto= kullaniciDAL.slider();
            return dto;
        }
        public List<KullaniciCvDTO> Cv(int id)
        {
            List<KullaniciCvDTO> dto = kullaniciDAL.Cv(id);
            return dto;
        }

        public KullaniciCvDTO revizecv(int id)
        {
            KullaniciCvDTO dto=kullaniciDAL.RevizeCv(id);
            return dto;
        }
        public void revize_et(KullaniciCvDTO model)
        {
            kullaniciDAL.revize_et(model);
           
        }
        public List<KullaniciCvDTO> cvdetay(int id)
        {
            List<KullaniciCvDTO> dto=kullaniciDAL.CvDetay(id);
            return dto;
        }

        public List<IsilaniDTO> isara()
        {
            List<IsilaniDTO> dto = kullaniciDAL.isara();
            return dto;
        }
        public BasvuruDTO isdetay(int id,int k_id)
        {
            BasvuruDTO dto = kullaniciDAL.isdetay(id,k_id);
            return dto;
        }
        public void basvurular(BasvuruDTO dto)
        {
             kullaniciDAL.basvuru(dto);
            
        }

        public void ilan_kaldir2(int id)
        {
            kullaniciDAL.kaldir_ilan2(id);
        }



    }
}
