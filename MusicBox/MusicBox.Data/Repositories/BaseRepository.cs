using MusicBox.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicBox.Data.Repositories
{
    public class BaseRepository : IBaseRepository
    {
        public int Get()
        {
            throw new NotImplementedException();
        }


        //IEnumerable<T> GetAll();
        //T Get(int id);
        //void Create(T item);
        //void Update(T item);
        //void Delete(int id);
    }

}
