using MusicBox.Domain.Models.Entities;
using MusicBox.Domain.Repositories;
using MusicBox.Domain.UnitOfWork;

namespace MusicBox.Data.Repositories
{
    public class TrackStatisticsRepository : BaseRepository<TrackStatistics>, ITrackStatisticsRepository
    {
        public TrackStatisticsRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }
    }
}
