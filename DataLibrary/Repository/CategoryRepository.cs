using Models;
using DataLibrary.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;

namespace DataLibrary.Repository
{
    public class CategoryRepository : ICategoryRepository<Category>
    {
        //Fields
        DataManager<Category> dataManager;
        List<Category> categories;
        public CategoryRepository()
        {
            dataManager = new DataManager<Category>("categories.xml");
            categories = new List<Category>();
            categories = GetAll();
        }
        public void Add(Category entity)
        {
            if (categories == null)
            {
                categories = new List<Category>();
            }
            categories.Add(entity);
            SaveChanges();
        }

        public void Delete(int index)
        {
            categories.RemoveAt(index);
            SaveChanges();
        }

        public List<Category> GetAll()
        {
            categories = new List<Category>();
            try
            {
                categories = dataManager.GetData();
            }
            catch (Exception)
            {

            }
            SaveChanges();
            return categories;
        }

        public Category GetByName(string name)
        {
            return GetAll().FirstOrDefault(p => p.Name.Equals(name));
        }

        public int GetIndex(string name)
        {
            int categoryIndex = GetAll().FindIndex(e => e.Name.Equals(name));
            return categoryIndex;
        }

        public void SaveChanges()
        {
            dataManager.SaveAllData(categories);
        }

        public void Update(Category entity,int index)
        {
            if (index >= 0)
            {
                categories[index] = entity;
            }
            
            SaveChanges();
        }
    }
}
