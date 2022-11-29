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
    public partial class LIB_CREATE_MEMBER_FORM : Form
    {
        public LIB_CREATE_MEMBER_FORM()
        {
            InitializeComponent();
        }

        private void LIB_CREATE_MEMBER_FORM_Load(object sender, EventArgs e)
        {
            LIB_FORM_ANIMATION.Form_Animation(this);
        }

        #region"Title Bar Panel Event"

        private void shopfy_create_customer_title_bar_panel_MouseDown(object sender, MouseEventArgs e)
        {
            LIB_FORM_ANIMATION.Form_Drag(this, e);
        }

        private void shopfy_create_customer_minimize_btn_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void shopfy_create_customer_close_btn_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion

        #region"Tool Bar Event"

        private void lib_create_member_cancel_btn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void lib_create_member_add_btn_Click(object sender, EventArgs e)
        {
            string member_id = lib_create_member_member_id_tb.Text.Trim();
            string member_name=lib_create_member_member_name_tb.Text.Trim();
            string rollno_post = lib_create_member_roll_no_or_post_tb.Text.Trim();
            string class_or_dep=lib_create_member_class_or_dep_tb.Text.Trim();

            if (string.IsNullOrEmpty(member_id))
            {
                MessageBox.Show("Please enter member id.");
            }
            else if (string.IsNullOrEmpty(member_name))
            {
                MessageBox.Show("Please enter member name.");
            }
            else if (string.IsNullOrEmpty(rollno_post))
            {
                MessageBox.Show("Please enter roll number or post.");
            }
            else if (string.IsNullOrEmpty(class_or_dep))
            {
                MessageBox.Show("Please enter class or departmernt.");
            }
            else
            {
                try
                {
                    CreateMemberModel createMemberModel = new CreateMemberModel()
                    {
                        MemberId = member_id,
                        MemberName = member_name,
                        RNPost = rollno_post,
                        ClassDepartment = class_or_dep
                    };

                    await MemberProcessor.SetMember(createMemberModel);

                    LIB_MEMBER_REPORT_GRID_VIEW_DATA.load_status = "Members Added";

                    LIB_MEMBER_REPORT_FORM member_report_form = (LIB_MEMBER_REPORT_FORM)LIB_FORM_STATE.Get_Open_Form("LIB_MEMBER_REPORT_FORM");

                    if (member_report_form != null)
                    {
                        LIB_MEMBER_REPORT_BL member_report_bl = new LIB_MEMBER_REPORT_BL();
                        member_report_form.On_Set_Member_Report_Control += member_report_bl.On_Set_Member_Report_Controls;

                        member_report_form.Set_Member_Report_Controls();

                        await member_report_bl.Load_Member_Gridview_Data(1);
                    }

                    MessageBox.Show("You have created a member successfully.");

                    this.Close();
                }
                catch (HttpRequestException ex)
                {
                    LIB_ERROR_MESSAGE.HttpRequestExceptionMessage(ex);
                }
                catch (Exception)
                {
                    MessageBox.Show("This member id is already exit.");
                }                
            }
        }

        #endregion        
    }
}
