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

            RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Please specify a first name.")
            .MaximumLength(20).WithMessage("Title can have a maximum of 20 characters.")
            .Must(IsUniqueTitle).WithMessage("Title name already exists. Please modify Title name.");

            RuleFor(x => x.Image)
            .Must(x => x.ContentLength <= 10000)
            .When(x => x.Image != null)
            .WithMessage("File size is larger than allowed");

            RuleFor(x => x.Image)
            .Must(x => x.ContentType.Equals("image/jpeg") || x.ContentType.Equals("image/jpg") || x.ContentType.Equals("image/png"))
            .When(x => x.Image != null)
            .WithMessage("File type is not allowed");

        }

        private bool IsUniqueTitle(EditArtistsViewModel editArtistViewModel, string title)
        {
            return artistDomainService.IsUniqueTitle(editArtistViewModel.Id, title);
        }

    }
}