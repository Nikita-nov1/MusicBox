using MusicBox.Domain.Models.Entities;
using System.Collections.Generic;

namespace MusicBox.Domain.DomainServices.Interfaces
{
    public interface IAlbumDomainService : IBaseDomainService
    {
        void AddAlbum(Album album);
        List<Album> GetAlbums();
        Album GetAlbumWhitArtist(int id);
        Album GetAlbumWithImageAndArtist(int id);
        void EditAlbum();
        void DeleteAlbum(int id);
        Album GetAlbum(int id);
        List<Album> GetAlbumsForArtist(string artistTitle);
        bool IsIdExists(int id);
    }
}
