using MusicBox.Domain.Models.Entities;
using MusicBox.Models.Album;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicBox.PresentationServices.Interfaces
{
    public interface IAlbumPresentationServices : IBasePresentationService
    {
       List<GetAlbumsForClientViewModel> GetAlbums();
       AlbumImage GetImage(int albumId);
    }
}
