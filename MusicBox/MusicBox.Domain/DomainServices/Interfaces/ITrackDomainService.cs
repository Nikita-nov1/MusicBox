using MusicBox.Domain.Models.Entities;
using System.Collections.Generic;
using System.Web;

namespace MusicBox.Domain.DomainServices.Interfaces
{
    public interface ITrackDomainService : IBaseDomainService  
    {
        void AddTrack(Track track, HttpPostedFileBase uploadTrack);
        List<Track> GetTracksWithAllAttachmentsExceptPlaylistsAndTrackFile();
    }
}
