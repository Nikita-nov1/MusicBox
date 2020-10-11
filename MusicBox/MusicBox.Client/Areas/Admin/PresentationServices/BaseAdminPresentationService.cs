using MusicBox.Areas.Admin.PresentationServices.Interfaces;
using System.IO;
using System.Web;

namespace MusicBox.Areas.Admin.PresentationServices
{
    public class BaseAdminPresentationService : IBaseAdminPresentationService
    {
        protected byte[] ConvertToBytes(HttpPostedFileBase image)
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
    }
}