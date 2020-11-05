using MusicBox.Domain.Models.Entities.Identity;
using MusicBox.Models.User;
using System.Threading.Tasks;

namespace MusicBox.PresentationServices.Interfaces
{
    public interface IUserPresentationServices : IBasePresentationService
    {
       Task<GetUserViewModel> GetUserVmByNameAsync(string userName);
       Task<EditUserViewModel> GetEditUserVmByNameAsync(string userName);
       User GetUserForRegister(RegisterUserViewModel model);
       Task<User> GetUser(string userName);
       bool Updste(User user);
    }
}
