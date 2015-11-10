using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieShopDAL.Repository.iRepository
{
    public interface IRepository<T>
    {
        IEnumerable<T> ReadAll();

        T ReadById(int Id);

        T Add(T item);

        void Remove(T item);

        T Update(T item);
    }
}
