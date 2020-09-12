namespace MusicBox.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddManyToManyForTreksPlaylist : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tracks", "PlaylistId", "dbo.Playlists");
            DropIndex("dbo.Tracks", new[] { "PlaylistId" });
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
            
            DropColumn("dbo.Tracks", "PlaylistId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tracks", "PlaylistId", c => c.Int());
            DropForeignKey("dbo.TrackPlaylists", "PlaylistId", "dbo.Tracks");
            DropForeignKey("dbo.TrackPlaylists", "TrackId", "dbo.Playlists");
            DropIndex("dbo.TrackPlaylists", new[] { "PlaylistId" });
            DropIndex("dbo.TrackPlaylists", new[] { "TrackId" });
            DropTable("dbo.TrackPlaylists");
            CreateIndex("dbo.Tracks", "PlaylistId");
            AddForeignKey("dbo.Tracks", "PlaylistId", "dbo.Playlists", "Id");
        }
    }
}
