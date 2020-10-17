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

        public Album GetAlbumWhitArtist(int id)
        {
            var entityAlbum = Get(id);
            Entry(entityAlbum).Reference(c => c.Artist).Load();

            return entityAlbum;

        }

    }
}

