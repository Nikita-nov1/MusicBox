using System.Web;

namespace MusicBox.Areas.Admin.Models.Artists
{
    public class EditArtistsViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public HttpPostedFileBase Image { get; set; }
    }
}