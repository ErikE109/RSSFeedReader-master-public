using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Repository
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);

        void Update(T entity, int index);

        void Delete(int index);

        void SaveChanges();

    }
}
