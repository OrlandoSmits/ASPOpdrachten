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
            ViewBag.Message = "Bereken het aantal dagen tot je verjaardag";

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

            if (nextBirthDay < dateToday)
            {
                nextBirthDay = nextBirthDay.AddYears(1);
            }

            //Het aantal overgebleven dagen tot aan de volgende verjaardag. 
            int numbDays = (nextBirthDay - dateToday).Days;
            ViewBag.numbDays = numbDays;
            
            //Berekenen van de leeftijd en afronden op een heel getal
            double age = Math.Round(((dateToday - inputBirthday).TotalDays) / 365);

           
            @ViewBag.age = (age);


            return View("Uitkomst", birthdayModel);

            




        }
    }
}