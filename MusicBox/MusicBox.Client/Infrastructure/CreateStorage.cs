using System.IO;
using System.Web.Hosting;

namespace MusicBox.Infrastructure
{
    public static class CreateStorage
    {
        public static void CreateUploadedFiles()
        {
            var folder = HostingEnvironment.MapPath("~/UploadedFiles");
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
                Directory.CreateDirectory(folder + "/Tracks");
            }
        }
    }
}