using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
