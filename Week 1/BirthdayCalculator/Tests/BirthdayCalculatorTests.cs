using System;
using System.Collections.Generic;
using System.Web.Mvc;
using BirthdayCalculator.Controllers;
using BirthdayCalculator.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BirthdayCalculator.Tests
{
    [TestClass]
    public class BirthdayCalculatorTests
    {
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
