using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLibrary;
using BusinessLibrary.Controllers;
using System.Text.RegularExpressions;
using Models;

namespace RSSFeedReader.Forms
{
    public partial class FormNewFeed : Form

    {
        FeedController feedController;
        CategoryController categoryController;
        ExceptionHandler exceptionHandler;
        Form1 form;

        public DataGridView datagrid;
        public FormNewFeed(DataGridView datagrid, Form1 form)
        {
            InitializeComponent();
            this.datagrid = datagrid;
            categoryController = new CategoryController();
            feedController = new FeedController();
            exceptionHandler = new ExceptionHandler();
            categoryController.FillComboBoxCategory(comboBoxCategory);
            feedController.FillComboBoxFrequency(comboBoxFrequency);
            this.form = form;


        }

        private async void buttonSaveCategory_Click(object sender, EventArgs e)
        {

            string URL = textBoxURL.Text;
            string Name = textBoxName.Text;
            string Frequency = Regex.Match(comboBoxFrequency.Text, @"\d+").Value;

            string Category = comboBoxCategory.Text;

            if (Validator.CheckIfTheInputIsEmpty(URL, Name, Frequency, Category) && Validator.CheckForValidUrl(URL) && Validator.CheckIfFeedIsInList(Name,URL, feedController.GetAllFeeds()) && exceptionHandler.ValidateRSS(URL))
            {

                int FrequencyToInt = Int32.Parse(Frequency);
                await feedController.CreateFeed(URL, Name, FrequencyToInt, Category, datagrid);

                this.Dispose();
                form.Activate();
            }



        }

        private void textBoxURL_TextChanged(object sender, EventArgs e)
        {

        }

        private void FormNewFeed_Load(object sender, EventArgs e)
        {

        }
    }
}
