namespace MusicBox.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MusicBox.Data.Context.MusicBoxDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(MusicBox.Data.Context.MusicBoxDbContext context)
        {
            
        }
    }
}
