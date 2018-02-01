using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UncleSan.Models;
using Newtonsoft.Json;

namespace UncleSan.Controllers
{
    public class AddController : Controller
    {
        public static Boolean Success;
        // GET: Add
        public ActionResult Index()
        {
            return View();
        }

        public User SelectLogin(User Model)
        {

            SqlHelper ins = new SqlHelper();
            User usering = new User();//
            usering = ins.GetLoginToken(Model.Name);
            if(usering == null)
            {
                return null;
            }
            //Success = Model.Password == usering.Password.Replace(" ", "");
            return usering;//Model.Password == usering.Password.Replace(" ", "");
        }

        public ActionResult Weblist()
        {
            if(!Success)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
            
        }
        public int InsertData(Url Model)
        {
            int num;
            SqlHelper ins = new SqlHelper();
            num = ins.InsertUrl(Model.Name, Model.Link, Model.Slot);
            return num;
        }
    }
}