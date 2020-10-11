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
                    // ContentType = (artistVm is null) ? null : artistVm.Image.ContentType  //todoM   разобраться, как тут мапить Image.ContentType с условием, если artistVm.Image != null
                });

            cfg.CreateMap<Artist, GetArtistsViewModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title));

            cfg.CreateMap<InfArtist, GetArtistsViewModel>()
                .ForSourceMember(dest => dest.Id, opt=>opt.DoNotValidate())
                .ForMember(dest => dest.NumberOfAlbums, opt => opt.MapFrom(src => src.NumberOfAlbums))
                .ForMember(dest => dest.NumberOfTracks, opt => opt.MapFrom(src => src.NumberOfTracks));


            cfg.CreateMap<Artist, EditArtistsViewModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
                .ForMember(dest => dest.Image, opt => opt.Ignore());

            cfg.CreateMap<EditArtistsViewModel, Artist>()               //todo  можно ли сделать такие условия, чтобы мапились только те значения, которые отличаются от первоначальных?
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
                .ForMember(dest => dest.ArtistImage, opt => opt.Ignore());   //todoM  как сделать условие,чтобы смапить картинку, если она не null - поменять, если null, то не изменять её - не для этого случая


        }

        //.ForMember(b => b.GuestPhone, options => options.MapFrom(source => GetGuestAllPhoneNumbers(source.Guest)))
    }
}