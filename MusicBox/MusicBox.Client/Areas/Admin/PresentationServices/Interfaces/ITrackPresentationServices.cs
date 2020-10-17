using MusicBox.Areas.Admin.Models.Tracks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicBox.Areas.Admin.PresentationServices.Interfaces
{
    public interface ITrackPresentationServices : IBaseAdminPresentationService
    {
        CreateTracksViewModel GetCreateTrackVm();
        List<GetTracksViewModel> GetTracks();

        void AddTrack(CreateTracksViewModel tracksVm);
    }
}
