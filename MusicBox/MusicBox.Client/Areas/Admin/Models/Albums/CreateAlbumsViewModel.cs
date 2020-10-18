using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicBox.Areas.Admin.Models.Albums
{
    public class CreateAlbumsViewModel  
    {
        public string Title { get; set; }
        public short Year { get; set; }  
        public string Artist { get; set; }  
        public HttpPostedFileBase Image { get; set; }
    }
}