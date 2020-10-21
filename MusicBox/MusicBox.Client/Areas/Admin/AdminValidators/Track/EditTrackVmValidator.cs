using FluentValidation;
using MusicBox.Areas.Admin.Models.Tracks;
using MusicBox.Domain.DomainServices.Interfaces;

namespace MusicBox.Areas.Admin.AdminValidators.Track
{
    //public class EditTrackVmValidator : AbstractValidator<EditTracksViewModel>
    //{
    //    private readonly ITrackDomainService trackDomainService;

    //    public EditTrackVmValidator(ITrackDomainService trackDomainService)
    //    {
    //        this.trackDomainService = trackDomainService;


    //    }

    //     Id - должен существовать
    //  public string Title { get; set; }   - обязательный, проверить длину
    //    //public string Artist { get; set; }   - должен существовать
    //    //public int AlbumId { get; set; }    - должен принадлежать артисту
    //    //public int MoodId { get; set; }      - должен существовать
    //    //public int GenreId { get; set; }    - должен существовать

    //    //public HttpPostedFileBase UploadTrack { get; set; }  - проверка на размер до 50мб , обязательный,  проверка на тип файла(музыкальное расширение ContentType = "audio/mpeg") 
    //}
}