using FluentValidation;
using MusicBox.Areas.Admin.Models.Artists;
using MusicBox.Domain.DomainServices.Interfaces;

namespace MusicBox.Areas.Admin.AdminValidators.Artist
{
    public class EditArtistVmValidator : AbstractValidator<EditArtistsViewModel>
    {
        private readonly IArtistDomainService artistDomainService;

        public EditArtistVmValidator(IArtistDomainService artistDomainService)
        {
            this.artistDomainService = artistDomainService;

            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Please specify a title for the artist.")
                .MaximumLength(20).WithMessage("A title for the artist can have a maximum of 30 characters.")
                .Must(IsUniqueTitle).WithMessage("An artist title already exists. Please modify an artist title.");

            RuleFor(x => x.Image)
                .Must(x => x.ContentLength <= 10_240).WithMessage("The image file for the artist is too large.")
                .Must(x => x.ContentType.Equals("image/jpeg") || x.ContentType.Equals("image/jpg") || x.ContentType.Equals("image/png"))
                .WithMessage("This file type for the artist image is not allowed.")
                .When(x => x.Image != null);
        }

        private bool IsUniqueTitle(EditArtistsViewModel editArtistViewModel, string title)
        {
            return artistDomainService.IsUniqueTitle(editArtistViewModel.Id, title);
        }
    }
}