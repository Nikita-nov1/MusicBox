using MusicBox.Domain.Models.Entities;
using MusicBox.Domain.Repositories;
using MusicBox.Domain.UnitOfWork;

namespace MusicBox.Data.Repositories
{
    public class MoodRepository : BaseRepository<Mood>, IMoodRepository
    {
        public MoodRepository(IUnitOfWork unitOfWork)
          : base(unitOfWork)
        {
        }
    }
}
