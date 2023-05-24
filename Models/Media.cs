using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Models
{
    public abstract class Media<T>
    {
        public string Url { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public int Frequency { get; set; }
        public List<T> Episodes { get; set; }

        public Media()
        {

        }
        public Media(string url, string name, string category, int frequency)
        {
            Url = url;
            Name = name;
            Category = category;
            Frequency = frequency;
            
        }
        public int EpisodeCount()
        {
            return Episodes.Count;
        }

        public virtual void DisplayInfo()
        {
            Console.WriteLine("this is a media");
        }
    }
}
