using MusicBox.Domain.DomainServices.Interfaces;
using MusicBox.Domain.Repositories;

namespace MusicBox.Domain.DomainServices
{
    public class ArtistDomainService : IArtistDomainService
    {
        private readonly IArtistRepository artistRepository;

        public ArtistDomainService(IArtistRepository artistRepository)
        {
            this.artistRepository = artistRepository;
        }

    }
}
