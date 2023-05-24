using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Episode
    {
        public string EpisodeTitle { get; set; }

        public string Description { get; set; }

        public string PublishDate { get; set; } 

        public string EpisodeLink { get; set; }
        public Episode()
        {
        }
        public Episode(string title, string summary, string publishDate, string link)
        {
            EpisodeTitle = title;
            Description = summary;
            PublishDate = publishDate;
            EpisodeLink = link;

        }
    }

    

}
