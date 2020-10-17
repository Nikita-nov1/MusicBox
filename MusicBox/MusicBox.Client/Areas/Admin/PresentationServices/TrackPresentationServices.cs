using AutoMapper;
using MusicBox.Areas.Admin.Models.Tracks;
using MusicBox.Areas.Admin.PresentationServices.Interfaces;
using MusicBox.Domain.DomainServices.Interfaces;
using MusicBox.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
            ITrackStatisticsDomainService trackStatisticsDomainService,IAlbumDomainService albumDomainService,
            IGenreDomainService genreDomainService, IMoodDomainService moodDomainService,IArtistDomainService artistDomainService )
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
                SelectListAlbums = GetAlbumsSelectList(),
                SelectListGenres = GetGenresSelectList(),
                SelectListMoods = GetMoodsSelectList()
            };
        }

        public List<GetTracksViewModel> GetTracks()
        {
            throw new Exception();
        }

        public void AddTrack(CreateTracksViewModel tracksVm)
        {
            Track track = Mapper.Map<Track>(tracksVm);
            track.Artist = artistDomainService.GetArtistOrCreateNewIfHeNotExist(tracksVm.Artist);   // сделать потом проверку в валидаторе - сущетвует ли такой Артист?
            track.Genre = genreDomainService.GetGenre(tracksVm.GenreId);
            track.Mood = moodDomainService.GetMood(tracksVm.MoodId);
            track.Album = albumDomainService.GetAlbum(tracksVm.AlbumId);
            

            trackDomainService.AddTrack(track, tracksVm.UploadTrack);
 
        }

        private SelectList GetAlbumsSelectList()
        {
            return new SelectList(albumDomainService.GetAlbums(), nameof(Album.Id), nameof(Album.Title));

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