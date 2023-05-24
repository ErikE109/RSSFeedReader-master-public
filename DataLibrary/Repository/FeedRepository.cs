using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLibrary.Repository;
using Models;

namespace DataLibrary.FeedRepository
{
    public class FeedRepository : IFeedRepository<Feed>
        
    {
        //Fields
        DataManager<Feed> dataManager;
        List<Feed> feedList;
        List<Episode> episodeList;
        DataReader<Episode> dataReader;

        public string Url{ get; set; }  

        public FeedRepository()
        {
            Url = null;
            feedList = new List<Feed>();
            episodeList = new List<Episode>();
            dataManager = new DataManager<Feed>(nameof(feedList)+".xml");
            dataReader = new DataReader<Episode>();
            feedList = GetAll();
        }

        public void Add(Feed entity)
        {
            if(feedList == null)
            {
                feedList = new List<Feed>();
            }
            feedList.Add(entity);
            SaveChanges();
        }

        public void Delete(int index)
        {
            feedList = GetAll();
            feedList.RemoveAt(index);
            SaveChanges();
        }


        public List<Feed> GetAll()
        {
            List<Feed> feedListFromXML = new List<Feed>();
            feedListFromXML = dataManager.GetData();
            return feedListFromXML;
        }

        
        public async Task UpdateAllEpisodesAsync()
        {
            
            foreach (var item in feedList)
            {
                item.Episodes = await GetAllEpisodesAsync(item);
                
            }
            SaveChanges();

        }

        public async Task<List<Episode>> GetAllEpisodesAsync(Feed feed)
        {
            try
            {
                feed.Episodes = await dataReader.GetAllEpisodesAsync(feed);
            }
            catch (Exception)
            {
                throw new DataAccessException("Cant get all data from syndication");
            }
            return feed.Episodes;
        }


        public int GetEpisodeIndexLink(string link, Feed feed)
        {
            return feed.Episodes.FindIndex(e => e.EpisodeLink.Equals(link));
        }


        public void Update(Feed newFeed, int index)
        {
            feedList = GetAll();
            feedList[index] = newFeed;
            SaveChanges();
        }

        public void SaveChanges()
        {
            dataManager.SaveAllData(feedList);
        }


        public int GetIndex(string name)
        {
            return GetAll().FindIndex(e => e.Name.Equals(name));
        }

        public int GetIndexCategory(string categoryName)
        {
            return GetAll().FindIndex(e => e.Category.Equals(categoryName));
        }
    }
}