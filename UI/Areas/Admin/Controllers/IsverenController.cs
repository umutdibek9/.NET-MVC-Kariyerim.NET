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
    [Authorize(Roles = "Isveren")]
    public class IsverenController : Controller
    {
        // GET: Admin/Isveren
        IsverenBBL isverenBBL = new IsverenBBL();

        
        public ActionResult Index()
        {
            string isverenid = Session["isverenid"].ToString();
            int id = Convert.ToInt32(isverenid);
            List<IsilaniDTO> dto = isverenBBL.ilan_list(id);
            return View(dto);
        }
        [HttpGet]

        public ActionResult IlanOlustur()
        {
            IsilaniDTO dto = new IsilaniDTO();

            return View(dto);
        }
        [HttpPost]

        public ActionResult IlanOlustur(IsilaniDTO model, HttpPostedFileBase LogoURL)
        {
            string isverenid = Session["isverenid"].ToString();
            model.isverenid = Convert.ToInt32(isverenid);
            if (LogoURL != null)
            {
                WebImage img = new WebImage(LogoURL.InputStream);
                FileInfo imginfo = new FileInfo(LogoURL.FileName);
                string logoname = LogoURL.FileName + imginfo.Extension;
                img.Save("~/Areas/Uploads/Logo/" + logoname);
                model.logo = "/Areas/Uploads/Logo/" + logoname;
            }
            isverenBBL.Ilan(model);
            return RedirectToAction("Index", "Isveren");
           
        }
        [HttpGet]
        public ActionResult IlanDetay(int id)
        {
            //  IsilaniDTO dto = isverenBBL.ilan_detay(id);
            List<IsilaniDTO> dto = isverenBBL.ilan_detay2(id);
            return View(dto);
        }
        [HttpGet]
        public ActionResult IlanRevize(int id)
        {
            IsilaniDTO dto = isverenBBL.ilan_detay(id);

            return View(dto);
        }
        [HttpPost]
        public ActionResult IlanRevize(IsilaniDTO model,HttpPostedFileBase imgInp)
        {

            string isverenid = Session["isverenid"].ToString();
            model.isverenid = Convert.ToInt32(isverenid);
            int x = model.ID;
            if (imgInp != null)
            {
                if (System.IO.File.Exists(Server.MapPath(model.logo)))
                {
                    System.IO.File.Delete(Server.MapPath(model.logo));
                }
                WebImage img = new WebImage(imgInp.InputStream);
                FileInfo imginfo = new FileInfo(imgInp.FileName);
                string logoname = imgInp.FileName + imginfo.Extension;
                img.Save("~/Areas/Uploads/Logo/" + logoname);
                model.logo = "/Areas/Uploads/Logo/" + logoname;
            }
            isverenBBL.ilan_revize(model);


            return RedirectToAction("Index", "Isveren");

        }

        public ActionResult IlaniKaldir(int id)
        {
            isverenBBL.ilan_kaldir(id);
            return RedirectToAction("Index", "Isveren");
        }
        public ActionResult basvurusayfasi(int ID)
        {
            List<BasvuruDTO> dto = isverenBBL.isverenbasvuru(ID);
            return View(dto);
        }
        [HttpGet]

        public ActionResult KullaniciCvDetay(int id)
        {
            KullaniciCvDTO dto = isverenBBL.isverencvgoruntule(id);
            return View(dto);
        }
        public ActionResult LogOut()
        {
            Session["email"] = null;
            Session["kullaniciid"] =null;
            Session["ad"] = null;
            Session["Soyad"] = null;
            Session.Abandon();
            FormsAuthentication.SignOut();
            return RedirectToAction("IsLogin", "Login");
        }



    }
}