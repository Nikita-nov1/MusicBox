using MusicBox.Data.Context;
using MusicBox.Domain.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            return db.Entry<TEntity>(entity);
        }

        public int SaveChanges()
        {
            return db.SaveChanges();
        }

    }
}


