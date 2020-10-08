using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicBox.Areas.Admin.Models.Artists
{
    public class CreateArtistsViewModel
    {
        public string Title { get; set; }

        public HttpPostedFileBase Image { get; set; }
    }
}