using MusicBox.Data.InitializersDb;
//using MusicBox.Data.Migrations;
using System.Data.Entity;
using System;
using System.Diagnostics;

namespace MusicBox.Data.Context
{
    public class MusicBoxDbContext : DbContext, IMusicBoxDbContext
    {
    
        public MusicBoxDbContext()
            : base("name=MusicBoxDb")
        {
            Debug.WriteLine("---------1---");
            //Database.SetInitializer<MusicBoxDbContext>(new MusicBoxDbContextDropCreateDatabaseAlways());

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.AddFromAssembly(GetType().Assembly);
        }
    }
}
