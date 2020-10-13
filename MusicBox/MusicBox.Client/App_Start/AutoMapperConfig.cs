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


            cfg.CreateMap<EditArtistsViewModel, Artist>()            //todo  можно ли сделать такие условия, чтобы мапились только те значения, которые отличаются от первоначальных?    
               .ForMember(dest => dest.Id, opt => opt.Ignore())
               .AfterMap((src, dest) => ChangeArtistImage(src.Image, dest));

            cfg.CreateMap<Artist, DeleteArtistsViewModel>();

            cfg.CreateMap<Artist, DetailsArtistsViewModel>();


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

    }
}