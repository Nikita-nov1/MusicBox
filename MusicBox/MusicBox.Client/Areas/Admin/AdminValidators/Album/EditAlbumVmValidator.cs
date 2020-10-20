using FluentValidation;
using MusicBox.Areas.Admin.Models.Albums;
using MusicBox.Domain.DomainServices.Interfaces;

namespace MusicBox.Areas.Admin.AdminValidators.Album
{

    public class EditAlbumVmValidator : AbstractValidator<EditAlbumsViewModel>
    {
        private readonly IAlbumDomainService albumDomainService;
        private readonly IArtistDomainService artistDomainService;

        public EditAlbumVmValidator(IAlbumDomainService albumDomainService , IArtistDomainService artistDomainService)
        {
            this.albumDomainService = albumDomainService;
            this.artistDomainService = artistDomainService;


        }

        //Id - Должен существовать в бд
        //Title  - макс длинна 30, not null, IsUnique(true)
        //Year  - IsOptional(); если есть, то в пределах от 1900 - текущего(DateTime.Now.Year)
        //Artist  - Должен существовать в бд,
        //HttpPostedFileBase Image - ограничение на картинку(размер, расширение) (можешь в  Presentation layer поменять существующие дефолтные картинки на твои легковесные )

    }
}