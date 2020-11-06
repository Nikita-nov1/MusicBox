using System.Collections.Generic;
using MusicBox.Areas.Admin.Models.Artists;
using MusicBox.Domain.Models.Entities;

namespace MusicBox.Areas.Admin.PresentationServices.Interfaces
{
    public interface IArtistPresentationServices : IBaseAdminPresentationService
    {
        void AddArtist(CreateArtistsViewModel artistVm);

        List<GetArtistsViewModel> GetArtists();

        ArtistImage GetImage(int artitId);

        EditArtistsViewModel GetEditArtistVm(int id);

        void EditArtist(EditArtistsViewModel artistVm);

        DeleteArtistsViewModel GetDeleteArtistVm(int id);

        void DeleteArtist(int id);

        DetailsArtistsViewModel GetDetailsArtistsViewModel(int id);
    }
}
