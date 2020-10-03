using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace MusicBox.Data.Context
{
    public interface IMusicBoxDbContext
    {
        DbSet<TEntity> Set<TEntity>()
            where TEntity : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity)
            where TEntity : class;

        int SaveChanges();
    }
}
