using MusicBox.Domain.Models.AdditionalModels;
using MusicBox.Domain.Models.Entities;
using System.Collections.Generic;

namespace MusicBox.Domain.Repositories
{
    public interface IArtistRepository : IBaseRepository<Artist>
    {
        List<ArtistStatistics> GetArtistsStatistics();
        Artist GetArtistWithImage(int id);
        Artist GetArtistWithTracksAndAlbumsWithAllAttachments(int id);
        bool IsUniqueNewTitle(string title);
        bool IsUniqueTitle(int id, string title);
        Artist GetFirstOrDefault(string artistTitle);
        List<Album> GetAlbumsForArtist(string artistTitle);
        List<Album> GetAlbumsForArtist(int artistId);
        Artist GetArtist(string artistTitle);
        Artist GetArtistWhitTracks(int artistId);
        bool IsExistsArtist(string artistTitle);
        bool IsUniqueNewTitleArtistAlbum(string artistTitle, string albumTitle);
        bool IsUniqueNewTitleArtistTrack(string artistTitle, string trackTitle);
        bool IsUniqueTitleArtistAlbum(string currentAlbumTitle, string artistTitle, string albumTitle);
    }
}
