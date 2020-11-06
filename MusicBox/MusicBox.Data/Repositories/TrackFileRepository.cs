using MusicBox.Domain.Models.Entities;
using MusicBox.Domain.Repositories;
using MusicBox.Domain.UnitOfWork;

namespace MusicBox.Data.Repositories
{
    public class TrackFileRepository : BaseRepository<TrackFile>, ITrackFileRepository
    {
        public TrackFileRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }
    }
}
