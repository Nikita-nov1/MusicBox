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

            RuleFor(x => x.Id)
                .Must(IsIdExists).WithMessage("This album doesn't exists.");

            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Please specify a title name.")
                .MaximumLength(30).WithMessage("Title can have a maximum of 30 characters.")
                .Must(IsUniqueNewTitleArtistAlbum).WithMessage("Title name already exists. Please modify Title name.");

            RuleFor(x => x.Year)
                .Must(x => x >= 1900 & x <= DateTime.Now.Year)
                .When(x => x != null)
                .WithMessage("The year must be between 1900 and the current year.");

            RuleFor(x => x.Image)
                .Must(x => x.ContentLength <= 10_240)
                .When(x => x.Image != null)
                .WithMessage("File size is larger than allowed");

            RuleFor(x => x.Image)
                .Must(x => x.ContentType.Equals("image/jpeg") || x.ContentType.Equals("image/jpg") || x.ContentType.Equals("image/png"))
                .When(x => x.Image != null)
                .WithMessage("File type is not allowed");

            RuleFor(x => x.Artist)
                .Must(IsExistsArtist).WithMessage("This artist doesn't exists.");
        }

        private bool IsIdExists(int id)
        {
            return albumDomainService.IsIdExists(id);
        }

        private bool IsUniqueNewTitleArtistAlbum(EditAlbumsViewModel editAlbumsViewModel, string title)
        {
            return artistDomainService.IsUniqueNewTitleArtistAlbum(editAlbumsViewModel.Artist, title);
        }

        private bool IsExistsArtist(string artistTitle)
        {
            return artistDomainService.IsExistsArtist(artistTitle);
        }
    }
}