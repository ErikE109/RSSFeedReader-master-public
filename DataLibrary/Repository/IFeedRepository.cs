using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace DataLibrary.Repository
{
    public interface IFeedRepository<T>: IRepository<T> where T : class
    {
        public int GetIndex(string name);
        public List<Feed> GetAll();
    }
}
