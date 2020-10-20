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

        public bool IsUniqueNewTitle(string title)
        {
            return !GetQueryableItems().Any(x => x.Title.Equals(title));
        }

        public bool IsUniqueTitle(int id, string title)
        {
            var album = Get(id);
            if (album.Title.Equals(title))
            {
                return true;
            }

            else return !GetQueryableItems().Any(x => x.Title.Equals(title));
        }
    }
}
