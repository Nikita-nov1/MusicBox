using MusicBox.Models.Track;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicBox.PresentationServices.Interfaces
{
    public interface ITrackPresentationService : IBasePresentationService
    {
        List<GetTracksForClientViewModel> GetTracksVmForAlbum(int albumId); 
        GetTrackInformationViewModel GetTrackInformationForPlay(int trackId);
        List<GetTracksForClientViewModel> GetTracksVmForArtist(int artistId);
    }
}
