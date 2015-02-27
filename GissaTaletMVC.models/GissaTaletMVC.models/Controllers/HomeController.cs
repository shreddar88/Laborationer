using GissaTaletMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GissaTaletMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var number = GetNumber();
            return View(number);
        }

        public ActionResult NewPage()
        {
            GetNumber().Initialize();
            return RedirectToAction("Index");
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Index(int? number)
        {
            if (Session.IsNewSession)
            {
                return View("SessionError"); //skapa ny vy kallad ex SessionError, där du skriver ut felet
            }

            var secretNumber = GetNumber();

            if (!number.HasValue)
            {
                ModelState.AddModelError("number", "Ange ett tal");
            }

            else if (number < 1 || number > 100)
            {
                
                ModelState.AddModelError("number", "Talet måste vara mellan 1 och 100");
            }

            else
            {
                secretNumber.MakeGuess(number.Value);
            }

            return View(secretNumber);
        }

        private SecretNumber GetNumber()
        {
            var number = (SecretNumber)Session["Number"];
            if (number == null)
            {
                number = new SecretNumber();
                Session["Number"] = number;
            }
            return number;
        }

    }
}