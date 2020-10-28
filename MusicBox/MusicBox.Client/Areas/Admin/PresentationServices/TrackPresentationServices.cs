using AutoMapper;
using MusicBox.Areas.Admin.Models.Tracks;
using MusicBox.Areas.Admin.PresentationServices.Interfaces;
using MusicBox.Domain.DomainServices.Interfaces;
using MusicBox.Domain.Models.Entities;
using System.Collections.Generic;
using System.Web.Mvc;

namespace MusicBox.Areas.Admin.PresentationServices
{
    public class TrackPresentationServices : BaseAdminPresentationService, ITrackPresentationServices
    {
        private readonly ITrackDomainService trackDomainService;
        private readonly ITrackFileDomainService trackFileDomainService;
        private readonly ITrackStatisticsDomainService trackStatisticsDomainService;
        private readonly IAlbumDomainService albumDomainService;
        private readonly IGenreDomainService genreDomainService;
        private readonly IMoodDomainService moodDomainService;
        private readonly IArtistDomainService artistDomainService;


        public TrackPresentationServices(ITrackDomainService trackDomainService, ITrackFileDomainService trackFileDomainService,
            ITrackStatisticsDomainService trackStatisticsDomainService, IAlbumDomainService albumDomainService,
            IGenreDomainService genreDomainService, IMoodDomainService moodDomainService, IArtistDomainService artistDomainService)
        {
            this.trackDomainService = trackDomainService;
            this.trackFileDomainService = trackFileDomainService;
            this.trackStatisticsDomainService = trackStatisticsDomainService;
            this.albumDomainService = albumDomainService;
            this.genreDomainService = genreDomainService;
            this.moodDomainService = moodDomainService;
            this.artistDomainService = artistDomainService;

        }

        public CreateTracksViewModel GetCreateTrackVm()
        {
            return new CreateTracksViewModel
            {
                SelectListAlbums = GetEmptyAlbumsSelectList(),
                SelectListGenres = GetGenresSelectList(),
                SelectListMoods = GetMoodsSelectList()
            };
        }

        public CreateTracksViewModel GetCreateTrackVm(CreateTracksViewModel tracksVm)
        {
            tracksVm.SelectListAlbums = GetAlbumsSelectList(artistDomainService.GetArtist(tracksVm.Artist).Id);
            tracksVm.SelectListGenres = GetGenresSelectList();
            tracksVm.SelectListMoods = GetMoodsSelectList();
            return tracksVm;

        }

        public EditTracksViewModel GetEditTrackVm(int id)
        {
            Track track = trackDomainService.GetTrackWithAllAttachmentsExceptPlaylistsAndTrackFileAndTrackStatistics(id);
            EditTracksViewModel trackVm = Mapper.Map<EditTracksViewModel>(track);
            trackVm.SelectListGenres = GetGenresSelectList();
            trackVm.SelectListMoods = GetMoodsSelectList();
            trackVm.SelectListAlbums = GetAlbumsSelectList(track.Artist.Id);

            return trackVm;

        }

        public EditTracksViewModel GetEditTrackVm(EditTracksViewModel trackVm)
        {
            trackVm.SelectListGenres = GetGenresSelectList();
            trackVm.SelectListMoods = GetMoodsSelectList();
            trackVm.SelectListAlbums = GetAlbumsSelectList(artistDomainService.GetArtist(trackVm.Artist).Id);

            return trackVm;

        }


        public DeleteTracksViewModel GetDeleteTrackVm(int id)
        {
            Track track = trackDomainService.GetTrackWithAllAttachmentsExceptPlaylistsAndTrackFileAndTrackStatistics(id);
            return Mapper.Map<DeleteTracksViewModel>(track);
            
        }

        public DetailsTracksViewModel GetDetailsTrackVm(int id)
        {
            Track track = trackDomainService.GetTrackWithAllAttachmentsExceptPlaylistsAndTrackFile(id);
            return Mapper.Map<DetailsTracksViewModel>(track);
        }

        public List<GetTracksViewModel> GetTracks()
        {
            List<Track> tracks = trackDomainService.GetTracksWithAllAttachmentsExceptPlaylistsAndTrackFile();
            return Mapper.Map<List<GetTracksViewModel>>(tracks);

        }

        public void AddTrack(CreateTracksViewModel trackVm)
        {
            Track track = Mapper.Map<Track>(trackVm);
            track.Artist = artistDomainService.GetArtist(trackVm.Artist);
            track.Genre = genreDomainService.GetGenre(trackVm.GenreId);
            track.Mood = moodDomainService.GetMood(trackVm.MoodId);
            track.Album = albumDomainService.GetAlbum(trackVm.AlbumId);


            trackDomainService.AddTrack(track, trackVm.UploadTrack);

        }

        public void EditTrack(EditTracksViewModel trackVm)
        {
            Track track = trackDomainService.GetTrackWithAllAttachmentsExceptPlaylistsAndTrackStatistics(trackVm.Id);
            track = Mapper.Map<EditTracksViewModel, Track>(trackVm, track);
            track.Artist = artistDomainService.GetArtist(trackVm.Artist);
            track.Genre = genreDomainService.GetGenre(trackVm.GenreId);
            track.Mood = moodDomainService.GetMood(trackVm.MoodId);
            track.Album = albumDomainService.GetAlbum(trackVm.AlbumId);

            trackDomainService.EditTrack(track, trackVm.UploadTrack);

        }

        public void DeleteTrack(int id)
        {
            trackDomainService.DeleteTrack(id);
        }

        private SelectList GetAlbumsSelectList(int artistId)
        {
            return new SelectList(albumDomainService.GetAlbumsForArtist(artistId), nameof(Album.Id), nameof(Album.Title));

        }

        private SelectList GetEmptyAlbumsSelectList()
        {
            return new SelectList(new List<Album>(), nameof(Album.Id), nameof(Album.Title));

        }
        private SelectList GetGenresSelectList()
        {
            return new SelectList(genreDomainService.GetGenres(), nameof(Genre.Id), nameof(Genre.Title));

        }

        private SelectList GetMoodsSelectList()
        {
            return new SelectList(moodDomainService.GetMoods(), nameof(Mood.Id), nameof(Mood.Title));

        }
    }
}