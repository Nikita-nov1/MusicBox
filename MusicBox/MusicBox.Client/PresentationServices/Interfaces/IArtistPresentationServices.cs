using MusicBox.Domain.Models.Entities;
using MusicBox.Models.Artist;
using System.Collections.Generic;

namespace MusicBox.PresentationServices.Interfaces
{

    public interface IArtistPresentationServices : IBasePresentationService
    {
        List<GetArtistsForClientViewModel> GetArtists();
        ArtistImage GetImage(int artistId);

    }
}
