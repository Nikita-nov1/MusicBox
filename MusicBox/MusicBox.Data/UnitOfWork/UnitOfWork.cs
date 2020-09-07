using MusicBox.Data.Context;
using MusicBox.Domain.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicBox.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork//, IDisposable
    {
        private IMusicBoxDbContext db;
       
        public UnitOfWork(IMusicBoxDbContext db)
        {
            this.db = db;
        }

        public DbSet<TEntity> Set<TEntity>()
            where TEntity : class
        {
            return db.Set<TEntity>();
        }

        public int SaveChanges()
        {
            return db.SaveChanges();
        }

        //private bool disposed = false;

        //public virtual void Dispose(bool disposing)
        //{
        //    if (!this.disposed)
        //    {
        //        if (disposing)
        //        {
        //            db.Dispose();
        //        }
        //        this.disposed = true;
        //    }
        //}

        //public void Dispose()
        //{
        //    Dispose(true);
        //    GC.SuppressFinalize(this);
        //}
    }


    
}
