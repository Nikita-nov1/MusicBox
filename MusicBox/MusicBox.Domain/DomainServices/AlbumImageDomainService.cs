using MusicBox.Domain.DomainServices.Interfaces;
using MusicBox.Domain.Models.Entities;
using MusicBox.Domain.Repositories;
using MusicBox.Domain.UnitOfWork;

namespace MusicBox.Domain.DomainServices
{
    public class AlbumImageDomainService : IAlbumImageDomainService
    {
        private readonly IAlbumImageRepository albumImageRepository;
        private readonly IUnitOfWork unitOfWork;
        public AlbumImageDomainService(IAlbumImageRepository albumImageRepository, IUnitOfWork unitOfWork)
        {
            this.albumImageRepository = albumImageRepository;
            this.unitOfWork = unitOfWork;

        }

        public AlbumImage GetAlbumImage(int albumId)
        {
            return albumImageRepository.GetFirstOrDefault(albumId);
        }


    }
}
