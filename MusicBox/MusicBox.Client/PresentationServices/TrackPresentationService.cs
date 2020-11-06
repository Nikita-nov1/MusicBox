using System.Collections.Generic;
using AutoMapper;
using MusicBox.Domain.DomainServices.Interfaces;
using MusicBox.Domain.Models.Entities;
using MusicBox.Models.Track;
using MusicBox.PresentationServices.Interfaces;

namespace MusicBox.PresentationServices
{
    public class TrackPresentationService : ITrackPresentationService
    {
        private readonly ITrackDomainService trackDomainService;

        public TrackPresentationService(ITrackDomainService trackDomainService)
        {
            this.trackDomainService = trackDomainService;
        }

        public List<GetTracksForClientViewModel> GetTracksVmForAlbum(int albumId)
        {
            var tracks = trackDomainService.GetAllTracksForAlbumWhitArtist(albumId);
            return Mapper.Map<List<GetTracksForClientViewModel>>(tracks);
        }

        public List<GetTracksForClientViewModel> GetTracksVmForArtist(int artistId)
        {
            var tracks = trackDomainService.GetAllTracksForArtistWhitArtist(artistId);
            return Mapper.Map<List<GetTracksForClientViewModel>>(tracks);
        }

        public GetTrackInformationViewModel GetTrackInformationForPlay(int trackId)
        {
            Track track = trackDomainService.GetTrackWithAllAttachmentsExceptPlaylistsAndTrackStatisticsForPlay(trackId);
            return Mapper.Map<GetTrackInformationViewModel>(track);
        }
    }
}