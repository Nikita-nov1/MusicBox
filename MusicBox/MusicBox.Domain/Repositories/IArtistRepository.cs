using MusicBox.Domain.Models.AdditionalModels;
using MusicBox.Domain.Models.Entities;
using System.Collections.Generic;

namespace MusicBox.Domain.Repositories
{
    public interface IArtistRepository : IBaseRepository<Artist>
    {
        List<ArtistStatistics> GetArtistsStatistics();
        Artist GetArtistWithImage(int id);
        Artist GetAtristWithTracksAndAlbumsWithAllAttachments(int id);
        bool IsUniqueNewTitle(string title);
        bool IsUniqueTitle(int id, string title);
        Artist GetFirstOrDefault(string artistTitle);
        List<Album> GetAlbumsForArtist(string artistTitle);
        Artist GetArtist(string artistTitle);
        Artist GetArtistWhitTracks(int artistId);
        bool IsExistsArtist(string artistTitle);
        bool IsUniqueNewTitleArtistAlbum(string artistTitle, string albumTitle);
    }
}
