using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicBox.Domain.Repositories
{
    public interface IBaseRepository
    {
        int Get();

        //IEnumerable<T> GetAll();
        //T Get(int id);
        //void Create(T item);
        //void Update(T item);
        //void Delete(int id);
    }
}
