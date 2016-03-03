using System.Web.Mvc;
using PartyInvite.Domain.Abstract;

namespace PartyInvite.WebUI.Controllers
{
    public class NavController : Controller
    {
        private IRepository _repository;

        public NavController(IRepository iRepository)
        {
            _repository = iRepository;
        }

        public PartialViewResult Menu(string category = null)
        {
            ViewBag.SelectedCategory = category;
            return PartialView();
        }
    }
}