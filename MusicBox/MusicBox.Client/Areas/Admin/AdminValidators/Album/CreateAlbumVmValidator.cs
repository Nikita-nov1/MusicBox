using FluentValidation;
using MusicBox.Areas.Admin.Models.Albums;
using MusicBox.Domain.DomainServices.Interfaces;

namespace MusicBox.Areas.Admin.AdminValidators.Album
{
    public class CreateAlbumVmValidator : AbstractValidator<CreateAlbumsViewModel>
    {
        private readonly IAlbumDomainService albumDomainService;
        private readonly IArtistDomainService artistDomainService;

        public CreateAlbumVmValidator(IAlbumDomainService albumDomainService, IArtistDomainService artistDomainService)
        {
            this.albumDomainService = albumDomainService;
            this.artistDomainService = artistDomainService;


        }

        //Title  - макс длинна 30, not null, IsUnique(true)
        //Year  - IsOptional(); если есть, то в пределах от 1900 - текущего(DateTime.Now.Year)
        //Artist  - Должен существовать,
        //HttpPostedFileBase Image - ограничение на картинку(размер, расширение) (можешь в  Presentation layer поменять существующие дефолтные картинки на твои легковесные )

        // ps -если нам нужно получить Artist, обращаемся к artistDomainService->IArtistRepository

    }
}