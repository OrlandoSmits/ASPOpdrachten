using System;
using System.Collections.Generic;
using System.Runtime.Remoting;
using System.Web.Mvc;
using BirthdayCalculator.Controllers;
using BirthdayCalculator.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BirthdayCalculator.Tests
{
    [TestClass]
    public class BirthdayCalculatorTests
    {
        // Unit test om te kijken of het formulier gesubmitted is en er dus een View Geladen word
        [TestMethod]
        public void CanFillInForm()
        {
            //Arange
            BirthdayResponse birthdayRespone = new BirthdayResponse()
            {
                Name = "Orlando",
                Day = 13,
                Month = 02,
                Year = 1995
            };

            HomeController targetController = new HomeController();

            // Act
            ActionResult result = targetController.BirthdayForm(birthdayRespone);

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }
    }
}
