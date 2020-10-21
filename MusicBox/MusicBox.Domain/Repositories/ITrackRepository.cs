using MusicBox.Domain.Models.Entities;
using System.Collections.Generic;

namespace MusicBox.Domain.Repositories
{
    public interface ITrackRepository : IBaseRepository<Track>
    {
        List<Track> GetTracksWithAllAttachmentsExceptPlaylistsAndTrackFile();
        Track GetTrackWithAllAttachmentsExceptPlaylistsAndTrackFileAndTrackStatistics(int trackId);
        Track GetTrackWithAllAttachmentsExceptPlaylistsAndTrackStatistics(int trackId);
    }
}
