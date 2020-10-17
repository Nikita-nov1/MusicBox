using MusicBox.Domain.DomainServices.Interfaces;
using MusicBox.Domain.Repositories;
using MusicBox.Domain.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicBox.Domain.DomainServices
{
    public class TrackStatisticsDomainService : ITrackStatisticsDomainService
    {
        private readonly ITrackStatisticsRepository trackStatisticsRepository;
        private readonly IUnitOfWork unitOfWork;

        public TrackStatisticsDomainService(ITrackStatisticsRepository trackStatisticsRepository, IUnitOfWork unitOfWork)
        {
            this.trackStatisticsRepository = trackStatisticsRepository;
            this.unitOfWork = unitOfWork;
        }
    }
}
