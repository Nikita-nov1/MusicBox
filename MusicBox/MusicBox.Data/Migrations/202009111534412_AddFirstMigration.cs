namespace MusicBox.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFirstMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Albums",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateOfCreation = c.DateTime(nullable: false),
                        Year = c.Short(),
                        Title = c.String(maxLength: 30),
                        AlbumImageId = c.Int(nullable: false),
                        ArtistId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AlbumImages", t => t.AlbumImageId, cascadeDelete: true)
                .ForeignKey("dbo.Artists", t => t.ArtistId)
                .Index(t => t.Title, unique: true)
                .Index(t => t.AlbumImageId)
                .Index(t => t.ArtistId);
            
            CreateTable(
                "dbo.AlbumImages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Image = c.Binary(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Artists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Full_Name = c.String(maxLength: 30),
                        ArtistImageId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ArtistImages", t => t.ArtistImageId, cascadeDelete: true)
                .Index(t => t.Full_Name, unique: true)
                .Index(t => t.ArtistImageId);
            
            CreateTable(
                "dbo.ArtistImages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Image = c.Binary(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tracks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateOfCreation = c.DateTime(),
                        DurationSong = c.String(maxLength: 10),
                        Title = c.String(nullable: false, maxLength: 30),
                        ArtistId = c.Int(nullable: false),
                        GenreId = c.Int(),
                        MoodId = c.Int(),
                        PlaylistId = c.Int(),
                        TrackFileId = c.Int(nullable: false),
                        TrackStatisticsId = c.Int(nullable: false),
                        AlbumId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Artists", t => t.ArtistId)
                .ForeignKey("dbo.Genres", t => t.GenreId)
                .ForeignKey("dbo.Moods", t => t.MoodId)
                .ForeignKey("dbo.Playlists", t => t.PlaylistId)
                .ForeignKey("dbo.TrackFiles", t => t.TrackFileId, cascadeDelete: true)
                .ForeignKey("dbo.TrackStatistics", t => t.TrackStatisticsId, cascadeDelete: true)
                .ForeignKey("dbo.Albums", t => t.AlbumId)
                .Index(t => t.ArtistId)
                .Index(t => t.GenreId)
                .Index(t => t.MoodId)
                .Index(t => t.PlaylistId)
                .Index(t => t.TrackFileId)
                .Index(t => t.TrackStatisticsId)
                .Index(t => t.AlbumId);
            
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 30),
                        GenreImageId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.GenreImages", t => t.GenreImageId, cascadeDelete: true)
                .Index(t => t.Title, unique: true)
                .Index(t => t.GenreImageId);
            
            CreateTable(
                "dbo.GenreImages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Image = c.Binary(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Moods",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 30),
                        MoodImageId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MoodImages", t => t.MoodImageId, cascadeDelete: true)
                .Index(t => t.Title, unique: true)
                .Index(t => t.MoodImageId);
            
            CreateTable(
                "dbo.MoodImages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Image = c.Binary(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Playlists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 30),
                        PlaylistImageId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PlaylistImages", t => t.PlaylistImageId, cascadeDelete: true)
                .Index(t => t.PlaylistImageId);
            
            CreateTable(
                "dbo.PlaylistImages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Image = c.Binary(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TrackFiles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TrackLocation = c.String(nullable: false, maxLength: 110),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TrackStatistics",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CountOfCalls = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tracks", "AlbumId", "dbo.Albums");
            DropForeignKey("dbo.Albums", "ArtistId", "dbo.Artists");
            DropForeignKey("dbo.Tracks", "TrackStatisticsId", "dbo.TrackStatistics");
            DropForeignKey("dbo.Tracks", "TrackFileId", "dbo.TrackFiles");
            DropForeignKey("dbo.Tracks", "PlaylistId", "dbo.Playlists");
            DropForeignKey("dbo.Playlists", "PlaylistImageId", "dbo.PlaylistImages");
            DropForeignKey("dbo.Tracks", "MoodId", "dbo.Moods");
            DropForeignKey("dbo.Moods", "MoodImageId", "dbo.MoodImages");
            DropForeignKey("dbo.Tracks", "GenreId", "dbo.Genres");
            DropForeignKey("dbo.Genres", "GenreImageId", "dbo.GenreImages");
            DropForeignKey("dbo.Tracks", "ArtistId", "dbo.Artists");
            DropForeignKey("dbo.Artists", "ArtistImageId", "dbo.ArtistImages");
            DropForeignKey("dbo.Albums", "AlbumImageId", "dbo.AlbumImages");
            DropIndex("dbo.Playlists", new[] { "PlaylistImageId" });
            DropIndex("dbo.Moods", new[] { "MoodImageId" });
            DropIndex("dbo.Moods", new[] { "Title" });
            DropIndex("dbo.Genres", new[] { "GenreImageId" });
            DropIndex("dbo.Genres", new[] { "Title" });
            DropIndex("dbo.Tracks", new[] { "AlbumId" });
            DropIndex("dbo.Tracks", new[] { "TrackStatisticsId" });
            DropIndex("dbo.Tracks", new[] { "TrackFileId" });
            DropIndex("dbo.Tracks", new[] { "PlaylistId" });
            DropIndex("dbo.Tracks", new[] { "MoodId" });
            DropIndex("dbo.Tracks", new[] { "GenreId" });
            DropIndex("dbo.Tracks", new[] { "ArtistId" });
            DropIndex("dbo.Artists", new[] { "ArtistImageId" });
            DropIndex("dbo.Artists", new[] { "Full_Name" });
            DropIndex("dbo.Albums", new[] { "ArtistId" });
            DropIndex("dbo.Albums", new[] { "AlbumImageId" });
            DropIndex("dbo.Albums", new[] { "Title" });
            DropTable("dbo.TrackStatistics");
            DropTable("dbo.TrackFiles");
            DropTable("dbo.PlaylistImages");
            DropTable("dbo.Playlists");
            DropTable("dbo.MoodImages");
            DropTable("dbo.Moods");
            DropTable("dbo.GenreImages");
            DropTable("dbo.Genres");
            DropTable("dbo.Tracks");
            DropTable("dbo.ArtistImages");
            DropTable("dbo.Artists");
            DropTable("dbo.AlbumImages");
            DropTable("dbo.Albums");
        }
    }
}
