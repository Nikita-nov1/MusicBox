using MusicBox.Data.InitializersDb;
using MusicBox.Data.Migrations;
using System.Data.Entity;

namespace MusicBox.Data.Context
{
    public class MusicBoxDbContext : DbContext, IMusicBoxDbContext
    {
        public MusicBoxDbContext()
            : base("name=MusicBoxDb")
        {
            Database.SetInitializer(new MusicBoxDbContextDropCreateDatabaseIfModelChanges());  
        }
          
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.AddFromAssembly(GetType().Assembly);
        }
    }
}
