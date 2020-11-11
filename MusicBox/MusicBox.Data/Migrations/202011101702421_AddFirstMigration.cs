namespace MusicBox.Data.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddFirstMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                {
                    Id = c.String(nullable: false, maxLength: 128),
                    Name = c.String(nullable: false, maxLength: 256),
                    Description = c.String(maxLength: 126),
                    Discriminator = c.String(nullable: false, maxLength: 128),
                })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");

            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                {
                    UserId = c.String(nullable: false, maxLength: 128),
                    RoleId = c.String(nullable: false, maxLength: 128),
                })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);

            CreateTable(
                "dbo.Users",
                c => new
                {
                    Id = c.String(nullable: false, maxLength: 128),
                    FirstName = c.String(nullable: false, maxLength: 25),
                    LastName = c.String(nullable: false, maxLength: 25),
                    DateBorn = c.DateTime(storeType: "date"),
                    Email = c.String(),
                    EmailConfirmed = c.Boolean(nullable: false),
                    PasswordHash = c.String(),
                    SecurityStamp = c.String(),
                    PhoneNumber = c.String(),
                    PhoneNumberConfirmed = c.Boolean(nullable: false),
                    TwoFactorEnabled = c.Boolean(nullable: false),
                    LockoutEndDateUtc = c.DateTime(),
                    LockoutEnabled = c.Boolean(nullable: false),
                    AccessFailedCount = c.Int(nullable: false),
                    UserName = c.String(),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    UserId = c.String(maxLength: 128),
                    ClaimType = c.String(),
                    ClaimValue = c.String(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId);

            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                {
                    LoginProvider = c.String(nullable: false, maxLength: 128),
                    ProviderKey = c.String(nullable: false, maxLength: 128),
                    UserId = c.String(nullable: false, maxLength: 128),
                })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);

            CreateTable(
                "dbo.Playlists",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Title = c.String(nullable: false, maxLength: 30),
                    User_Id = c.String(maxLength: 128),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.User_Id);

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
                "dbo.Tracks",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    DateOfCreation = c.DateTime(),
                    DurationSong = c.String(maxLength: 10),
                    Title = c.String(nullable: false, maxLength: 30),
                    AlbumId = c.Int(),
                    ArtistId = c.Int(nullable: false),
                    GenreId = c.Int(),
                    MoodId = c.Int(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Albums", t => t.AlbumId)
                .ForeignKey("dbo.Artists", t => t.ArtistId, cascadeDelete: true)
                .ForeignKey("dbo.Genres", t => t.GenreId)
                .ForeignKey("dbo.Moods", t => t.MoodId)
                .Index(t => t.AlbumId)
                .Index(t => t.ArtistId)
                .Index(t => t.GenreId)
                .Index(t => t.MoodId);

            CreateTable(
                "dbo.Albums",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    DateOfCreation = c.DateTime(nullable: false),
                    Year = c.Short(),
                    Title = c.String(nullable: false, maxLength: 30),
                    ArtistId = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Artists", t => t.ArtistId, cascadeDelete: true)
                .Index(t => t.Title)
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
                    Full_Name = c.String(nullable: false, maxLength: 30),
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
                "dbo.TrackFiles",
                c => new
                {
                    Id = c.Int(nullable: false),
                    ContentType = c.String(nullable: false, maxLength: 50),
                    TrackLocation = c.String(nullable: false, maxLength: 200),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tracks", t => t.Id, cascadeDelete: true)
                .Index(t => t.Id);

            CreateTable(
                "dbo.TrackStatistics",
                c => new
                {
                    Id = c.Int(nullable: false),
                    CountOfCalls = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tracks", t => t.Id, cascadeDelete: true)
                .Index(t => t.Id);

            CreateTable(
                "dbo.UserImages",
                c => new
                {
                    Id = c.String(nullable: false, maxLength: 128),
                    Image = c.Binary(),
                    ContentType = c.String(maxLength: 50),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Id, cascadeDelete: true)
                .Index(t => t.Id);

            CreateTable(
                "dbo.TrackPlaylists",
                c => new
                {
                    PlaylistId = c.Int(nullable: false),
                    TrackId = c.Int(nullable: false),
                })
                .PrimaryKey(t => new { t.PlaylistId, t.TrackId })
                .ForeignKey("dbo.Playlists", t => t.PlaylistId, cascadeDelete: true)
                .ForeignKey("dbo.Tracks", t => t.TrackId, cascadeDelete: true)
                .Index(t => t.PlaylistId)
                .Index(t => t.TrackId);
        }

        public override void Down()
        {
            DropForeignKey("dbo.UserImages", "Id", "dbo.Users");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.Users");
            DropForeignKey("dbo.Playlists", "User_Id", "dbo.Users");
            DropForeignKey("dbo.TrackPlaylists", "TrackId", "dbo.Tracks");
            DropForeignKey("dbo.TrackPlaylists", "PlaylistId", "dbo.Playlists");
            DropForeignKey("dbo.TrackStatistics", "Id", "dbo.Tracks");
            DropForeignKey("dbo.TrackFiles", "Id", "dbo.Tracks");
            DropForeignKey("dbo.Tracks", "MoodId", "dbo.Moods");
            DropForeignKey("dbo.MoodImages", "Id", "dbo.Moods");
            DropForeignKey("dbo.Tracks", "GenreId", "dbo.Genres");
            DropForeignKey("dbo.GenreImages", "Id", "dbo.Genres");
            DropForeignKey("dbo.Tracks", "ArtistId", "dbo.Artists");
            DropForeignKey("dbo.Tracks", "AlbumId", "dbo.Albums");
            DropForeignKey("dbo.Albums", "ArtistId", "dbo.Artists");
            DropForeignKey("dbo.ArtistImages", "Id", "dbo.Artists");
            DropForeignKey("dbo.AlbumImages", "Id", "dbo.Albums");
            DropForeignKey("dbo.PlaylistImages", "Id", "dbo.Playlists");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.Users");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.Users");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropIndex("dbo.TrackPlaylists", new[] { "TrackId" });
            DropIndex("dbo.TrackPlaylists", new[] { "PlaylistId" });
            DropIndex("dbo.UserImages", new[] { "Id" });
            DropIndex("dbo.TrackStatistics", new[] { "Id" });
            DropIndex("dbo.TrackFiles", new[] { "Id" });
            DropIndex("dbo.MoodImages", new[] { "Id" });
            DropIndex("dbo.Moods", new[] { "Title" });
            DropIndex("dbo.GenreImages", new[] { "Id" });
            DropIndex("dbo.Genres", new[] { "Title" });
            DropIndex("dbo.ArtistImages", new[] { "Id" });
            DropIndex("dbo.Artists", new[] { "Full_Name" });
            DropIndex("dbo.AlbumImages", new[] { "Id" });
            DropIndex("dbo.Albums", new[] { "ArtistId" });
            DropIndex("dbo.Albums", new[] { "Title" });
            DropIndex("dbo.Tracks", new[] { "MoodId" });
            DropIndex("dbo.Tracks", new[] { "GenreId" });
            DropIndex("dbo.Tracks", new[] { "ArtistId" });
            DropIndex("dbo.Tracks", new[] { "AlbumId" });
            DropIndex("dbo.PlaylistImages", new[] { "Id" });
            DropIndex("dbo.Playlists", new[] { "User_Id" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropTable("dbo.TrackPlaylists");
            DropTable("dbo.UserImages");
            DropTable("dbo.TrackStatistics");
            DropTable("dbo.TrackFiles");
            DropTable("dbo.MoodImages");
            DropTable("dbo.Moods");
            DropTable("dbo.GenreImages");
            DropTable("dbo.Genres");
            DropTable("dbo.ArtistImages");
            DropTable("dbo.Artists");
            DropTable("dbo.AlbumImages");
            DropTable("dbo.Albums");
            DropTable("dbo.Tracks");
            DropTable("dbo.PlaylistImages");
            DropTable("dbo.Playlists");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.Users");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
        }
    }
}
