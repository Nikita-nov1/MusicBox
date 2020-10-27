using MusicBox.Domain.Models.AdditionalModels;
using MusicBox.Domain.Models.Entities;
using MusicBox.Domain.Repositories;
using MusicBox.Domain.UnitOfWork;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace MusicBox.Data.Repositories
{
    public class ArtistRepository : BaseRepository<Artist>, IArtistRepository
    {
        public ArtistRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public Artist GetArtistWithImage(int id)
        {
            var entityArtist = Get(id);
            Entry(entityArtist).Reference(c => c.ArtistImage).Load();
            return entityArtist;
        }

        public Artist GetFirstOrDefault(string artistTitle)
        {
            return GetQueryableItems().FirstOrDefault(c => c.Title == artistTitle);
        }

        public Artist GetArtistWhitTracks(int artistId) //todo replace GetArtistWhitTracks on GetArtistWithTracks
        {
            var entityArtist = Get(artistId);
            Entry(entityArtist).Collection(c => c.Tracks).Load();
            return entityArtist;
        }

        public Artist GetArtist(string artistTitle)
        {
            return GetQueryableItems().Single(c => c.Title.Equals(artistTitle));
        }

        public List<ArtistStatistics> GetArtistsStatistics()
        {
            return GetQueryableItems().Select(c => new ArtistStatistics
            {
                Artist = c,
                NumberOfAlbums = c.Albums.Count(),
                NumberOfTracks = c.Tracks.Count()
            }).ToList();
        }

        public Artist GetArtistWithTracksAndAlbumsWithAllAttachments(int id)
        {
            return GetQueryableItems()
            .Include(x => x.Tracks)
            .Include(x => x.Tracks.Select(y => y.Genre))
            .Include(x => x.Tracks.Select(y => y.Mood))
            .Include(x => x.Tracks.Select(y => y.TrackStatistics))
            .Include(x => x.Albums)
            .Include(x => x.Albums.Select(y => y.Tracks))
            .Include(x => x.Albums.Select(y => y.Tracks))
            .Include(x => x.Albums.Select(y => y.Artist))
            .Single(x => x.Id == id);
        }

        public bool IsUniqueNewTitle(string title)
        {
            return !GetQueryableItems().Any(x => x.Title.Equals(title));
        }

        public bool IsUniqueTitle(int id, string title)
        {
            var artist = Get(id);
            if (artist.Title.Equals(title))
            {
                return true;
            }

            else return !GetQueryableItems().Any(x => x.Title.Equals(title));
        }

        public List<Album> GetAlbumsForArtist(string artistTitle)
        {
            return GetQueryableItems().Include(x => x.Albums).Single(c => c.Title.Equals(artistTitle)).Albums;
        }

        public List<Album> GetAlbumsForArtist(int artistId)
        {
            var artist = Get(artistId);
            Entry(artist).Collection(c => c.Albums).Load();

            return artist.Albums;

        }

        public List<Track> GetTracksForArtist(int artistId)
        {
            return GetQueryableItems().Include(x => x.Tracks).Single(c => c.Id.Equals(artistId)).Tracks;
        }

        public bool IsExistsArtist(string artistTitle)
        {
            return GetQueryableItems().Any(x => x.Title.Equals(artistTitle));
        }

        public bool IsUniqueNewTitleArtistTrack(string artistTitle, string trackTitle)
        {
            if (IsExistsArtist(artistTitle).Equals(true))
            {
                var tracksForArtist = GetQueryableItems().Include(x => x.Tracks).Single(c => c.Title.Equals(artistTitle)).Tracks;
                return !tracksForArtist.Any(x => x.Title.Equals(trackTitle));
            }

            else return true;
        }
    }
}
