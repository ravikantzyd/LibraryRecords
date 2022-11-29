using Library_Records.Api_Processor;
using Library_Records.Common_Methods;
using Library_Records.Common_Methods.Input_Parameters;
using Library_Records.Members.BL_Methods;
using Library_Records.Members.BL_Methods.BL_Input_Params;
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

namespace Library_Records.Members
{
    public partial class LIB_MEMBER_REPORT_FORM : Form
    {
        #region"Class Variable Decalration"

        public Progress<ProgressReport> general_search_cb_progress { get; } = new Progress<ProgressReport>();

        public event EventHandler<LIB_MEMBER_REPORT_SET_CONTROL_EVENT_ARGS> On_Set_Member_Report_Control;
        public string paging_status { get; set; } = "";

        public int on_off_refresh { get; set; } = 0;
        public int on_off_excel { get; set; } = 0;
        public int on_off_cb { get; set; } = 0;

        #endregion

        public LIB_MEMBER_REPORT_FORM()
        {
            InitializeComponent();
            general_search_cb_progress.ProgressChanged += General_Search_Cb_Progress_Report;
        }
        
        private async void LIB_MEMBERS_REPORT_FORM_Load(object sender, EventArgs e)
        {
            LIB_MEMBER_REPORT_BL member_report_bl = new LIB_MEMBER_REPORT_BL();

            this.On_Set_Member_Report_Control += member_report_bl.On_Set_Member_Report_Controls;
            this.Set_Member_Report_Controls();

            LIB_MEMBER_REPORT_GRID_VIEW_DATA.load_status = "Grid Load";

            try
            {
                await member_report_bl.Load_Member_Gridview_Data(1);
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
            lib_member_report_search_percent_l.Text = string.Format("{0} %", e.ProgressPercent);
        }

        public void Set_Member_Report_Controls()
        {
            LIB_MEMBER_REPORT_SET_CONTROL_EVENT_ARGS event_args = new LIB_MEMBER_REPORT_SET_CONTROL_EVENT_ARGS
            {
                grid_view = this.lib_member_report_grid_view,
                grid_view_page_num_l = lib_member_report_page_number_l,
                total_member_l = lib_member_report_total_member_l,
                total_member_amount_l = lib_member_report_total_member_amount_l,
                total_member_equal_l = lib_member_report_total_member_equal_l
            };

            On_Set_Member_Report_Control?.Invoke(this, event_args);
        }

        #endregion

        #region"Title Bar Panel Event"
        
        private async void lib_member_report_refresh_btn_Click(object sender, EventArgs e)
        {
            if (on_off_refresh == 0)
            {
                on_off_refresh = 1;

                LIB_MEMBER_REPORT_BL member_report_bl = new LIB_MEMBER_REPORT_BL();

                this.On_Set_Member_Report_Control += member_report_bl.On_Set_Member_Report_Controls;
                this.Set_Member_Report_Controls();

                LIB_MEMBER_REPORT_GRID_VIEW_DATA.load_status = "Grid Load";
                lib_member_report_search_percent_l.Text = "0 %";

                try
                {
                    await member_report_bl.Load_Member_Gridview_Data(1);
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

        private async void lib_member_report_page_num_go_btn_Click(object sender, EventArgs e)
        {
            string page_num_str = lib_member_report_page_num_tb.Text.Trim();

            if (Int32.TryParse(page_num_str, out int page_num_int))
            {
                if (!paging_status.Equals("Running"))
                {
                    int maxpage = Convert.ToInt32(lib_member_report_page_number_l.Text.Split('/')[1]);

                    paging_status = "Running";

                    if ((page_num_int <= maxpage) && (page_num_int >= 1))
                    {
                        LIB_MEMBER_REPORT_BL member_report_bl = new LIB_MEMBER_REPORT_BL();

                        this.On_Set_Member_Report_Control += member_report_bl.On_Set_Member_Report_Controls;

                        this.Set_Member_Report_Controls();

                        await member_report_bl.Load_Member_Gridview_Data_By_Page_Num(page_num_int);

                        lib_member_report_page_number_l.Text = (page_num_int) + "/" + maxpage;
                    }

                    paging_status = "";
                }
            }
            else
            {
                MessageBox.Show("Please enter number value in Page Number Box!");
            }
        }

        private void lib_member_report_page_num_tb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                lib_member_report_page_num_go_btn_Click(this, EventArgs.Empty);
            }
        }

        private async void lib_member_report_paging_previous_btn_Click(object sender, EventArgs e)
        {
            if (!paging_status.Equals("Running"))
            {
                int page_num = Convert.ToInt32(lib_member_report_page_number_l.Text.Split('/')[0]);

                int maxpage = Convert.ToInt32(lib_member_report_page_number_l.Text.Split('/')[1]);

                paging_status = "Running";

                if (page_num > 1)
                {
                    LIB_MEMBER_REPORT_BL member_report_bl = new LIB_MEMBER_REPORT_BL();

                    this.On_Set_Member_Report_Control += member_report_bl.On_Set_Member_Report_Controls;

                    this.Set_Member_Report_Controls();

                    await member_report_bl.Load_Member_Gridview_Data_By_Page_Num(page_num - 1);

                    lib_member_report_page_number_l.Text = (page_num - 1) + "/" + maxpage;
                }

                paging_status = "";
            }
        }

        private async void lib_member_report_paging_next_btn_Click(object sender, EventArgs e)
        {
            if (!paging_status.Equals("Running"))
            {
                int page_num = Convert.ToInt32(lib_member_report_page_number_l.Text.Split('/')[0]);

                int maxpage = Convert.ToInt32(lib_member_report_page_number_l.Text.Split('/')[1]);

                paging_status = "Running";

                if ((maxpage > 1) && (page_num < maxpage))
                {
                    LIB_MEMBER_REPORT_BL member_report_bl = new LIB_MEMBER_REPORT_BL();

                    this.On_Set_Member_Report_Control += member_report_bl.On_Set_Member_Report_Controls;

                    this.Set_Member_Report_Controls();

                    await member_report_bl.Load_Member_Gridview_Data_By_Page_Num(page_num + 1);

                    lib_member_report_page_number_l.Text = (page_num + 1) + "/" + maxpage;
                }

                paging_status = "";
            }
        }

        #endregion

        #region"Tool Bar Panel Event"
        
        private void lib_member_report_create_member_btn_Click(object sender, EventArgs e)
        {
            LIB_CREATE_MEMBER_FORM create_member = new LIB_CREATE_MEMBER_FORM();
            LIB_FORM_STATE _form_state = new LIB_FORM_STATE();

            LIB_FORM_STATE_PARAM form_param = new LIB_FORM_STATE_PARAM()
            {
                form = create_member
            };

            _form_state.Show(form_param);
        }

        private void lib_member_report_edit_member_btn_Click(object sender, EventArgs e)
        {
            if (LIB_MEMBER_REPORT_GRID_VIEW_DATA.selected_row_index < 0)
            {
                MessageBox.Show("Please select a Member to Edit!");
            }
            else
            {
                LIB_EDIT_MEMBER_FORM edit_member = new LIB_EDIT_MEMBER_FORM();
                LIB_FORM_STATE _form_state = new LIB_FORM_STATE();

                LIB_FORM_STATE_PARAM form_param = new LIB_FORM_STATE_PARAM()
                {
                    form = edit_member
                };

                _form_state.Show(form_param);
            }
        }

        #endregion

        private void lib_member_report_grid_view_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                LIB_MEMBER_REPORT_GRID_VIEW_DATA.selected_row_index = -1;
                LIB_MEMBER_REPORT_GRID_VIEW_DATA.selected_row = null;
            }
            else
            {
                LIB_MEMBER_REPORT_GRID_VIEW_DATA.selected_row_index = e.RowIndex;
                LIB_MEMBER_REPORT_GRID_VIEW_DATA.selected_row =
                    lib_member_report_grid_view.Rows[e.RowIndex];

                if (LIB_MEMBER_REPORT_GRID_VIEW_DATA.selected_row.Cells[0].Value == null)
                {
                    LIB_MEMBER_REPORT_GRID_VIEW_DATA.selected_row_index = -1;
                    LIB_MEMBER_REPORT_GRID_VIEW_DATA.selected_row = null;
                }
            }
        }

