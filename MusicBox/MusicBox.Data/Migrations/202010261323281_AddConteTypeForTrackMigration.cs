namespace MusicBox.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddConteTypeForTrackMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TrackFiles", "ContentType", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TrackFiles", "ContentType");
        }
    }
}
