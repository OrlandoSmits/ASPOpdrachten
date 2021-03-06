﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PartyInvites.Models;

namespace PartyInvites.Controllers
{
    public class HomeController : Controller
    {

        private IPartyRepository _repository;
        public ActionResult Index()
        {
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
                return View("Thanks", guestResponse);
            }
            else
            {
                return View();
            }
         
        }

        public ViewResult Attendees()
        {
            IEnumerable<GuestResponse> responses = _repository.GetAllResponses();

            ViewResult result;

            if (responses.Any())
            {
                result = View(responses);
            }
            else
            {
                result = View("NoAttendees");
            }
        }
    }
}