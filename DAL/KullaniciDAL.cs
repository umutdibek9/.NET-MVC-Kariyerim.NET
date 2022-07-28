using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class KullaniciDAL:DatabaseContext
    {
        public KullaniciDTO KullaniciLogin(KullaniciDTO model)
        {
            KullaniciDTO dto = new KullaniciDTO();
            Kullanici kullanici = db.Kullanicis.Where(x => x.Eposta == model.Email && x.Sifre == model.Sifre).FirstOrDefault();
            if (kullanici != null && kullanici.KullaniciId != 0)
            {
                dto.ID = kullanici.KullaniciId;
                dto.Email = kullanici.Eposta;
                dto.Ad = kullanici.Ad;
                dto.Soyad = kullanici.Soyad;
                dto.Sifre = kullanici.Sifre;

            }
            return dto;
        }
        public bool KullaniciRegister()
        {
            KullaniciDTO dto = new KullaniciDTO();
            Kullanici kullanici = db.Kullanicis.Where(x => x.Eposta == "Admin" && x.Sifre == "1234").FirstOrDefault();
            Kullanici yeni_kullanici = new Kullanici();
            if (kullanici == null)
            {
                yeni_kullanici.Eposta = "Kullanici";
                yeni_kullanici.Sifre = "1234";
                db.Kullanicis.Add(yeni_kullanici);
                db.SaveChanges();
                return true;
            }
            return false;
        }
        public bool KullaniciRol()
        {
            RolDTO dto = new RolDTO();
            Rol_Table rol = db.Rol_Table.Where(x => x.Rol == "Kullanici").FirstOrDefault();
            Rol_Table yeni_rol = new Rol_Table();
            if (rol == null)
            {
                yeni_rol.Rol = "Kullanici";
                db.Rol_Table.Add(yeni_rol);
                db.SaveChanges();
                return true;
            }
            return false;
        }
        public void CvKaydet(KullaniciCvDTO model)
        {
            KullaniciCv db_kullanici = new KullaniciCv();

            db_kullanici.Onyazi = model.Onyazi;
            db_kullanici.Okul = model.Okul;
            db_kullanici.resim = model.Resim;
            db_kullanici.il = model.il;
            db_kullanici.ilce = model.ilce;
            db_kullanici.Ad = model.Ad;
            db_kullanici.Soyad = model.Soyad;
            db_kullanici.Adres = model.Adres;
            db_kullanici.kullaniciid = model.ID;
            db_kullanici.Bolum = model.Bolum;
            db_kullanici.CalisilanYerler = model.YerS;
            db_kullanici.YerD = model.YerD;
            db_kullanici.AGNO = model.AGNO;
            db_kullanici.BeklenenUcret = model.BeklenenUcret;
            db_kullanici.Email = model.Email;
            db_kullanici.Durum = 1;
            db_kullanici.Tarih = DateTime.Now;
            db.KullaniciCvs.Add(db_kullanici);
            db.SaveChanges();

        }
        public void kaldir_ilan2(int id)
        {
            var x = db.KullaniciCvs.Find(id);
          
                x.Durum = 2;
            db.SaveChanges();


        }
        public List<IsilaniDTO> slider()
        {
            List<IsIlani> dto=db.IsIlanis.ToList();
            List<IsilaniDTO> model = new List<IsilaniDTO>();
            foreach(var i in dto)
            {
                IsilaniDTO d = new IsilaniDTO();
             
                d.logo = i.logo;
                
                model.Add(d);
            }
            return model;
        }
        public List<KullaniciCvDTO> Cv(int id)
        {
            var model = db.KullaniciCvs.Where(x=>x.kullaniciid==id).ToList();
            List<KullaniciCvDTO> dto = new List<KullaniciCvDTO>();
            foreach(var i in model)
            {
                KullaniciCvDTO dto1 = new KullaniciCvDTO();
                dto1.Ad = i.Ad;
                dto1.Soyad = i.Soyad;
                dto1.ID = i.id;
                if (i.Durum == 1) { 
                dto1.CvDurum = DTO.CvDurum.Aktif;
                }
                else {
                    dto1.CvDurum = DTO.CvDurum.Kaldirilmis;
                }
                dto.Add(dto1);
            }
            return dto;


        }
        public KullaniciCvDTO RevizeCv(int id)
        {
            var model = db.KullaniciCvs.Where(x=>x.id==id).FirstOrDefault();
            KullaniciCvDTO dto = new KullaniciCvDTO();
            
                dto.Ad = model.Ad;
                dto.Soyad = model.Soyad;
                dto.ID = model.id;
                dto.Adres = model.Adres;
                dto.AGNO = model.AGNO;
                dto.BeklenenUcret = model.BeklenenUcret;
                dto.Bolum = model.Bolum;
                dto.Email = model.Email;
                dto.il = model.il;
                dto.ilce = model.ilce;
                dto.Onyazi = model.Onyazi;
                dto.Resim = model.resim;
                dto.YerD = model.YerD;
                dto.YerS = model.CalisilanYerler;
            dto.Okul = model.Okul;
            


            dto.YerDegiskeni= model.YerD.Split(new[] { "{\"YerD:[", "]}", "\"", "," }, StringSplitOptions.None).ToList();
            dto.YerSecenek = model.CalisilanYerler.Split(new[] { "{\"YerS:[", "]}", "\"", "," }, StringSplitOptions.None).ToList();
            for(var i = 0; i < 3; i++)
            {
                dto.YerDegiskeni.RemoveAt(0);
                dto.YerSecenek.RemoveAt(0);
            }
            for (var i = 0; i < dto.YerDegiskeni.Count(); i++)
            {
                if (dto.YerDegiskeni[i] == "\"" || dto.YerDegiskeni[i]=="")
                {
                    dto.YerDegiskeni.RemoveAt(i);
                    i--;
                }
            }

            for (var i = 0; i < dto.YerDegiskeni.Count(); i++)
            {
                if (dto.YerSecenek[i] == "\"" || dto.YerSecenek[i]=="")
                {
                    dto.YerSecenek.RemoveAt(i);
                    i--;
                }
            }

            return dto;


        }
        public void revize_et(KullaniciCvDTO model)
        {
            EskiCv eski = new EskiCv();

            var x = db.KullaniciCvs.Find(model.ID);

            eski.Ad = x.Ad;
            eski.Soyad = x.Soyad;
            eski.Okul = x.Okul;
            eski.AGNO = x.AGNO;
            eski.Onyazi = x.Onyazi;
            eski.cvid = x.id;
            eski.Tarih = x.Tarih;
            eski.Adres = x.Adres;
            eski.il = x.il;
            eski.ilce = x.ilce;
            eski.resim = x.resim;
            eski.BeklenenUcret = x.BeklenenUcret;
            eski.Bolum = x.Bolum;
            eski.Email = x.Email;
            eski.kullaniciid = x.kullaniciid;
            eski.YerD = x.YerD;
            eski.CalisilanYerler = x.CalisilanYerler;



            x.Onyazi = model.Onyazi;
            x.Adres = model.Adres;
            x.il = model.il;
            x.ilce = model.ilce;
            x.resim = model.Resim;
            x.BeklenenUcret = model.BeklenenUcret;
            x.Bolum = model.Bolum;
            x.Tarih = DateTime.Now;
            x.Soyad = model.Soyad;
            x.kullaniciid = model.kullaniciid;
            x.Email = model.Email;

            db.EskiCvs.Add(eski);
            db.SaveChanges();
        }
        public List<KullaniciCvDTO> CvDetay(int id)
        {
           
                List<KullaniciCvDTO> x = new List<KullaniciCvDTO>();
                var dto = db.EskiCvs.Where(y => y.cvid == id);
                KullaniciCvDTO t = new KullaniciCvDTO();
                foreach (var i in dto)
                {
                    t.Onyazi = i.Onyazi;
                    t.Adres = i.Adres;
                    t.il = i.il;
                    t.ilce = i.ilce;
                    t.Resim = i.resim;
                    t.BeklenenUcret = i.BeklenenUcret;
                    t.Bolum = i.Bolum;
                    t.tarih = i.Tarih;
                    t.YerD = i.YerD;
                    t.YerS = i.CalisilanYerler;
                    t.Ad = i.Ad;
                    t.Soyad = i.Soyad;
                    t.AGNO = i.AGNO;
                t.Email = i.Email;
                t.YerDegiskeni = i.YerD.Split(new[] { "{\"YerD:[", "]}", "\"", "," }, StringSplitOptions.None).ToList();
                t.YerSecenek = i.CalisilanYerler.Split(new[] { "{\"YerS:[", "]}", "\"", "," }, StringSplitOptions.None).ToList();
                for (var k = 0; k < 3; k++)
                {
                    t.YerDegiskeni.RemoveAt(0);
                    t.YerSecenek.RemoveAt(0);
                }
                for (var k = 0; k < t.YerDegiskeni.Count(); k++)
                {
                    if (t.YerDegiskeni[k] == "\"" || t.YerDegiskeni[k] == "")
                    {
                        t.YerDegiskeni.RemoveAt(k);
                        k--;
                    }
                }

                for (var k = 0; k < t.YerDegiskeni.Count(); k++)
                {
                    if (t.YerSecenek[k] == "\"" || t.YerSecenek[k] == "")
                    {
                        t.YerSecenek.RemoveAt(k);
                        k--;
                    }
                }
                x.Add(t);
                }
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



            x.Add(z);
                return x;
            
        }
        public List<IsilaniDTO> isara()
        {
            List<IsIlani> model = new List<IsIlani>();
            List<IsilaniDTO> dto = new List<IsilaniDTO>();
            model = db.IsIlanis.ToList();

            foreach(var i in model)
            {
                IsilaniDTO q = new IsilaniDTO();
                q.logo = i.logo;
                q.ilanadi = i.IlanAdi;
                q.ID = i.id;
                dto.Add(q);

            }

            return dto;
        }
        public BasvuruDTO isdetay(int id,int k_id)
        {
            BasvuruDTO dto = new BasvuruDTO();
            dto.ids = new List<int>();
            dto.cvids = new List<int>();
            IsIlani model = db.IsIlanis.Where(x => x.id == id).FirstOrDefault();
            List<KullaniciCv> kullaniciCvs = db.KullaniciCvs.Where(x=>x.kullaniciid==k_id).ToList();

            for (var i = 0; i < kullaniciCvs.Count(); i++)
            {
                if (kullaniciCvs[i].Durum == 1) { 
                int x = kullaniciCvs[i].kullaniciid;
                int y = kullaniciCvs[i].id;
                
                dto.ids.Add(x);
                dto.cvids.Add(y);
                }
            }
            dto.aciklama = model.aciklama;
            dto.adres = model.Adres;
            dto.ilanadi = model.IlanAdi;
            dto.il = model.il;
            dto.ilce = model.ilce;
            dto.logo = model.logo;
            dto.Sektor = model.Sektor;
            dto.YayimlamaTarihi = model.YayimlamaTarihi;
            dto.SirketIsmi = model.SirketIsmi;
            
            return dto;
        }
        public void basvuru(BasvuruDTO dto)
        {
            Basvurular basvurular = new Basvurular();
            basvurular.kullaniciid = dto.kullaniciid;
            basvurular.cvid = dto.cvid;
            basvurular.isilaniid = dto.ID;
            db.Basvurulars.Add(basvurular);
            db.SaveChanges();

        }

    }
}
