using System.Collections.Generic;
using MusicBox.Models.Track;

namespace MusicBox.PresentationServices.Interfaces
{
    public interface IChartsPresentationService : IBasePresentationService
    {
        List<GetTracksForClientViewModel> GetTracksVmForCharts();
    }
}
