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
                .Must(IsIdExists);

            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Please specify a title for the album.")
                .MaximumLength(30).WithMessage("A title for the album can have a maximum of 30 characters.")
                .Must(IsUniqueTitleArtistAlbum).WithMessage("An album title for this artist already exists. Please modify an album title.");

            RuleFor(x => x.Year)
                .Must(x => x >= 1900 & x <= DateTime.Now.Year).WithMessage("An album year must be between 1900 and the current year.")
                .When(x => x != null);

            RuleFor(x => x.Image)
                .Must(x => x.ContentLength <= 10_240).WithMessage("The image file for the album is too large.")
                .Must(x => x.ContentType.Equals("image/jpeg") || x.ContentType.Equals("image/jpg") || x.ContentType.Equals("image/png"))
                .WithMessage("This file type for the album image is not allowed.")
                .When(x => x.Image != null);

            RuleFor(x => x.Artist)
                .Must(IsExistsArtist).WithMessage("This artist doesn't exists.");
        }

        private bool IsIdExists(int id)
        {
            return albumDomainService.IsIdExists(id);
        }

        private bool IsUniqueTitleArtistAlbum(EditAlbumsViewModel editAlbumsViewModel, string title)
        {
            return albumDomainService.IsUniqueTitleArtistAlbum(editAlbumsViewModel.Id, editAlbumsViewModel.Artist, title);
        }

        private bool IsExistsArtist(string artistTitle)
        {
            return artistDomainService.IsExistsArtist(artistTitle);
        }
    }
}