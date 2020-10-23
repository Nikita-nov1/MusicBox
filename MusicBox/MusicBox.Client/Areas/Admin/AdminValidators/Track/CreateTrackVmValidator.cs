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

        public CreateTrackVmValidator(IArtistDomainService artistDomainService, IGenreDomainService genreDomainService,
            IMoodDomainService moodDomainService, IAlbumDomainService albumDomainService)
        {
            this.artistDomainService = artistDomainService;
            this.moodDomainService = moodDomainService;
            this.genreDomainService = genreDomainService;
            this.albumDomainService = albumDomainService;

            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Please specify a title name for track.")
                .MaximumLength(20).WithMessage("Title name for track can have a maximum of 20 characters.")
                .Must(IsUniqueNewTitleArtistTrack).WithMessage("Track's title name for this artist already exists. Please modify track's title name.");

            RuleFor(x => x.Artist)
                .NotEmpty().WithMessage("Please specify an artist's title.")
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
                .WithMessage("File size is larger than allowed");

            RuleFor(x => x.UploadTrack)
                .Must(x => x.ContentType.Equals("audio/mpeg") || x.ContentType.Equals("audio/ogg") || x.ContentType.Equals("audio/vnd.wav"))
                .WithMessage("File type is not allowed");
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
            return artistDomainService.IsUniqueNewTitleArtistTrack(createTracksViewModel.Artist, title);
        }

        private bool IsExistsArtist(string artistTitle)
        {
            return artistDomainService.IsExistsArtist(artistTitle);
        }
    }
}