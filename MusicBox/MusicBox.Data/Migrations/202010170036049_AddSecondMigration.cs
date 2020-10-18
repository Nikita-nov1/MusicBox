namespace MusicBox.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSecondMigration : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.TrackFiles", "TrackLocation", c => c.String(nullable: false, maxLength: 200));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TrackFiles", "TrackLocation", c => c.String(nullable: false, maxLength: 110));
        }
    }
}
