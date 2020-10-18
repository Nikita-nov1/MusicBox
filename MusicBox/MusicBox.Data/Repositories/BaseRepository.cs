using MusicBox.Domain.Repositories;
using MusicBox.Domain.UnitOfWork;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace MusicBox.Data.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly IUnitOfWork unitOfWork;

        public BaseRepository(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public virtual T Get(object id)
        {
            return DbSet().Find(id);
        }

        public virtual int Count()
        {
            return DbSet().Count();
        }

        public virtual void Add(T item)
        {
            DbSet().Add(item);
        }
        public virtual T AddWithEntityReturn(T item)
        {
            return DbSet().Add(item);
        }

        public virtual T Create()
        {
            return DbSet().Create();
        }


        public virtual void Delete(T item)
        {
            DbSet().Remove(item);
        }

        public virtual void DeleteById(object itemId)
        {
            Delete(Get(itemId));
        }

        public virtual List<T> GetAll()
        {
            return DbSet().ToList();
        }

        protected virtual IQueryable<T> GetQueryableItems()
        {
            return DbSet().AsQueryable();
        }

        protected virtual DbEntityEntry<T> Entry(T entry)
        {
            return unitOfWork.Entry<T>(entry);
        }

        private DbSet<T> DbSet()
        {
            return unitOfWork.Set<T>();
        }
    }


}
