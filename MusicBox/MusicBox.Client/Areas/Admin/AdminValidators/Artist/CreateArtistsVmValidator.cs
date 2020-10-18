using FluentValidation;
using Microsoft.Ajax.Utilities;
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

            RuleFor(x => x.Title)
             .NotEmpty().WithMessage("Please specify a first name.")
             .MaximumLength(20).WithMessage("Title can have a maximum of 20 characters.");

            RuleFor(x => x.Image)
            .Must(x => x.ContentLength <= 10000)
            .When(x => x.Image != null)
            .WithMessage("File size is larger than allowed");

 
            RuleFor(x => x.Image)
            .Must(x => x.ContentType.Equals("image/jpeg") || x.ContentType.Equals("image/jpg") || x.ContentType.Equals("image/png"))
            .When(x => x.Image != null)
            .WithMessage("File type is not allowed");

            RuleFor(x => x)
                .Must(IsUniqueNewTitle).WithMessage("Title name already exists. Please modify Title name.");
        }

        private bool IsUniqueNewTitle(CreateArtistsViewModel createArtistViewModel)
        {
            return artistDomainService.IsUniqueNewTitle(createArtistViewModel.Title);
        }
    }
}