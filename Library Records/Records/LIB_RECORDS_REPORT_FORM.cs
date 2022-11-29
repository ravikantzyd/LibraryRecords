using Library_Records.Common_Methods;
using Library_Records.Common_Methods.Input_Parameters;
using Library_Records.Records.BL_Methods;
using Library_Records.Records.BL_Methods.BL_Methods_Param;
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
    public partial class LIB_RECORDS_REPORT_FORM : Form
    {
        #region"Class Variable Decalration"

        public Progress<ProgressReport> general_search_cb_progress { get; } = new Progress<ProgressReport>();

        public event EventHandler<LIB_RECORD_REPORT_SET_CONTROL_EVENT_ARGS> On_Set_Record_Report_Control;
        public string paging_status { get; set; } = "";

        public int on_off_refresh { get; set; } = 0;
        public int on_off_excel { get; set; } = 0;
        public int on_off_cb { get; set; } = 0;

        #endregion

        public LIB_RECORDS_REPORT_FORM()
        {
            InitializeComponent();
            general_search_cb_progress.ProgressChanged += General_Search_Cb_Progress_Report;
        }

        private async void LIB_RECORDS_REPORT_FORM_Load(object sender, EventArgs e)
        {
            LIB_RECORDS_REPORT_BL record_report_bl = new LIB_RECORDS_REPORT_BL();

            this.On_Set_Record_Report_Control += record_report_bl.On_Set_Record_Report_Controls;
            this.Set_Record_Report_Controls();

            LIB_RECORDS_REPORT_GRID_VIEW_DATA.load_status = "Grid Load";

            try
            {
                await record_report_bl.Load_Record_Gridview_Data(1);
            }
            catch (HttpRequestException ex)
            {
                LIB_ERROR_MESSAGE.HttpRequestExceptionMessage(ex);
            }
            catch (Exception ex) { LIB_ERROR_MESSAGE.ExceptionMessage(ex); }
        }

        #region"Data Entry Methods"

        private void General_Search_Cb_Progress_Report(object sender, ProgressReport e)
        {
            lib_record_report_search_percent_l.Text = string.Format("{0} %", e.ProgressPercent);
        }

        public void Set_Record_Report_Controls()
        {
            LIB_RECORD_REPORT_SET_CONTROL_EVENT_ARGS event_args = new LIB_RECORD_REPORT_SET_CONTROL_EVENT_ARGS
            {
                grid_view = this.lib_record_report_grid_view,
                grid_view_page_num_l = lib_record_report_page_number_l                
            };

            On_Set_Record_Report_Control?.Invoke(this, event_args);
        }

        #endregion

        #region"Title Bar Panel Event"

        private async void lib_record_report_refresh_btn_Click(object sender, EventArgs e)
        {
            if (on_off_refresh == 0)
            {
                on_off_refresh = 1;

                LIB_RECORDS_REPORT_BL record_report_bl = new LIB_RECORDS_REPORT_BL();

                this.On_Set_Record_Report_Control += record_report_bl.On_Set_Record_Report_Controls;
                this.Set_Record_Report_Controls();

                LIB_RECORDS_REPORT_GRID_VIEW_DATA.load_status = "Grid Load";
                lib_record_report_search_percent_l.Text = "0 %";

                try
                {
                    await record_report_bl.Load_Record_Gridview_Data(1);
                }
                catch (HttpRequestException ex)
                {
                    LIB_ERROR_MESSAGE.HttpRequestExceptionMessage(ex);
                }
                catch (Exception ex) { LIB_ERROR_MESSAGE.ExceptionMessage(ex); }

                on_off_refresh = 0;
            }
        }

        private async void lib_record_report_search_tb_TextChanged(object sender, EventArgs e)
        {
            try
            {
                LIB_RECORDS_REPORT_BL product_details_bl = new LIB_RECORDS_REPORT_BL();

                this.On_Set_Record_Report_Control += product_details_bl.On_Set_Record_Report_Controls;
                this.Set_Record_Report_Controls();

                LIB_RECORDS_REPORT_GRID_VIEW_DATA.load_status = "Records Search";

                string word = lib_record_report_search_tb.Text.Trim();
                await product_details_bl.Load_Record_Gridview_Data(1, 0, word);
            }
            catch (HttpRequestException ex)
            {
                LIB_ERROR_MESSAGE.HttpRequestExceptionMessage(ex);
            }
            catch (Exception ex) { LIB_ERROR_MESSAGE.ExceptionMessage(ex); }
        }

        #endregion

        #region"Tool Bar Panel Event"

        private async void lib_record_report_create_borrow_btn_Click(object sender, EventArgs e)
        {
            LIB_BORROW_BOOK_FORM borrow_book = new LIB_BORROW_BOOK_FORM();
            LIB_FORM_STATE _form_state = new LIB_FORM_STATE();

            LIB_FORM_STATE_PARAM form_param = new LIB_FORM_STATE_PARAM()
            {
                form = borrow_book,
                form_state = LIB_BORROW_BOOK_FORM.form_state
            };

            _form_state.form_state_change += borrow_book.Form_State_Change_Event;
            _form_state.Show(form_param);

            if (!LIB_BORROW_BOOK_FORM.data_entry_process_status.Equals("Running"))
            {
                LIB_BORROW_BOOK_FORM borrow_book_open_form = (LIB_BORROW_BOOK_FORM)LIB_FORM_STATE.Get_Open_Form("LIB_BORROW_BOOK_FORM");

                LIB_FORM_CLEAR form_clear = new LIB_FORM_CLEAR();
                form_clear.On_Clear_To_New_Form_Event += borrow_book_open_form.On_Clear_To_New_Form;
                form_clear.Form_Clear();

                if (LIB_BORROW_BOOK_FORM.data_entry_process_status.Equals("") ||
                    LIB_BORROW_BOOK_FORM.data_entry_process_status.Equals("Cancelled"))
                {
                    LIB_BORROW_BOOK_BL borrow_book_bl = new LIB_BORROW_BOOK_BL();

                    borrow_book_open_form.On_Set_Borrow_Book_Data_Entry_Data += borrow_book_bl.On_Set_Borrow_Book_Data_Entry_Data;
                    borrow_book_bl.On_Get_Borrow_Book_Data_Entry_Data += borrow_book_open_form.On_Notify_Borrow_Book_For_Set_Data_Entry_Data;
                    borrow_book_bl.On_Set_Borrow_Book_Data_Entry_Process_Status += borrow_book_open_form.On_Set_Data_Entry_Process_Status;

                    await borrow_book_bl.Load_Borrow_Book_Data_Entry(borrow_book_open_form.data_entry_progress,
                        borrow_book_open_form.Cts);
                }                
            }
        }

        private void lib_record_report_return_book_btn_Click(object sender, EventArgs e)
        {
            if (LIB_RECORDS_REPORT_GRID_VIEW_DATA.selected_row_index < 0)
            {
                MessageBox.Show("Please select a Member to Edit!");
            }
            else
            {
                LIB_RETURN_BOOK_FORM return_book = new LIB_RETURN_BOOK_FORM();
                LIB_FORM_STATE _form_state = new LIB_FORM_STATE();

                LIB_FORM_STATE_PARAM form_param = new LIB_FORM_STATE_PARAM()
                {
                    form = return_book
                };

                _form_state.Show(form_param);
            }
        }

        #endregion

        #region"Status Bar Panel Event"

        private async void lib_record_report_page_num_go_btn_Click(object sender, EventArgs e)
        {
            string page_num_str = lib_record_report_page_num_tb.Text.Trim();

            if (Int32.TryParse(page_num_str, out int page_num_int))
            {
                if (!paging_status.Equals("Running"))
                {
                    int maxpage = Convert.ToInt32(lib_record_report_page_number_l.Text.Split('/')[1]);

                    paging_status = "Running";

                    if ((page_num_int <= maxpage) && (page_num_int >= 1))
                    {
                        LIB_RECORDS_REPORT_BL record_report_bl = new LIB_RECORDS_REPORT_BL();

                        this.On_Set_Record_Report_Control += record_report_bl.On_Set_Record_Report_Controls;

                        this.Set_Record_Report_Controls();

                        await record_report_bl.Load_Record_Gridview_Data_By_Page_Num(page_num_int);

                        lib_record_report_page_number_l.Text = (page_num_int) + "/" + maxpage;
                    }

                    paging_status = "";
                }
            }
            else
            {
                MessageBox.Show("Please enter number value in Page Number Box!");
            }
        }

        private async void lib_record_report_paging_previous_btn_Click(object sender, EventArgs e)
        {
            if (!paging_status.Equals("Running"))
            {
                int page_num = Convert.ToInt32(lib_record_report_page_number_l.Text.Split('/')[0]);

                int maxpage = Convert.ToInt32(lib_record_report_page_number_l.Text.Split('/')[1]);

                paging_status = "Running";

                if (page_num > 1)
                {
                    LIB_RECORDS_REPORT_BL record_report_bl = new LIB_RECORDS_REPORT_BL();

                    this.On_Set_Record_Report_Control += record_report_bl.On_Set_Record_Report_Controls;

                    this.Set_Record_Report_Controls();

                    await record_report_bl.Load_Record_Gridview_Data_By_Page_Num(page_num - 1);

                    lib_record_report_page_number_l.Text = (page_num - 1) + "/" + maxpage;
                }

                paging_status = "";
            }
        }

        private async void lib_record_report_paging_next_btn_Click(object sender, EventArgs e)
        {
            if (!paging_status.Equals("Running"))
            {
                int page_num = Convert.ToInt32(lib_record_report_page_number_l.Text.Split('/')[0]);

                int maxpage = Convert.ToInt32(lib_record_report_page_number_l.Text.Split('/')[1]);

                paging_status = "Running";

                if ((maxpage > 1) && (page_num < maxpage))
                {
                    LIB_RECORDS_REPORT_BL record_report_bl = new LIB_RECORDS_REPORT_BL();

                    this.On_Set_Record_Report_Control += record_report_bl.On_Set_Record_Report_Controls;

                    this.Set_Record_Report_Controls();

                    await record_report_bl.Load_Record_Gridview_Data_By_Page_Num(page_num + 1);

                    lib_record_report_page_number_l.Text = (page_num + 1) + "/" + maxpage;
                }

                paging_status = "";
            }
        }

        private void lib_record_report_page_num_tb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                lib_record_report_page_num_go_btn_Click(this, EventArgs.Empty);
            }
        }

        #endregion

        #region"Grid View Click Event"

        private void lib_record_report_grid_view_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                LIB_RECORDS_REPORT_GRID_VIEW_DATA.selected_row_index = -1;
                LIB_RECORDS_REPORT_GRID_VIEW_DATA.selected_row = null;
            }
            else
            {
                LIB_RECORDS_REPORT_GRID_VIEW_DATA.selected_row_index = e.RowIndex;
                LIB_RECORDS_REPORT_GRID_VIEW_DATA.selected_row =
                    lib_record_report_grid_view.Rows[e.RowIndex];

                if (LIB_RECORDS_REPORT_GRID_VIEW_DATA.selected_row.Cells[0].Value == null)
                {
                    LIB_RECORDS_REPORT_GRID_VIEW_DATA.selected_row_index = -1;
                    LIB_RECORDS_REPORT_GRID_VIEW_DATA.selected_row = null;
                }

                if (e.ColumnIndex == 8)
                {
                    if (LIB_RECORDS_REPORT_GRID_VIEW_DATA.selected_row_index < 0)
                    {
                        MessageBox.Show("Please select a correct record!");
                    }
                    else
                    {
                        Form open_borrow_sign_form = LIB_FORM_STATE.Get_Open_Form("LIB_BORROW_SIGNATURE_VIEW_FORM");

                        if (open_borrow_sign_form != null)
                        {
                            open_borrow_sign_form.Close();
                        }

                        LIB_BORROW_SIGNATURE_VIEW_FORM borrow_sign_form = new LIB_BORROW_SIGNATURE_VIEW_FORM();
                        LIB_FORM_STATE _form_state = new LIB_FORM_STATE();

                        LIB_FORM_STATE_PARAM form_param = new LIB_FORM_STATE_PARAM()
                        {
                            form = borrow_sign_form
                        };

                        _form_state.Show(form_param);
                    }
                }

                if (e.ColumnIndex == 9)
                {
                    if (LIB_RECORDS_REPORT_GRID_VIEW_DATA.selected_row_index < 0)
                    {
                        MessageBox.Show("Please select a correct record!");
                    }
                    else
                    {
                        Form open_return_sign_form = LIB_FORM_STATE.Get_Open_Form("LIB_RETURN_SIGNATURE_VIEW_FORM");

                        if (open_return_sign_form != null)
                        {
                            open_return_sign_form.Close();
                        }

                        LIB_RETURN_SIGNATURE_VIEW_FORM return_sign_form = new LIB_RETURN_SIGNATURE_VIEW_FORM();
                        LIB_FORM_STATE _form_state = new LIB_FORM_STATE();

                        LIB_FORM_STATE_PARAM form_param = new LIB_FORM_STATE_PARAM()
                        {
                            form = return_sign_form
                        };

                        _form_state.Show(form_param);
                    }
                }

                if (e.ColumnIndex == 10)
                {
                    if (LIB_RECORDS_REPORT_GRID_VIEW_DATA.selected_row_index < 0)
                    {
                        MessageBox.Show("Please select a correct record!");
                    }
                    else
                    {
                        Form open_extended_day_sign_form = LIB_FORM_STATE.Get_Open_Form("LIB_EXTENDED_DAY_SIGNATURE_VIEW_FORM");

                        if (open_extended_day_sign_form != null)
                        {
                            open_extended_day_sign_form.Close();
                        }

                        LIB_EXTENDED_DAY_SIGNATURE_VIEW_FORM extended_day_sign_form = new LIB_EXTENDED_DAY_SIGNATURE_VIEW_FORM();
                        LIB_FORM_STATE _form_state = new LIB_FORM_STATE();

                        LIB_FORM_STATE_PARAM form_param = new LIB_FORM_STATE_PARAM()
                        {
                            form = extended_day_sign_form
                        };

                        _form_state.Show(form_param);
                    }
                }
            }
        }

        private void lib_record_report_grid_view_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                LIB_RECORDS_REPORT_GRID_VIEW_DATA.selected_row_index = -1;
                LIB_RECORDS_REPORT_GRID_VIEW_DATA.selected_row = null;
            }
            else
            {
                LIB_RECORDS_REPORT_GRID_VIEW_DATA.selected_row_index = e.RowIndex;
                LIB_RECORDS_REPORT_GRID_VIEW_DATA.selected_row =
                    lib_record_report_grid_view.Rows[e.RowIndex];

                if (LIB_RECORDS_REPORT_GRID_VIEW_DATA.selected_row.Cells[0].Value == null)
                {
                    LIB_RECORDS_REPORT_GRID_VIEW_DATA.selected_row_index = -1;
                    LIB_RECORDS_REPORT_GRID_VIEW_DATA.selected_row = null;
                }
            }

            lib_record_report_return_book_btn_Click(this, EventArgs.Empty);
        }

        #endregion
    }
}
