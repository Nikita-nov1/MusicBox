using MusicBox.Domain.Models.Entities.Identity;
using System;

namespace MusicBox.Domain.Repositories
{
    public interface IUserRepository : IBaseRepository<User>
    {
        User GetUserWithPlaylists(string userId);
    }
}
