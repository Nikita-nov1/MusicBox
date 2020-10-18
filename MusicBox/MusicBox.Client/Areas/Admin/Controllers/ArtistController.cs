using MusicBox.Areas.Admin.Models.Artists;
using MusicBox.Areas.Admin.PresentationServices.Interfaces;
using MusicBox.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MusicBox.Areas.Admin.Controllers
{
    public class ArtistController : Controller
    {
        private readonly IArtistPresentationServices presentationServices;

        public ArtistController(IArtistPresentationServices presentationServices)
        {
            this.presentationServices = presentationServices;
        }

        // GET: Admin/Artist
        public ActionResult Index()
        {
            return View(presentationServices.GetArtists());
        }

        public ActionResult RenderImage(int id)  // todo доделать async
        {
            ArtistImage artistImage = presentationServices.GetImage(id);
            if (artistImage.Image != null && !string.IsNullOrEmpty(artistImage.ContentType))
            {
                return File(artistImage.Image, artistImage.ContentType);
            }
            else
            {
                return null;
            }
        }

        // GET: Admin/Artist/Details/5
        public ActionResult Details(int id)
        {
            return View(presentationServices.GetDetailsArtistsViewModel(id));
        }

        // GET: Admin/Artist/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Artist/Create
        [HttpPost]
        public ActionResult Create(CreateArtistsViewModel artistVm)
        {
            if (ModelState.IsValid)
            {
                presentationServices.AddArtist(artistVm);
                return RedirectToAction("Index");
            }

            return View();
        }

        // GET: Admin/Artist/Edit/5
        public ActionResult Edit(int id)
        {
            return View(presentationServices.GetEditArtistVm(id));
        }

        //POST: Admin/Artist/Edit/5
        [HttpPost]
        public ActionResult Edit(EditArtistsViewModel artistVm)
        {
            if (ModelState.IsValid)
            {
                presentationServices.EditArtist(artistVm);
                return RedirectToAction("Index");
            }

            return View(artistVm);
        }


        // GET: Admin/Artist/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            return View(presentationServices.GetDeleteArtistVm((int)id));
        }

        // POST: Admin/Artist/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            if (ModelState.IsValid)
            {
                presentationServices.DeleteArtist(id);
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");

        }
    }
}
