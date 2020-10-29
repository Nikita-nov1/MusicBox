using MusicBox.Models.Track;
using System.Collections.Generic;

namespace MusicBox.PresentationServices.Interfaces
{
    public interface ITrackPresentationService : IBasePresentationService
    {
        List<GetTracksForClientViewModel> GetTracksVmForAlbum(int albumId);
        GetTrackInformationViewModel GetTrackInformationForPlay(int trackId);
        List<GetTracksForClientViewModel> GetTracksVmForArtist(int artistId);
    }
}
