using AutoMapper;
using MusicBox.Domain.DomainServices.Interfaces;
using MusicBox.Domain.Models.Entities;
using MusicBox.Models.Album;
using MusicBox.PresentationServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicBox.PresentationServices
{
    public class AlbumPresentationServices : IAlbumPresentationServices
    {
        private readonly IAlbumDomainService albumDomainService;
        private readonly IAlbumImageDomainService albumImageDomainService;

        public AlbumPresentationServices(IAlbumDomainService albumDomainService, IAlbumImageDomainService albumImageDomainService)
        {
            this.albumDomainService = albumDomainService;
            this.albumImageDomainService = albumImageDomainService;
        }
        public List<GetAlbumsForClientViewModel> GetAlbums()
        {
           List<Album> albums =  albumDomainService.GetAlbumsWithArtist();
           return Mapper.Map<List<GetAlbumsForClientViewModel>>(albums);
        }

        public AlbumImage GetImage(int albumId)
        {
            AlbumImage albumImage = albumImageDomainService.GetAlbumImage(albumId);
            if (albumImage == null)
            {
                return new AlbumImage();
            }
            return albumImage;
        }


    }
}