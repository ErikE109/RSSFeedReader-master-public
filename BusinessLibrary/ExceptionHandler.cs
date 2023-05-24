using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel.Syndication;
using System.Xml;
using System.Diagnostics;

namespace BusinessLibrary
{

    public class ExceptionHandler : Exception
        {
            public ExceptionHandler()
            {

            }
            public bool ValidateRSS(string url)
            {
                try
                {
                    SyndicationFeed feed = SyndicationFeed.Load(XmlReader.Create(url));
                    foreach (SyndicationItem item in feed.Items)
                    {

                        Debug.Print(item.Title.Text);
                    }

                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"URL is not an RSS-feed \n{ex.Message}");
                    return false;
                }

            }
        }


    }


