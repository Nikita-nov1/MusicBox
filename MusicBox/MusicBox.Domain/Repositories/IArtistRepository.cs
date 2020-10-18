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
        Artist Get(string artistTitle);
        List<Album> GetAlbumsForArtist(int artistId);

    }
}
