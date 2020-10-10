using AutoMapper;
using MusicBox.Areas.Admin.Models.Artists;
using MusicBox.Domain.Models.AdditionalModels;
using MusicBox.Domain.Models.Entities;
using MusicBox.ExtensionMethods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicBox.App_Start
{
    public static class AutoMapperConfig
    {
        //ContentType = artistVm?.Image.ContentType
        public static void Configure(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<CreateArtistsViewModel, Artist>()
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
                .AfterMap((artistVm, artist) => artist.ArtistImage = new ArtistImage
                {
                    // ContentType = (artistVm is null) ? null : artistVm.Image.ContentType  //todo   C
                });

            cfg.CreateMap<Artist, GetArtistsViewModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title));

            cfg.CreateMap<InfArtist, GetArtistsViewModel>()
                .ForSourceMember(dest => dest.Id, opt=>opt.DoNotValidate())
                .ForMember(dest => dest.NumberOfAlbums, opt => opt.MapFrom(src => src.NumberOfAlbums))
                .ForMember(dest => dest.NumberOfTracks, opt => opt.MapFrom(src => src.NumberOfTracks));



        }
    }
}