using MusicBox.Areas.Admin.Models.Albums;
using MusicBox.Areas.Admin.PresentationServices.Interfaces;
using MusicBox.Domain.Models.Entities;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;

namespace MusicBox.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
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

        public ActionResult RenderImage(int id)  // todo доделать async
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

        public ActionResult Details(int id)
        {
            return View(presentationServices.GetDetailsAlbumVm(id));

        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();

        }

        [HttpPost]
        public ActionResult Create(CreateAlbumsViewModel albumsVm)
        {
            if (ModelState.IsValid)
            {
                presentationServices.AddAlbum(albumsVm);
                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(presentationServices.GetEditAlbumVm(id));
        }

        [HttpPost]
        public ActionResult Edit(EditAlbumsViewModel albumsVm)
        {
            if (ModelState.IsValid)
            {
                presentationServices.EditAlbum(albumsVm);
                return RedirectToAction("Index");
            }

            return View(albumsVm);
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            return View(presentationServices.GetDeleteAlbumVm((int)id));
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            if (ModelState.IsValid)
            {
                presentationServices.DeleteAlbum(id);
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");

        }

        [HttpPost]
        public ActionResult GetAlbumsForArtist(string artist)
        {
            (List<GetAlbumsForArtistVm>, bool isExistsArtist) albums = presentationServices.GetAlbumsForArtist(artist);

            return Json(albums);
        }
    }
}