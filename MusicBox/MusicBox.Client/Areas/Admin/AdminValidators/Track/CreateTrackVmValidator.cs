using FluentValidation;
using MusicBox.Areas.Admin.Models.Tracks;
using MusicBox.Domain.DomainServices.Interfaces;

namespace MusicBox.Areas.Admin.AdminValidators.Track
{
    public class CreateTrackVmValidator : AbstractValidator<CreateTracksViewModel>
    {
        private readonly IArtistDomainService artistDomainService;
        private readonly IGenreDomainService genreDomainService;
        private readonly IMoodDomainService moodDomainService;
        private readonly IAlbumDomainService albumDomainService;
        private readonly ITrackDomainService trackDomainService;

        public CreateTrackVmValidator(
            IArtistDomainService artistDomainService,
            IGenreDomainService genreDomainService,
            IMoodDomainService moodDomainService,
            IAlbumDomainService albumDomainService,
            ITrackDomainService trackDomainService)
        {
            this.artistDomainService = artistDomainService;
            this.moodDomainService = moodDomainService;
            this.genreDomainService = genreDomainService;
            this.albumDomainService = albumDomainService;
            this.trackDomainService = trackDomainService;

            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Please specify a title for the track.")
                .MaximumLength(30).WithMessage("A title for the track can have a maximum of 30 characters.")
                .Must(IsUniqueNewTitleArtistTrack).WithMessage("A track title for this artist already exists. Please modify a track title.");

            RuleFor(x => x.Artist)
                .NotEmpty().WithMessage("Please specify an artist title for the track.")
                .Must(IsExistsArtist).WithMessage("This artist doesn't exists.");

            RuleFor(x => x.AlbumId)
                .NotEmpty().WithMessage("Please specify an artist album for the track.")
                .Must(IsExistsArtistsAlbum).WithMessage("This artist doesn't have this album.");

            RuleFor(x => x.MoodId)
                .NotEmpty().WithMessage("Please specify an artist mood for the track.")
                .Must(IsExistsMood).WithMessage("This mood doesn't exists.");

            RuleFor(x => x.GenreId)
                .NotEmpty().WithMessage("Please specify an artist genre for the track.")
                .Must(IsExistsGenre).WithMessage("This genre doesn't exists.");

            RuleFor(x => x.UploadTrack)
                .NotEmpty().WithMessage("You need to download file")
                .Must(x => x.ContentLength <= 52_428_800).WithMessage("The track file is too large.")
                .Must(x => x.ContentType.Equals("audio/mpeg") || x.ContentType.Equals("audio/ogg") || x.ContentType.Equals("audio/vnd.wav"))
                .WithMessage("This file type for the track file is not allowed.");
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

        private bool IsUniqueNewTitleArtistTrack(CreateTracksViewModel createTracksViewModel, string title)
        {
            return trackDomainService.IsUniqueNewTitleArtistTrack(createTracksViewModel.Artist, title);
        }

        private bool IsExistsArtist(string artistTitle)
        {
            return artistDomainService.IsExistsArtist(artistTitle);
        }
    }
}