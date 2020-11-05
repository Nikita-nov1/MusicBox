using MusicBox.Domain.Models.Entities.Identity;
using System;
using System.Threading.Tasks;

namespace MusicBox.Domain.Repositories
{
    public interface IUserRepository : IBaseRepository<User>
    {
        User GetUserWithPlaylistsAndTracks(string userId);
        Task<User> GetUserByNameAsync(string userName);
    }
}
