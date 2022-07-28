using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UI.Areas.Admin.Controllers
{
    public class SiteController : Controller
    {
        // GET: Admin/Site
        public ActionResult Index()
        {
            return View();
        }
    }
}