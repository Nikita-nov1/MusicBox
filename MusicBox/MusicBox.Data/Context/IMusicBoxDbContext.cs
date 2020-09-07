using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicBox.Data.Context
{
    public interface IMusicBoxDbContext
    {
        DbSet<TEntity> Set<TEntity>()
            where TEntity : class;

        int SaveChanges();
    }
}
