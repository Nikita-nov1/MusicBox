using System.Web.Mvc;
using MusicBox.PresentationServices.Interfaces;

namespace MusicBox.Controllers
{
    public class TrackController : Controller
    {
        private readonly ITrackPresentationService presentationServices;

        public TrackController(ITrackPresentationService presentationServices)
        {
            this.presentationServices = presentationServices;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult TracksAjaxPartialForAlbum(int albumId)
        {
            return PartialView("TracksAjaxPartialForAlbum", presentationServices.GetTracksVmForAlbum(albumId));
        }

        [HttpPost]
        public ActionResult TracksAjaxPartialForArtist(int artistId)
        {
            return PartialView("TracksAjaxPartialForArtist", presentationServices.GetTracksVmForArtist(artistId));
        }

        [HttpPost]
        public ActionResult GetTrackInformation(int trackId)
        {
            return Json(presentationServices.GetTrackInformationForPlay(trackId));
        }
    }
}