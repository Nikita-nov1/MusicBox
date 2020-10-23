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

        public Track GetTrackWithAllAttachmentsExceptPlaylistsAndTrackFileAndTrackStatistics(int trackId)
        {
            var entityTrack = Get(trackId);
            Entry(entityTrack).Reference(c => c.Album).Load();
            Entry(entityTrack).Reference(c => c.Artist).Load();
            Entry(entityTrack).Reference(c => c.Mood).Load();
            Entry(entityTrack).Reference(c => c.Genre).Load();

            return entityTrack;

        }

        public Track GetTrackWithAllAttachmentsExceptPlaylistsAndTrackStatistics(int trackId)
        {
            var entityTrack = Get(trackId);
            Entry(entityTrack).Reference(c => c.Album).Load();
            Entry(entityTrack).Reference(c => c.Artist).Load();
            Entry(entityTrack).Reference(c => c.Mood).Load();
            Entry(entityTrack).Reference(c => c.Genre).Load();
            Entry(entityTrack).Reference(c => c.TrackFile).Load();

            return entityTrack;

        }

        public Track GetTrackWithAllAttachmentsExceptPlaylistsAndTrackFile(int trackId)
        {
            var entityTrack = Get(trackId);
            Entry(entityTrack).Reference(c => c.Album).Load();
            Entry(entityTrack).Reference(c => c.Artist).Load();
            Entry(entityTrack).Reference(c => c.Mood).Load();
            Entry(entityTrack).Reference(c => c.Genre).Load();
            Entry(entityTrack).Reference(c => c.TrackStatistics).Load();

            return entityTrack;

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

        public bool IsIdExists(int id)
        {
            return GetQueryableItems().Any(x => x.Id.Equals(id));
        }
    }
}
