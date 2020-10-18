using MusicBox.Domain.Models.Entities;
using MusicBox.Domain.Repositories;
using MusicBox.Domain.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
