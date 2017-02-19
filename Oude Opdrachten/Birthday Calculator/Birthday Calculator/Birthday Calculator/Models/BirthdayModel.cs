using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Birthday_Calculator.Models
{
    public class BirthdayModel : Controller
    {
        [Required(ErrorMessage = "Voer hier je naam in")]
        public String Name { get; set; }

        [Required(ErrorMessage = "Voer hier de dag in waarop je geboren bent")]
        public int Day { get; set; }

        [Required(ErrorMessage = "Voer hier de maand in waarop je geboren bent")]
        public int Month { get; set; }

        [Required(ErrorMessage = "Voer hier het jaar in waarop je geboren bent")]
        public int Year { get; set; }

    }
}