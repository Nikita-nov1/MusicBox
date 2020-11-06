using System;
using FluentValidation;
using MusicBox.Areas.Admin.Models.Albums;
using MusicBox.Domain.DomainServices.Interfaces;

namespace MusicBox.Areas.Admin.AdminValidators.Album
{
    public class CreateAlbumVmValidator : AbstractValidator<CreateAlbumsViewModel>
    {
        private readonly IArtistDomainService artistDomainService;
        private readonly IAlbumDomainService albumDomainService;

        public CreateAlbumVmValidator(IArtistDomainService artistDomainService, IAlbumDomainService albumDomainService)
        {
            this.artistDomainService = artistDomainService;
            this.albumDomainService = albumDomainService;

            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Please specify a title for the album.")
                .MaximumLength(30).WithMessage("A title for the album can have a maximum of 30 characters.")
                .Must(IsUniqueNewTitleArtistAlbum).WithMessage("An album title for this artist already exists. Please modify an album title.");

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

        private bool IsUniqueNewTitleArtistAlbum(CreateAlbumsViewModel createAlbumsViewModel, string title)
        {
            return albumDomainService.IsUniqueNewTitleArtistAlbum(createAlbumsViewModel.Artist, title);
        }

        private bool IsExistsArtist(string artistTitle)
        {
            return artistDomainService.IsExistsArtist(artistTitle);
        }
    }
}