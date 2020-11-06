using System.Collections.Generic;
using MusicBox.Domain.Models.Entities;
using MusicBox.Models.Artist;

namespace MusicBox.PresentationServices.Interfaces
{
    public interface IArtistPresentationServices : IBasePresentationService
    {
        List<GetArtistsForClientViewModel> GetArtists();

        ArtistImage GetImage(int artistId);
    }
}
