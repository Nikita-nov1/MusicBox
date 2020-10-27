using System.Web;
using System.Web.Mvc;

namespace MusicBox.Areas.Admin.Models.Tracks
{
    public class EditTracksViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Artist { get; set; }
        public int AlbumId { get; set; }
        public int MoodId { get; set; }
        public int GenreId { get; set; }
        public SelectList SelectListAlbums { get; set; }
        public SelectList SelectListMoods { get; set; }
        public SelectList SelectListGenres { get; set; }
        public HttpPostedFileBase UploadTrack { get; set; }
    }
}