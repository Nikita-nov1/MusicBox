using MusicBox.Domain.Models.Entities;
using MusicBox.Domain.Repositories;
using MusicBox.Domain.UnitOfWork;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace MusicBox.Data.Repositories
{
    public class AlbumRepository : BaseRepository<Album>, IAlbumRepository
    {
        public AlbumRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public List<Album> GetAllWithArtistAndTracks()
        {
            return GetQueryableItems()
                .Include(c => c.Artist)
                .Include(c => c.Tracks)
                .ToList();
        }

        public List<Album> GetAlbumsWithArtist()
        {
            return GetQueryableItems()
                .Include(c => c.Artist)
                .ToList();
        }

        public List<Track> GetAllTracksForAlbumWhitArtist(int albumId)
        {
            return GetQueryableItems()
                .Include(x => x.Artist)
                .Include(q => q.Tracks)
                .Single(q => q.Id.Equals(albumId)).Tracks;


        }

        public Album GetAlbumWithImageAndArtist(int id)
        {
            var entityAlbum = Get(id);
            Entry(entityAlbum).Reference(c => c.AlbumImage).Load();
            Entry(entityAlbum).Reference(c => c.Artist).Load();
            return entityAlbum;
        }

        public Album GetAlbumWhitTracks(int id)
        {
            var entityAlbum = Get(id);
            Entry(entityAlbum).Collection(c => c.Tracks).Load();
            return entityAlbum;
        }

        public Album GetAlbumWhitArtist(int id)
        {
            var entityAlbum = Get(id);
            Entry(entityAlbum).Reference(c => c.Artist).Load();
            return entityAlbum;
        }

        public Album GetAlbumAndHisTracksWithAllAttachments(int id)
        {
            return GetQueryableItems()
            .Include(x => x.Artist)
            .Include(x => x.Tracks)
            .Include(x => x.Tracks.Select(y => y.Genre))
            .Include(x => x.Tracks.Select(y => y.Mood))
            .Include(x => x.Tracks.Select(y => y.TrackStatistics))
            .Single(x => x.Id == id);

        }

        public bool IsIdExists(int id)
        {
            return GetQueryableItems().Any(x => x.Id.Equals(id));
        }

        public bool IsUniqueTitleArtistAlbum(int albumId, string artistTitle, string albumTitle)
        {
            return !GetQueryableItems().Any(x => x.Title.Equals(albumTitle) && x.Artist.Title.Equals(artistTitle) && !x.Id.Equals(albumId));
        }

        public bool IsUniqueNewTitleArtistAlbum(string artistTitle, string albumTitle)
        {
            return !GetQueryableItems().Any(x => x.Title.Equals(albumTitle) && x.Artist.Title.Equals(artistTitle));
        }
    }
}
