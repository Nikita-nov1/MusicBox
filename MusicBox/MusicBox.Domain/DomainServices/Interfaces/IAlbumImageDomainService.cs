using MusicBox.Domain.Models.Entities;

namespace MusicBox.Domain.DomainServices.Interfaces
{
    public interface IAlbumImageDomainService : IBaseDomainService
    {
        AlbumImage GetAlbumImage(int albumId);
    }
}
