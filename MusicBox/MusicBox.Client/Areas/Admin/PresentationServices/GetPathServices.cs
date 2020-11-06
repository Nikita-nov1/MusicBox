using System.Web.Hosting;
using MusicBox.Domain.Interfaces;

namespace MusicBox.Areas.Admin.PresentationServices
{
    public class GetPathServices : IGetPathServices
    {
        public string GetPathDefaultArtistImage()
        {
            return HostingEnvironment.MapPath("~/Files/Images/Artist/defaultArtistImage.jpg");
        }

        public string GetPathDefaultAlbumImage()
        {
            return HostingEnvironment.MapPath("~/Files/Images/Album/defaultAlbumImage.jpg");
        }

        public string GetPathForSaveTracks()
        {
            return HostingEnvironment.MapPath("~/UploadedFiles/Tracks");
        }
    }
}
