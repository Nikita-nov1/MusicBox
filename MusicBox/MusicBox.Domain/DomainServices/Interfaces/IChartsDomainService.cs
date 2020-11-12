using System.Collections.Generic;
using MusicBox.Domain.Models.Entities;

namespace MusicBox.Domain.DomainServices.Interfaces
{
    public interface IChartsDomainService : IBaseDomainService
    {
        List<Track> GetTracksVmForCharts();
    }
}
