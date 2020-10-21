using MusicBox.Domain.Models.Entities;
using System.Collections.Generic;
using System.Web;

namespace MusicBox.Domain.DomainServices.Interfaces
{
    public interface ITrackDomainService : IBaseDomainService  
    {
        void AddTrack(Track track, HttpPostedFileBase uploadTrack);
        List<Track> GetTracksWithAllAttachmentsExceptPlaylistsAndTrackFile();
        Track GetTrackWithAllAttachmentsExceptPlaylistsAndTrackFileAndTrackStatistics(int Trackid);
        Track GetTrackWithAllAttachmentsExceptPlaylistsAndTrackStatistics(int Trackid);
        void EditTrack(Track track ,HttpPostedFileBase uploadTrack);
        void DeleteTrack(int id);
    }
}
