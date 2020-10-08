using MusicBox.Areas.Admin.Models.Artists;
using MusicBox.Areas.Admin.PresentationServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicBox.Areas.Admin.Controllers
{
    public class ArtistController : Controller
    {
        readonly IArtistPresentationServices presentationServices;

        public ArtistController(IArtistPresentationServices presentationServices)
        {
            this.presentationServices = presentationServices;
        }

        // GET: Admin/Artist
        public ActionResult Index()
        {
            return View();
        }

        // GET: Admin/Artist/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Artist/Create
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
            return View();
        }

        // POST: Admin/Artist/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Artist/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/Artist/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
