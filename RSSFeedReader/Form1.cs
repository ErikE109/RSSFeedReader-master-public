using BusinessLibrary.Controllers;
using BusinessLibrary;
using Models;
using RSSFeedReader.Forms;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.ObjectiveC;
using System.Windows.Forms;
using System.Diagnostics;
using System.Windows.Documents;
using System.ComponentModel.Design;
using System.Windows.Controls;
using Button = System.Windows.Forms.Button;
using Control = System.Windows.Forms.Control;

namespace RSSFeedReader
{
    public partial class Form1 : Form
    {
        //Fields
        private Button currentButton;
        private FeedController feedController;
        CategoryController categoryController;
        private Episode currentEpisode;
        private Feed currentFeed;
        int timerCounter = 0;


        public Form1()
        {
            InitializeComponent();
            Font = new Font(Font.Name, 8.25f * 126f / CreateGraphics().DpiX, Font.Style, Font.Unit, Font.GdiCharSet, Font.GdiVerticalFont);
            feedController = new FeedController();
            categoryController = new CategoryController();
            feedController.UpdateAllEpisodeListsAsync();   

            /*Tanken är att denna metod ska köras när programmet 
             * startas för att se till vid uppstart så visas alla senaste episodes/items
            */
            
            feedController.FillDataGrid(dataGridView1);
            
            
            

            createCategoryButton();
        }

      
        public void SetSelectedFeed()
        {
            if (dataGridView1.CurrentRow != null)
            {
                string selectedItem = dataGridView1.CurrentRow.Cells["DgName"].Value.ToString();
                Feed feed = feedController.GetFeedByIndex(selectedItem);
                currentFeed = feed;
            }
        }

        public void FillOrUpdateEpisodeList(Feed feed)
        {
            if (feed != null)
            {
                flowLayoutPanel.Controls.Clear();
                List<Episode> episodes = feedController.GetFeedEpisodeList(feed);

                foreach (Episode episode in episodes)
                {
                    CustomListItem listItem = new CustomListItem(this);
                    listItem.Title = episode.EpisodeTitle;
                    listItem.PublishDate = episode.PublishDate;
                    listItem.EpisodeLink = episode.EpisodeLink;

                    flowLayoutPanel.Controls.Add(listItem);
                }
            }
        }


        public void SetSelectedEpisode(string title)
        {
            foreach( Episode episode in currentFeed.Episodes) 
            { 
            if(title == episode.EpisodeTitle)
                {
                    currentEpisode = episode;
                }
            }
        }


        public void ListItemOnClick(object sender, EventArgs e)
        {
            CustomListItem listItem = (CustomListItem)sender;
            Episode episode = null;
            foreach( Episode episodeByLink in currentFeed.Episodes) 
            {
                if (episodeByLink.EpisodeLink == listItem.EpisodeLink)
                    episode = episodeByLink;
            }

            summaryBox1.Title = Validator.CleanUpTextRemoveHtml(episode.EpisodeTitle);
            summaryBox1.PublishDate = episode.PublishDate;
            summaryBox1.Summary = Validator.CleanUpTextRemoveHtml(episode.Description);
            summaryBox1.ImageLink = episode.EpisodeLink;

            SetSelectedEpisode(listItem.Title);
        }


        private void newCategoryButton_Click(object sender, EventArgs e)
        {
            var formCategory = new FormCategory(this);
            formCategory.ShowDialog(this);
        }


        private void buttonAddNewFeed_Click(object sender, EventArgs e)
        {
            var formNewFeed = new FormNewFeed(dataGridView1, this);
            formNewFeed.ShowDialog(this);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {


                string selectedItem = dataGridView1.CurrentRow.Cells["DgName"].Value.ToString();

                var formEditFeed = new FormEditFeed(selectedItem, dataGridView1, this);

                formEditFeed.Show(this);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {


                feedController.DeleteFeed(dataGridView1.CurrentRow.Cells["DgName"].Value.ToString());
                feedController.UpdateDataGrid(dataGridView1);
                flowLayoutPanel.Controls.Clear();

                summaryBox1.Title = "";
                summaryBox1.PublishDate = "";
                summaryBox1.Summary = "";

                if (dataGridView1.Rows.Count == 0)
                {
                    currentFeed = null;
                }
            }
        }

        public void createCategoryButton()
        {
            panelCategoryButtons.Controls.Clear();
            int top = 0;
            int left = 0;
            foreach (Category item in categoryController.GetAllCategories())
            {
                if (item != null)
                {
                    Button newButton = new Button();
                    newButton.Text = item.Name;
                    newButton.Name = item.Name.ToLower() + "Button";
                    newButton.Top = top;
                    newButton.Left = left;
                    newButton.Size = new Size(224, 48);
                    newButton.TextAlign = ContentAlignment.MiddleCenter;
                    newButton.Dock = DockStyle.Top;
                    newButton.Location = new Point(0, top);
                    newButton.ForeColor = Color.Gainsboro;
                    newButton.FlatStyle = FlatStyle.Flat;
                    newButton.FlatAppearance.BorderSize = 0;
                    newButton.FlatAppearance.BorderColor = Color.FromArgb(51, 51, 76);
                    newButton.Click += new EventHandler(buttonFeedByCategory);
                    newButton.AutoSize = true;
                    panelCategoryButtons.Controls.Add(newButton);
                    top += newButton.Height + 2;

                }
            }
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();
        }


        private void buttonFeedByCategory(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            List<Feed> feedCategories = feedController.FilterFeedByCategory(btn.Text);
            feedController.FillDataGridByCategory(dataGridView1, feedCategories);
        }


        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            SetSelectedFeed();
            FillOrUpdateEpisodeList(currentFeed);
        }

        private async void timer1_Tick(object sender, EventArgs e)
        {
            timerCounter++;

            bool currentEpisodeWasUpdated = false;

            List<Feed> feedList = feedController.GetAllFeeds();
            foreach (Feed feed in feedList)
            { 
                if (timerCounter % feed.Frequency == 0)
                {
                    if (currentFeed != null && feed.Name == currentFeed.Name)
                    {
                        currentEpisodeWasUpdated = true;
                    }
                    
                    Task task = feedController.UpdateAnEpisodeListAsync(feed);
                    await task;

                    if (timerCounter == 11)
                    {
                        timerCounter = 1;
                    }
                }
                
            }
            if ((currentFeed != null) && (currentEpisodeWasUpdated))
            {
                    Feed updatedCurrentFeed = feedList.FirstOrDefault(f => f.Name.Equals(currentFeed.Name));
                    currentFeed = updatedCurrentFeed;
                    FillOrUpdateEpisodeList(currentFeed);
            }
        }
    

        private void buttonAllFeeds_Click(object sender, EventArgs e)
        {
            feedController.UpdateDataGrid(dataGridView1);
        }

    }
}