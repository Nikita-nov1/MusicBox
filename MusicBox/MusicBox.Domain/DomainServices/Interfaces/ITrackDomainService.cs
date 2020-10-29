using MusicBox.Domain.Models.Entities;
using System.Collections.Generic;
using System.Web;

namespace MusicBox.Domain.DomainServices.Interfaces
{
    public interface ITrackDomainService : IBaseDomainService  
    {
        void AddTrack(Track track, HttpPostedFileBase uploadTrack);
        List<Track> GetTracksWithAllAttachmentsExceptPlaylistsAndTrackFile();
        List<Track> GetAllTracksForAlbumWhitArtist(int albumId);
        List<Track> GetAllTracksForArtistWhitArtist(int artistId);
        Track GetTarck(int trackId);
        Track GetTrackWithAllAttachmentsExceptPlaylistsAndTrackFile(int trackId);
        Track GetTrackWithAllAttachmentsExceptPlaylistsAndTrackStatisticsForPlay(int trackId);
        Track GetTrackWithAllAttachmentsExceptPlaylistsAndTrackFileAndTrackStatistics(int trackId);
        Track GetTrackWithAllAttachmentsExceptPlaylistsAndTrackStatistics(int trackId);
        void EditTrack(Track track ,HttpPostedFileBase uploadTrack);
        void DeleteTrack(int id);
        bool IsIdExists(int id);
        bool IsUniqueNewTitleArtistTrack(string artist, string title);
        bool IsUniqueTitleArtistTrack(int id, string artist, string title);
    }
}
