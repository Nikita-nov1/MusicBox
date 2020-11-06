using System.IO;
using System.Threading.Tasks;
using System.Web;
using System.Web.Hosting;
using AutoMapper;
using MusicBox.Domain.DomainServices.Interfaces;
using MusicBox.Domain.Models.Entities;
using MusicBox.Domain.Models.Entities.Identity;
using MusicBox.Models.User;
using MusicBox.PresentationServices.Interfaces;

namespace MusicBox.PresentationServices
{
    public class UserPresentationServices : IUserPresentationServices
    {
        private readonly IPlaylistDomainService playlistDomainService;
        private readonly IUserDomainService userDomainService;

        public UserPresentationServices(IPlaylistDomainService playlistDomainService, IUserDomainService userDomainService)
        {
            this.playlistDomainService = playlistDomainService;
            this.userDomainService = userDomainService;
        }

        public async Task<GetUserViewModel> GetUserVmByNameAsync(string userName)
        {
            User user = await userDomainService.GetUserByNameAsync(userName);
            return Mapper.Map<GetUserViewModel>(user);
        }

        public async Task<EditUserViewModel> GetEditUserVmByNameAsync(string userName)
        {
            User user = await userDomainService.GetUserByNameAsync(userName);
            if (user != null)
            {
                return Mapper.Map<EditUserViewModel>(user);
            }

            return null;
        }

        public async Task<User> GetUser(string userName)
        {
            return await userDomainService.GetUserByNameAsync(userName);
        }

        public bool Updste(User user)
        {
            return userDomainService.Updste(user);
        }

        public User GetUserForRegister(RegisterUserViewModel modelVm)
        {
            User user = Mapper.Map<User>(modelVm);

            if (modelVm.Image != null)
            {
                user.UserImage.Image = ConvertToBytes(modelVm.Image);
            }
            else
            {
                AddDefaultUserImage(user);
            }

            user.Playlists.Add(GetPlaylistForLike());
            return user;
        }

        private Playlist GetPlaylistForLike()
        {
            Playlist playlist = new Playlist();
            AddDefaultPlaylistImage(playlist);
            playlist.Title = "MyFavoriteTracks";

            return playlist;
        }

        private byte[] ConvertToBytes(HttpPostedFileBase image)
        {
            if (image == null)
            {
                return null;
            }

            byte[] imageBytes = null;

            using (var binaryReader = new BinaryReader(image.InputStream))
            {
                imageBytes = binaryReader.ReadBytes(image.ContentLength);
            }

            return imageBytes;
        }

        private void AddDefaultUserImage(User user)
        {
            using (FileStream fileStream = new FileStream(HostingEnvironment.MapPath("~/Files/Images/User/user_default.png"), FileMode.Open))
            {
                using (var binaryReader = new BinaryReader(fileStream))
                {
                    user.UserImage.ContentType = Path.GetExtension(fileStream.Name);
                    user.UserImage.Image = binaryReader.ReadBytes((int)fileStream.Length);
                }
            }
        }

        private void AddDefaultPlaylistImage(Playlist playlist)
        {
            using (FileStream fileStream = new FileStream(HostingEnvironment.MapPath("~/Files/Images/Playlist/playlist-like.png"), FileMode.Open))
            {
                using (var binaryReader = new BinaryReader(fileStream))
                {
                    playlist.PlaylistImage = new PlaylistImage
                    {
                        ContentType = Path.GetExtension(fileStream.Name),
                        Image = binaryReader.ReadBytes((int)fileStream.Length)
                    };
                }
            }
        }
    }
}