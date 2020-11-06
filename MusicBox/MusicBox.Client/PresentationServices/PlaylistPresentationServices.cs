using MusicBox.Domain.DomainServices.Interfaces;
using MusicBox.PresentationServices.Interfaces;

namespace MusicBox.PresentationServices
{
    public class PlaylistPresentationServices : IPlaylistPresentationServices
    {
        private readonly IPlaylistDomainService playlistDomainService;

        public PlaylistPresentationServices(IPlaylistDomainService playlistDomainService)
        {
            this.playlistDomainService = playlistDomainService;
        }

        public void AddTrackToFavoritePlaylist(int trackId, string userId)
        {
            playlistDomainService.AddTrackToFavoritePlaylist(trackId, userId);
        }
    }
}