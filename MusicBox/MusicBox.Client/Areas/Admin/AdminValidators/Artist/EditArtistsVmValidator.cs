using FluentValidation;
using MusicBox.Areas.Admin.Models.Artists;
using MusicBox.Domain.DomainServices.Interfaces;

namespace MusicBox.Areas.Admin.AdminValidators.Artist
{
    public class EditArtistsVmValidator : AbstractValidator<EditArtistsViewModel>
    {
        private readonly IArtistDomainService artistDomainService;

        public EditArtistsVmValidator(IArtistDomainService artistDomainService)
        {
            this.artistDomainService = artistDomainService;

            RuleFor(x => x.Title);
            //.NotEmpty().WithMessage("Please specify a first name.")
            //.MaximumLength(15).WithMessage("First Name can have a max of 15 characters.");

            RuleFor(x => x.Image);
            //    .NotEmpty().WithMessage("Please specify a first name.")
            //    .MaximumLength(15).WithMessage("Last Name can have a max of 15 characters.");

            // Сделать валидацию для Id -> Существует ли такая сушность
            // Сделать валидацию для Title -> Проверку на размер и на уникальность(кроме себя самого) - как у меня в дз(если я тебе не скидывал последню версию, то сообщи)
            // Сделать валидацию для Image -> Проверку на тип расширения(допусается только картинки) , размер (HttpPostedFileBase ->ContentLength) , Image моет быть null
        }

        //public bool ImageToByte(HttpPostedFileBase imageFile) - что-то тип такого
        //{
        //    if (imageFile == null) { return true; }
        //    return (imageFile.ContentType == "image/jpeg" || imageFile.ContentType == "image/gif" || imageFile.ContentType == "image/png")    - просмотри допустимые форматы расширения для картинок(не обязательно все))
        //}
    }
}