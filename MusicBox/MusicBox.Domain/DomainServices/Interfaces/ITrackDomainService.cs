using MusicBox.Domain.Models.Entities;
using System.Collections.Generic;
using System.Web;

namespace MusicBox.Domain.DomainServices.Interfaces
{
    public interface ITrackDomainService : IBaseDomainService  
    {
        void AddTrack(Track track, HttpPostedFileBase uploadTrack);
        List<Track> GetTracksWithAllAttachmentsExceptPlaylistsAndTrackFile();
        Track GetTrackWithAllAttachmentsExceptPlaylistsAndTrackFile(int trackId);
        Track GetTrackWithAllAttachmentsExceptPlaylistsAndTrackFileAndTrackStatistics(int trackId);
        Track GetTrackWithAllAttachmentsExceptPlaylistsAndTrackStatistics(int trackId);
        void EditTrack(Track track ,HttpPostedFileBase uploadTrack);
        void DeleteTrack(int id);
    }
}
