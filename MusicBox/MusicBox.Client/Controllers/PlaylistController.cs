using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using MusicBox.PresentationServices.Interfaces;

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