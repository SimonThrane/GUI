using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //Brug af Ajax 
            if (Request.IsAjaxRequest())
            {
                return PartialView();
            }
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            if (Request.IsAjaxRequest())
            {
                return PartialView();
            }
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            if (Request.IsAjaxRequest())
            {
                return PartialView();
            }
            return View();
        }
    }
}