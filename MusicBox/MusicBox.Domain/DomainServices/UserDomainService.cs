using System.Threading.Tasks;
using MusicBox.Domain.DomainServices.Interfaces;
using MusicBox.Domain.Models.Entities.Identity;
using MusicBox.Domain.Repositories;
using MusicBox.Domain.UnitOfWork;

namespace MusicBox.Domain.DomainServices
{
    public class UserDomainService : IUserDomainService
    {
        private readonly IUserRepository userRepository;
        private readonly IUnitOfWork unitOfWork;

        public UserDomainService(IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            this.userRepository = userRepository;
            this.unitOfWork = unitOfWork;
        }

        public User GetUserWithPlaylistsAndTracks(string userId)
        {
            return userRepository.GetUserWithPlaylistsAndTracks(userId);
        }

        public async Task<User> GetUserByNameAsync(string userName)
        {
            return await userRepository.GetUserByNameAsync(userName);
        }

        public bool Updste(User user)
        {
            var result = unitOfWork.SaveChanges();

            if (result > 0)
            {
                return true;
            }

            return false;
        }
    }
}
