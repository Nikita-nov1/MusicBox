using System.Threading.Tasks;
using MusicBox.Domain.Models.Entities.Identity;

namespace MusicBox.Domain.Repositories
{
    public interface IUserRepository : IBaseRepository<User>
    {
        User GetUserWithPlaylistsAndTracks(string userId);

        Task<User> GetUserByNameAsync(string userName);
    }
}
