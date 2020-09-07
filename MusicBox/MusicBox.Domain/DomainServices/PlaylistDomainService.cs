using MusicBox.Domain.DomainServices.Interfaces;
using MusicBox.Domain.Repositories;

namespace MusicBox.Domain.DomainServices
{
    public class PlaylistDomainService : IPlaylistDomainService
    {
        private readonly IPlaylistRepository playlistRepository;

        public PlaylistDomainService(IPlaylistRepository playlistRepository)
        {
            this.playlistRepository = playlistRepository;
        }

    }
}