        private void lib_member_report_grid_view_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                LIB_MEMBER_REPORT_GRID_VIEW_DATA.selected_row_index = -1;
                LIB_MEMBER_REPORT_GRID_VIEW_DATA.selected_row = null;
            }
            else
            {
                LIB_MEMBER_REPORT_GRID_VIEW_DATA.selected_row_index = e.RowIndex;
                LIB_MEMBER_REPORT_GRID_VIEW_DATA.selected_row =
                    lib_member_report_grid_view.Rows[e.RowIndex];

                if (LIB_MEMBER_REPORT_GRID_VIEW_DATA.selected_row.Cells[0].Value == null)
                {
                    LIB_MEMBER_REPORT_GRID_VIEW_DATA.selected_row_index = -1;
                    LIB_MEMBER_REPORT_GRID_VIEW_DATA.selected_row = null;
                }
            }

            lib_member_report_edit_member_btn_Click(this, EventArgs.Empty);
        }

        private async void lib_member_report_search_tb_TextChanged(object sender, EventArgs e)
        {
            try
            {                
                LIB_MEMBER_REPORT_BL product_details_bl = new LIB_MEMBER_REPORT_BL();

                this.On_Set_Member_Report_Control += product_details_bl.On_Set_Member_Report_Controls;
                this.Set_Member_Report_Controls();

                LIB_MEMBER_REPORT_GRID_VIEW_DATA.load_status = "Members Search";

                string word = lib_member_report_search_tb.Text.Trim();
                await product_details_bl.Load_Member_Gridview_Data(1, 0, word);
            }
            catch (HttpRequestException ex)
            {
                LIB_ERROR_MESSAGE.HttpRequestExceptionMessage(ex);
            }
            catch (Exception ex) { LIB_ERROR_MESSAGE.ExceptionMessage(ex); }
        }
    }
}
