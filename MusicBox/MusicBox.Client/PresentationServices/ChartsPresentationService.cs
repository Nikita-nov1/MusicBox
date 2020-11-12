using System.Collections.Generic;
using AutoMapper;
using MusicBox.Domain.DomainServices.Interfaces;
using MusicBox.Domain.Models.Entities;
using MusicBox.Models.Track;
using MusicBox.PresentationServices.Interfaces;

namespace MusicBox.PresentationServices
{
    public class ChartsPresentationService : IChartsPresentationService
    {
        private readonly IChartsDomainService chartsDomainService;

        public ChartsPresentationService(IChartsDomainService chartsDomainService)
        {
            this.chartsDomainService = chartsDomainService;
        }

        public List<GetTracksForClientViewModel> GetTracksVmForCharts()
        {
            List<Track> tracks = chartsDomainService.GetTracksVmForCharts();
            return Mapper.Map<List<GetTracksForClientViewModel>>(tracks);
        }
    }
}