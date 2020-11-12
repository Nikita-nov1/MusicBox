using System.Linq;
using MusicBox.Domain.DomainServices.Interfaces;
using MusicBox.Domain.Models.Entities;
using MusicBox.Domain.Models.Entities.Identity;
using MusicBox.Domain.Repositories;
using MusicBox.Domain.UnitOfWork;

namespace MusicBox.Domain.DomainServices
{
    public class PlaylistDomainService : IPlaylistDomainService
    {
        private readonly IPlaylistRepository playlistRepository;
        private readonly IUserDomainService userDomainService;
        private readonly ITrackDomainService trackDomainService;
        private readonly IUnitOfWork unitOfWork;

        public PlaylistDomainService(IPlaylistRepository playlistRepository, IUnitOfWork unitOfWork, IUserDomainService userDomainService, ITrackDomainService trackDomainService)
        {
            this.playlistRepository = playlistRepository;
            this.userDomainService = userDomainService;
            this.trackDomainService = trackDomainService;
            this.unitOfWork = unitOfWork;
        }

        public void AddTrackToFavoritePlaylist(int trackId, string userId)
        {
            User user = userDomainService.GetUserWithPlaylistsAndTracks(userId);
            Track track = trackDomainService.GetTarck(trackId);

            user.Playlists.First().Tracks.Add(track);
            unitOfWork.SaveChanges();
        }
    }
}
