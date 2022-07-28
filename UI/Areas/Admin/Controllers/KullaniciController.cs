using BBL;
using DTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Security;

namespace UI.Areas.Admin.Controllers
{

    [Authorize(Roles = "Kullanici")]
    public class KullaniciController : Controller
    {
        // GET: Admin/Kullanici
        KullaniciBBL kullaniciBBL = new KullaniciBBL();

        public ActionResult Index()
        {
            List<IsilaniDTO> isilaniDTO = new List<IsilaniDTO>();
            isilaniDTO = kullaniciBBL.sliders();
            return View(isilaniDTO);
        }
        [HttpGet]

        public ActionResult CvOlustur()
        {
            KullaniciCvDTO dto = new KullaniciCvDTO();

            return View(dto);
        }
        [HttpPost]

        public ActionResult CvOlustur(KullaniciCvDTO model, HttpPostedFileBase fileInput)
        {
            string kullaniciid = Session["kullaniciid"].ToString();
            model.ID = Convert.ToInt32(kullaniciid);
            if (fileInput != null)
            {
                WebImage img = new WebImage(fileInput.InputStream);
                FileInfo imginfo = new FileInfo(fileInput.FileName);
                string logoname = fileInput.FileName + imginfo.Extension;
                img.Save("~/Areas/Uploads/Logo/" + logoname);
                model.Resim = "/Areas/Uploads/Logo/" + logoname;
            }
            kullaniciBBL.KaydetCV(model);
            
            return RedirectToAction("Index","Kullanici");
        }
        [HttpGet]

        public ActionResult Cv()
        {

            string kullaniciid = Session["kullaniciid"].ToString();
            int id = Convert.ToInt32(kullaniciid);
            List<KullaniciCvDTO> dto = new List<KullaniciCvDTO>();
            dto = kullaniciBBL.Cv(id);

            return View(dto);
        }
        [HttpGet]

        public ActionResult CvRevize(int id)
        {
            KullaniciCvDTO dto = kullaniciBBL.revizecv(id);

            return View(dto);
        }
        [HttpPost]
        public ActionResult CvRevize(KullaniciCvDTO model, HttpPostedFileBase imgInp)
        {
            string kullaniciid = Session["kullaniciid"].ToString();
            model.kullaniciid = Convert.ToInt32(kullaniciid);
            if (imgInp != null)
            {
                if (System.IO.File.Exists(Server.MapPath(model.Resim)))
                {
                    System.IO.File.Delete(Server.MapPath(model.Resim));
                }
                WebImage img = new WebImage(imgInp.InputStream);
                FileInfo imginfo = new FileInfo(imgInp.FileName);
                string logoname = imgInp.FileName + imginfo.Extension;
                img.Save("~/Areas/Uploads/Logo/" + logoname);
                model.Resim = "/Areas/Uploads/Logo/" + logoname;
            }
            kullaniciBBL.revize_et(model);
            
            return RedirectToAction("Index", "Kullanici");
        }
        [HttpGet]
        public ActionResult CvDetay(int id)
        {
            List<KullaniciCvDTO> dto=kullaniciBBL.cvdetay(id);
            return View(dto);
        }

        [HttpGet]

        public ActionResult IsAra()
        {
            List<IsilaniDTO> dto = kullaniciBBL.isara();
            return View(dto);
        }
        [HttpGet]

        public ActionResult IsDetay(int id)
        {
            string kullaniciid = Session["kullaniciid"].ToString();
            int k_id = Convert.ToInt32(kullaniciid);
            BasvuruDTO dto = kullaniciBBL.isdetay(id,k_id);
            return View(dto);
        }
        [HttpPost]
        public ActionResult IsDetay(BasvuruDTO model,int cvId)
        {

            string kullaniciid = Session["kullaniciid"].ToString();
            int k_id = Convert.ToInt32(kullaniciid);
            model.cvid = cvId;
            model.kullaniciid=k_id;
            kullaniciBBL.basvurular(model);
            return RedirectToAction("Index","Kullanici");
        }

        public ActionResult LogOut()
        {
            Session["email"] = null;
            Session["kullaniciid"] = null;
            Session["ad"] = null;
            Session["Soyad"] = null;
            Session.Abandon();
            FormsAuthentication.SignOut();
            return RedirectToAction("KullaniciLogin", "Login");
        }

        public ActionResult IlaniKaldir2(int id)
        {
            kullaniciBBL.ilan_kaldir2(id);
            return RedirectToAction("Cv", "Kullanici");
        }
    }
}