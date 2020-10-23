using MusicBox.Domain.DomainServices.Interfaces;
using MusicBox.Domain.Interfaces;
using MusicBox.Domain.Models.Entities;
using MusicBox.Domain.Repositories;
using MusicBox.Domain.UnitOfWork;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web;

namespace MusicBox.Domain.DomainServices
{
    public class TrackDomainService : ITrackDomainService
    {
        private readonly ITrackRepository trackRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IGetPathServices getPathServices;

        public TrackDomainService(ITrackRepository trackRepository, IUnitOfWork unitOfWork, IGetPathServices getPathServices)
        {
            this.trackRepository = trackRepository;
            this.unitOfWork = unitOfWork;
            this.getPathServices = getPathServices;
        }

        public void AddTrack(Track track, HttpPostedFileBase uploadTrack)
        {
            track.TrackFile.TrackLocation = SaveTrack(uploadTrack);
            track.DateOfCreation = DateTime.Now;

            track.DurationSong = GetDurationSongMp3(track.TrackFile.TrackLocation);

            trackRepository.Add(track);
            unitOfWork.SaveChanges();

        }

        public void EditTrack(Track track ,HttpPostedFileBase uploadTrack)
        {
            if (uploadTrack != null)
            {
                track.TrackFile.TrackLocation = SaveTrack(uploadTrack);   
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

        private string GetDurationSongMp3(string pathTrack)
        {
            string result = string.Empty;
            string fileExt = Path.GetExtension(pathTrack);
            if (fileExt == ".mp3")
            {
                //Use NAudio to get the duration of the File as a TimeSpan object
                TimeSpan duration = new Mp3FileReader(pathTrack).TotalTime;
                result = duration.ToString("mm\\:ss");
            }
            return result;

        }


        private string SaveTrack(HttpPostedFileBase track)
        {

            var contentType = Path.GetExtension(track.FileName);
            var directoryToSave = getPathServices.GetPathForSaveTracks();

            var pathToSave = Path.Combine(directoryToSave, Guid.NewGuid().ToString() + contentType);

            track.SaveAs(pathToSave);
            return pathToSave;

        }

        public bool IsIdExists(int id)
        {
            return trackRepository.IsIdExists(id);
        }
    }
}



