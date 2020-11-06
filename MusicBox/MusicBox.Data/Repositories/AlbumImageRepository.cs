using System.Linq;
using MusicBox.Domain.Models.Entities;
using MusicBox.Domain.Repositories;
using MusicBox.Domain.UnitOfWork;

namespace MusicBox.Data.Repositories
{
    public class AlbumImageRepository : BaseRepository<AlbumImage>, IAlbumImageRepository
    {
        public AlbumImageRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public AlbumImage GetFirstOrDefault(int id)
        {
            return GetQueryableItems().Where(c => c.Id == id).FirstOrDefault();
        }
    }
}
