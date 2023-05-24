using BusinessLibrary.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Models;
using System.Text.RegularExpressions;
using System.Security.Policy;
using BusinessLibrary;

namespace RSSFeedReader.Forms
{
    public partial class FormEditFeed : Form
    {
        //Fields
        public Feed currentFeed { get; set; }
        public FeedController feedController;
        public CategoryController categoryController;
        public DataGridView datagrid;
        Form1 form;

        public FormEditFeed(string selectedItem, DataGridView datagrid, Form1 form)
        {
            InitializeComponent();
            this.datagrid = datagrid;
            feedController = new FeedController();
            categoryController = new CategoryController();
            categoryController.FillComboBoxCategory(cmbCategory);
            feedController.FillComboBoxFrequency(cmbFrequency);
            currentFeed = feedController.GetFeedByIndex(selectedItem);
            this.form = form;
            
            SetUpEditForm();
        }

        public void SetUpEditForm()
        {
            textBoxUrl.Text = currentFeed.Url;
            textBoxName.Text = currentFeed.Name;
            cmbCategory.SelectedIndex = cmbCategory.Items.IndexOf(currentFeed.Category);
            cmbFrequency.SelectedIndex = cmbFrequency.Items.IndexOf(currentFeed.Frequency.ToString() + " min");
        }

        private async void buttonSaveFeed_Click(object sender, EventArgs e)
        {
            string URL = textBoxUrl.Text;
            string name = textBoxName.Text;
            string Frequency = Regex.Match(cmbFrequency.Text, @"\d+").Value;
            string category = cmbCategory.Text;
            if (Validator.CheckIfTheInputIsEmpty(URL, name, Frequency, category) && Validator.CheckForValidUrl(URL) && Validator.CheckIfFeedNameIsInList(name, currentFeed.Name, feedController.GetAllFeeds()) && Validator.CheckIfFeedURLIsInList(URL, currentFeed.Url, feedController.GetAllFeeds())) //exceptionHandler.ValidateRSS(URL)
            {

                int FrequencyToInt = Int32.Parse(Frequency);
                Feed newItem = new Feed(URL, name, category, FrequencyToInt);
                
                await feedController.UpdateFeed(newItem, currentFeed);

                MessageBox.Show("Your Changes Have Been Saved");
                this.Dispose();
                form.Activate();

                feedController.UpdateDataGrid(datagrid);
            }
        }
    }
}
