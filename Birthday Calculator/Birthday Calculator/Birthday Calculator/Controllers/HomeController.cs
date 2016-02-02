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
            //Ophalen van de velden uit het form in een DateTime object.


            DateTime inputBirthday = new DateTime(birthdayModel.Year, birthdayModel.Month, birthdayModel.Day);
            

            //Bepalen van de datum van vandaag. 
            DateTime dateToday = DateTime.Today;

            //Haal de volgende verjaardag op, kijken naar het verschil van het jaartal van vandaag en het geboortejaar. 
            DateTime nextBirthDay = inputBirthday.AddYears(dateToday.Year - inputBirthday.Year);

            //Het aantal overgebleven dagen tot aan de volgende verjaardag. 
            int numbDays = (nextBirthDay - dateToday).Days;
            ViewBag.numbDays = numbDays;


            return View("Uitkomst", birthdayModel);

            //Bepalen van het aantal dagen tot aan de verjaardag.




        }
    }
}