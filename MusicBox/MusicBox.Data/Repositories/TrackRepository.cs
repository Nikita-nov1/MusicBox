using MusicBox.Domain.Models.Entities;
using MusicBox.Domain.Repositories;
using MusicBox.Domain.UnitOfWork;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace MusicBox.Data.Repositories
{
    public class TrackRepository : BaseRepository<Track>, ITrackRepository
    {
        public TrackRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
           
        }

        public List<Track> GetTracksWithAllAttachmentsExceptPlaylistsAndTrackFile()
        {
            return GetQueryableItems()
                .Include(c => c.Album)
                .Include(c => c.Artist)
                .Include(c => c.Mood)
                .Include(c => c.Genre)
                .Include(c => c.TrackStatistics)
                .ToList();

        }
    }
}
