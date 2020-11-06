using System.Collections.Generic;
using MusicBox.Domain.Models.Entities;

namespace MusicBox.Domain.DomainServices.Interfaces
{
    public interface IAlbumDomainService : IBaseDomainService
    {
        void AddAlbum(Album album);

        List<Album> GetAlbumsWithArtistAndTracks();

        List<Album> GetAlbumsWithArtist();

        List<Track> GetAllTracksForAlbumWhitArtist(int albumId);

        Album GetAlbumWhitArtist(int id);

        Album GetAlbumWithImageAndArtist(int id);

        Album GetAlbumAndHisTracksWithAllAttachments(int id);

        void EditAlbum();

        void DeleteAlbum(int id);

        Album GetAlbum(int id);

        List<Album> GetAlbumsForArtist(string artistTitle);

        List<Album> GetAlbumsForArtist(int artistId);

        bool IsIdExists(int id);

        string GetAlbumTitle(int id);

        bool IsUniqueTitleArtistAlbum(int albumId, string artistTitle, string albumTitle);

        bool IsUniqueNewTitleArtistAlbum(string artistTitle, string albumTitle);
    }
}
