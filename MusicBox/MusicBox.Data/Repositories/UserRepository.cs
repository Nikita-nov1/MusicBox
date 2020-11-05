using MusicBox.Domain.Models.Entities.Identity;
using MusicBox.Domain.Repositories;
using MusicBox.Domain.UnitOfWork;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace MusicBox.Data.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public User GetUserWithPlaylistsAndTracks(string userId)
        {
             return GetQueryableItems()
            .Include(x => x.Playlists)
            .Include(x => x.Playlists.Select(y => y.Tracks))
            .Single(x => x.Id.Equals(userId));
        }

        public async Task<User> GetUserByNameAsync(string userName)
        {
            return await GetQueryableItems().SingleAsync(c => c.UserName.Equals(userName));
        }

    }
}
