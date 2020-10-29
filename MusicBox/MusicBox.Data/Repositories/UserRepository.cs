using MusicBox.Domain.Models.Entities.Identity;
using MusicBox.Domain.Repositories;
using MusicBox.Domain.UnitOfWork;
using System;

namespace MusicBox.Data.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public User GetUserWithPlaylists(string userId)
        {
            var entityUser = Get(userId);
            Entry(entityUser).Collection(c => c.Playlists).Load();
            
            return entityUser;
        }

    }
}
