using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MusicBox.Domain.Models.AdditionalModels
{
    public class DefaultImage
    {
        public FileResult GetFile()
        {
            // Путь к файлу
            string file_path = Server.MapPath("~/Files/Images/Artists/defaultArtistImage.jpg");
            // Тип файла - content-type
            string file_type = "image/jpg";
            // Имя файла - необязательно
            string file_name = "defaultArtistImage.jpg";
            return File(file_path, file_type, file_name);
        }

    }

}
