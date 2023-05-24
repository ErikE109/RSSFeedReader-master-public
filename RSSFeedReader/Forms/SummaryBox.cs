using BusinessLibrary;
using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RSSFeedReader.Forms
{
    public partial class SummaryBox : UserControl
    {
        //Fields
        private string title;
        private string publishDate;
        private string summary;
        private string imageLink;

        public SummaryBox()
        {
            InitializeComponent();
        }

    public void ListItemOnClick(object sender, EventArgs e, Episode episode)
    {
        this.Title = Validator.CleanUpTextRemoveHtml(episode.EpisodeTitle);
        this.PublishDate = episode.PublishDate;
        this.Summary = Validator.CleanUpTextRemoveHtml(episode.Description);
        this.imageLink = episode.EpisodeLink;
    }

    public string ImgLink 
        {
         get { return imgLink.Name; }
        }

    public string ImageLink
        {
         get { return imageLink; }
         set { imageLink = value;}
        }

    public string Title
    {
        get { return title; }
        set { title = value; lblTitle.Text = value; }
    }

    public string PublishDate
    {
        get { return publishDate; }
        set { publishDate = value; lblPublishDate.Text = value; }
    }

    public string Summary
    {
        get { return summary; }
        set { summary = value; textBoxSummary.Text = value; }
    }

        private void imgLink_MouseClick(object sender, MouseEventArgs e)
        {
            if (Title != null)
            {
                Process.Start(new ProcessStartInfo(ImageLink) { UseShellExecute = true, Verb = "open" });
            }
            
        }

    }
}
