using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Birthday_Calculator.Models;

namespace Birthday_Calculator.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            String currentDate = DateTime.Now.ToString("dd MMMM yyy");
            ViewBag.Greeting = "Het is vandaag: " + currentDate;
            
            return View();
        }
        [HttpGet]
        public ViewResult FormPage()
        {
            ViewBag.Message = "Bereken het aantal dagen tot mijn verjaardag";

            return View();
        }
        [HttpPost]
        public ViewResult FormPage(BirthdayModel birthdayModel)
        {
            //Ophalen van de velden uit het form.
            
            //Bepalen van de datum van vandaag. 

            //Bepalen van het aantal dagen tot aan de verjaardag.
        



        }
    }
}