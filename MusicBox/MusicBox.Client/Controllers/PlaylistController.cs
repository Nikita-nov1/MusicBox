using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using MusicBox.App_Start.Core;
using MusicBox.Domain.Models.Entities.Identity;
using MusicBox.PresentationServices.Interfaces;
using System;
using System.Web;
using System.Web.Mvc;

namespace MusicBox.Controllers
{
    public class PlaylistController : Controller
    {
        private readonly IPlaylistPresentationServices presentationServices;

        public PlaylistController(IPlaylistPresentationServices presentationServices)
        {
            this.presentationServices = presentationServices;
        }
        private AppUserManager UserManager
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<AppUserManager>();
            }
        }

        [HttpPost]
        public void AddTrackToFavoritePlaylist(int trackId)
        {
            User user = UserManager.FindByName(User.Identity.Name);
            presentationServices.AddTrackToFavoritePlaylist(trackId,user.Id);
        }

    }
}