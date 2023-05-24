using DataLibrary.FeedRepository;
using DataLibrary.Repository;
using Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BusinessLibrary.Controllers
{
    public class CategoryController
    {
        ICategoryRepository<Category> categoryRepository;
        FeedRepository feedRepository;

        public CategoryController()
        {
            categoryRepository = new CategoryRepository();
            feedRepository = new FeedRepository();
        }

        public void CreateCategory(string name)
        {
            Category category = new Category(name);
            categoryRepository.Add(category);
        }

        public List<Category> GetAllCategories()
        {
            return categoryRepository.GetAll();
        }

        public void DeleteCategory(string name)
        {
            int categoryIndex = categoryRepository.GetIndex(name);
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete the chosen category? " +
                "If you continue, all related feeds will be deleted too.", "Delete category", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                categoryRepository.Delete(categoryIndex);

                foreach (Feed feed in feedRepository.GetAll())
                {
                    if (feed.Category == name)
                    {
                        int index = feedRepository.GetIndexCategory(name);
                        feedRepository.Delete(index);
                    }
                }
            }
            else if (dialogResult == DialogResult.No)
            {
            }
        }

        public void UpdateCategory(string oldName, string newName)
        {
            Category category = new Category();
            category.Name = newName;
            int categoryIndex = categoryRepository.GetIndex(oldName);
            categoryRepository.Update(category, categoryIndex);

            //Changes the categoryname of each feed that has the old name 
            foreach (Feed feed in feedRepository.GetAll())
            {
                if (feed.Category == oldName)
                {
                    feed.Category = newName;
                    int index = feedRepository.GetIndexCategory(oldName);
                    feedRepository.Update(feed, index);
                }
            }
        }

        public void FillComboBoxCategory(ComboBox comboBox)
        {
            List<Category> categoryList = GetAllCategories();
            if (categoryList != null)
            {
                foreach (var item in categoryList)
                {
                    comboBox.Items.Add(item.Name);
                }
            }
        }
    }
}
