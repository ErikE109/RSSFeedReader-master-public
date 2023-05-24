using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataLibrary.FeedRepository;
using DataLibrary.Repository;
using Models;

namespace BusinessLibrary.Controllers
{
    public class FeedController
    {
        //Fields
        FeedRepository feedRepository;
        Feed feed;
        List<Episode> allEpisodes;

        public FeedController()
        {
            feedRepository = new FeedRepository();
        }


        public async Task CreateFeed(string url, string name, int frequency, string category, DataGridView dataGridView)
        {
            if (Validator.CheckForValidUrl(url)) {
                Feed newFeed = new Feed(url, name, category, frequency);
                allEpisodes = await feedRepository.GetAllEpisodesAsync(newFeed);
                newFeed.Episodes = allEpisodes;
                
                feedRepository.Add(newFeed);

                feedRepository.SaveChanges();

                 AddToDataGrid(dataGridView, newFeed);
            }
        }

        public async void UpdateAllEpisodeListsAsync()
        {
            Task task = feedRepository.UpdateAllEpisodesAsync();
            await task;
        }

        public async Task<Feed> UpdateAnEpisodeListAsync(Feed feed)
        {
            
                List<Episode> episodeList = await feedRepository.GetAllEpisodesAsync(feed);
                feed.Episodes = episodeList;
            

            feedRepository.Update(feed, feedRepository.GetIndex(feed.Name));
            return feed;
        }

        public void SetFeedEpisodeList(Feed selectedFeed)
        {
            allEpisodes = selectedFeed.Episodes;
        }

        public List<Episode> GetFeedEpisodeList(Feed selectedFeed)
        {
            SetFeedEpisodeList(selectedFeed);
            return allEpisodes;
        }

        public void DeleteFeed(string name)
        {
            int index = feedRepository.GetIndex(name);
            feedRepository.Delete(index);
        }


        public List<Feed> GetAllFeeds()
        {
            return feedRepository.GetAll();
        }


        public async Task UpdateFeed(Feed newFeed, Feed oldFeed)
        {
      
            int index = feedRepository.GetIndex(oldFeed.Name);
            List<Episode> episodes = await feedRepository.GetAllEpisodesAsync(newFeed);
            newFeed.Episodes = episodes;
            feedRepository.Update(newFeed, index);
            
        }



        public Feed GetFeedByIndex(string name)
        {
            List<Feed> feedList = GetAllFeeds();
            int index = feedRepository.GetIndex(name);

            return feedList[index];
        }


        public void FillDataGridByCategory(DataGridView dataGridView, List<Feed> feedCategories)
        {
            dataGridView.Rows.Clear();

            if (feedCategories != null)
            {
                foreach (Feed feed in feedCategories)
                {
                    var feedData = GetFeedGridData(feed);
                    dataGridView.Rows.Add(feedData);
                }
                dataGridView.ClearSelection();
            }

        }

        public void FillDataGrid(DataGridView dataGridView)
        {
            
            List<Feed> feedList = GetAllFeeds();
            if (feedList != null)
            {
                foreach (Feed feed in feedList)
                {
                    var feedData = GetFeedGridData(feed);
                    dataGridView.Rows.Add(feedData);
                }
                dataGridView.ClearSelection();
            }  
        }

        public List<Feed> FilterFeedByCategory(string category)
        {
            List<Feed> filteredFeedList = (List<Feed>)GetAllFeeds().Where(feed => feed.Category.Equals(category)).ToList(); 
            return filteredFeedList;
        }

        public void UpdateDataGrid(DataGridView dataGridView)
        {
            dataGridView.Rows.Clear();
            FillDataGrid(dataGridView);
        }


        public void AddToDataGrid(DataGridView dataGridView, Feed feed)
        {
            dataGridView.Rows.Add(GetFeedGridData(feed));
        }

        public string[] GetFeedGridData(Feed feed)
        {
            string episodes = feed.EpisodeCount().ToString();
            string name = feed.Name;
            string frequency = feed.Frequency.ToString() + " min";
            string category = feed.Category;

            string[] feedData = new string[] { episodes, name, frequency, category };

            return feedData;
        }


        public void FillComboBoxFrequency(ComboBox comboBox)
        {
            List<string> frequencyList = new List<string>() { "2 min", "5 min", "10 min" };

            foreach (var item in frequencyList)
            {
                comboBox.Items.Add(item);
            }


        }
    }
}
