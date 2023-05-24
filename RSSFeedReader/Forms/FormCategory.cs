using Models;
using System;
using BusinessLibrary.Controllers;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using BusinessLibrary;

namespace RSSFeedReader.Forms
{
    public partial class FormCategory : Form
    {

        //Fields
        private Form1 _parentForm;
        bool txtBoxHasBeenClicked = false;
        CategoryController categoryController;
        FeedController feedController;
        public FormCategory(Form1 parentForm)
        {
            InitializeComponent();
            categoryController = new CategoryController();
            feedController = new FeedController();  
            fillListBoxCategory();
            _parentForm = parentForm;
        }
        

        private void textBoxCategoryName_MouseClick(object sender, MouseEventArgs e)
        {

            if (!txtBoxHasBeenClicked)
            {
                textBoxCategoryName.Text = String.Empty;
                textBoxCategoryName.ForeColor = Color.White;
                txtBoxHasBeenClicked = true;
                
            }
        }


        private void fillListBoxCategory()
        {
            listBoxCategory.Items.Clear();
            foreach (Category item in categoryController.GetAllCategories())
                {
                if (item != null)
                {
                    listBoxCategory.Items.Add(item.Name);
                }
                }
        }

        private void buttonNewCategory_Click(object sender, EventArgs e)
        {
            if (textBoxCategoryName.Text.Equals("Add a New Category"))
            {
                textBoxCategoryName.Text = "";
            }
            if (Validator.CheckIfTheInputIsEmpty(textBoxCategoryName.Text) && Validator.CheckIfCategoryIsInList(textBoxCategoryName.Text, categoryController.GetAllCategories())) { 
                categoryController.CreateCategory(textBoxCategoryName.Text);
                textBoxCategoryName.Text = "";
                fillListBoxCategory();
                _parentForm.createCategoryButton();
            }
        }

        private void buttonDeleteCategory_Click(object sender, EventArgs e)
        {
            if (Validator.CheckIfItemIsSelected(listBoxCategory.SelectedIndex)) { 
                categoryController.DeleteCategory(listBoxCategory.SelectedItem.ToString());
                fillListBoxCategory();
                textBoxChosenCategory.Text = "";
                _parentForm.createCategoryButton();
                feedController.UpdateDataGrid(_parentForm.dataGridView1);
            }
        }

        private void buttonSaveCategory_Click(object sender, EventArgs e)
        {
            if (Validator.CheckIfListBoxIsNull(listBoxCategory) && Validator.CheckIfTheInputIsEmpty(textBoxChosenCategory.Text) && Validator.CheckIfCategoryIsInList(textBoxChosenCategory.Text, categoryController.GetAllCategories()))
            {
              


                    categoryController.UpdateCategory(listBoxCategory.SelectedItem.ToString(), textBoxChosenCategory.Text);
                    fillListBoxCategory();
                    textBoxChosenCategory.Text = "";
                    _parentForm.createCategoryButton();
                    feedController.UpdateDataGrid(_parentForm.dataGridView1);
                
            }
        }

        private void listBoxCategory_MouseClick(object sender, MouseEventArgs e)
        {
            if (listBoxCategory.SelectedItem != null)
            {
                textBoxChosenCategory.Text = listBoxCategory.SelectedItem.ToString();
                textBoxChosenCategory.ReadOnly = false;
            }
        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {
            // ToolTip
        }
    }
}
