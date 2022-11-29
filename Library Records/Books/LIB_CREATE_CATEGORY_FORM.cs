using Library_Records.Api_Processor;
using Library_Records.Common_Methods;
using Library_Records.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library_Records.Books
{
    public partial class LIB_CREATE_CATEGORY_FORM : Form
    {
        public LIB_CREATE_CATEGORY_FORM()
        {
            InitializeComponent();
        }

        private void LIB_CREATE_CATEGORY_FORM_Load(object sender, EventArgs e)
        {
            LIB_FORM_ANIMATION.Form_Animation(this);
        }

        #region"Title Bar Panel Event"

        private void lib_create_category_title_bar_panel_MouseDown(object sender, MouseEventArgs e)
        {
            LIB_FORM_ANIMATION.Form_Drag(this, e);
        }

        private void lib_create_category_minimize_btn_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void lib_create_category_close_btn_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion

        #region"Tool Bar Panel Event"

        private void lib_create_category_cancel_btn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void lib_create_category_add_btn_Click(object sender, EventArgs e)
        {
            string category_name = lib_create_category_category_name_tb.Text.Trim();

            if (string.IsNullOrEmpty(category_name))
            {
                MessageBox.Show("Please enter category name.");
            }
            else
            {
                try
                {
                    CreateCategoryModel category = new CreateCategoryModel
                    {
                        CategoryName = category_name
                    };

                    await CategoryProcessor.SetCategory(category);

                    MessageBox.Show("Create category is successfull.");

                    this.Close();
                }
                catch (HttpRequestException ex)
                {
                    LIB_ERROR_MESSAGE.HttpRequestExceptionMessage(ex);
                }
                catch(Exception ex)
                {
                    LIB_ERROR_MESSAGE.ExceptionMessage(ex);
                }                
            }
        }

        #endregion
    }
}
