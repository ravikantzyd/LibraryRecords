using Library_Records.Api_Processor;
using Library_Records.Books.BL_Methods;
using Library_Records.Books.BL_Methods.BL_Input_Params;
using Library_Records.Common_Methods;
using Library_Records.Common_Methods.Input_Parameters;
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
    public partial class LIB_BOOK_REPORT_FORM : Form
    {
        #region"Class Variable Decalration"

        public Progress<ProgressReport> general_search_cb_progress { get; } = new Progress<ProgressReport>();

        public event EventHandler<LIB_BOOK_REPORT_NOTIFY_EVENT_ARGS> On_Notify_Set_Control;
        public event EventHandler<LIB_BOOK_REPORT_SET_CONTROL_EVENT_ARGS> On_Set_Book_Report_Control;
        public string paging_status { get; set; } = "";

        public int on_off_refresh { get; set; } = 0;
        public int on_off_excel { get; set; } = 0;
        public int on_off_cb { get; set; } = 0;

        #endregion

        public LIB_BOOK_REPORT_FORM()
        {
            InitializeComponent();
            general_search_cb_progress.ProgressChanged += General_Search_Cb_Progress_Report;
        }        

        private async void LIB_BOOKS_REPORT_FORM_Load(object sender, EventArgs e)
        {
            LIB_BOOK_REPORT_BL book_report_bl = new LIB_BOOK_REPORT_BL();

            On_Set_Book_Report_Control += book_report_bl.On_Set_Book_Report_Controls;
            this.Set_Book_Report_Controls();

            LIB_BOOK_REPORT_GRID_VIEW_DATA.load_status = "Grid Load";

            try
            {
                await book_report_bl.Load_Book_Gridview_Data(1);
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
            lib_book_report_search_percent_l.Text = string.Format("{0} %", e.ProgressPercent);
        }

        public void Set_Book_Report_Controls()
        {
            LIB_BOOK_REPORT_SET_CONTROL_EVENT_ARGS event_args = new LIB_BOOK_REPORT_SET_CONTROL_EVENT_ARGS
            {
                grid_view = this.lib_book_report_grid_view,
                grid_view_page_num_l = lib_book_report_page_number_l,
                total_book_l = lib_book_report_total_book_l,
                total_book_amount_l = lib_book_report_total_book_amount_l,
                total_book_equal_l = lib_book_report_total_book_equal_l
            };

            On_Set_Book_Report_Control?.Invoke(this, event_args);
        }

        #endregion

        #region"Title Bar Panel Event"

        private async void lib_book_report_search_box_cb_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private async void lib_book_report_refresh_btn_Click(object sender, EventArgs e)
        {
            if (on_off_refresh == 0)
            {
                on_off_refresh = 1;

                LIB_BOOK_REPORT_BL book_report_bl = new LIB_BOOK_REPORT_BL();

                this.On_Set_Book_Report_Control += book_report_bl.On_Set_Book_Report_Controls;
                this.Set_Book_Report_Controls();

                LIB_BOOK_REPORT_GRID_VIEW_DATA.load_status = "Grid Load";
                lib_book_report_search_percent_l.Text = "0 %";

                try
                {
                    await book_report_bl.Load_Book_Gridview_Data(1);
                }
                catch (HttpRequestException ex)
                {
                    LIB_ERROR_MESSAGE.HttpRequestExceptionMessage(ex);
                }
                catch (Exception ex) { LIB_ERROR_MESSAGE.ExceptionMessage(ex); }

                on_off_refresh = 0;
            }
        }

        #endregion

        #region"Status Bar Panel Event"

        private async void lib_book_report_page_num_go_btn_Click(object sender, EventArgs e)
        {
            string page_num_str = lib_book_report_page_num_tb.Text.Trim();

            if (Int32.TryParse(page_num_str, out int page_num_int))
            {
                if (!paging_status.Equals("Running"))
                {
                    int maxpage = Convert.ToInt32(lib_book_report_page_number_l.Text.Split('/')[1]);

                    paging_status = "Running";

                    if ((page_num_int <= maxpage) && (page_num_int >= 1))
                    {
                        LIB_BOOK_REPORT_BL book_report_bl = new LIB_BOOK_REPORT_BL();

                        this.On_Set_Book_Report_Control += book_report_bl.On_Set_Book_Report_Controls;

                        this.Set_Book_Report_Controls();

                        await book_report_bl.Load_Book_Gridview_Data_By_Page_Num(page_num_int);

                        lib_book_report_page_number_l.Text = (page_num_int) + "/" + maxpage;
                    }

                    paging_status = "";
                }
            }
            else
            {
                MessageBox.Show("Please enter number value in Page Number Box!");
            }
        }

        private async void lib_book_report_paging_previous_btn_Click(object sender, EventArgs e)
        {
            if (!paging_status.Equals("Running"))
            {
                int page_num = Convert.ToInt32(lib_book_report_page_number_l.Text.Split('/')[0]);

                int maxpage = Convert.ToInt32(lib_book_report_page_number_l.Text.Split('/')[1]);

                paging_status = "Running";

                if (page_num > 1)
                {
                    LIB_BOOK_REPORT_BL book_report_bl = new LIB_BOOK_REPORT_BL();

                    this.On_Set_Book_Report_Control += book_report_bl.On_Set_Book_Report_Controls;

                    this.Set_Book_Report_Controls();

                    await book_report_bl.Load_Book_Gridview_Data_By_Page_Num(page_num - 1);

                    lib_book_report_page_number_l.Text = (page_num - 1) + "/" + maxpage;
                }

                paging_status = "";
            }
        }

        private async void lib_book_report_paging_next_btn_Click(object sender, EventArgs e)
        {
            if (!paging_status.Equals("Running"))
            {
                int page_num = Convert.ToInt32(lib_book_report_page_number_l.Text.Split('/')[0]);

                int maxpage = Convert.ToInt32(lib_book_report_page_number_l.Text.Split('/')[1]);

                paging_status = "Running";

                if ((maxpage > 1) && (page_num < maxpage))
                {
                    LIB_BOOK_REPORT_BL book_report_bl = new LIB_BOOK_REPORT_BL();

                    this.On_Set_Book_Report_Control += book_report_bl.On_Set_Book_Report_Controls;

                    this.Set_Book_Report_Controls();

                    await book_report_bl.Load_Book_Gridview_Data_By_Page_Num(page_num + 1);

                    lib_book_report_page_number_l.Text = (page_num + 1) + "/" + maxpage;
                }

                paging_status = "";
            }
        }

        private void lib_book_report_page_num_tb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                lib_book_report_page_num_go_btn_Click(this, EventArgs.Empty);
            }
        }

        #endregion

        #region"Tool Bar Panel Event"

        private void lib_book_report_create_book_btn_Click(object sender, EventArgs e)
        {
            LIB_CREATE_BOOK_FORM create_book = new LIB_CREATE_BOOK_FORM();
            LIB_FORM_STATE _form_state = new LIB_FORM_STATE();

            LIB_FORM_STATE_PARAM form_param = new LIB_FORM_STATE_PARAM()
            {
                form = create_book
            };

            _form_state.Show(form_param);
        }

        private void lib_book_report_edit_book_btn_Click(object sender, EventArgs e)
        {
            if (LIB_BOOK_REPORT_GRID_VIEW_DATA.selected_row_index < 0)
            {
                MessageBox.Show("Please select a Book to Edit!");
            }
            else
            {
                LIB_EDIT_BOOK_FORM edit_book = new LIB_EDIT_BOOK_FORM();
                LIB_FORM_STATE _form_state = new LIB_FORM_STATE();

                LIB_FORM_STATE_PARAM form_param = new LIB_FORM_STATE_PARAM()
                {
                    form = edit_book
                };

                _form_state.Show(form_param);
            }
        }

        private void lib_book_report_create_category_btn_Click(object sender, EventArgs e)
        {
            LIB_CREATE_CATEGORY_FORM create_category = new LIB_CREATE_CATEGORY_FORM();
            LIB_FORM_STATE _form_state = new LIB_FORM_STATE();

            LIB_FORM_STATE_PARAM form_param = new LIB_FORM_STATE_PARAM()
            {
                form = create_category,
            };

            _form_state.Show(form_param);
        }

        private async void lib_book_report_edit_category_btn_Click(object sender, EventArgs e)
        {
            LIB_EDIT_CATEGORY_FORM edit_category = new LIB_EDIT_CATEGORY_FORM();
            LIB_FORM_STATE _form_state = new LIB_FORM_STATE();

            LIB_FORM_STATE_PARAM form_param = new LIB_FORM_STATE_PARAM()
            {
                form = edit_category,
                form_state = LIB_EDIT_CATEGORY_FORM.form_state
            };

            _form_state.form_state_change += edit_category.Form_State_Change_Event;
            _form_state.Show(form_param);

            if (!LIB_EDIT_CATEGORY_FORM.data_entry_process_status.Equals("Running"))
            {                
                LIB_EDIT_CATEGORY_FORM edit_category_open_form = (LIB_EDIT_CATEGORY_FORM) LIB_FORM_STATE.Get_Open_Form("LIB_EDIT_CATEGORY_FORM");
                
                LIB_FORM_CLEAR form_clear = new LIB_FORM_CLEAR();
                form_clear.On_Clear_To_New_Form_Event += edit_category_open_form.On_Clear_To_New_Form;
                form_clear.Form_Clear();

                if (LIB_EDIT_CATEGORY_FORM.data_entry_process_status.Equals("")||
                    LIB_EDIT_CATEGORY_FORM.data_entry_process_status.Equals("Cancelled"))
                {
                    LIB_EDIT_CATEGORY_BL category_bl = new LIB_EDIT_CATEGORY_BL();

                    edit_category_open_form.On_Set_Edit_Category_Data_Entry_Data += category_bl.On_Set_Edit_Category_Data_Entry_Data;
                    category_bl.On_Get_Edit_Category_Data_Entry_Data += edit_category_open_form.On_Notify_Edit_Category_For_Set_Data_Entry_Data;
                    category_bl.On_Set_Edit_Category_Data_Entry_Process_Status += edit_category_open_form.On_Set_Data_Entry_Process_Status;

                    await category_bl.Load_Edit_Category_Data_Entry(edit_category_open_form.data_entry_progress,
                        edit_category_open_form.Cts);
                }
            }       
        }

        #endregion

        #region"Grid View Event"

        private void lib_book_report_grid_view_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                LIB_BOOK_REPORT_GRID_VIEW_DATA.selected_row_index = -1;
                LIB_BOOK_REPORT_GRID_VIEW_DATA.selected_row = null;
            }
            else
            {
                LIB_BOOK_REPORT_GRID_VIEW_DATA.selected_row_index = e.RowIndex;
                LIB_BOOK_REPORT_GRID_VIEW_DATA.selected_row =
                    lib_book_report_grid_view.Rows[e.RowIndex];

                if (LIB_BOOK_REPORT_GRID_VIEW_DATA.selected_row.Cells[0].Value == null)
                {
                    LIB_BOOK_REPORT_GRID_VIEW_DATA.selected_row_index = -1;
                    LIB_BOOK_REPORT_GRID_VIEW_DATA.selected_row = null;
                }
            }
        }

        private void lib_book_report_grid_view_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                LIB_BOOK_REPORT_GRID_VIEW_DATA.selected_row_index = -1;
                LIB_BOOK_REPORT_GRID_VIEW_DATA.selected_row = null;
            }
            else
            {
                LIB_BOOK_REPORT_GRID_VIEW_DATA.selected_row_index = e.RowIndex;
                LIB_BOOK_REPORT_GRID_VIEW_DATA.selected_row =
                    lib_book_report_grid_view.Rows[e.RowIndex];

                if (LIB_BOOK_REPORT_GRID_VIEW_DATA.selected_row.Cells[0].Value == null)
                {
                    LIB_BOOK_REPORT_GRID_VIEW_DATA.selected_row_index = -1;
                    LIB_BOOK_REPORT_GRID_VIEW_DATA.selected_row = null;
                }
            }

            lib_book_report_edit_book_btn_Click(this, EventArgs.Empty);
        }

        #endregion

        private async void lib_book_report_search_tb_TextChanged(object sender, EventArgs e)
        {
            try
            {
                LIB_BOOK_REPORT_BL book_details_bl = new LIB_BOOK_REPORT_BL();

                this.On_Set_Book_Report_Control += book_details_bl.On_Set_Book_Report_Controls;
                this.Set_Book_Report_Controls();

                LIB_BOOK_REPORT_GRID_VIEW_DATA.load_status = "Books Search";

                string word = lib_book_report_search_tb.Text.Trim();
                await book_details_bl.Load_Book_Gridview_Data(1, 0, word);
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
}
