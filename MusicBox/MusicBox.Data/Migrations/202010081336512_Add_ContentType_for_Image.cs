namespace MusicBox.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_ContentType_for_Image : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AlbumImages", "ContentType", c => c.String(maxLength: 50));
            AddColumn("dbo.ArtistImages", "ContentType", c => c.String(maxLength: 50));
            AddColumn("dbo.GenreImages", "ContentType", c => c.String(maxLength: 50));
            AddColumn("dbo.MoodImages", "ContentType", c => c.String(maxLength: 50));
            AddColumn("dbo.PlaylistImages", "ContentType", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PlaylistImages", "ContentType");
            DropColumn("dbo.MoodImages", "ContentType");
            DropColumn("dbo.GenreImages", "ContentType");
            DropColumn("dbo.ArtistImages", "ContentType");
            DropColumn("dbo.AlbumImages", "ContentType");
        }
    }
}
