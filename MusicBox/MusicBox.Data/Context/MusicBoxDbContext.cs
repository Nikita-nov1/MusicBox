using Microsoft.AspNet.Identity.EntityFramework;
using MusicBox.Domain.Models.Entities.Identity;
using System.Data.Entity;

namespace MusicBox.Data.Context
{
    public class MusicBoxDbContext : IdentityDbContext<User>, IMusicBoxDbContext
    {
        public static MusicBoxDbContext Create()
        {
            return new MusicBoxDbContext();
        }
        public MusicBoxDbContext()
            : base("name=MusicBoxDb")
        {
            Database.SetInitializer<MusicBoxDbContext>(null);

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.AddFromAssembly(GetType().Assembly);
        }
    }
}
