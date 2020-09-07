using MusicBox.Domain.DomainServices.Interfaces;
using MusicBox.Domain.Repositories;

namespace MusicBox.Domain.DomainServices
{
    public class AlbumDomainService : IAlbumDomainService
    {
        private readonly IAlbumRepository albumRepository;

        public AlbumDomainService(IAlbumRepository albumRepository)
        {
            this.albumRepository = albumRepository;
        }

    }
}
