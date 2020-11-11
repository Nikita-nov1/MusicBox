namespace MusicBox.Data.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class FixUserPlaylists : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Playlists", "User_Id", "dbo.Users");
            DropIndex("dbo.Playlists", new[] { "User_Id" });
            CreateTable(
                "dbo.UserPlaylists",
                c => new
                {
                    UserId = c.String(nullable: false, maxLength: 128),
                    PlaylistId = c.Int(nullable: false),
                })
                .PrimaryKey(t => new { t.UserId, t.PlaylistId })
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.Playlists", t => t.PlaylistId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.PlaylistId);

            DropColumn("dbo.Playlists", "User_Id");
        }

        public override void Down()
        {
            AddColumn("dbo.Playlists", "User_Id", c => c.String(maxLength: 128));
            DropForeignKey("dbo.UserPlaylists", "PlaylistId", "dbo.Playlists");
            DropForeignKey("dbo.UserPlaylists", "UserId", "dbo.Users");
            DropIndex("dbo.UserPlaylists", new[] { "PlaylistId" });
            DropIndex("dbo.UserPlaylists", new[] { "UserId" });
            DropTable("dbo.UserPlaylists");
            CreateIndex("dbo.Playlists", "User_Id");
            AddForeignKey("dbo.Playlists", "User_Id", "dbo.Users", "Id");
        }
    }
}
