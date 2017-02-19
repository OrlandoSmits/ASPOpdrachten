using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BirthdayCalculator.Models;

namespace BirthdayCalculator.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ViewResult Index()
        {
            // Get the current date/time
            string hour = DateTime.Now.ToString("D");
            ViewBag.CurrentDate = hour;
            return View();
        }

        public ViewResult NotYet()
        {
            return View();
        }

        public ViewResult Birthday()
        {
            return View();
        }

        [HttpGet]
        public ViewResult BirthdayForm()
        {
            return View();
        }

        [HttpPost]
        public ViewResult BirthdayForm(BirthdayResponse birthdayResponse)
        {
            double Difference = birthdayResponse.getDaysTillBirthday();
            
            if (Difference > 0)
            {
                ViewBag.DaysTillBirthday = Difference;
                return View("NotYet", birthdayResponse);
            } else
            {
                ViewBag.Name = birthdayResponse.Name;
                ViewBag.Age = birthdayResponse.getUserAge();
                return View("Birthday", birthdayResponse);
            }

        }
    }
}