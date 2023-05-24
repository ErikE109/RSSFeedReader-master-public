using BusinessLibrary.Controllers;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Policy;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BusinessLibrary
{
    public static class Validator
    {
       
        public static bool CheckIfTheInputIsEmpty(string text1, string text2, string text3, string text4)
        {
            if (string.IsNullOrWhiteSpace(text1) || string.IsNullOrWhiteSpace(text2) || string.IsNullOrWhiteSpace(text3) ||string.IsNullOrWhiteSpace(text4))

            {
                MessageBox.Show("A field is empty. Please make sure all fields contain a value and try again.");
                return false;
            }
            else
            {
                return true;
            }
        }
        public static bool CheckIfTheInputIsEmpty(string text)
        {
            if (string.IsNullOrWhiteSpace(text))

            {
                MessageBox.Show("You have not defined a name for your category, please try again");
                return false;
            }
            else
            {
                return true;
            }
        }

        public static bool CheckIfCategoryIsInList(string name, List<Category> list)
        {
            {
                foreach (var item in list)
                {
                    if (item.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
                    {
                        MessageBox.Show("There is already a category with that name in the list");
                        return false;
                    }
                }
            }
            return true;
        }

        public static bool CheckIfFeedIsInList(string name, string url, List<Feed> list)
        {
            bool result = true;

            
                List<string> nameList = list.Select(f => f.Name).ToList();

                List<string> urlList = list.Select(f => f.Url).ToList();

                    if (nameList.Contains(name) || urlList.Contains(url))
                    {
                        MessageBox.Show("There is already a feed with that name or Url in the list");
                        result = false;
                    }
                

            
            return result;
        }

        public static bool CheckIfFeedNameIsInList(string newName, string oldName, List<Feed> list)
        {
            bool result = true;

            List<string> names = list.Select(f => f.Name).ToList();

            if (!newName.Equals(oldName))
            {
               
                if(names.Contains(newName))
                {
                    MessageBox.Show("There is already a feed with that name in the list");
                    result = false;
                }
            }
            return result;
        }

        public static bool CheckIfListBoxIsNull(ListBox box)
        {
            bool result = true;
            if(box.SelectedItem == null)
            {
                MessageBox.Show("Please select a category and edit its name before Saving");
                result = false;
            }
            return result;
        }

        public static bool CheckIfFeedURLIsInList(string newURL, string oldURL, List<Feed> list)
        {
            bool result = true;

            List<string> urlList = list.Select(f => f.Url).ToList();

            if(!newURL.Equals(oldURL))
            {
                        if (urlList.Contains(newURL))
                        {
                            MessageBox.Show("There is already a feed with that URL in the list");
                            result = false;
                        }

            }
            return result;
        }


        public static string CleanUpTextRemoveHtml(string text)
        {
            string newText = Regex.Replace(text, "<.*?>", String.Empty);
            return newText;
        }

        public static bool CheckForValidUrl(string uriName)
        {
            Uri uriResult;
            bool result = Uri.TryCreate(uriName, UriKind.Absolute, out uriResult)
                && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);

            if (!result)
            {
                MessageBox.Show("URL is not valid. Please enter a RSS-link.");
            }
            return result;
        }

        public static bool CheckIfItemIsSelected(int itemIndex)
        {
            if (itemIndex > -1)
            {
                return true;
            }
            return false;
        }

    }

}
