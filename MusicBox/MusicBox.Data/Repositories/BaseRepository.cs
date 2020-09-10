using MusicBox.Domain.Repositories;
using MusicBox.Domain.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace MusicBox.Data.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private IUnitOfWork unitOfWork;

        public BaseRepository(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public T Get(object id)
        {
            return DbSet().Find(id);
        }

        public virtual int Count()
        {
            return DbSet().Count();
        }

        public virtual void Create(T item)
        {
            DbSet().Add(item);
        }

        public virtual void Delete(T item)
        {
            DbSet().Remove(item);
        }

        protected virtual IQueryable<T> GetAll()
        {
            return DbSet();
        }

        protected virtual IQueryable<T> GetItems()
        {
            return DbSet().AsQueryable();
        }

        private DbSet<T> DbSet()
        {
            return unitOfWork.Set<T>();
        }

        public void Update(T item)
        {
            throw new NotImplementedException();
        }
       
        IEnumerable<T> IBaseRepository<T>.GetAll()
        {
            throw new NotImplementedException();
        }
    }


}
