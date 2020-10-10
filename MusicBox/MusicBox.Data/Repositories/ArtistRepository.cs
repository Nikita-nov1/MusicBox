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

        
        public List<InfArtist> GetInfArtists()
        {
            return GetQueryableItems().Select(c => new InfArtist
            {
                Id = c.Id,
                NumberOfAlbums = c.Albums.Count,
                NumberOfTracks = c.Tracks.Count

            }).ToList();
        }


    }
}
