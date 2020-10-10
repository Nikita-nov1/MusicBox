using MusicBox.Domain.Models.Entities;

namespace MusicBox.Domain.DomainServices.Interfaces
{
    public interface IArtistImageDomainService : IBaseDomainService
    {
        ArtistImage GetArtistImage(int artitId);
    }
}
