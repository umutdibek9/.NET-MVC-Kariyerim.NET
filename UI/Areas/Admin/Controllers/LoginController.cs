using BBL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace UI.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        AdminBBL adminBBL = new AdminBBL();
        IsverenBBL isverenBBL = new IsverenBBL();
        KullaniciBBL kullaniciBBL = new KullaniciBBL();

        // GET: Admin/Login
        public ActionResult Index()
        {
            AdminDTO dto = new AdminDTO();

            return View(dto);
        }
        [HttpPost]
        public ActionResult Index(AdminDTO model)
        {
            if (ModelState.IsValid) {

                AdminDTO kullanici = adminBBL.Login(model);
                if (kullanici.ID != 0)
                {
                    FormsAuthentication.SetAuthCookie(kullanici.Email, false);
                    Session["email"] = kullanici.Email;
                    Session["kullaniciid"] = kullanici.ID;
                    Session["ad"] = kullanici.Ad;
                    Session["Soyad"] = kullanici.Soyad;
                    return RedirectToAction("Index","Admin");
                }
                else
                {
                    return View(model);

                }
                }
            else
            {

                return View(model);
            }   

        }
        [HttpGet]
        public ActionResult IsLogin()
        {
            IsverenDTO dto = new IsverenDTO();

            return View(dto);
        }
        [HttpPost]
        public ActionResult IsLogin(IsverenDTO model)
        {
            if (ModelState.IsValid)
            {

                IsverenDTO isveren = isverenBBL.Login(model);
                if (isveren.ID != 0)
                {

                    FormsAuthentication.SetAuthCookie(isveren.Email, false);
                    Session["email"] = isveren.Email;
                    Session["kullaniciid"] = isveren.ID;
                    Session["ad"] = isveren.Ad;
                    Session["Soyad"] = isveren.Soyad;
                    Session["isverenid"] = isveren.ID;
                    return RedirectToAction("Index", "Isveren");
                }
                else
                {
                    return View(model);

                }
            }
            else
            {

                return View(model);
            }

        }
        [AllowAnonymous]
        public JsonResult Register()
        {

            bool rol = adminBBL.RolRegister();
            bool kullanici = adminBBL.Register();
            if (kullanici == true && rol == true)
            {
                return this.Json("Islem basarili", JsonRequestBehavior.AllowGet);
            }
            else
            {
                return this.Json("Islem basarisiz", JsonRequestBehavior.AllowGet);
            }

        }
        [HttpGet]
        public ActionResult KullaniciLogin()
        {
            KullaniciDTO dto = new KullaniciDTO();

            return View(dto);
        }
        [HttpPost]
        public ActionResult KullaniciLogin(KullaniciDTO model)
        {
            if (ModelState.IsValid)
            {

                KullaniciDTO kullanici = kullaniciBBL.KullaniciLogin(model);
                if (kullanici.ID != 0)
                {
                    FormsAuthentication.SetAuthCookie(kullanici.Email, false);
                    Session["email"] = kullanici.Email;
                    Session["kullaniciid"] = kullanici.ID;
                    Session["ad"] = kullanici.Ad;
                    Session["Soyad"] = kullanici.Soyad;
                    return RedirectToAction("Index", "Kullanici");
                }
                else
                {
                    return View(model);

                }
            }
            else
            {

                return View(model);
            }

        }
        [AllowAnonymous]
        public JsonResult KullaniciRegister()
        {

            bool rol = kullaniciBBL.KullaniciRol();
            bool kullanici = kullaniciBBL.KullaniciRegister();
            if (kullanici == true && rol == true)
            {
                return this.Json("Islem basarili", JsonRequestBehavior.AllowGet);
            }
            else
            {
                return this.Json("Islem basarisiz", JsonRequestBehavior.AllowGet);
            }

        }
    }
}