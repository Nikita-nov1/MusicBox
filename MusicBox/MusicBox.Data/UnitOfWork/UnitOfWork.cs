using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using MusicBox.Data.Context;
using MusicBox.Domain.UnitOfWork;

namespace MusicBox.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IMusicBoxDbContext db;

        public UnitOfWork(IMusicBoxDbContext db)
        {
            this.db = db;
        }

        public DbSet<TEntity> Set<TEntity>()
            where TEntity : class
        {
            return db.Set<TEntity>();
        }

        public DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity)
            where TEntity : class
        {
            return db.Entry(entity);
        }

        public int SaveChanges()
        {
            return db.SaveChanges();
        }
    }
}
