using MusicBox.Domain.DomainServices.Interfaces;
using MusicBox.Domain.Models.Entities.Identity;
using MusicBox.Domain.Repositories;
using MusicBox.Domain.UnitOfWork;
using System;

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

        public User GetUserWithPlaylists(string userId)
        {
            return userRepository.GetUserWithPlaylists(userId);
        }
    }
}
