using MusicBox.Domain.Models.Entities;

namespace MusicBox.Domain.DomainServices.Interfaces
{
    public interface IArtistDomainService : IBaseDomainService
    {
       void AddArtist(Artist artist);
    }
}
