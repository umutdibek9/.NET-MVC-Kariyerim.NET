using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class IsverenDAL : DatabaseContext

    {
        public IsverenDTO IsLogin(IsverenDTO model)
        {
            IsverenDTO dto = new IsverenDTO();
            Isveren isveren = db.Isverens.Where(x => x.Eposta == model.Email && x.Sifre == model.Sifre).FirstOrDefault();
            if (isveren != null && isveren.IsverenId != 0)
            {
                dto.ID = isveren.IsverenId;
                dto.Email = isveren.Eposta;
                dto.Ad = isveren.Ad;
                dto.Soyad = isveren.Soyad;
                dto.Sifre = isveren.Sifre;

            }
            return dto;
        }
        public void Ilan(IsilaniDTO model)
        {
            IsIlani ilan_model = new IsIlani();

            ilan_model.aciklama = model.aciklama;
            ilan_model.Sektor = model.Sektor;
            ilan_model.SirketIsmi = model.SirketIsmi;
            ilan_model.il = model.il;
            ilan_model.ilce = model.ilce;
            ilan_model.Durum = 1;
            ilan_model.logo = model.logo;
            ilan_model.Adres = model.adres;
            ilan_model.isverenid = model.isverenid;
            ilan_model.IlanAdi = model.ilanadi;
            ilan_model.YayimlamaTarihi=DateTime.Now;
            db.IsIlanis.Add(ilan_model);
            db.SaveChanges();

        }
        public List<IsilaniDTO> list_ilan(int id)
        {

            List<IsIlani> list_dto = db.IsIlanis.Where(db_id=>db_id.isverenid==id).ToList();
            List<IsilaniDTO> x = new List<IsilaniDTO>();
            foreach (var item in list_dto) {
                IsilaniDTO d = new IsilaniDTO();
                d.ID = item.id;
                if (item.Durum == 1)
                {
                    d.Durum = Durum.Aktif;
                }
                else if(item.Durum==2)
                {
                    d.Durum = Durum.Kaldirilmis;
                }
                else if (item.Durum == 3)
                {
                    d.Durum = Durum.Revize;
                }
                d.aciklama = item.aciklama;
                d.adres = item.Adres;
                d.il = item.il;
                d.ilce = item.ilce;
                d.isverenid = item.isverenid;
                d.logo = item.logo;
                d.Sektor = item.Sektor;
                d.SirketIsmi = item.SirketIsmi;
                d.ilanadi = item.IlanAdi;
              
                x.Add(d);
            }
            return x;

        }
        public IsilaniDTO detay_ilan(int id)
        {
            IsilaniDTO x = new IsilaniDTO();
            int z = id;
            var dto = db.IsIlanis.Find(id);
            x.aciklama = dto.aciklama;
            x.adres = dto.Adres;
            x.ID = dto.id;
            x.ilanadi = dto.IlanAdi;
            x.il = dto.il;
            x.ilce = dto.ilce;
            x.logo = dto.logo;
            x.Sektor = dto.Sektor;
            x.SirketIsmi = dto.SirketIsmi;
            x.YayimlamaTarihi = dto.YayimlamaTarihi;
           


            return x;
        }
        public List<IsilaniDTO> detay_ilan2(int id)
        {
            List<IsilaniDTO> x = new List<IsilaniDTO>();
            var dto = db.EskiIlans.Where(y=>y.eskiid==id);
            IsilaniDTO t = new IsilaniDTO();
            foreach (var i in dto)
            {
                t.aciklama = i.aciklama;
                t.adres = i.Adres;
                t.il = i.il;
                t.ilce = i.ilce;
                t.logo = i.logo;
                t.SirketIsmi = i.SirketIsmi;
                t.Sektor = i.Sektor;
                t.YayimlamaTarihi = i.YayimlamaTarihi;
                t.ilanadi = i.IlanAdi;
                x.Add(t);
            }
            IsilaniDTO z = new IsilaniDTO();
            var dto2 = db.IsIlanis.Find(id);
            z.aciklama = dto2.aciklama;
            z.adres = dto2.Adres;
            z.il = dto2.il;
            z.ilce = dto2.ilce;
            z.logo = dto2.logo;
            z.SirketIsmi = dto2.SirketIsmi;
            z.YayimlamaTarihi = dto2.YayimlamaTarihi;
            z.ilanadi = dto2.IlanAdi;
            z.YayimlamaTarihi = dto2.YayimlamaTarihi;
            z.Sektor = dto2.Sektor;
            x.Add(z);
            return x;
        }
        public void revize_ilan(IsilaniDTO model)
        {

            EskiIlan eski = new EskiIlan();

            var x = db.IsIlanis.Find(model.ID);

            eski.aciklama = x.aciklama;
            eski.eskiid = x.id;
            eski.YayimlamaTarihi = x.YayimlamaTarihi;
            eski.Adres = x.Adres;
            eski.il = x.il;
            eski.ilce = x.ilce;
            eski.logo = x.logo;
            eski.Sektor = x.Sektor;
            eski.SirketIsmi = x.SirketIsmi;
            eski.IlanAdi = x.IlanAdi;
            eski.isverenid = x.isverenid;
            


            x.aciklama = model.aciklama;
            x.Adres = model.adres;
            x.il = model.il;
            x.ilce = model.ilce;
            x.logo = model.logo;
            x.Sektor = model.Sektor;
            x.SirketIsmi = model.SirketIsmi;
            x.YayimlamaTarihi = DateTime.Now;
            x.IlanAdi = model.ilanadi;
            x.isverenid = model.isverenid;

            db.EskiIlans.Add(eski);
            db.SaveChanges();
               

        }
        public void kaldir_ilan(int id)
        {
            var x = db.IsIlanis.Find(id);
            if (x.Durum == 1)
            {
                x.Durum = 2;
            }
            db.SaveChanges();


        }
       public List<BasvuruDTO> isverenbasvuru(int ID)
        {
            List<Basvurular> basvurular = db.Basvurulars.Where(x => x.isilaniid == ID).ToList();
            List<KullaniciCv> kullaniciCvs = db.KullaniciCvs.ToList();
            BasvuruDTO dto = new BasvuruDTO();
            List<BasvuruDTO> dto2 = new List<BasvuruDTO>();
            dto.cvler = new List<int?>();
            dto.adsoyad = new List<string>();
            dto.kullaniciresim = new List<string>();
            for(int i = 0; i < kullaniciCvs.Count(); i++)
            {
                for (int j = 0; j < basvurular.Count(); j++) { 
                if (kullaniciCvs[i].id==basvurular[j].cvid)
                {

                        BasvuruDTO dto3 = new BasvuruDTO();
                        dto3.isim = kullaniciCvs[i].Ad + " " + kullaniciCvs[i].Soyad;
                        dto3.idler = basvurular[j].cvid;
                        dto3.kullaniciresmi = kullaniciCvs[i].resim;
                        dto2.Add(dto3);
                        dto.cvler.Add(basvurular[j].cvid);
                        dto.adsoyad.Add(kullaniciCvs[i].Ad+" "+kullaniciCvs[i].Soyad);
                        
                        dto.kullaniciresim.Add(kullaniciCvs[i].resim);
                        
                    }
                }

            }

            return dto2;
        }
        public KullaniciCvDTO isverencvgoruntule(int id)
        {
            KullaniciCvDTO z = new KullaniciCvDTO();
            var dto2 = db.KullaniciCvs.Find(id);
            z.Onyazi = dto2.Onyazi;
            z.Adres = dto2.Adres;
            z.il = dto2.il;
            z.ilce = dto2.ilce;
            z.Resim = dto2.resim;
            z.Okul = dto2.Okul;
            z.tarih = dto2.Tarih;
            z.tarih = dto2.Tarih;
            z.BeklenenUcret = dto2.BeklenenUcret;
            z.Ad = dto2.Ad;
            z.Soyad = dto2.Soyad;
            z.Email = dto2.Email;

            z.YerDegiskeni = dto2.YerD.Split(new[] { "{\"YerD:[", "]}", "\"", "," }, StringSplitOptions.None).ToList();
            z.YerSecenek = dto2.CalisilanYerler.Split(new[] { "{\"YerS:[", "]}", "\"", "," }, StringSplitOptions.None).ToList();
            for (var k = 0; k < 3; k++)
            {
                z.YerDegiskeni.RemoveAt(0);
                z.YerSecenek.RemoveAt(0);
            }
            for (var k = 0; k < z.YerDegiskeni.Count(); k++)
            {
                if (z.YerDegiskeni[k] == "\"" || z.YerDegiskeni[k] == "")
                {
                    z.YerDegiskeni.RemoveAt(k);
                    k--;
                }
            }

            for (var k = 0; k < z.YerDegiskeni.Count(); k++)
            {
                if (z.YerSecenek[k] == "\"" || z.YerSecenek[k] == "")
                {
                    z.YerSecenek.RemoveAt(k);
                    k--;
                }
            }
            return z;
        }


    }
}
