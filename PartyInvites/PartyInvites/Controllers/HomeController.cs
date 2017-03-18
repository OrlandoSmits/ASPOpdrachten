using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PartyInvites.Models;
using Ninject;

namespace PartyInvites.Controllers
{
    public class HomeController : Controller
    {
        private IGuestRepository _repository;

        public HomeController(IGuestRepository repository)
        {
            _repository = repository;
        }

        // GET: Home
        public ViewResult Index()
        {
            ViewBag.Attendees = _repository.GetAllResponses();
            int hour = DateTime.Now.Hour;
            ViewBag.Greeting = hour < 12 ? "Good Morning" : "Good Afternoon";
            return View();
        }

        [HttpGet]
        public ViewResult RsvpForm()
        {
            return View();
        }

        [HttpPost]
        public ViewResult RsvpForm(GuestResponse guestResponse)
        {
            if (ModelState.IsValid)
            {
                _repository.AddResponse(guestResponse);
                return View("Thanks", guestResponse);
            }
            else
            {
                return View();
            }
        }
    }
}