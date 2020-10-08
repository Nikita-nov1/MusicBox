using MusicBox.Domain.Models.Entities;
using MusicBox.Domain.Repositories;
using MusicBox.Domain.UnitOfWork;

namespace MusicBox.Data.Repositories
{
    public class AlbumRepository : BaseRepository<Album>, IAlbumRepository
    {
        public AlbumRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
         
        }
    }
}

