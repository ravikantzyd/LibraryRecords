using Library_Records.Api_Processor;
using Library_Records.Members.BL_Methods.BL_Input_Params;
using Library_Records.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library_Records.Members.BL_Methods
{
    public class LIB_MEMBER_REPORT_BL
    {
        #region"Shopfy Member Report BL Declaration"

        private DataGridView member_report_gv = new DataGridView();
        public System.Windows.Forms.Label total_member_amount_l { get; set; } = new System.Windows.Forms.Label();
        public System.Windows.Forms.Label total_member_equal_l { get; set; } = new System.Windows.Forms.Label();
        private System.Windows.Forms.Label total_member_l = new System.Windows.Forms.Label();
        public System.Windows.Forms.Label member_report_gv_page_num_l = new System.Windows.Forms.Label();

        #endregion

        public async Task Load_Member_Gridview_Data(int page_num_param, int member_id = 0, string search_word = "")
        {
            int maxpage = 1;
            total_member_l.Visible = true;
            total_member_equal_l.Visible = true;
            total_member_amount_l.Visible = true;

            if (LIB_MEMBER_REPORT_GRID_VIEW_DATA.load_status.Equals("Members Added"))
            {
                LIB_MEMBER_REPORT_GRID_VIEW_DATA.member_list =
                    await MemberProcessor.LoadMembersByDecending();
            }
            else if (LIB_MEMBER_REPORT_GRID_VIEW_DATA.load_status.Equals("Members Search"))
            {
                total_member_equal_l.Visible = false;
                total_member_amount_l.Visible = false;
                total_member_l.Visible = false;

                LIB_MEMBER_REPORT_GRID_VIEW_DATA.member_list =
                    await MemberProcessor.LoadMemberBySearch(search_word);
            }
            else
            {
                LIB_MEMBER_REPORT_GRID_VIEW_DATA.member_list =
                    await MemberProcessor.LoadMembers();
            }

            int member_list_count = LIB_MEMBER_REPORT_GRID_VIEW_DATA.member_list.Count;

            if (member_list_count != 0)
            {
                if (member_list_count < 20)
                {
                    maxpage = 1;
                }
                else
                {
                    maxpage = member_list_count / 20;

                    if (member_list_count % 20 != 0)
                    {
                        maxpage += 1;
                    }
                }
            }

            string page_num = page_num_param + "/" + maxpage;

            member_report_gv_page_num_l.Text = page_num;
            total_member_amount_l.Text = member_list_count.ToString();

            await Load_Member_Gridview_Data_By_Page_Num(page_num_param);
        }

        public async Task Load_Member_Gridview_Data_By_Page_Num(int page_num)
        {
            List<MemberModel> member_list = LIB_MEMBER_REPORT_GRID_VIEW_DATA.member_list
                .Skip((page_num - 1) * 20).Take(20).ToList();

            member_report_gv.Rows.Clear();
            LIB_MEMBER_REPORT_GRID_VIEW_DATA.selected_row_index = -1;
            LIB_MEMBER_REPORT_GRID_VIEW_DATA.selected_row = null;

            List<DataGridViewRow> dataGridViewRows = new List<DataGridViewRow>();

            for (int i = 0; i < member_list.Count; i++)
            {                
                DataGridViewRow dataGridViewRow = new DataGridViewRow();
                dataGridViewRow.Height = 28;
                dataGridViewRow.Cells.Add(new DataGridViewTextBoxCell());
                dataGridViewRow.Cells[0].Value = member_list[i].MemberId;
                dataGridViewRow.Cells.Add(new DataGridViewTextBoxCell());
                dataGridViewRow.Cells[1].Value = member_list[i].MemberName;
                dataGridViewRow.Cells.Add(new DataGridViewTextBoxCell());
                dataGridViewRow.Cells[2].Value = member_list[i].RNPost;
                dataGridViewRow.Cells.Add(new DataGridViewTextBoxCell());
                dataGridViewRow.Cells[3].Value = member_list[i].ClassDepartment;

                dataGridViewRows.Add(dataGridViewRow);
            }

            await Task.Run(() => {

                if (member_report_gv.InvokeRequired)
                {
                    member_report_gv.Invoke(new System.Action(() =>
                    {
                        member_report_gv.Rows.AddRange(dataGridViewRows.ToArray());
                    }));
                }

                Thread.Sleep(100);
            });
        }
        
        public void On_Set_Member_Report_Controls(object sender, LIB_MEMBER_REPORT_SET_CONTROL_EVENT_ARGS event_args)
        {
            member_report_gv = event_args.grid_view;
            member_report_gv_page_num_l = event_args.grid_view_page_num_l;
            total_member_l = event_args.total_member_l;
            total_member_amount_l = event_args.total_member_amount_l;
            total_member_equal_l = event_args.total_member_equal_l;
        }
    }
}
