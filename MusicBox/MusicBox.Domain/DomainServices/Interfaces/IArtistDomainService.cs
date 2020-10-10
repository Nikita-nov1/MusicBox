using MusicBox.Domain.Models.AdditionalModels;
using MusicBox.Domain.Models.Entities;
using System.Collections.Generic;

namespace MusicBox.Domain.DomainServices.Interfaces
{
    public interface IArtistDomainService : IBaseDomainService
    {
        void AddArtist(Artist artist);
        List<Artist> GetAtrists();

        List<InfArtist> GetInfArtist();
    }
}
