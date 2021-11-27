using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCAdoConnection.Models;
using MVCAdoConnection.ViewModels;

namespace MVCAdoConnection.Controllers
{
    public class HomeController : Controller
    {
        clsFamily objFamily = new clsFamily();
        public ActionResult Index()
        {
            List<clsFamilyMember> objMemberEntity = new List<clsFamilyMember>();
            //objFamily.InsertFamliyMemberDetail();
            objMemberEntity = objFamily.GetFamilyDetails();
            return View(objMemberEntity);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}