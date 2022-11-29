using Library_Records.Api_Processor;
using Library_Records.Books.BL_Methods;
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
    public partial class LIB_CREATE_BOOK_FORM : Form
    {
        public LIB_CREATE_BOOK_FORM()
        {
            InitializeComponent();
        }

        private async void LIB_CREATE_BOOK_FORM_Load(object sender, EventArgs e)
        {
            LIB_FORM_ANIMATION.Form_Animation(this);

            try
            {
                List<CategoryModel> categories = await CategoryProcessor.LoadCategories();

                if (categories != null)
                {
                    string[] category_names = categories.Select(c => c.CategoryName).ToArray();

                    lib_create_book_category_name_cb.Items.AddRange(category_names);

                    lib_create_book_category_name_cb.SelectedIndex = 0;
                }
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

        #region"Title Bar Panel Event"

        private void lib_create_book_title_bar_panel_MouseDown(object sender, MouseEventArgs e)
        {
            LIB_FORM_ANIMATION.Form_Drag(this, e);
        }

        private void shopfy_create_customer_minimize_btn_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Normal;
        }

        private void shopfy_create_customer_close_btn_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion

        #region"Tool Bar Panel Event"

        private void lib_create_book_cancel_btn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void lib_create_book_add_btn_Click(object sender, EventArgs e)
        {
            string book_id = lib_create_book_book_id_tb.Text.Trim();
            string book_name = lib_create_book_book_name_tb.Text.Trim();
            string author_name = lib_create_book_author_name_tb.Text.Trim();
            string total = lib_create_book_total_tb.Text.Trim();
            int total_count = 0;

            if (string.IsNullOrEmpty(book_id))
            {
                MessageBox.Show("Please enter book id.");
            }
            else if (string.IsNullOrEmpty(book_name))
            {
                MessageBox.Show("Please enter book name.");
            }
            else if (string.IsNullOrEmpty(author_name))
            {
                MessageBox.Show("Please enter author name.");
            }
            else if (string.IsNullOrEmpty(total))
            {
                MessageBox.Show("Please enter book total.");
            }
            else if(!int.TryParse(total, out total_count))
            {
                MessageBox.Show("Please enter total in number value.");
            }
            else if (lib_create_book_category_name_cb.SelectedItem == null)
            {
                MessageBox.Show("Please select a correct category.");
            }
            else
            {
                try
                {
                    string category_name = lib_create_book_category_name_cb.Items[
                    lib_create_book_category_name_cb.SelectedIndex].ToString();

                    CategoryModel category = await CategoryProcessor.LoadCategoryByName(category_name);

                    if (category != null)
                    {
                        CreateBookModel create_book_model = new CreateBookModel()
                        {
                            BookId = book_id,
                            BookName = book_name,
                            Author = author_name,
                            CategoryId = category.Id,
                            TotalCount = total_count
                        };

                        await BookProcessor.SetBook(create_book_model);

                        LIB_BOOK_REPORT_GRID_VIEW_DATA.load_status = "Books Added";

                        LIB_BOOK_REPORT_FORM member_report_form = (LIB_BOOK_REPORT_FORM)LIB_FORM_STATE.Get_Open_Form("LIB_BOOK_REPORT_FORM");

                        if (member_report_form != null)
                        {
                            LIB_BOOK_REPORT_BL member_report_bl = new LIB_BOOK_REPORT_BL();
                            member_report_form.On_Set_Book_Report_Control += member_report_bl.On_Set_Book_Report_Controls;

                            member_report_form.Set_Book_Report_Controls();

                            await member_report_bl.Load_Book_Gridview_Data(1);
                        }

                        MessageBox.Show("Create book is successfull.");

                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("This category is not exist.");
                    }
                }
                catch (HttpRequestException ex)
                {
                    LIB_ERROR_MESSAGE.HttpRequestExceptionMessage(ex);
                }
                catch (Exception ex)
                {
                    LIB_ERROR_MESSAGE.ExceptionMessage(ex);
                }                
            }
        }

        #endregion
    }
}
