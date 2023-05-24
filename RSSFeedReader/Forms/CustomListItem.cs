using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RSSFeedReader.Forms
{
    public partial class CustomListItem : UserControl
    {
        //Fields
        private string title;
        private string publishDate;
        private string episodeLink;
        

        public CustomListItem(Form1 form)
        {
            InitializeComponent();
            this.lblTitle.Click += (sender, e) => form.ListItemOnClick(this, e);
        }

        public string Title
        {
            get { return title; }
            set { title = value; lblTitle.Text = value; }
        }

        public string PublishDate
        {
            get { return publishDate; }
            set { publishDate = value; lblDate.Text = value; }
        }

        public string EpisodeLink
        {
            get { return episodeLink; }
            set { episodeLink = value;  }
        }

    }
}
