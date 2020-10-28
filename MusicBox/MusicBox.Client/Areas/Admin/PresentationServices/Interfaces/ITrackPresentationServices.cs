using MusicBox.Areas.Admin.Models.Tracks;
using System.Collections.Generic;

namespace MusicBox.Areas.Admin.PresentationServices.Interfaces
{
    public interface ITrackPresentationServices : IBaseAdminPresentationService
    {
        CreateTracksViewModel GetCreateTrackVm();
        CreateTracksViewModel GetCreateTrackVm(CreateTracksViewModel tracksVm);
        List<GetTracksViewModel> GetTracks();
        void AddTrack(CreateTracksViewModel tracksVm);
        EditTracksViewModel GetEditTrackVm(int id);
        EditTracksViewModel GetEditTrackVm(EditTracksViewModel trackVm);
        void EditTrack(EditTracksViewModel trackVm);
        DeleteTracksViewModel GetDeleteTrackVm(int id);
        void DeleteTrack(int id);
        DetailsTracksViewModel GetDetailsTrackVm(int id);
    }
}
