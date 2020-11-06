using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using MusicBox.Domain.Models.Entities.Identity;

namespace MusicBox.Data.Context
{
    public class MusicBoxDbContext : IdentityDbContext<User>, IMusicBoxDbContext
    {
        public MusicBoxDbContext()
            : base("name=MusicBoxDb")
        {
            Database.SetInitializer<MusicBoxDbContext>(null);
        }

        public static MusicBoxDbContext Create()
        {
            return new MusicBoxDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.AddFromAssembly(GetType().Assembly);
        }
    }
}
