using System.IO;
using System.Web.Hosting;

namespace MusicBox.Infrastructure
{
    public static class CreateStorage
    {
        public static void CreateUploadedFiles()
        {
            var folder = HostingEnvironment.MapPath("~/UploadedFiles");
            if (!Directory.Exists(folder)) // 1  метод создать если не существует
            {
                Directory.CreateDirectory(folder);
            }
        }
    }
}