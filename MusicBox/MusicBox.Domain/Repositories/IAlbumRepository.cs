using System.Collections.Generic;
using MusicBox.Domain.Models.Entities;

namespace MusicBox.Domain.Repositories
{
    public interface IAlbumRepository : IBaseRepository<Album>
    {
       List<Album> GetAllWithArtistAndTracks();

       List<Album> GetAlbumsWithArtist();

       List<Track> GetAllTracksForAlbumWhitArtist(int albumId);

       Album GetAlbumWhitArtist(int id);

       Album GetAlbumWithImageAndArtist(int id);

       Album GetAlbumWhitTracks(int id);

       Album GetAlbumAndHisTracksWithAllAttachments(int id);

       bool IsIdExists(int id);

       bool IsUniqueTitleArtistAlbum(int albumId, string artistTitle, string albumTitle);

       bool IsUniqueNewTitleArtistAlbum(string artistTitle, string albumTitle);
    }
}
