using AutoMapper;
using MusicBox.Areas.Admin.Models.Artists;
using MusicBox.Domain.Models.Entities;
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
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
                .AfterMap((artistVm, artist) => artist.ArtistImage = new ArtistImage
                {
                    ContentType = artistVm.Image.ContentType
                });
                
        }
    }
}