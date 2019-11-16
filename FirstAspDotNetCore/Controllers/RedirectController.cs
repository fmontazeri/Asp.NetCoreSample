using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace FirstAspDotNetCore.Controllers
{
    public class RedirectController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public RedirectResult ToGitHub()
        {
            return Redirect("https://github.com/");
        }
        public IActionResult ToIndex()
        {
            return Redirect("/redirect/Index");
        }

        public IActionResult ToAction()
        {
            ViewBag.Message = "Redirect to Index";
            return RedirectToAction("Index");
        }

        public RedirectToActionResult ToForeignAction()
        {
            return RedirectToAction("GetImage", "File");
        }

        #region Pass params to another action
        public IActionResult PassParams()
        {
            return RedirectToAction("PersonInfo", new { Name = "Fatemeh", Family = "Montazeri" });

        }

        public IActionResult PersonInfo(string Name, string Family)
        {
            ViewBag.Name = Name;
            ViewBag.Family = Family;
            return View();
        }
        #endregion



    }
}