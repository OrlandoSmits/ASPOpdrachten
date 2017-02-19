using System;
using System.Linq;
using System.Web.Mvc;
using PartyInvite.Domain.Abstract;
using PartyInvite.WebUI.Models;

namespace PartyInvite.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private IRepository _repository;

        public HomeController(IRepository repositoryParam)
        {
            _repository = repositoryParam;
        }

        public ViewResult Index()
        {
            return View();
        }
    }
}