using System;
using System.Threading.Tasks;
using MusicBox.Domain.Models.Entities.Identity;

namespace MusicBox.Domain.DomainServices.Interfaces
{
    public interface IUserDomainService : IBaseDomainService
    {
        User GetUserWithPlaylistsAndTracks(string userId);

        Task<User> GetUserByNameAsync(string userName);

        bool Updste(User user);
    }
}
