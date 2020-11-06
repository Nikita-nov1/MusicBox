﻿using System.Web.Mvc;
using MusicBox.Domain.Models.Entities;
using MusicBox.PresentationServices.Interfaces;

namespace MusicBox.Controllers
{
    public class ArtistController : Controller
    {
        private readonly IArtistPresentationServices presentationServices;

        public ArtistController(IArtistPresentationServices presentationServices)
        {
            this.presentationServices = presentationServices;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View(presentationServices.GetArtists());
        }

        public ActionResult RenderImage(int id) // todo доделать async
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
    }
}