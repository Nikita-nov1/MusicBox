﻿using System.Collections.Generic;
using System.Web;
using AutoMapper;
using MusicBox.Areas.Admin.Models.Albums;
using MusicBox.Areas.Admin.Models.Artists;
using MusicBox.Areas.Admin.Models.Tracks;
using MusicBox.Domain.Models.AdditionalModels;
using MusicBox.Domain.Models.Entities;
using MusicBox.Domain.Models.Entities.Identity;
using MusicBox.Models.Album;
using MusicBox.Models.Artist;
using MusicBox.Models.Track;
using MusicBox.Models.User;

namespace MusicBox.App_Start
{
    public static class AutoMapperConfig
    {
        public static void Configure(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<CreateArtistsViewModel, Artist>()
                .BeforeMap((src, dest) => dest.ArtistImage = new ArtistImage())
                .AfterMap((src, dest) => SetContentTypeForArtistImage(src.Image, dest));

            cfg.CreateMap<Artist, GetArtistsViewModel>();

            cfg.CreateMap<ArtistStatistics, GetArtistsViewModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(scr => scr.Artist.Id))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(scr => scr.Artist.Title));

            cfg.CreateMap<Artist, EditArtistsViewModel>()
                .ForMember(dest => dest.Image, opt => opt.Ignore());

            cfg.CreateMap<EditArtistsViewModel, Artist>()
               .ForMember(dest => dest.Id, opt => opt.Ignore())
               .AfterMap((src, dest) => ChangeArtistImage(src.Image, dest));

            cfg.CreateMap<Artist, DeleteArtistsViewModel>();

            cfg.CreateMap<Artist, DetailsArtistsViewModel>();

            cfg.CreateMap<CreateAlbumsViewModel, Album>()
                .BeforeMap((src, dest) => dest.AlbumImage = new AlbumImage())
                .ForMember(dest => dest.Artist, opt => opt.Ignore())
                .AfterMap((src, dest) => SetContentTypeForAlbumImage(src.Image, dest));

            cfg.CreateMap<Album, GetAlbumsViewModel>()
                .ForMember(dest => dest.ArtistName, opt => opt.MapFrom(scr => scr.Artist.Title))
                .ForMember(dest => dest.NumberOfTracks, opt => opt.MapFrom(scr => scr.Tracks.Count));

            cfg.CreateMap<Album, EditAlbumsViewModel>()
                .ForMember(dest => dest.Artist, opt => opt.MapFrom(scr => scr.Artist.Title))
                .ForMember(dest => dest.Image, opt => opt.Ignore());

            cfg.CreateMap<EditAlbumsViewModel, Album>()
               .ForMember(dest => dest.Id, opt => opt.Ignore())
               .ForMember(dest => dest.Artist, opt => opt.Ignore())
               .AfterMap((src, dest) => ChangeAlbumImage(src.Image, dest));

            cfg.CreateMap<Album, DeleteAlbumsViewModel>();

            cfg.CreateMap<Album, GetAlbumsForArtistVm>();

            cfg.CreateMap<Album, DetailsAlbumsViewModel>();

            cfg.CreateMap<CreateTracksViewModel, Track>()
                .BeforeMap((src, dest) =>
                {
                    dest.TrackFile = new TrackFile();
                    dest.TrackStatistics = new TrackStatistics();
                })
                .ForMember(dest => dest.Artist, opt => opt.Ignore());

            cfg.CreateMap<Track, GetTracksViewModel>()
                .ForMember(dest => dest.Mood, opt => opt.MapFrom(scr => scr.Mood.Title))
                .ForMember(dest => dest.Genre, opt => opt.MapFrom(scr => scr.Genre.Title))
                .ForMember(dest => dest.Album, opt => opt.MapFrom(scr => scr.Album.Title))
                .ForMember(dest => dest.Artist, opt => opt.MapFrom(scr => scr.Artist.Title))
                .ForMember(dest => dest.CountOfCalls, opt => opt.MapFrom(scr => scr.TrackStatistics.CountOfCalls));

            cfg.CreateMap<Track, EditTracksViewModel>()
                .ForMember(dest => dest.MoodId, opt => opt.MapFrom(scr => scr.Mood.Id))
                .ForMember(dest => dest.GenreId, opt => opt.MapFrom(scr => scr.Genre.Id))
                .ForMember(dest => dest.AlbumId, opt => opt.MapFrom(scr => scr.Album.Id))
                .ForMember(dest => dest.Artist, opt => opt.MapFrom(scr => scr.Artist.Title));

