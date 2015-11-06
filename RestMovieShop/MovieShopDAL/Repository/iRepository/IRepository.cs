using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieShopDAL.Repository.iRepository
{
    interface IRepository<T>
    {
        IEnumerable<T> ReadAll();

        T ReadById(int Id);

        void Add(T item);

        void Remove(T item);

        void Update(T item);
    }
}
