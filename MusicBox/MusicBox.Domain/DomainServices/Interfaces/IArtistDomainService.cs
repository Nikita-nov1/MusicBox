using MusicBox.Domain.Models.AdditionalModels;
using MusicBox.Domain.Models.Entities;
using System.Collections.Generic;

namespace MusicBox.Domain.DomainServices.Interfaces
{
    public interface IArtistDomainService : IBaseDomainService
    {
        Artist AddArtist(Artist artist);
        List<Artist> GetArtists();
        List<ArtistStatistics> GetArtistsStatistics();
        Artist GetArtistWithImage(int id);
        Artist GetArtist(int id);
        Artist GetArtist(string artistTitle);
        void EditArtist();
        void DeleteArtist(int id);
        Artist GetArtistWithTracksAndAlbumsWithAllAttachments(int id);
        bool IsUniqueNewTitle(string title);
        bool IsUniqueTitle(int id, string title);
        Artist GetArtistOrCreateNewIfHeNotExist(string artist);
        List<Album> GetAlbumsForArtist(string artistTitle);
        List<Album> GetAlbumsForArtist(int artistId);
        bool IsExistsArtist(string artistTitle);
        bool IsUniqueNewTitleArtistAlbum(string artistTitle, string albumTitle);
        bool IsUniqueNewTitleArtistTrack(string artistTitle, string trackTitle);
    }
}
