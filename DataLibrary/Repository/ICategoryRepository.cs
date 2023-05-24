using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Repository
{
    public interface ICategoryRepository<T>: IRepository<T> where T : class
    {
        T GetByName(string name);
        int GetIndex(string name);
        List<T> GetAll();
    }
}
