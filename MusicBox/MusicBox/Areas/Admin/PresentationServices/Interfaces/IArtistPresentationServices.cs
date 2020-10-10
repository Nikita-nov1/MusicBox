using MusicBox.Areas.Admin.Models.Artists;
using MusicBox.Domain.Models.Entities;
using System.Collections.Generic;

namespace MusicBox.Areas.Admin.PresentationServices.Interfaces
{
    public interface IArtistPresentationServices : IBaseAdminPresentationService
    {
        void AddArtist(CreateArtistsViewModel artistVm);

        List<GetArtistsViewModel> GetArtists();

        ArtistImage GetImage(int artitId);

    }
}
