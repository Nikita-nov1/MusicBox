using FluentValidation;
using MusicBox.Areas.Admin.Models.Artists;
using MusicBox.Domain.DomainServices.Interfaces;

namespace MusicBox.Areas.Admin.AdminValidators.Artist
{
    public class CreateArtistsVmValidator : AbstractValidator<CreateArtistsViewModel>
    {
        private readonly IArtistDomainService artistDomainService;

        public CreateArtistsVmValidator(IArtistDomainService artistDomainService)
        {
            this.artistDomainService = artistDomainService;

            RuleFor(x => x.Title);
            //.NotEmpty().WithMessage("Please specify a first name.")
            //.MaximumLength(15).WithMessage("First Name can have a max of 15 characters.");

            RuleFor(x => x.Image);
            //    .NotEmpty().WithMessage("Please specify a first name.")
            //    .MaximumLength(15).WithMessage("Last Name can have a max of 15 characters.");

            // Сделать валидацию для Title -> Проверку на размер и на уникальность

            // Сделать валидацию для Image -> Проверку на тип расширения(допусается только картинки), размер (HttpPostedFileBase ->ContentLength) , Image моет быть null
        }

        //public bool ImageToByte(HttpPostedFileBase imageFile) - что-то тип такого
        //{
        //    if (imageFile == null) { return true; }
        //    return (imageFile.ContentType == "image/jpeg" || imageFile.ContentType == "image/gif" || imageFile.ContentType == "image/png")    - просмотри допустимые форматы расширения для картинок(не обязательно все))
        //}
    }
}