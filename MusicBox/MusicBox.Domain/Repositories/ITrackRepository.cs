using MusicBox.Domain.Models.Entities;
using System.Collections.Generic;

namespace MusicBox.Domain.Repositories
{
    public interface ITrackRepository : IBaseRepository<Track>
    {
        List<Track> GetTracksWithAllAttachmentsExceptPlaylistsAndTrackFile();
        Track GetTrackWithAllAttachmentsExceptPlaylistsAndTrackFile(int trackId);
        Track GetTrackWithAllAttachmentsExceptPlaylistsAndTrackFileAndTrackStatistics(int trackId);
        Track GetTrackWithAllAttachmentsExceptPlaylistsAndTrackStatistics(int trackId);
        bool IsIdExists(int id);
        bool IsUniqueNewTitleArtistTrack(string artistTitle, string trackTitle);
        bool IsUniqueTitleArtistTrack(int trackId, string artistTitle, string trackTitle);
    }
}
