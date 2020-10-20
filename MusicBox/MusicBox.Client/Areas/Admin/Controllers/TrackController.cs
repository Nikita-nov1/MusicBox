using MusicBox.Areas.Admin.Models.Tracks;
using MusicBox.Areas.Admin.PresentationServices.Interfaces;
using MusicBox.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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

        //public ActionResult RenderImage(int id)  // todo доделать async
        //{
        //    AlbumImage albumImage = presentationServices.GetImage(id);
        //    if (albumImage.Image != null && !string.IsNullOrEmpty(albumImage.ContentType))
        //    {
        //        return File(albumImage.Image, albumImage.ContentType);
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}



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

        //[HttpGet]
        //public ActionResult Edit(int id)
        //{
        //    return View(presentationServices.GetEditAlbumVm(id));
        //}

        //[HttpPost]
        //public ActionResult Edit(EditAlbumsViewModel albumsVm)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        presentationServices.EditAlbum(albumsVm);
        //        return RedirectToAction("Index");
        //    }

        //    return View(albumsVm);
        //}

        //[HttpGet]
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }

        //    return View(presentationServices.GetDeleteAlbumtVm((int)id));
        //}

        //[HttpPost, ActionName("Delete")]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        presentationServices.DeleteAlbum(id);
        //        return RedirectToAction("Index");
        //    }

        //    return RedirectToAction("Index");

        //}

    }
}