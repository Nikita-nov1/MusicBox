using MusicBox.Areas.Admin.Models.Albums;
using MusicBox.Domain.Models.Entities;
using System.Collections.Generic;

namespace MusicBox.Areas.Admin.PresentationServices.Interfaces
{
    public interface IAlbumPresentationServices : IBaseAdminPresentationService
    {
        void AddAlbum(CreateAlbumsViewModel albumsVm);
        List<GetAlbumsViewModel> GetAlbums();
        (List<GetAlbumsForArtistVm>, bool isExistsArtist) GetAlbumsForArtist(string artistTitle);
        AlbumImage GetImage(int albumId);
        EditAlbumsViewModel GetEditAlbumVm(int id);
        void EditAlbum(EditAlbumsViewModel albumsVm);
        DeleteAlbumsViewModel GetDeleteAlbumVm(int id);
        void DeleteAlbum(int id);
        DetailsAlbumsViewModel GetDetailsAlbumVm(int id);
    }
}
