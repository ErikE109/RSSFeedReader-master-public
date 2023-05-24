using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel.Syndication;
using System.Xml;
using Models;
using System.Xml.Serialization;

namespace DataLibrary
{
    internal class DataReader<T>
    {
        string summary;


        public DataReader()
        {

        }


            public async Task<List<Episode>> GetAllEpisodesAsync (Feed feed)
            {

                string Url = feed.Url;
                List<Episode> allEpisodes = new List<Episode>();

                    try
                    {

                   
           
                        using (XmlReader xmlReader = XmlReader.Create(Url))
                        {
                            SyndicationFeed feeder = await Task.Run (() => SyndicationFeed.Load(xmlReader));



                            foreach (var item in feeder.Items)
                            {

                              
                                    if (item.Summary == null || string.IsNullOrEmpty(item.Summary.Text))
                                    {
                                        summary = "Summary not available;";
                                    }
                                    else if (item.Summary != null)
                                    {
                                        summary = item.Summary.Text;
                                    }
                                    string title = item.Title.Text;
                                    string publishDate = item.PublishDate.ToString().Substring(0, 20);
                                    string link = item.Links[0].Uri.ToString();

                                    Episode episode = new Episode(title, summary, publishDate, item.Links[0].Uri.ToString());
                                    allEpisodes.Add(episode);


                            }

                            return allEpisodes;
                        }

                    }
                    catch (Exception)
                    {

                        throw new DataAccessException("Can't get all data from syndication");
                    }




        }





        }

    }
