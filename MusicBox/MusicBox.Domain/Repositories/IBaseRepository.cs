using System.Collections.Generic;

namespace MusicBox.Domain.Repositories
{
    public interface IBaseRepository<T> where T : class
    {
        int Count();

        void Create(T item);

        void Delete(T item);
        //void Delete(int id);

        void Update(T item);

        T Get(object id);

        IEnumerable<T> GetAll();

    }
}
