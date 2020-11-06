using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using MusicBox.Domain.DomainServices.Interfaces;
using MusicBox.Domain.Interfaces;
using MusicBox.Domain.Models.Entities;
using MusicBox.Domain.Repositories;
using MusicBox.Domain.UnitOfWork;
using NAudio.Wave;

namespace MusicBox.Domain.DomainServices
{
    public class TrackDomainService : ITrackDomainService
    {
        private readonly ITrackRepository trackRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IGetPathServices getPathServices;
        private readonly IAlbumDomainService albumDomainService;
        private readonly ITrackStatisticsDomainService trackStatisticsDomainService;
        private readonly IArtistDomainService artistDomainService;

        public TrackDomainService(
            ITrackRepository trackRepository,
            IUnitOfWork unitOfWork,
            IGetPathServices getPathServices,
            IAlbumDomainService albumDomainService,
            ITrackStatisticsDomainService trackStatisticsDomainService,
            IArtistDomainService artistDomainService)
        {
            this.trackRepository = trackRepository;
            this.unitOfWork = unitOfWork;
            this.getPathServices = getPathServices;
            this.albumDomainService = albumDomainService;
            this.trackStatisticsDomainService = trackStatisticsDomainService;
            this.artistDomainService = artistDomainService;
        }

        public void AddTrack(Track track, HttpPostedFileBase uploadTrack)
        {
            track.TrackFile.TrackLocation = SaveTrack(uploadTrack);
            track.DateOfCreation = DateTime.Now;
            track.TrackFile.ContentType = uploadTrack.ContentType;
            track.DurationSong = GetDurationSongMp3(track.TrackFile.TrackLocation);
            trackRepository.Add(track);
            unitOfWork.SaveChanges();
        }

        public void EditTrack(Track track, HttpPostedFileBase uploadTrack)
        {
            if (uploadTrack != null)
            {
                track.TrackFile.TrackLocation = SaveTrack(uploadTrack);
                track.TrackFile.ContentType = uploadTrack.ContentType;
                track.DurationSong = GetDurationSongMp3(track.TrackFile.TrackLocation);
            }

            unitOfWork.SaveChanges();
        }

        public void DeleteTrack(int id)
        {
            trackRepository.DeleteById(id);
            unitOfWork.SaveChanges();
        }

        public List<Track> GetTracksWithAllAttachmentsExceptPlaylistsAndTrackFile()
        {
            return trackRepository.GetTracksWithAllAttachmentsExceptPlaylistsAndTrackFile();
        }

        public List<Track> GetAllTracksForAlbumWhitArtist(int albumId)
        {
             return albumDomainService.GetAllTracksForAlbumWhitArtist(albumId);
        }

        public List<Track> GetAllTracksForArtistWhitArtist(int artistId)
        {
            return artistDomainService.GetAllTracksForArtistWhitArtist(artistId);
        }

        public Track GetTrackWithAllAttachmentsExceptPlaylistsAndTrackFile(int trackId)
        {
            return trackRepository.GetTrackWithAllAttachmentsExceptPlaylistsAndTrackFile(trackId);
        }

        public Track GetTrackWithAllAttachmentsExceptPlaylistsAndTrackFileAndTrackStatistics(int trackId)
        {
            return trackRepository.GetTrackWithAllAttachmentsExceptPlaylistsAndTrackFileAndTrackStatistics(trackId);
        }

        public Track GetTrackWithAllAttachmentsExceptPlaylistsAndTrackStatistics(int trackId)
        {
            return trackRepository.GetTrackWithAllAttachmentsExceptPlaylistsAndTrackStatistics(trackId);
        }

        public Track GetTarck(int trackId)
        {
            return trackRepository.Get(trackId);
        }

        public Track GetTrackWithAllAttachmentsExceptPlaylistsAndTrackStatisticsForPlay(int trackId)
        {
            Track track = trackRepository.GetTrackWithAllAttachmentsExceptPlaylistsAndTrackStatistics(trackId);

            trackStatisticsDomainService.IncrementCountOfCalls(trackId);
            FixPathTrackLocationForPlayer(track);

            return track;
        }

        public bool IsIdExists(int id)
        {
            return trackRepository.IsIdExists(id);
        }

        public bool IsUniqueNewTitleArtistTrack(string artistTitle, string trackTitle)
        {
            return trackRepository.IsUniqueNewTitleArtistTrack(artistTitle, trackTitle);
        }

        public bool IsUniqueTitleArtistTrack(int trackId, string artistTitle, string trackTitle)
        {
            return trackRepository.IsUniqueTitleArtistTrack(trackId, artistTitle, trackTitle);
        }

        private string GetDurationSongMp3(string pathTrack)
        {
            string result = string.Empty;
            string fileExt = Path.GetExtension(pathTrack);
            if (fileExt == ".mp3")
            {
                // Use NAudio to get the duration of the File as a TimeSpan object
                TimeSpan duration = new Mp3FileReader(pathTrack).TotalTime;
                result = duration.ToString("mm\\:ss");
            }

            return result;
        }

        private void FixPathTrackLocationForPlayer(Track track)
        {
            var lastIndex = track.TrackFile.TrackLocation.LastIndexOf("Client");
            if (lastIndex != -1)
            {
                track.TrackFile.TrackLocation = track.TrackFile.TrackLocation.Substring(lastIndex + 6);
            }
        }

        private string SaveTrack(HttpPostedFileBase track)
        {
            var contentType = Path.GetExtension(track.FileName);
            var directoryToSave = getPathServices.GetPathForSaveTracks();

            var pathToSave = Path.Combine(directoryToSave, Guid.NewGuid().ToString() + contentType);

            track.SaveAs(pathToSave);
            return pathToSave;
        }
    }
}
