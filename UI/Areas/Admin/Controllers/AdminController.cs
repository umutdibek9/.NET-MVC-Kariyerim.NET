using BBL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace UI.Areas.Admin.Controllers
{
    public class AdminController : Controller
    {
        AdminBBL adminBBL = new AdminBBL();

        // GET: Admin/Admin

        [Authorize(Roles="Admin")]
        public ActionResult Index()
        {
            List<IsilaniDTO> dto = adminBBL.adminis();
            return View(dto);
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult Kaldir(int id)
        {
            adminBBL.Kaldir(id);
            return RedirectToAction("Index","Admin");
        }
        [HttpGet]
        public ActionResult KayitOl()
        {
            KayitDTO dto = new KayitDTO();
            return View(dto);
        }
        [HttpPost]
        public JsonResult KayitOl(KayitDTO model)
        {
            bool kullanici = adminBBL.KayitOl(model);
            if (kullanici == true)
            {
                return this.Json("Islem basarili", JsonRequestBehavior.AllowGet);
            }
            else
            {
                return this.Json("Islem basarisiz", JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult LogOut()
        {
            Session["email"] = null;
            Session["kullaniciid"] = null;
            Session["ad"] = null;
            Session["Soyad"] = null;
            Session.Abandon();
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Login");
        }



    }
}