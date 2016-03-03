using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PartyInvite.Domain.Abstract;
using PartyInvite.Domain.Entities;
using PartyInvite.WebUI.Models;

namespace PartyInvite.WebUI.Controllers
{
    public class ResponseController : Controller
    {
        private IRepository _repository;
        public int PageSize = 4;

        public ResponseController(IRepository guestResponseRepository)
        {
            _repository = guestResponseRepository;
        }

        public ViewResult Index()
        {
            return View();
        }

        public PartialViewResult Summary()
        {
            WidgetViewModel model = new WidgetViewModel()
            {
                GuestResponses = _repository.GuestResponses.Count(),
                Present = _repository.GuestResponses.Count(g => g.WillAttend == true)
            };
            return PartialView(model);
        }

        //Create function
        [HttpGet]
        public ViewResult Rsvp()
        {
            return View();
        }

        [HttpPost]
        public ViewResult Rsvp(GuestResponse response, HttpPostedFileBase image = null)
        {
            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    response.ImageMimeType = image.ContentType;
                    response.ImageData = new byte[image.ContentLength];
                    image.InputStream.Read(response.ImageData, 0, image.ContentLength);
                }
                _repository.AddResponse(response);
                return View("Thanks", response);
            }
            else
            {
                return View();
            }
        }


        public ViewResult List(bool? category, int page = 1)
        {
            GuestResponseListViewModel model = new GuestResponseListViewModel()
            {
                GuestResponses =
                    _repository.GuestResponses.Where(g => category == null || g.WillAttend == category)
                    // .OrderBy(g => g.Name) //OrderBy Makes test fail
                    .Skip((page - 1) * PageSize)
                    .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = category == null ?
                       _repository.GuestResponses.Count() :
                       _repository.GuestResponses.Count(e => e.WillAttend == category)
                },
                CurrentCategory = category
            };
            return System.Web.UI.WebControls.View(model);
        }


        public FileContentResult GetImage(string email)
        {
            GuestResponse guestResponse = _repository.GuestResponses
                .FirstOrDefault(g => g.Email == email);
            if (guestResponse != null)
            {
                return File(guestResponse.ImageData, guestResponse.ImageMimeType);
            }
            return null;
        }
    }
}
