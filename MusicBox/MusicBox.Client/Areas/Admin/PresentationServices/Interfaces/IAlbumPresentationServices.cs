using MusicBox.Areas.Admin.Models.Albums;
using MusicBox.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicBox.Areas.Admin.PresentationServices.Interfaces
{
    public interface IAlbumPresentationServices : IBaseAdminPresentationService
    {
        void AddAlbum(CreateAlbumsViewModel albumsVm);
        List<GetAlbumsViewModel> GetAlbums();
        AlbumImage GetImage(int albumId);
        EditAlbumsViewModel GetEditAlbumVm(int id);
        void EditAlbum(EditAlbumsViewModel albumsVm);
        DeleteAlbumsViewModel GetDeleteAlbumtVm(int id);
        void DeleteAlbum(int id);
    }
}
