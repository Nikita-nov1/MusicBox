using MusicBox.Domain.DomainServices;
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


        public List<ArtistStatistics> GetArtistsStatistics()
        {
            return GetQueryableItems().Select(c => new ArtistStatistics
            {
                Artist = c,
                NumberOfAlbums = c.Albums.Count(),
                NumberOfTracks = c.Tracks.Count()

            }).ToList();
        }

        public Artist GetAtristWithTracksAndAlbumsWithAllAttachments(int id) // todo
        {
            var artist = Get(id);

            return GetQueryableItems()
            .Include(x => x.Tracks)
            .Include(x => x.Tracks.Select(y => y.Genre))
            .Include(x => x.Tracks.Select(y => y.Mood))
            .Include(x => x.Albums)
            .Include(x => x.Albums.Select(y => y.Tracks))
            .Include(x => x.Albums.Select(y => y.Artist))
            .FirstOrDefault(x=>x.Id == id);
       
        }

    }
}
