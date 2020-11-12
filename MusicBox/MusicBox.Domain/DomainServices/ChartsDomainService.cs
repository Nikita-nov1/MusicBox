using System.Collections.Generic;
using MusicBox.Domain.DomainServices.Interfaces;
using MusicBox.Domain.Models.Entities;
using MusicBox.Domain.UnitOfWork;

namespace MusicBox.Domain.DomainServices
{
    public class ChartsDomainService : IChartsDomainService
    {
        private readonly ITrackDomainService trackDomainService;
        private readonly IUnitOfWork unitOfWork;

        public ChartsDomainService(IUnitOfWork unitOfWork, ITrackDomainService trackDomainService)
        {
            this.trackDomainService = trackDomainService;
            this.unitOfWork = unitOfWork;
        }

        public List<Track> GetTracksVmForCharts()
        {
           return trackDomainService.GetTracksVmForCharts();
        }
    }
}
