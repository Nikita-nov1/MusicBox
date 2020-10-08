using AutoMapper;
using MusicBox.Areas.Admin.Models.Artists;
using MusicBox.Areas.Admin.PresentationServices.Interfaces;
using MusicBox.Domain.DomainServices.Interfaces;
using MusicBox.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace MusicBox.Areas.Admin.PresentationServices
{
    public class ArtistPresentationServices : BaseAdminPresentationService, IArtistPresentationServices
    {
        private readonly IArtistDomainService artistDomainService;
        public ArtistPresentationServices(IArtistDomainService artistDomainService)
        {
            this.artistDomainService = artistDomainService;
        }

        
        public void AddArtist(CreateArtistsViewModel artistVm)
        {
            //public static byte[] ImageToByte(HttpPostedFileBase imageFile)
            //{
            //    if (imageFile == null) { return null; }
            //    return (imageFile.ContentType == "image/jpeg" || imageFile.ContentType == "image/gif" || imageFile.ContentType == "image/png") ? FileToByte(imageFile) : null;  //todo проверить в валидации на тип
            //}

            if (artistVm.Image == null || artistVm.Image.ContentLength ==0 )  // перенести на уровень DS
            {
                // в Image предаю дефолтную картинку
            }

            Artist artist = Mapper.Map<Artist>(artistVm);
            artist.ArtistImage.Image = ConvertToBytes(artistVm.Image);

            artistDomainService.AddArtist(artist);
        }

       
    }
}