namespace MusicBox.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigration : DbMigration
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
                        ArtistId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Artists", t => t.ArtistId)
                .Index(t => t.Title, unique: true)
                .Index(t => t.ArtistId);
            
            CreateTable(
                "dbo.AlbumImages",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Image = c.Binary(),
                        ContentType = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Albums", t => t.Id, cascadeDelete: true)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Artists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Full_Name = c.String(maxLength: 30),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Full_Name, unique: true);
            
            CreateTable(
                "dbo.ArtistImages",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Image = c.Binary(),
                        ContentType = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Artists", t => t.Id, cascadeDelete: true)
                .Index(t => t.Id);
            
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
                        TrackFileId = c.Int(nullable: false),
                        TrackStatisticsId = c.Int(nullable: false),
                        AlbumId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Artists", t => t.ArtistId)
                .ForeignKey("dbo.Genres", t => t.GenreId)
                .ForeignKey("dbo.Moods", t => t.MoodId)
                .ForeignKey("dbo.TrackFiles", t => t.TrackFileId, cascadeDelete: true)
                .ForeignKey("dbo.TrackStatistics", t => t.TrackStatisticsId, cascadeDelete: true)
                .ForeignKey("dbo.Albums", t => t.AlbumId)
                .Index(t => t.ArtistId)
                .Index(t => t.GenreId)
                .Index(t => t.MoodId)
                .Index(t => t.TrackFileId)
                .Index(t => t.TrackStatisticsId)
                .Index(t => t.AlbumId);
            
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 30),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Title, unique: true);
            
            CreateTable(
                "dbo.GenreImages",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Image = c.Binary(),
                        ContentType = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Genres", t => t.Id, cascadeDelete: true)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Moods",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 30),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Title, unique: true);
            
            CreateTable(
                "dbo.MoodImages",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Image = c.Binary(),
                        ContentType = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Moods", t => t.Id, cascadeDelete: true)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Playlists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PlaylistImages",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Image = c.Binary(),
                        ContentType = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Playlists", t => t.Id, cascadeDelete: true)
                .Index(t => t.Id);
            
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
            
            CreateTable(
                "dbo.TrackPlaylists",
                c => new
                    {
                        TrackId = c.Int(nullable: false),
                        PlaylistId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.TrackId, t.PlaylistId })
                .ForeignKey("dbo.Playlists", t => t.TrackId, cascadeDelete: true)
                .ForeignKey("dbo.Tracks", t => t.PlaylistId, cascadeDelete: true)
                .Index(t => t.TrackId)
                .Index(t => t.PlaylistId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tracks", "AlbumId", "dbo.Albums");
            DropForeignKey("dbo.Albums", "ArtistId", "dbo.Artists");
            DropForeignKey("dbo.Tracks", "TrackStatisticsId", "dbo.TrackStatistics");
            DropForeignKey("dbo.Tracks", "TrackFileId", "dbo.TrackFiles");
            DropForeignKey("dbo.TrackPlaylists", "PlaylistId", "dbo.Tracks");
            DropForeignKey("dbo.TrackPlaylists", "TrackId", "dbo.Playlists");
            DropForeignKey("dbo.PlaylistImages", "Id", "dbo.Playlists");
            DropForeignKey("dbo.Tracks", "MoodId", "dbo.Moods");
            DropForeignKey("dbo.MoodImages", "Id", "dbo.Moods");
            DropForeignKey("dbo.Tracks", "GenreId", "dbo.Genres");
            DropForeignKey("dbo.GenreImages", "Id", "dbo.Genres");
            DropForeignKey("dbo.Tracks", "ArtistId", "dbo.Artists");
            DropForeignKey("dbo.ArtistImages", "Id", "dbo.Artists");
            DropForeignKey("dbo.AlbumImages", "Id", "dbo.Albums");
            DropIndex("dbo.TrackPlaylists", new[] { "PlaylistId" });
            DropIndex("dbo.TrackPlaylists", new[] { "TrackId" });
            DropIndex("dbo.PlaylistImages", new[] { "Id" });
            DropIndex("dbo.MoodImages", new[] { "Id" });
            DropIndex("dbo.Moods", new[] { "Title" });
            DropIndex("dbo.GenreImages", new[] { "Id" });
            DropIndex("dbo.Genres", new[] { "Title" });
            DropIndex("dbo.Tracks", new[] { "AlbumId" });
            DropIndex("dbo.Tracks", new[] { "TrackStatisticsId" });
            DropIndex("dbo.Tracks", new[] { "TrackFileId" });
            DropIndex("dbo.Tracks", new[] { "MoodId" });
            DropIndex("dbo.Tracks", new[] { "GenreId" });
            DropIndex("dbo.Tracks", new[] { "ArtistId" });
            DropIndex("dbo.ArtistImages", new[] { "Id" });
            DropIndex("dbo.Artists", new[] { "Full_Name" });
            DropIndex("dbo.AlbumImages", new[] { "Id" });
            DropIndex("dbo.Albums", new[] { "ArtistId" });
            DropIndex("dbo.Albums", new[] { "Title" });
            DropTable("dbo.TrackPlaylists");
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
