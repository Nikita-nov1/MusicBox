using MusicBox.Domain.Models.Entities;
using MusicBox.Domain.Repositories;
using MusicBox.Domain.UnitOfWork;
using System.Linq;

namespace MusicBox.Data.Repositories
{
    public class MoodRepository : BaseRepository<Mood>, IMoodRepository
    {
        public MoodRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }

        public bool IsExistsMood(int id)
        {
            return GetQueryableItems().Any(x => x.Id.Equals(id));
        }
    }
}
