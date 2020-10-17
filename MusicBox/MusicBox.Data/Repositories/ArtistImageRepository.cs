using MusicBox.Domain.Models.Entities;
using MusicBox.Domain.Repositories;
using MusicBox.Domain.UnitOfWork;
using System.Linq;

namespace MusicBox.Data.Repositories
{
    public class ArtistImageRepository : BaseRepository<ArtistImage>, IArtistImageRepository
    {
        public ArtistImageRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }

        public ArtistImage GetFirstOrDefault(int id)
        {
            return GetQueryableItems().Where(c => c.Id == id).FirstOrDefault();
        }
    }
}
