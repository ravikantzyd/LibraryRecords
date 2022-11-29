using Library_Records.Api_Processor;
using Library_Records.Common_Methods;
using Library_Records.Books.BL_Methods;
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
    public partial class LIB_EDIT_BOOK_FORM : Form
    {
        public LIB_EDIT_BOOK_FORM()
        {
            InitializeComponent();
        }

        DataGridViewRow row;

        private async void LIB_EDIT_BOOK_FORM_Load(object sender, EventArgs e)
        {
            LIB_FORM_ANIMATION.Form_Animation(this);

            if (LIB_BOOK_REPORT_GRID_VIEW_DATA.selected_row_index < 0)
            {
                MessageBox.Show("Please select a book to edit!");
            }            
            else
            {
                row = LIB_BOOK_REPORT_GRID_VIEW_DATA.selected_row;

                try
                {
                    List<CategoryModel> categories = await CategoryProcessor.LoadCategories();
                    string[] category_arr = categories.Select(c => c.CategoryName).ToArray();

                    lib_edit_book_category_name_cb.Items.AddRange(category_arr);

                    lib_edit_book_book_id_tb.Text = row.Cells[0].Value.ToString();
                    lib_edit_book_book_name_tb.Text = row.Cells[1].Value.ToString();
                    lib_edit_book_author_name_tb.Text = row.Cells[2].Value.ToString();
                    lib_edit_book_total_tb.Text = row.Cells[4].Value.ToString();

                    if (lib_edit_book_category_name_cb.Items.Contains(row.Cells[3].Value.ToString()))
                    {
                        lib_edit_book_category_name_cb.SelectedItem = row.Cells[3].Value.ToString();
                    }
                    else
                    {
                        MessageBox.Show("Information is not correct.");
                        this.Close();
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
        }

        #region"Title Bar Panel Event"

        private void lib_edit_book_title_bar_panel_MouseDown(object sender, MouseEventArgs e)
        {
            LIB_FORM_ANIMATION.Form_Drag(this, e);
        }

        private void lib_edit_book_minimize_btn_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void lib_edit_book_close_btn_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion

        #region"Tool Bar Panel Event"

        private void lib_edit_book_cancel_btn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void lib_edit_book_save_btn_Click(object sender, EventArgs e)
        {
            string book_id = lib_edit_book_book_id_tb.Text.Trim();
            string new_book_name = lib_edit_book_book_name_tb.Text.Trim();
            string new_author_name = lib_edit_book_author_name_tb.Text.Trim();
            string new_total_book_str = lib_edit_book_total_tb.Text.Trim();
            int new_total_book_int = 0;

            if (string.IsNullOrEmpty(book_id))
            {
                MessageBox.Show("This is not a correct book to edit!");
            }
            else if (string.IsNullOrEmpty(new_book_name))
            {
                MessageBox.Show("Please enter book name.");
            }
            else if (string.IsNullOrEmpty(new_author_name))
            {
                MessageBox.Show("Please enter author name.");
            }
            else if (lib_edit_book_category_name_cb.SelectedItem == null)
            {
                MessageBox.Show("Please select a correct category name.");
            }
            else if (string.IsNullOrEmpty(new_total_book_str))
            {
                MessageBox.Show("Please enter a correct total book.");
            }
            else if (!int.TryParse(new_total_book_str, out new_total_book_int))
            {
                MessageBox.Show("Please enter number value in total book field.");
            }
            else
            {
                string old_book_name = row.Cells[1].Value.ToString();
                string old_author_name = row.Cells[2].Value.ToString();
                string old_category_name = row.Cells[3].Value.ToString();                

                string new_category_name = lib_edit_book_category_name_cb.Items[
                    lib_edit_book_category_name_cb.SelectedIndex].ToString();

                int available_book = 0;

                try
                {
                    BookModel book = await BookProcessor.LoadBookByBookId(book_id);

                    if (!((old_book_name == new_book_name) && (old_author_name == new_author_name)
                        && (old_category_name == new_category_name) && (new_total_book_int == book.TotalCount)))
                    {                        
                        List<RecordModel> records = await RecordProcessor.LoadRecordByBookId(book.Id);
                        List<string> borrow_signs = new List<string>();
                        List<string> return_signs = new List<string>();

                        if (records.Count != 0)
                        {
                            borrow_signs = records.Where(r => r.BorrowSignature != null).Select(s => s.BorrowSignature).ToList();
                            return_signs = records.Where(r => r.ReturnSignature != null).Select(s => s.ReturnSignature).ToList();

                            available_book = (new_total_book_int - borrow_signs.Count) + return_signs.Count;
                        }
                        else
                        {
                            available_book = new_total_book_int;
                        }

                        if ((available_book <= 0) && (records.Count != 0))
                        {
                            MessageBox.Show($"You cannot change to this amount because " +
                                $"{borrow_signs.Count} books is borrowed and {return_signs.Count} books" +
                                $" is already returned and {borrow_signs.Count - return_signs.Count} books" +
                                $" is needed to return. So, you can set total books to greater than " +
                                $"{borrow_signs.Count - return_signs.Count} .");
                        }
                        else if(available_book == 0)
                        {
                            MessageBox.Show("You cannot set total books to zero.");
                        }
                        else
                        {
                            CategoryModel new_category = await CategoryProcessor.LoadCategoryByName(new_category_name);

                            UpdateBookModel updateBookModel = new UpdateBookModel()
                            {
                                BookId = book_id,
                                BookName = new_book_name,
                                Author = new_author_name,
                                CategoryId = new_category.Id,
                                TotalCount = new_total_book_int
                            };

                            await BookProcessor.ModifyBook(book.Id, updateBookModel);

                            LIB_BOOK_REPORT_GRID_VIEW_DATA.load_status = "Grid Load";

                            LIB_BOOK_REPORT_FORM book_report_form = (LIB_BOOK_REPORT_FORM)LIB_FORM_STATE
                                .Get_Open_Form("LIB_BOOK_REPORT_FORM");

                            LIB_BOOK_REPORT_BL book_report_bl = new LIB_BOOK_REPORT_BL();
                            book_report_form.On_Set_Book_Report_Control += book_report_bl.On_Set_Book_Report_Controls;

                            book_report_form.Set_Book_Report_Controls();

                            int page_num = Convert.ToInt32(book_report_bl.book_report_gv_page_num_l.Text.Split('/')[0]);

                            await book_report_bl.Load_Book_Gridview_Data(page_num);

                            MessageBox.Show("Books data have updated successfully.");

                            this.Close();
                        }                        
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

        private async void lib_edit_book_remove_btn_Click(object sender, EventArgs e)
        {
            string book_id = lib_edit_book_book_id_tb.Text.Trim();

            if (string.IsNullOrEmpty(book_id))
            {
                MessageBox.Show("This is not a correct book to remove.");
            }
            else
            {
                DialogResult dr = MessageBox.Show("Are you sure want to delete this book?", "Warning!", MessageBoxButtons.YesNoCancel,
                        MessageBoxIcon.Warning);

                if (dr == DialogResult.Yes)
                {
                    BookModel book = await BookProcessor.LoadBookByBookId(book_id);

                    List<RecordModel> records = await RecordProcessor.LoadRecordByBookId(book.Id);

                    if(records != null)
                    {
                        await BookProcessor.DeleteBook(book.Id);

                        LIB_BOOK_REPORT_GRID_VIEW_DATA.load_status = "Grid Load";

                        LIB_BOOK_REPORT_FORM book_report_form = (LIB_BOOK_REPORT_FORM)LIB_FORM_STATE
                            .Get_Open_Form("LIB_BOOK_REPORT_FORM");

                        LIB_BOOK_REPORT_BL book_report_bl = new LIB_BOOK_REPORT_BL();
                        book_report_form.On_Set_Book_Report_Control += book_report_bl.On_Set_Book_Report_Controls;

                        book_report_form.Set_Book_Report_Controls();

                        int page_num = Convert.ToInt32(book_report_bl.book_report_gv_page_num_l.Text.Split('/')[0]);

                        await book_report_bl.Load_Book_Gridview_Data(page_num);

                        MessageBox.Show("Books data have deleted successfully!");

                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("You cannot remove this book because this book data is " +
                            "relating with record book data.");
                    }
                }
            }
        }

        #endregion        
    }
}
