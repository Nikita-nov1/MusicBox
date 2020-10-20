namespace MusicBox.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixAlbumTitleIsNotUniqueMigration : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Albums", new[] { "Title" });
            CreateIndex("dbo.Albums", "Title");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Albums", new[] { "Title" });
            CreateIndex("dbo.Albums", "Title", unique: true);
        }
    }
}
