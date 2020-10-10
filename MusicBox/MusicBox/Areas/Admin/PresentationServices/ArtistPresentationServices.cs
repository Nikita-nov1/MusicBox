using AutoMapper;
using MusicBox.Areas.Admin.Models.Artists;
using MusicBox.Areas.Admin.PresentationServices.Interfaces;
using MusicBox.Domain.DomainServices.Interfaces;
using MusicBox.Domain.Models.AdditionalModels;
using MusicBox.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.Hosting;

namespace MusicBox.Areas.Admin.PresentationServices
{
    public class ArtistPresentationServices : BaseAdminPresentationService, IArtistPresentationServices
    {
        private readonly IArtistDomainService artistDomainService;
        private readonly IArtistImageDomainService artistImageDomainService;
        public ArtistPresentationServices(IArtistDomainService artistDomainService, IArtistImageDomainService artistImageDomainService)
        {
            this.artistDomainService = artistDomainService;
            this.artistImageDomainService = artistImageDomainService;
        }


        public void AddArtist(CreateArtistsViewModel artistVm)
        {
            //public static byte[] ImageToByte(HttpPostedFileBase imageFile)
            //{
            //    if (imageFile == null) { return null; }
            //    return (imageFile.ContentType == "image/jpeg" || imageFile.ContentType == "image/gif" || imageFile.ContentType == "image/png") ? FileToByte(imageFile) : null;  //todo проверить в валидации на тип
            //}

            if (artistVm.Image == null && artistVm.Image.ContentLength == 0)  // перенести на уровень DS
            {
                // в Image предаю дефолтную картинку
            }
            //  Save(artistVm.Image);
            Artist artist = Mapper.Map<Artist>(artistVm);
            artist.ArtistImage.Image = ConvertToBytes(artistVm.Image);


            artistDomainService.AddArtist(artist);
        }

        public ArtistImage GetImage(int artitId)
        {
            return artistImageDomainService.GetArtistImage(artitId);
        }

        public List<GetArtistsViewModel> GetArtists()
        {
            List<GetArtistsViewModel> artistsViewModels = new List<GetArtistsViewModel>();
            List<Artist> artists = artistDomainService.GetAtrists();
            List<InfArtist> infArtists = artistDomainService.GetInfArtist();


            artistsViewModels = Mapper.Map<List<GetArtistsViewModel>>(artists);
            //artistsViewModels = Mapper.Map<List<InfArtist>, List<GetArtistsViewModel>>(infArtists, artistsViewModels); // todo спросить, как обновлять модель, не изменяя не существующие значения

            int index = 0;
            foreach (var artistVm in artistsViewModels)
            {
                artistVm.NumberOfTracks = infArtists[index].NumberOfTracks;
                artistVm.NumberOfAlbums = infArtists[index++].NumberOfAlbums;

            }

            return artistsViewModels;
        }

        //private void Save(HttpPostedFileBase image)
        //{
        //    var contentType = Path.GetExtension(image.FileName);
        //    var directoryToSave = HostingEnvironment.MapPath("~/UploadedFiles");

        //    var pathToSave = Path.Combine(directoryToSave, Guid.NewGuid().ToString() + contentType);

        //    image.SaveAs(pathToSave);

        //}
    }
}