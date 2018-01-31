using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UncleSan.Models;

namespace UncleSan.Controllers
{
    public class CSharpController : Controller
    {
        // GET: CSharp
        public ActionResult Index()
        {
            SqlHelper ins = new SqlHelper();
            ViewBag.Url = ins.GetUrl("csharp");
            return View();
        }
    }
}