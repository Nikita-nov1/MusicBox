using MusicBox.Domain.Models.Entities;
using System.Collections.Generic;

namespace MusicBox.Domain.Repositories
{
    public interface IAlbumRepository : IBaseRepository<Album>
    {
       List<Album> GetAllWithArtistAndTracks();
       Album GetAlbumWhitArtist(int id);
       Album GetAlbumWithImageAndArtist(int id);
       Album GetAlbumWhitTracks(int id);
       Album GetAlbumAndHisTracksWithAllAttachments(int id);
       bool IsIdExists(int id);
    }
}
