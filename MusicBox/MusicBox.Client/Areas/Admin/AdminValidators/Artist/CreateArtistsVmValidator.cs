using FluentValidation;
using MusicBox.Areas.Admin.Models.Artists;
using MusicBox.Domain.DomainServices.Interfaces;
using System;

namespace MusicBox.Areas.Admin.AdminValidators.Artist
{
    public class CreateArtistsVmValidator : AbstractValidator<CreateArtistsViewModel>
    {
        private readonly IArtistDomainService artistDomainService;

        public CreateArtistsVmValidator(IArtistDomainService artistDomainService)
        {
            this.artistDomainService = artistDomainService;

            RuleFor(x => x.Title)
             .NotEmpty().WithMessage("Please specify a first name.")
             .MaximumLength(20).WithMessage("Title can have a maximum of 20 characters.");

             //RuleFor(x => x.Image.ContentLength)
             //.LessThanOrEqualTo(70)
             //.When(x => x.Image != null)
             //.WithMessage("File size is larger than allowed");

             RuleFor(x => x.Image)
             .Must(x => x.ContentType.Equals("image/jpeg") || x.Equals("image/jpg") || x.Equals("image/png"))
             .WithMessage("File type is not allowed");

            //RuleFor(x => x)
            // .Must(Rulescc)
            // .WithMessage("File type is not allowed");


            // Сделать валидацию для Title -> Проверку на размер и на уникальность
            // Сделать валидацию для Image -> Проверку на тип расширения(допусается только картинки), размер (HttpPostedFileBase ->ContentLength) , Image моет быть null
        }

        //private bool Rulescc(CreateArtistsViewModel arg)
        //{
        //   arg.Image.ContentType
        //}

        //public bool ImageToByte(HttpPostedFileBase imageFile) - что-то тип такого
        //{
        //    if (imageFile == null) { return true; }
        //    return (imageFile.ContentType == "image/jpeg" || imageFile.ContentType == "image/gif" || imageFile.ContentType == "image/png")    - просмотри допустимые форматы расширения для картинок(не обязательно все))
        //}
    }
}