namespace MusicBox.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFirstMigration1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Albums",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateOfCreation = c.DateTime(nullable: false),
                        Year = c.DateTime(nullable: false),
                        Title = c.String(),
                        AlbumImageId = c.Int(nullable: false),
                        ArtistId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AlbumImage", t => t.AlbumImageId, cascadeDelete: true)
                .ForeignKey("dbo.Artists", t => t.ArtistId)
                .Index(t => t.AlbumImageId)
                .Index(t => t.ArtistId);
            
            CreateTable(
                "dbo.AlbumImage",
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
                        Title = c.String(),
                        ArtistImageId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ArtistImage", t => t.ArtistImageId, cascadeDelete: true)
                .Index(t => t.ArtistImageId);
            
            CreateTable(
                "dbo.ArtistImage",
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
                        DateOfCreation = c.DateTime(nullable: false),
                        DurationSong = c.String(),
                        Title = c.String(),
                        ArtistId = c.Int(nullable: false),
                        TrackFileId = c.Int(nullable: false),
                        TrackStatisticsId = c.Int(nullable: false),
                        AlbumId = c.Int(),
                        Genre_Id = c.Int(),
                        Mood_Id = c.Int(),
                        Playlist_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Artists", t => t.ArtistId)
                .ForeignKey("dbo.TrackFile", t => t.TrackFileId, cascadeDelete: true)
                .ForeignKey("dbo.TrackStatistics", t => t.TrackStatisticsId, cascadeDelete: true)
                .ForeignKey("dbo.Albums", t => t.AlbumId)
                .ForeignKey("dbo.Genres", t => t.Genre_Id)
                .ForeignKey("dbo.Moods", t => t.Mood_Id)
                .ForeignKey("dbo.Playlists", t => t.Playlist_Id)
                .Index(t => t.ArtistId)
                .Index(t => t.TrackFileId)
                .Index(t => t.TrackStatisticsId)
                .Index(t => t.AlbumId)
                .Index(t => t.Genre_Id)
                .Index(t => t.Mood_Id)
                .Index(t => t.Playlist_Id);
            
            CreateTable(
                "dbo.TrackFile",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TrackLocation = c.String(),
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
            
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Image = c.Binary(),
                        Image1 = c.Binary(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Moods",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Playlists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Image = c.Binary(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tracks", "Playlist_Id", "dbo.Playlists");
            DropForeignKey("dbo.Tracks", "Mood_Id", "dbo.Moods");
            DropForeignKey("dbo.Tracks", "Genre_Id", "dbo.Genres");
            DropForeignKey("dbo.Tracks", "AlbumId", "dbo.Albums");
            DropForeignKey("dbo.Albums", "ArtistId", "dbo.Artists");
            DropForeignKey("dbo.Tracks", "TrackStatisticsId", "dbo.TrackStatistics");
            DropForeignKey("dbo.Tracks", "TrackFileId", "dbo.TrackFile");
            DropForeignKey("dbo.Tracks", "ArtistId", "dbo.Artists");
            DropForeignKey("dbo.Artists", "ArtistImageId", "dbo.ArtistImage");
            DropForeignKey("dbo.Albums", "AlbumImageId", "dbo.AlbumImage");
            DropIndex("dbo.Tracks", new[] { "Playlist_Id" });
            DropIndex("dbo.Tracks", new[] { "Mood_Id" });
            DropIndex("dbo.Tracks", new[] { "Genre_Id" });
            DropIndex("dbo.Tracks", new[] { "AlbumId" });
            DropIndex("dbo.Tracks", new[] { "TrackStatisticsId" });
            DropIndex("dbo.Tracks", new[] { "TrackFileId" });
            DropIndex("dbo.Tracks", new[] { "ArtistId" });
            DropIndex("dbo.Artists", new[] { "ArtistImageId" });
            DropIndex("dbo.Albums", new[] { "ArtistId" });
            DropIndex("dbo.Albums", new[] { "AlbumImageId" });
            DropTable("dbo.Playlists");
            DropTable("dbo.Moods");
            DropTable("dbo.Genres");
            DropTable("dbo.TrackStatistics");
            DropTable("dbo.TrackFile");
            DropTable("dbo.Tracks");
            DropTable("dbo.ArtistImage");
            DropTable("dbo.Artists");
            DropTable("dbo.AlbumImage");
            DropTable("dbo.Albums");
        }
    }
}
