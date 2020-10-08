using MusicBox.Data.Context;
using MusicBox.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SetupDb
{
    public class AddElementsDb
    {
        public AddElementsDb()
        {

            Seed();
        }

        private void Seed()
        {
            using (MusicBoxDbContext db = new MusicBoxDbContext())
            {

                if (!db.Set<Genre>().Any())
                {
                    List<Genre> genres = new List<Genre>()
                    {
                       new Genre{Title = "Классика",GenreImage = new GenreImage{Image = null } },
                       new Genre{Title = "Метал",GenreImage = new GenreImage{Image = null }},
                       new Genre{Title = "Поп",GenreImage = new GenreImage{Image = null }},
                       new Genre{Title = "Рок",GenreImage = new GenreImage{Image = null }},
                       new Genre{Title = "Альтернатива",GenreImage = new GenreImage{Image = null }},
                       new Genre{Title = "Рэп и хип-хоп",GenreImage = new GenreImage{Image = null }},
                       new Genre{Title = "Джаз",GenreImage = new GenreImage{Image = null }},
                       new Genre{Title = "Шансон",GenreImage = new GenreImage{Image = null }},
                       new Genre{Title = "Русский рок",GenreImage = new GenreImage{Image = null }},
                       new Genre{Title = "Диско",GenreImage = new GenreImage{Image = null }},
                       new Genre{Title = "Русский рэп",GenreImage = new GenreImage{Image = null }}

                    };
                    db.Set<Genre>().AddRange(genres);
                    db.SaveChanges();
                }

                if (!db.Set<Mood>().Any())
                {
                    List<Mood> moods = new List<Mood>()
                    {
                       new Mood{Title = "Агрессивное",MoodImage = new MoodImage{Image = null }},
                       new Mood{Title = "Грустное",MoodImage = new MoodImage{Image = null }},
                       new Mood{Title = "Красивое",MoodImage = new MoodImage{Image = null }},
                       new Mood{Title = "Крутое",MoodImage = new MoodImage{Image = null }},
                       new Mood{Title = "Мечтательное",MoodImage = new MoodImage{Image = null }},
                       new Mood{Title = "Мистическое",MoodImage = new MoodImage{Image = null }},
                       new Mood{Title = "Радостное",MoodImage = new MoodImage{Image = null }},
                       new Mood{Title = "Энергичное",MoodImage = new MoodImage{Image = null }},
                       new Mood{Title = "Спокойное",MoodImage = new MoodImage{Image = null }},
                       new Mood{Title = "Эпичное",MoodImage = new MoodImage{Image = null }}

                    };
                    db.Set<Mood>().AddRange(moods);
                    db.SaveChanges();
                }

                if (!db.Set<Artist>().Any())
                {
                    List<Artist> artists = new List<Artist>()
                    {
                       new Artist(){Title = "Макс Корж",ArtistImage = new ArtistImage(){Image = null } },
                       new Artist(){Title = "Виктор Цой",ArtistImage = new ArtistImage(){Image = null } },
                       new Artist(){Title = "Сергей Михалок",ArtistImage = new ArtistImage(){Image = null } },
                       new Artist(){Title = "ДДТ",ArtistImage = new ArtistImage(){Image = null } },
                       new Artist(){Title = "Toni Moralez",ArtistImage = new ArtistImage(){Image = null } },
                       new Artist(){Title = "Bill Callahan",ArtistImage = new ArtistImage(){Image = null } },
                       new Artist(){Title = "NILETTO",ArtistImage = new ArtistImage(){Image = null } },
                       new Artist(){Title = "Сплин",ArtistImage = new ArtistImage(){Image = null } },
                       new Artist(){Title = "Linkin Park",ArtistImage = new ArtistImage(){Image = null } },
                       new Artist(){Title = "Неизвестный исполнитель",ArtistImage = new ArtistImage(){Image = null } }

                    };
                    db.Set<Artist>().AddRange(artists);
                    db.SaveChanges();
                }


                if (!db.Set<Album>().Any())
                {
                    var allArtists = db.Set<Artist>().ToList();
                    List<Album> albums = new List<Album>()
                    {
                       new Album() {Title = "Long in the Tooth",AlbumImage = new AlbumImage(){Image = null},DateOfCreation = DateTime.Now,Year = 2003,Artist = allArtists[1]},
                       new Album() {Title = "Голоса",AlbumImage = new AlbumImage(){Image = null},DateOfCreation = DateTime.Now,Year = 2003,Artist = allArtists[0]},
                       new Album() {Title = "Улетай со мной",AlbumImage = new AlbumImage(){Image = null},DateOfCreation = DateTime.Now,Year = 2003,Artist = allArtists[2]},
                       new Album() {Title = "Плохие манеры",AlbumImage = new AlbumImage(){Image = null},DateOfCreation = DateTime.Now,Year = 2003,Artist = allArtists[3]},
                       new Album() {Title = "Иллюзия нормальности",AlbumImage = new AlbumImage(){Image = null},DateOfCreation = DateTime.Now,Year = 2003,Artist = allArtists[4]},
                       new Album() {Title = "Альбом, которого нет",AlbumImage = new AlbumImage(){Image = null},DateOfCreation = DateTime.Now,Year = 2003,Artist = allArtists[5]},
                       new Album() {Title = "LOVE U GOD",AlbumImage = new AlbumImage(){Image = null},DateOfCreation = DateTime.Now,Year = 2003,Artist = allArtists[6]},
                       new Album() {Title = "Never Gonna Dance Again",AlbumImage = new AlbumImage(){Image = null},DateOfCreation = DateTime.Now,Year = 2003,Artist = allArtists[7]},
                       new Album() {Title = "Морская",AlbumImage = new AlbumImage(){Image = null},DateOfCreation = DateTime.Now,Year = 2003,Artist = allArtists[5]},
                       new Album() {Title = "I'm OK",AlbumImage = new AlbumImage(){Image = null},DateOfCreation = DateTime.Now,Year = 2003,Artist = allArtists[9]},
                       new Album() {Title = "Просвистела",AlbumImage = new AlbumImage(){Image = null},DateOfCreation = DateTime.Now,Year = 2003,Artist = allArtists[8]},

                    };
                    db.Set<Album>().AddRange(albums);
                    db.SaveChanges();
                }

                if (!db.Set<Track>().Any())
                {

                    var allAlbums = db.Set<Album>().ToList(); //11
                    var allArtists = db.Set<Artist>().ToList(); // 10
                    var allGenres = db.Set<Genre>().ToList(); //11
                    var allMood = db.Set<Mood>().ToList(); //10
                    List<Track> traks = new List<Track>()
                    {
                       new Track(){Title = "Перемен",Album = allAlbums[0],Artist =allArtists[0],Genre = allGenres[0],Mood =allMood[0] ,
                           TrackFile = new TrackFile{TrackLocation = "Some path" },TrackStatistics = new TrackStatistics{CountOfCalls = 0 } ,DateOfCreation = DateTime.Now,DurationSong = "1:13"},
                       new Track(){Title = "Юность",Album = allAlbums[1],Artist =allArtists[1],Genre = allGenres[1],Mood =allMood[2] ,
                           TrackFile = new TrackFile{TrackLocation = "Some path" },TrackStatistics = new TrackStatistics{CountOfCalls = 0 } ,DateOfCreation = DateTime.Now,DurationSong = "1:13"},
                       new Track(){Title = "Времена",Album = allAlbums[2],Artist =allArtists[2],Genre = allGenres[2],Mood =allMood[1] ,
                           TrackFile = new TrackFile{TrackLocation = "Some path" },TrackStatistics = new TrackStatistics{CountOfCalls = 0 } ,DateOfCreation = DateTime.Now,DurationSong = "1:13"},
                       new Track(){Title = "Воины света",Album = allAlbums[3],Artist =allArtists[3],Genre = allGenres[3],Mood =allMood[3] ,
                           TrackFile = new TrackFile{TrackLocation = "Some path" },TrackStatistics = new TrackStatistics{CountOfCalls = 0 } ,DateOfCreation = DateTime.Now,DurationSong = "1:13"},
                       new Track(){Title = "Самый белый цветок",Album = allAlbums[4],Artist =allArtists[4],Genre = allGenres[4],Mood =allMood[4] ,
                           TrackFile = new TrackFile{TrackLocation = "Some path" },TrackStatistics = new TrackStatistics{CountOfCalls = 0 } ,DateOfCreation = DateTime.Now,DurationSong = "1:13"},
                       new Track(){Title = "Грай",Album = allAlbums[5],Artist =allArtists[5],Genre = allGenres[5],Mood =allMood[5] ,
                           TrackFile = new TrackFile{TrackLocation = "Some path" },TrackStatistics = new TrackStatistics{CountOfCalls = 0 } ,DateOfCreation = DateTime.Now,DurationSong = "1:13"},
                       new Track(){Title = "Лютики",Album = allAlbums[6],Artist =allArtists[6],Genre = allGenres[6],Mood =allMood[6] ,
                           TrackFile = new TrackFile{TrackLocation = "Some path" },TrackStatistics = new TrackStatistics{CountOfCalls = 0 } ,DateOfCreation = DateTime.Now,DurationSong = "1:13"},
                       new Track(){Title = "Что такое осень",Album = allAlbums[7],Artist =allArtists[7],Genre = allGenres[7],Mood =allMood[7] ,
                           TrackFile = new TrackFile{TrackLocation = "Some path" },TrackStatistics = new TrackStatistics{CountOfCalls = 0 } ,DateOfCreation = DateTime.Now,DurationSong = "1:13"},
                       new Track(){Title = "В последний раз",Album = allAlbums[8],Artist =allArtists[8],Genre = allGenres[8],Mood =allMood[8] ,
                           TrackFile = new TrackFile{TrackLocation = "Some path" },TrackStatistics = new TrackStatistics{CountOfCalls = 0 } ,DateOfCreation = DateTime.Now,DurationSong = "1:13"},
                       new Track(){Title = "Девочка, танцуй",Album = allAlbums[9],Artist =allArtists[9],Genre = allGenres[9],Mood =allMood[9] ,
                           TrackFile = new TrackFile{TrackLocation = "Some path" },TrackStatistics = new TrackStatistics{CountOfCalls = 0 } ,DateOfCreation = DateTime.Now,DurationSong = "1:13"},
                       new Track(){Title = "Мир сошёл с ума",Album = allAlbums[10],Artist =allArtists[0],Genre = allGenres[10],Mood =allMood[0] ,
                           TrackFile = new TrackFile{TrackLocation = "Some path" },TrackStatistics = new TrackStatistics{CountOfCalls = 0 } ,DateOfCreation = DateTime.Now,DurationSong = "1:13"},
                       new Track(){Title = "В последнюю осень",Album = allAlbums[1],Artist =allArtists[1],Genre = allGenres[0],Mood =allMood[1] ,
                           TrackFile = new TrackFile{TrackLocation = "Some path" },TrackStatistics = new TrackStatistics{CountOfCalls = 0 } ,DateOfCreation = DateTime.Now,DurationSong = "1:13"},
                       new Track(){Title = "Положение",Album = allAlbums[2],Artist =allArtists[2],Genre = allGenres[2],Mood =allMood[2] ,
                           TrackFile = new TrackFile{TrackLocation = "Some path" },TrackStatistics = new TrackStatistics{CountOfCalls = 0 } ,DateOfCreation = DateTime.Now,DurationSong = "1:13"},
                       new Track(){Title = "Кукла колдуна",Album = allAlbums[3],Artist =allArtists[3],Genre = allGenres[1],Mood =allMood[3] ,
                           TrackFile = new TrackFile{TrackLocation = "Some path" },TrackStatistics = new TrackStatistics{CountOfCalls = 0 } ,DateOfCreation = DateTime.Now,DurationSong = "1:13"}

                    };
                    db.Set<Track>().AddRange(traks);
                    db.SaveChanges();
                }

                if (!db.Set<Playlist>().Any())
                {
                    var tracks = db.Set<Track>().ToList();//14
                    List<Playlist> playlists = new List<Playlist>()
                    {
                        new Playlist(){Title= "Плейлист 1",PlaylistImage = new PlaylistImage{Image = null},Tracks = new List<Track> {tracks[0],tracks[1],tracks[2] } },
                        new Playlist(){Title= "Плейлист 2",PlaylistImage = new PlaylistImage{Image = null},Tracks = new List<Track> {tracks[3],tracks[4],tracks[5] } },
                        new Playlist(){Title= "Плейлист 3",PlaylistImage = new PlaylistImage{Image = null},Tracks = new List<Track> {tracks[6],tracks[7],tracks[8] } },
                        new Playlist(){Title= "Плейлист 4",PlaylistImage = new PlaylistImage{Image = null},Tracks = new List<Track> {tracks[9],tracks[10],tracks[11] } },
                        new Playlist(){Title= "Плейлист 5",PlaylistImage = new PlaylistImage{Image = null},Tracks = new List<Track> {tracks[12],tracks[13],tracks[0] } },
                        new Playlist(){Title= "Плейлист 6",PlaylistImage = new PlaylistImage{Image = null},Tracks = new List<Track> {tracks[1],tracks[2],tracks[3] } },
                        new Playlist(){Title= "Плейлист 7",PlaylistImage = new PlaylistImage{Image = null},Tracks = new List<Track> {tracks[4],tracks[5],tracks[6] } },
                        new Playlist(){Title= "Плейлист 8",PlaylistImage = new PlaylistImage{Image = null},Tracks = new List<Track> {tracks[7],tracks[8],tracks[9] } },

                    };
                    db.Set<Playlist>().AddRange(playlists);
                    db.SaveChanges();

                }
            }

        }
    }
}
