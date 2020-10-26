using FluentValidation;
using MusicBox.Areas.Admin.Models.Artists;
using MusicBox.Domain.DomainServices.Interfaces;

namespace MusicBox.Areas.Admin.AdminValidators.Artist
{
    public class CreateArtistVmValidator : AbstractValidator<CreateArtistsViewModel>
    {
        private readonly IArtistDomainService artistDomainService;

        public CreateArtistVmValidator(IArtistDomainService artistDomainService)
        {
            this.artistDomainService = artistDomainService;

            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Please specify a title for the artist.")
                .MaximumLength(30).WithMessage("A title for the artist can have a maximum of 30 characters.")
                .Must(IsUniqueNewTitle).WithMessage("An artist title already exists. Please modify an artist title.");

            RuleFor(x => x.Image)
                .Must(x => x.ContentLength <= 10_240)
                .When(x => x.Image != null)
                .WithMessage("The image file for the artist is too large.");

            RuleFor(x => x.Image)
                .Must(x => x.ContentType.Equals("image/jpeg") || x.ContentType.Equals("image/jpg") || x.ContentType.Equals("image/png"))
                .When(x => x.Image != null)
                .WithMessage("This file type for the artist image is not allowed.");
        }

        private bool IsUniqueNewTitle(string title)
        {
            return artistDomainService.IsUniqueNewTitle(title);
        }
    }
}