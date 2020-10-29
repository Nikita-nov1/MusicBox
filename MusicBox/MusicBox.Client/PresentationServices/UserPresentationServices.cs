using MusicBox.Domain.DomainServices.Interfaces;
using MusicBox.PresentationServices.Interfaces;

namespace MusicBox.PresentationServices
{
    public class UserPresentationServices : IUserPresentationServices
    {
        private readonly IPlaylistDomainService playlistDomainService;

        public UserPresentationServices(IPlaylistDomainService playlistDomainService)
        {
            this.playlistDomainService = playlistDomainService;
        }



    }
}