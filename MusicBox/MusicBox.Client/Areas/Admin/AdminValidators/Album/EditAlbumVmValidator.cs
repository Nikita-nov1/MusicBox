using FluentValidation;
using MusicBox.Areas.Admin.Models.Albums;
using MusicBox.Domain.DomainServices.Interfaces;
using System;

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

            RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Please specify a title name.")
            .MaximumLength(30).WithMessage("Title can have a maximum of 30 characters.")
            .Must(IsUniqueTitle).WithMessage("Title name already exists. Please modify Title name.");

            RuleFor(x => x.Year)
            .Must(x => x >= 1900 & x <= DateTime.Now.Year)
            .When(x => x != null)
            .WithMessage("The year must be between 1900 and the current year.");

            RuleFor(x => x.Image)
            .Must(x => x.ContentLength <= 10000)
            .When(x => x.Image != null)
            .WithMessage("File size is larger than allowed");

            RuleFor(x => x.Image)
            .Must(x => x.ContentType.Equals("image/jpeg") || x.ContentType.Equals("image/jpg") || x.ContentType.Equals("image/png"))
            .When(x => x.Image != null)
            .WithMessage("File type is not allowed");
        }

        private bool IsUniqueTitle(EditAlbumsViewModel editAlbumViewModel, string title)
        {
            return albumDomainService.IsUniqueTitle(editAlbumViewModel.Id, title);
        }

        //Id - Должен существовать в бд
        //Artist  - Должен существовать в бд,
    }
}