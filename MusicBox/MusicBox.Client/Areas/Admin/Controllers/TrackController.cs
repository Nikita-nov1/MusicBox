using MusicBox.Areas.Admin.Models.Tracks;
using MusicBox.Areas.Admin.PresentationServices.Interfaces;
using System.Net;
using System.Web.Mvc;

namespace MusicBox.Areas.Admin.Controllers
{
    public class TrackController : Controller
    {
        private readonly ITrackPresentationServices presentationServices;

        public TrackController(ITrackPresentationServices presentationServices)
        {
            this.presentationServices = presentationServices;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View(presentationServices.GetTracks());
        }

        ////// GET: Admin/Artist/Details/5
        ////public ActionResult Details(int id)
        ////{
        ////    return View(presentationServices.GetDetailsArtistsViewModel(id));
        ////}

        [HttpGet]
        public ActionResult Create()
        {
            return View(presentationServices.GetCreateTrackVm());
        }

        [HttpPost]
        public ActionResult Create(CreateTracksViewModel tracksVm)
        {
            if (ModelState.IsValid)
            {
                presentationServices.AddTrack(tracksVm);
                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(presentationServices.GetEditTrackVm(id));
        }

        [HttpPost]
        public ActionResult Edit(EditTracksViewModel trackVm)
        {
            if (ModelState.IsValid)
            {
                presentationServices.EditTrack(trackVm);
                return RedirectToAction("Index");
            }

            return View(trackVm);
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            return View(presentationServices.GetDeleteTrackVm((int)id));
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            if (ModelState.IsValid)
            {
                presentationServices.DeleteTrack(id);
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");

        }

    }
}