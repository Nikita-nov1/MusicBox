using MusicBox.Domain.Models.Entities.Identity;
using System;

namespace MusicBox.Domain.DomainServices.Interfaces
{
    public interface IUserDomainService : IBaseDomainService
    {
        User GetUserWithPlaylists(string userId);
    }
}
