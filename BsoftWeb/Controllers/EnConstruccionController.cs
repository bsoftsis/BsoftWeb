using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BsoftWeb.Controllers
{
    public class EnConstruccionController : Controller
    {
        // GET: EnConstruccion
        public ActionResult Index()
        {
            ViewBag.Message = "En costrucion!!!";
            return View();
        }
    }
}
