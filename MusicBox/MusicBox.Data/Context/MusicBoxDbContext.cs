using System.Data.Entity;

namespace MusicBox.Data.Context
{
    public class MusicBoxDbContext : DbContext, IMusicBoxDbContext
    {
        public MusicBoxDbContext()
            : base("name=connectionString")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.AddFromAssembly(GetType().Assembly);
        }
    }
}
