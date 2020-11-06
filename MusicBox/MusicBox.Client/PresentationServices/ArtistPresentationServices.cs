using System.Collections.Generic;
using AutoMapper;
using MusicBox.Domain.DomainServices.Interfaces;
using MusicBox.Domain.Models.Entities;
using MusicBox.Models.Artist;
using MusicBox.PresentationServices.Interfaces;

namespace MusicBox.PresentationServices
{
    public class ArtistPresentationServices : IArtistPresentationServices
    {
        private readonly IArtistDomainService artistDomainService;
        private readonly IArtistImageDomainService artistImageDomainService;

        public ArtistPresentationServices(IArtistDomainService artistDomainService, IArtistImageDomainService artistImageDomainService)
        {
            this.artistDomainService = artistDomainService;
            this.artistImageDomainService = artistImageDomainService;
        }

        public List<GetArtistsForClientViewModel> GetArtists()
        {
            List<Artist> artists = artistDomainService.GetArtists();
            return Mapper.Map<List<GetArtistsForClientViewModel>>(artists);
        }

        public ArtistImage GetImage(int artistId)
        {
            ArtistImage artistImage = artistImageDomainService.GetArtistImage(artistId);
            if (artistImage == null)
            {
                return new ArtistImage();
            }

            return artistImage;
        }
    }
}