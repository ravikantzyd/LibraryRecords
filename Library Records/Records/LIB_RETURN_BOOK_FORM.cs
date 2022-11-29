using Library_Records.Api_Processor;
using Library_Records.Common_Methods;
using Library_Records.Models;
using Library_Records.Records.BL_Methods;
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

namespace Library_Records.Records
{
    public partial class LIB_RETURN_BOOK_FORM : Form
    {
        #region"Variable of Return Signature"

        private string return_sign_points { get; set; } = string.Empty;
        float ReturnPointX { get; set; }
        float ReturnPointY { get; set; }
        float ReturnLastX { get; set; }
        float ReturnLastY { get; set; }

        #endregion

        #region"Variable of Extended Day Signature"

        private string extended_sign_points { get; set; } = string.Empty;
        float ExtendedPointX { get; set; }
        float ExtendedPointY { get; set; }
        float ExtendedLastX { get; set; }
        float ExtendedLastY { get; set; }

        #endregion

        public LIB_RETURN_BOOK_FORM()
        {
            InitializeComponent();
        }

        DataGridViewRow row;

        private async void LIB_RETURN_BOOK_FORM_Load(object sender, EventArgs e)
        {
            LIB_FORM_ANIMATION.Form_Animation(this);

            if (LIB_RECORDS_REPORT_GRID_VIEW_DATA.selected_row_index < 0)
            {
                MessageBox.Show("Please select a record to edit!");
            }
            else
            {
                try
                {
                    row = LIB_RECORDS_REPORT_GRID_VIEW_DATA.selected_row;

                    string record_id = row.Cells[0].Value.ToString();

                    List<RecordModel> records = await RecordProcessor.LoadRecordByRID(record_id);
                    string[] left_borrow_books = records.Where(r => r.ReturnSignature == null)
                        .Select(r => r.Books.BookName).ToArray();

                    if (left_borrow_books.Length > 0)
                    {
                        DateTime return_date = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                        DateTime borrow_date = Convert.ToDateTime
                            (Convert.ToDateTime
                            (row.Cells[5].Value.ToString())
                            .ToShortDateString());

                        int extended_day_int = Convert.ToInt32((return_date - borrow_date).TotalDays);
                        string extended_day_str = "";

                        if (extended_day_int > 3)
                        {
                            extended_day_str = (extended_day_int - 3).ToString();
                            lib_return_book_extended_day_l.Enabled = true;
                            lib_return_book_extended_day_box_l.Enabled = true;
                            lib_return_book_extended_day_sign_l.Enabled = true;
                            lib_return_book_extended_day_sign_star_l.Enabled = true;
                            lib_return_book_extended_day_sign_panel.Enabled = true;
                            lib_return_book_extended_day_sign_clear_btn.Enabled = true;
                        }
                        else
                        {
                            extended_day_str = "0";
                        }

                        lib_return_book_record_id_box_l.Text = row.Cells[0].Value.ToString();
                        lib_return_book_borrow_date_box_l.Text = row.Cells[5].Value.ToString();
                        lib_return_book_member_name_box_l.Text = row.Cells[1].Value.ToString();
                        lib_return_book_borrow_book_cb.Items.AddRange(left_borrow_books);
                        lib_return_book_extended_day_box_l.Text = extended_day_str;
                    }
                    else
                    {
                        MessageBox.Show("All books are already returned.");
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

        private void lib_return_book_title_bar_panel_MouseDown(object sender, MouseEventArgs e)
        {
            LIB_FORM_ANIMATION.Form_Drag(this, e);
        }

        private async void lib_return_book_refresh_btn_Click(object sender, EventArgs e)
        {
            if (LIB_RECORDS_REPORT_GRID_VIEW_DATA.selected_row_index < 0)
            {
                MessageBox.Show("Please select a record to edit!");
            }
            else
            {
                try
                {
                    row = LIB_RECORDS_REPORT_GRID_VIEW_DATA.selected_row;

                    string record_id = row.Cells[0].Value.ToString();

                    List<RecordModel> records = await RecordProcessor.LoadRecordByRID(record_id);
                    string[] left_borrow_books = records.Where(r => r.ReturnSignature == null)
                        .Select(r => r.Books.BookName).ToArray();

                    if (left_borrow_books.Length > 0)
                    {
                        DateTime return_date = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                        DateTime borrow_date = Convert.ToDateTime
                            (Convert.ToDateTime
                            (row.Cells[5].Value.ToString())
                            .ToShortDateString());

                        int extended_day_int = Convert.ToInt32((return_date - borrow_date).TotalDays);
                        string extended_day_str = "";

                        if (extended_day_int > 3)
                        {
                            extended_day_str = (extended_day_int - 3).ToString();
                            lib_return_book_extended_day_l.Enabled = true;
                            lib_return_book_extended_day_box_l.Enabled = true;
                            lib_return_book_extended_day_sign_l.Enabled = true;
                            lib_return_book_extended_day_sign_star_l.Enabled = true;
                            lib_return_book_extended_day_sign_panel.Enabled = true;
                            lib_return_book_extended_day_sign_clear_btn.Enabled = true;
                        }
                        else
                        {
                            extended_day_str = "0";
                        }

                        lib_return_book_record_id_box_l.Text = row.Cells[0].Value.ToString();
                        lib_return_book_borrow_date_box_l.Text = row.Cells[5].Value.ToString();
                        lib_return_book_member_name_box_l.Text = row.Cells[1].Value.ToString();
                        lib_return_book_borrow_book_cb.Items.AddRange(left_borrow_books);
                        lib_return_book_extended_day_box_l.Text = extended_day_str;
                    }
                    else
                    {
                        MessageBox.Show("All books are already returned.");
                        this.Close();
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

        private void lib_return_book_minimize_btn_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void lib_return_book_close_btn_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion

        #region"Tool Bar Panel Event"

        private void lib_return_book_cancel_btn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void lib_return_book_clear_btn_Click(object sender, EventArgs e)
        {
            lib_return_book_return_date_picker.Text = DateTime.Now.ToString();
            lib_return_book_return_book_cb.Items.Clear();
            lib_return_book_return_book_cb.ResetText();
            Return_Sign_Clear_Signature();
            Extended_Sign_Clear_Signature();
        }

        private async void lib_return_book_return_btn_Click(object sender, EventArgs e)
        {
            DateTime return_date = Convert.ToDateTime
                (Convert.ToDateTime(lib_return_book_return_date_picker.Text).ToShortDateString());

            DateTime borrow_date = Convert.ToDateTime(lib_return_book_borrow_date_box_l.Text);

            string record_id = lib_return_book_record_id_box_l.Text.Trim();
            string member_name = lib_return_book_member_name_box_l.Text.Trim();

            int extended_day = 0;

            if ((return_date - borrow_date).TotalDays > 3)
            {
                extended_day = Convert.ToInt32((return_date - borrow_date).TotalDays) - 3;
            }
            else
            {
                extended_day = 0;
            }

            if (borrow_date == null)
            {
                MessageBox.Show("Your information is incorrect.");
            }
            else if(member_name==String.Empty)
            {
                MessageBox.Show("Your information is incorrect.");
            }
            else if (lib_return_book_borrow_book_cb.Items.Count <= 0)
            {
                MessageBox.Show("Your information is incorrect.");
            }
            else if (lib_return_book_return_book_cb.Items.Count <= 0)
            {
                MessageBox.Show("Please select any book to return.");
            }
            else if (return_sign_points == String.Empty)
            {
                MessageBox.Show("Please sign to return.");
            }
            else if ((extended_day > 0) && (extended_sign_points == String.Empty))
            {
                MessageBox.Show("Please sign for extened day(s)");
            }
            else
            {
                try
                {
                    for (int i = 0; i < lib_return_book_return_book_cb.Items.Count; i++)
                    {
                        string book_name = lib_return_book_return_book_cb.Items[i].ToString();

                        List<RecordModel> record = await RecordProcessor.LoadRecordByRIDandBookName(record_id, book_name);

                        UpdateRecordModel updateRecordModel = new UpdateRecordModel();

                        if (extended_day > 0)
                        {
                            updateRecordModel = new UpdateRecordModel()
                            {                                
                                ReturnDate = return_date,
                                ReturnSignature = return_sign_points,
                                DateExtended = extended_day,
                                DExtendedSignature = extended_sign_points
                            };
                        }
                        else
                        {
                            updateRecordModel = new UpdateRecordModel()
                            {
                                ReturnDate = return_date,
                                ReturnSignature = return_sign_points,
                            };
                        }

                        await RecordProcessor.ModifyRecord(record[0].Id, updateRecordModel);
                    }

                    LIB_RECORDS_REPORT_GRID_VIEW_DATA.load_status = "Grid Load";

                    LIB_RECORDS_REPORT_FORM record_report_form = (LIB_RECORDS_REPORT_FORM)LIB_FORM_STATE
                        .Get_Open_Form("LIB_RECORDS_REPORT_FORM");

                    LIB_RECORDS_REPORT_BL record_report_bl = new LIB_RECORDS_REPORT_BL();
                    record_report_form.On_Set_Record_Report_Control += record_report_bl.On_Set_Record_Report_Controls;

                    record_report_form.Set_Record_Report_Controls();

                    int page_num = Convert.ToInt32(record_report_bl.record_report_gv_page_num_l.Text.Split('/')[0]);

                    await record_report_bl.Load_Record_Gridview_Data(page_num);

                    MessageBox.Show("Return book operation is successfull.");

                    Close();
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

        private void lib_return_book_return_date_picker_ValueChanged(object sender, EventArgs e)
        {
            DateTime return_date = Convert.ToDateTime
                (Convert.ToDateTime(lib_return_book_return_date_picker.Text)
                .ToShortDateString());
            DateTime borrow_date = Convert.ToDateTime
                (Convert.ToDateTime
                (row.Cells[5].Value.ToString())
                .ToShortDateString());

            int extended_day_int = Convert.ToInt32((return_date - borrow_date).TotalDays);
            string extended_day_str = "";

            if (extended_day_int > 3)
            {
                extended_day_str = (extended_day_int - 3).ToString();
                lib_return_book_extended_day_l.Enabled = true;
                lib_return_book_extended_day_box_l.Enabled = true;
                lib_return_book_extended_day_sign_l.Enabled = true;
                lib_return_book_extended_day_sign_star_l.Enabled = true;
                lib_return_book_extended_day_sign_panel.Enabled = true;
                lib_return_book_extended_day_sign_clear_btn.Enabled = true;
            }
            else
            {
                extended_day_str = "0";
                lib_return_book_extended_day_l.Enabled = false;
                lib_return_book_extended_day_box_l.Enabled = false;
                lib_return_book_extended_day_sign_l.Enabled = false;
                lib_return_book_extended_day_sign_star_l.Enabled = false;
                lib_return_book_extended_day_sign_panel.Enabled = false;
                lib_return_book_extended_day_sign_clear_btn.Enabled = false;
            }

            lib_return_book_extended_day_box_l.Text = extended_day_str;
        }

        private void lib_return_book_borrow_book_select_btn_Click(object sender, EventArgs e)
        {
            if (lib_return_book_borrow_book_cb.SelectedItem == null)
            {
                MessageBox.Show("Please select correct values.");
            }
            else
            {
                string selected_book_name = lib_return_book_borrow_book_cb.Items[
                    lib_return_book_borrow_book_cb.SelectedIndex].ToString();

                if (lib_return_book_return_book_cb.Items.Contains(selected_book_name))
                {
                    MessageBox.Show("This book is already selected.");
                }                
                else
                {
                    lib_return_book_return_book_cb.Items.Add(selected_book_name);
                    lib_return_book_return_book_cb.SelectedIndex = 0;
                }
            }
        }

        #region"Return Signature"

        private void lib_return_book_return_signature_panel_Paint(object sender, PaintEventArgs e)
        {
            Graphics G = lib_return_book_return_signature_panel.CreateGraphics();
            G.DrawLine(Pens.Black, ReturnPointX, ReturnPointY, ReturnLastX, ReturnLastY);
            ReturnLastX = ReturnPointX;
            ReturnLastY = ReturnPointY;
        }

        private void lib_return_book_return_signature_panel_MouseDown(object sender, MouseEventArgs e)
        {
            ReturnLastX = e.X;
            ReturnLastY = e.Y;
        }

        private void lib_return_book_return_signature_panel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReturnPointX = e.X;
                ReturnPointY = e.Y;

                return_sign_points += $"{ReturnPointX},{ReturnPointY},{ReturnLastX},{ReturnLastY}/";

                lib_return_book_return_signature_panel_Paint(this, null);
            }
        }

        private void lib_return_book_return_signature_clear_btn_Click(object sender, EventArgs e)
        {
            Return_Sign_Clear_Signature();
        }

        private void Return_Sign_Clear_Signature()
        {
            ReturnPointX = 0;
            ReturnPointY = 0;
            ReturnLastX = 0;
            ReturnLastY = 0;
            return_sign_points = String.Empty;
            lib_return_book_return_signature_panel.Invalidate();
        }

        #endregion

        #region"Extended Signature"

        private void lib_return_book_extended_day_sign_panel_Paint(object sender, PaintEventArgs e)
        {
            Graphics G = lib_return_book_extended_day_sign_panel.CreateGraphics();
            G.DrawLine(Pens.Black, ExtendedPointX, ExtendedPointY, ExtendedLastX, ExtendedLastY);
            ExtendedLastX = ExtendedPointX;
            ExtendedLastY = ExtendedPointY;
        }

        private void lib_return_book_extended_day_sign_panel_MouseDown(object sender, MouseEventArgs e)
        {
            ExtendedLastX = e.X;
            ExtendedLastY = e.Y;
        }

        private void lib_return_book_extended_day_sign_panel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ExtendedPointX = e.X;
                ExtendedPointY = e.Y;

                extended_sign_points += $"{ExtendedPointX},{ExtendedPointY},{ExtendedLastX},{ExtendedLastY}/";

                lib_return_book_extended_day_sign_panel_Paint(this, null);
            }
        }

        private void lib_return_book_extended_day_sign_clear_btn_Click(object sender, EventArgs e)
        {
            Extended_Sign_Clear_Signature();
        }

        private void Extended_Sign_Clear_Signature()
        {
            ExtendedPointX = 0;
            ExtendedPointY = 0;
            ExtendedLastX = 0;
            ExtendedLastY = 0;
            return_sign_points = String.Empty;
            lib_return_book_extended_day_sign_panel.Invalidate();
        }

        #endregion        
    }
}
