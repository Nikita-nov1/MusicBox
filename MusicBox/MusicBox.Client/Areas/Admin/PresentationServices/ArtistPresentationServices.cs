﻿using AutoMapper;
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
            Artist artist = Mapper.Map<Artist>(artistVm);
            artist.ArtistImage.Image = ConvertToBytes(artistVm.Image);                                   

            artistDomainService.AddArtist(artist);
        }

        public EditArtistsViewModel GetEditArtistVm(int id)
        {
            Artist artist = artistDomainService.GetArtist(id);
            return Mapper.Map<EditArtistsViewModel>(artist);

        }

        public void EditArtist(EditArtistsViewModel artistVm)
        {
            Artist artist = artistDomainService.GetArtistWithImage(artistVm.Id);
            artist = Mapper.Map<EditArtistsViewModel, Artist>(artistVm, artist);

            if (artistVm.Image != null)
            {
                artist.ArtistImage.Image = ConvertToBytes(artistVm.Image);
            }

            artistDomainService.EditArtist();

        }

        public DetailsArtistsViewModel GetDetailsArtistsViewModel(int id)
        {
            var artist = artistDomainService.GetAtristWithTracksAndAlbumsWithAllAttachments(id);
            var result = Mapper.Map<DetailsArtistsViewModel>(artist);
            return result;
        }

        public DeleteArtistsViewModel GetDeleteArtistVm(int id)
        {
            Artist artist = artistDomainService.GetArtist(id);
            return Mapper.Map<DeleteArtistsViewModel>(artist);

        }

        public void DeleteArtist(int id)
        {
            artistDomainService.DeleteArtist(id);
        }

        public ArtistImage GetImage(int artitId)
        {
            ArtistImage artistImage = artistImageDomainService.GetArtistImage(artitId);
            if (artistImage == null)
            {
                return new ArtistImage();
            }
            return artistImage;
        }

        public List<GetArtistsViewModel> GetArtists()
        {
            List<ArtistStatistics> artistsStatistics = artistDomainService.GetArtistsStatistics();

            return Mapper.Map<List<GetArtistsViewModel>>(artistsStatistics);      

        }

     
    }
}