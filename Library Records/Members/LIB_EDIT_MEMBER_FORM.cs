using Library_Records.Api_Processor;
using Library_Records.Common_Methods;
using Library_Records.Members.BL_Methods;
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
    public partial class LIB_EDIT_MEMBER_FORM : Form
    {        
        public LIB_EDIT_MEMBER_FORM()
        {
            InitializeComponent();
        }

        DataGridViewRow row;

        private void LIB_EDIT_MEMBER_FORM_Load(object sender, EventArgs e)
        {
            LIB_FORM_ANIMATION.Form_Animation(this);

            if (LIB_MEMBER_REPORT_GRID_VIEW_DATA.selected_row_index < 0)
            {
                MessageBox.Show("Please select a member to edit!");
            }
            else
            {
                row = LIB_MEMBER_REPORT_GRID_VIEW_DATA.selected_row;
                
                lib_edit_member_member_id_tb.Text = row.Cells[0].Value.ToString();
                lib_edit_member_member_name_tb.Text = row.Cells[1].Value.ToString();
                lib_edit_member_roll_no_or_post_tb.Text = row.Cells[2].Value.ToString();
                lib_edit_member_class_or_dep_tb.Text = row.Cells[3].Value.ToString();
            }
        }
        
        #region"Title Bar Panel Event"

        private void lib_edit_member_title_bar_panel_MouseDown(object sender, MouseEventArgs e)
        {
            LIB_FORM_ANIMATION.Form_Drag(this, e);
        }

        private void lib_edit_member_minimize_btn_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void lib_edit_member_close_btn_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion

        #region"Tool Bar Panel Event"

        private void lib_edit_member_cancel_btn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void lib_edit_member_save_btn_Click(object sender, EventArgs e)
        {
            string member_id = lib_edit_member_member_id_tb.Text.Trim();
            string new_member_name = lib_edit_member_member_name_tb.Text.Trim();
            string new_roll_no_or_post = lib_edit_member_roll_no_or_post_tb.Text.Trim();
            string new_class_or_department = lib_edit_member_class_or_dep_tb.Text.Trim();

            if (string.IsNullOrEmpty(member_id))
            {
                MessageBox.Show("This is not a correct member to edit!");
            }
            else if (string.IsNullOrEmpty(new_member_name))
            {
                MessageBox.Show("Please enter member name.");
            }
            else if (string.IsNullOrEmpty(new_roll_no_or_post))
            {
                MessageBox.Show("Please enter roll number or post.");
            }
            else if (string.IsNullOrEmpty(new_class_or_department))
            {
                MessageBox.Show("Please enter class or department.");
            }
            else
            {
                string old_member_name = row.Cells[1].Value.ToString();
                string old_roll_no_or_post = row.Cells[2].Value.ToString();
                string old_class_or_department = row.Cells[3].Value.ToString();

                if (!((old_member_name == new_member_name) && (old_roll_no_or_post == new_roll_no_or_post) &&
                    (old_class_or_department == new_class_or_department)))
                {
                    try
                    {
                        UpdateMemberModel updateMemberModel = new UpdateMemberModel()
                        {
                            MemberId = member_id,
                            MemberName = new_member_name,
                            RNPost = new_roll_no_or_post,
                            ClassDepartment = new_class_or_department
                        };

                        MemberModel member = await MemberProcessor.LoadMemberByMemberId(member_id);

                        await MemberProcessor.ModifyMember(member.Id, updateMemberModel);

                        LIB_MEMBER_REPORT_GRID_VIEW_DATA.load_status = "Grid Load";

                        LIB_MEMBER_REPORT_FORM member_report_form = (LIB_MEMBER_REPORT_FORM)LIB_FORM_STATE
                            .Get_Open_Form("LIB_MEMBER_REPORT_FORM");

                        LIB_MEMBER_REPORT_BL member_report_bl = new LIB_MEMBER_REPORT_BL();
                        member_report_form.On_Set_Member_Report_Control += member_report_bl.On_Set_Member_Report_Controls;

                        member_report_form.Set_Member_Report_Controls();

                        int page_num = Convert.ToInt32(member_report_bl.member_report_gv_page_num_l.Text.Split('/')[0]);

                        await member_report_bl.Load_Member_Gridview_Data(page_num);

                        MessageBox.Show("Member datas have updated successfully.");
                        
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
        }

        private async void lib_edit_member_remove_btn_Click(object sender, EventArgs e)
        {
            string member_id = lib_edit_member_member_id_tb.Text.Trim();

            if (string.IsNullOrEmpty(member_id))
            {
                MessageBox.Show("This is not a correct member to remove.");
            }
            else
            {
                DialogResult dr = MessageBox.Show("Are you sure want to delete this member?", "Warning!", MessageBoxButtons.YesNoCancel,
                        MessageBoxIcon.Warning);

                if (dr == DialogResult.Yes)
                {
                    MemberModel member = await MemberProcessor.LoadMemberByMemberId(member_id);

                    List<RecordModel> records = await RecordProcessor.LoadRecordByMemberId(member.Id);

                    if (records != null)
                    {
                        await MemberProcessor.DeleteMember(member.Id);

                        LIB_MEMBER_REPORT_GRID_VIEW_DATA.load_status = "Grid Load";

                        LIB_MEMBER_REPORT_FORM member_report_form = (LIB_MEMBER_REPORT_FORM)LIB_FORM_STATE
                            .Get_Open_Form("LIB_MEMBER_REPORT_FORM");

                        LIB_MEMBER_REPORT_BL member_report_bl = new LIB_MEMBER_REPORT_BL();
                        member_report_form.On_Set_Member_Report_Control += member_report_bl.On_Set_Member_Report_Controls;

                        member_report_form.Set_Member_Report_Controls();

                        int page_num = Convert.ToInt32(member_report_bl.member_report_gv_page_num_l.Text.Split('/')[0]);

                        await member_report_bl.Load_Member_Gridview_Data(page_num);

                        MessageBox.Show("Member datas have deleted successfully!");

                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("You cannot remove this member because record data is relating with this member data.");
                    }                    
                }
            }
        }

        #endregion             
    }
}