            cfg.CreateMap<EditTracksViewModel, Track>()
               .ForMember(dest => dest.Id, opt => opt.Ignore())
               .ForMember(dest => dest.Artist, opt => opt.Ignore());

            cfg.CreateMap<Track, DeleteTracksViewModel>()
                .ForMember(dest => dest.Mood, opt => opt.MapFrom(scr => scr.Mood.Title))
                .ForMember(dest => dest.Genre, opt => opt.MapFrom(scr => scr.Genre.Title))
                .ForMember(dest => dest.Album, opt => opt.MapFrom(scr => scr.Album.Title))
                .ForMember(dest => dest.Artist, opt => opt.MapFrom(scr => scr.Artist.Title));

            cfg.CreateMap<Track, DetailsTracksViewModel>()
                .ForMember(dest => dest.Mood, opt => opt.MapFrom(scr => scr.Mood.Title))
                .ForMember(dest => dest.Genre, opt => opt.MapFrom(scr => scr.Genre.Title))
                .ForMember(dest => dest.Album, opt => opt.MapFrom(scr => scr.Album.Title))
                .ForMember(dest => dest.Artist, opt => opt.MapFrom(scr => scr.Artist.Title))
                .ForMember(dest => dest.CountOfCalls, opt => opt.MapFrom(scr => scr.TrackStatistics.CountOfCalls));

            cfg.CreateMap<Album, GetAlbumsForClientViewModel>()
                .ForMember(dest => dest.ArtistName, opt => opt.MapFrom(scr => scr.Artist.Title));

            cfg.CreateMap<Track, GetTrackInformationViewModel>()
                .ForMember(dest => dest.TrackLocation, opt => opt.MapFrom(scr => scr.TrackFile.TrackLocation))
                .ForMember(dest => dest.ContentType, opt => opt.MapFrom(scr => scr.TrackFile.ContentType));

            cfg.CreateMap<Track, GetTracksForClientViewModel>()
                .ForMember(dest => dest.ArtistName, opt => opt.MapFrom(scr => scr.Artist.Title));

            cfg.CreateMap<Artist, GetArtistsForClientViewModel>();

            cfg.CreateMap<Album, GetAlbumsForClientViewModel>()
                .ForMember(dest => dest.ArtistName, opt => opt.MapFrom(scr => scr.Artist.Title));

            cfg.CreateMap<Track, GetTrackInformationViewModel>()
                .ForMember(dest => dest.TrackLocation, opt => opt.MapFrom(scr => scr.TrackFile.TrackLocation))
                .ForMember(dest => dest.ContentType, opt => opt.MapFrom(scr => scr.TrackFile.ContentType));

            cfg.CreateMap<Track, GetTracksForClientViewModel>()
                .ForMember(dest => dest.ArtistName, opt => opt.MapFrom(scr => scr.Artist.Title));

            cfg.CreateMap<Artist, GetArtistsForClientViewModel>();

            cfg.CreateMap<User, GetUserViewModel>();

            cfg.CreateMap<RegisterUserViewModel, User>()
                .BeforeMap((src, dest) => dest.UserImage = new UserImage())
                .BeforeMap((src, dest) => dest.Playlists = new List<Playlist>())
                .AfterMap((src, dest) => SetContentTypeForAlbumImage(src.Image, dest));

            cfg.CreateMap<User, EditUserViewModel>();
        }

        private static void ChangeArtistImage(HttpPostedFileBase image, Artist dest)
        {
            if (image != null)
            {
                dest.ArtistImage.ContentType = image.ContentType;
            }
        }

        private static void SetContentTypeForArtistImage(HttpPostedFileBase image, Artist artist)
        {
            if (image != null)
            {
                artist.ArtistImage.ContentType = image.ContentType;
            }
        }

        private static void SetContentTypeForAlbumImage(HttpPostedFileBase image, Album album)
        {
            if (image != null)
            {
                album.AlbumImage.ContentType = image.ContentType;
            }
        }

        private static void SetContentTypeForAlbumImage(HttpPostedFileBase image, User user)
        {
            if (image != null)
            {
                user.UserImage.ContentType = image.ContentType;
            }
        }

        private static void ChangeAlbumImage(HttpPostedFileBase image, Album dest)
        {
            if (image != null)
            {
                dest.AlbumImage.ContentType = image.ContentType;
            }
        }
    }
}