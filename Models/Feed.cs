using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Feed : Media<Episode>
    {


        public Feed() : base()
        {

        }
        public Feed(string url, string name, string category, int frequency) : base(url, name, category, frequency)    
        {
  
        }

        public override void DisplayInfo()
        {
            Console.WriteLine("This is a News Media type");
        }

     
    }

    
}
