using System.Web.Mvc;
using MusicBox.Domain.Models.Entities;
using MusicBox.PresentationServices.Interfaces;

namespace MusicBox.Controllers
{
    public class AlbumController : Controller
    {
        private readonly IAlbumPresentationServices presentationServices;

        public AlbumController(IAlbumPresentationServices presentationServices)
        {
            this.presentationServices = presentationServices;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View(presentationServices.GetAlbums());
        }

        public ActionResult RenderImage(int id) // todo доделать async
        {
            AlbumImage albumImage = presentationServices.GetImage(id);
            if (albumImage.Image != null && !string.IsNullOrEmpty(albumImage.ContentType))
            {
                return File(albumImage.Image, albumImage.ContentType);
            }
            else
            {
                return null;
            }
        }
    }
}