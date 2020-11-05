using MusicBox.Domain.Models.Entities.Identity;
using System;
using System.Threading.Tasks;

namespace MusicBox.Domain.DomainServices.Interfaces
{
    public interface IUserDomainService : IBaseDomainService
    {
        User GetUserWithPlaylistsAndTracks(string userId);
        Task<User> GetUserByNameAsync(string userName);
        bool Updste(User user);
    }
}
