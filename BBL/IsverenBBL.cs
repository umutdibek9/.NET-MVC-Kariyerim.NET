using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBL
{
    public class IsverenBBL
    {
        IsverenDAL isverenDAL = new IsverenDAL();
        public IsverenDTO Login(IsverenDTO model)
        {
            IsverenDTO dto = new IsverenDTO();
            dto = isverenDAL.IsLogin(model);
            return dto;
        }
        public void Ilan(IsilaniDTO model)
        {  
            isverenDAL.Ilan(model);
            
        }
        public List<IsilaniDTO> ilan_list(int id)
        {
            List<IsilaniDTO> list_dto = new List<IsilaniDTO>();
            list_dto = isverenDAL.list_ilan(id);
            return list_dto;
        }
        public IsilaniDTO ilan_detay(int id)
        {
            IsilaniDTO dto = new IsilaniDTO();
            dto = isverenDAL.detay_ilan(id);
            return dto;
        }
        public List<IsilaniDTO> ilan_detay2(int id)
        {
            List<IsilaniDTO> dto = new List<IsilaniDTO>();
            dto = isverenDAL.detay_ilan2(id);
            return dto;
        }
        public void ilan_revize(IsilaniDTO isilaniDTO)
        {
            isverenDAL.revize_ilan(isilaniDTO);
        }

        public void ilan_kaldir(int id)
        {
            isverenDAL.kaldir_ilan(id);
        }
        public List<BasvuruDTO> isverenbasvuru(int ID)
        {
            List<BasvuruDTO> dto = isverenDAL.isverenbasvuru(ID);
            return dto;
        }
        public KullaniciCvDTO isverencvgoruntule(int id)
        {
            KullaniciCvDTO dto = isverenDAL.isverencvgoruntule(id);
            return dto;
        }

    }
}
