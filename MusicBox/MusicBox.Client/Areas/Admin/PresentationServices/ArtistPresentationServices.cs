using System.Collections.Generic;
using AutoMapper;
using MusicBox.Areas.Admin.Models.Artists;
using MusicBox.Areas.Admin.PresentationServices.Interfaces;
using MusicBox.Domain.DomainServices.Interfaces;
using MusicBox.Domain.Models.AdditionalModels;
using MusicBox.Domain.Models.Entities;

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
            artist = Mapper.Map(artistVm, artist);

            if (artistVm.Image != null)
            {
                artist.ArtistImage.Image = ConvertToBytes(artistVm.Image);
            }

            artistDomainService.EditArtist();
        }

        public DetailsArtistsViewModel GetDetailsArtistsViewModel(int id)
        {
            var artist = artistDomainService.GetArtistWithTracksAndAlbumsWithAllAttachments(id);
            return Mapper.Map<DetailsArtistsViewModel>(artist);
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