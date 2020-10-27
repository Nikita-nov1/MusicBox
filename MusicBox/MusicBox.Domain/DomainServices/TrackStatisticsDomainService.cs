using MusicBox.Domain.DomainServices.Interfaces;
using MusicBox.Domain.Models.Entities;
using MusicBox.Domain.Repositories;
using MusicBox.Domain.UnitOfWork;

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

        public void IncrementCountOfCalls(int trackId)
        {
            TrackStatistics trackStatistics = trackStatisticsRepository.Get(trackId);
            ++trackStatistics.CountOfCalls;
            unitOfWork.SaveChanges();

        }
    }
}
