using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary
{
    public class DataAccessException : Exception
    {
        public DataAccessException() : base("Can't access data")
        { 
        
        }
        public DataAccessException( string message): base(message)
        { }
    }
}
