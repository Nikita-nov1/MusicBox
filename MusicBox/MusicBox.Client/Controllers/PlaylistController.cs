using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using MusicBox.App_Start.Core;
using MusicBox.Domain.Models.Entities.Identity;
using MusicBox.PresentationServices.Interfaces;
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


        [HttpPost]
        public void AddTrackToFavoritePlaylist(int trackId)
        {
            presentationServices.AddTrackToFavoritePlaylist(trackId, User.Identity.GetUserId());
        }

    }
}