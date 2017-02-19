using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace BirthdayCalculator.Models
{
    public class BirthdayResponse
    {
        [Required(ErrorMessage = "Vul alstublieft uw naam in")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Vul alstublieft uw geboortedag in cijfers in")]
        public int Day { get; set; }

        [Required(ErrorMessage = "Vul alstublieft uw geboortemaand in cijfers in")]
        public int Month { get; set; }

        [Required(ErrorMessage = "Vul alstublieft uw geboortejaar in cijfers in")]
        public int Year { get; set; }

        public int getDaysTillBirthday()
        {
            // De dag van vandaag
            DateTime Today = DateTime.Today;

            // De ingevoerde dag
            DateTime inputDate = new DateTime(this.Year, this.Month, this.Day);

            // De volgende verjaardag ophalen
            DateTime nextBirthday = inputDate.AddYears(Today.Year - inputDate.Year);

            if(nextBirthday < Today)
            {
                // Als de ingevoerde verjaardag lager is dan vandaag, voeg een jaar toe aan deze datum
                nextBirthday = nextBirthday.AddYears(1);
            }
            
            int diff = (nextBirthday - Today).Days;
            // Bereken het verschil tussen de datums
            return diff;
        }

        public double getUserAge()
        {
            // De dag van vandaag
            DateTime Today = DateTime.Today;

            // De ingevoerde dag
            DateTime BirthDay = new DateTime(this.Year, this.Month, this.Day);

            // Bereken de leeftijd van de gebruiker
            double age = Math.Round(((Today - BirthDay).TotalDays) / 365);

            return age;
        }
    }
}