using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UncleSan.Models;

namespace UncleSan.Controllers
{
    public class AspnetController : Controller
    {
        // GET: Aspnet
        public ActionResult Index()
        {
            SqlHelper ins = new SqlHelper();
            ViewBag.Url = ins.GetUrl("aspnet");
            return View();
        }
    }
}