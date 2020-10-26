using FluentValidation;
using MusicBox.Areas.Admin.Models.Tracks;
using MusicBox.Domain.DomainServices.Interfaces;

namespace MusicBox.Areas.Admin.AdminValidators.Track
{
    public class EditTrackVmValidator : AbstractValidator<EditTracksViewModel>
    {
        private readonly IArtistDomainService artistDomainService;
        private readonly IGenreDomainService genreDomainService;
        private readonly IMoodDomainService moodDomainService;
        private readonly IAlbumDomainService albumDomainService;
        private readonly ITrackDomainService trackDomainService;

        public EditTrackVmValidator(IArtistDomainService artistDomainService, IGenreDomainService genreDomainService,
            IMoodDomainService moodDomainService, IAlbumDomainService albumDomainService, ITrackDomainService trackDomainService)
        {
            this.artistDomainService = artistDomainService;
            this.moodDomainService = moodDomainService;
            this.genreDomainService = genreDomainService;
            this.albumDomainService = albumDomainService;
            this.trackDomainService = trackDomainService;

            RuleFor(x => x.Id)
                .Must(IsIdExists).WithMessage("This track doesn't exists.");

            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Please specify a title for the track.")
                .MaximumLength(30).WithMessage("A title for the track can have a maximum of 30 characters.")
                .Must(IsUniqueNewTitleArtistTrack).WithMessage("A track title for this artist already exists. Please modify a track title.");

            RuleFor(x => x.Artist)
                .NotEmpty().WithMessage("Please specify an artist title for the track.")
                .Must(IsExistsArtist).WithMessage("This artist doesn't exists.");

            RuleFor(x => x.AlbumId)
                .Must(IsExistsArtistsAlbum).WithMessage("This artist doesn't have this album.");

            RuleFor(x => x.MoodId)
                .Must(IsExistsMood).WithMessage("This mood doesn't exists.");

            RuleFor(x => x.GenreId)
                .Must(IsExistsGenre).WithMessage("This genre doesn't exists.");

            RuleFor(x => x.UploadTrack)
                .NotEmpty().WithMessage("You need to download the track.")
                .Must(x => x.ContentLength <= 52_428_800)
                .WithMessage("The track file is too large.");

            RuleFor(x => x.UploadTrack)
                .Must(x => x.ContentType.Equals("audio/mpeg") || x.ContentType.Equals("audio/ogg") || x.ContentType.Equals("audio/vnd.wav"))
                .WithMessage("This file type for the track file is not allowed.");
        }

        private bool IsIdExists(int id)
        {
            return trackDomainService.IsIdExists(id);
        }

        private bool IsExistsGenre(int id)
        {
            return genreDomainService.IsExistsGenre(id);
        }

        private bool IsExistsMood(int id)
        {
            return moodDomainService.IsExistsMood(id);
        }

        private bool IsExistsArtistsAlbum(int id)
        {
            return albumDomainService.IsIdExists(id);
        }

        private bool IsUniqueNewTitleArtistTrack(EditTracksViewModel editTracksViewModel, string title)
        {
            return artistDomainService.IsUniqueNewTitleArtistTrack(editTracksViewModel.Artist, title);
        }

        private bool IsExistsArtist(string artistTitle)
        {
            return artistDomainService.IsExistsArtist(artistTitle);
        }
    }
}