using MusicBox.Domain.DomainServices.Interfaces;
using MusicBox.Domain.Models.Entities;
using MusicBox.Domain.Repositories;
using MusicBox.Domain.UnitOfWork;

namespace MusicBox.Domain.DomainServices
{
    public class ArtistImageDomainService : IArtistImageDomainService
    {
        private readonly IArtistImageRepository artistImageRepository;
        private readonly IUnitOfWork unitOfWork;
        public ArtistImageDomainService(IArtistImageRepository artistImageRepository, IUnitOfWork unitOfWork)
        {
            this.artistImageRepository = artistImageRepository;
            this.unitOfWork = unitOfWork;

        }

        public ArtistImage GetArtistImage(int artitId)
        {
            return artistImageRepository.GetFirstOrDefault(artitId);
        }
    }
}
