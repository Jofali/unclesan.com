using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UncleSan.Models;

namespace UncleSan.Controllers
{
    public class JsController : Controller
    {
        // GET: Js
        public ActionResult Index()
        {
            SqlHelper ins = new SqlHelper();
            ViewBag.Url = ins.GetUrl("js");
            ViewBag.webpack = ins.GetUrl("webpack");
            ViewBag.node = ins.GetUrl("node");
            return View();
        }
    }
}