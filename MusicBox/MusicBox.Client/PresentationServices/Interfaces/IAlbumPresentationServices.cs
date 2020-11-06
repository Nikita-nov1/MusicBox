using System.Collections.Generic;
using MusicBox.Domain.Models.Entities;
using MusicBox.Models.Album;

namespace MusicBox.PresentationServices.Interfaces
{
    public interface IAlbumPresentationServices : IBasePresentationService
    {
        List<GetAlbumsForClientViewModel> GetAlbums();

        AlbumImage GetImage(int albumId);
    }
}
