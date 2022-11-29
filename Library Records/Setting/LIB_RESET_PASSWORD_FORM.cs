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

namespace Library_Records.Setting
{
    public partial class LIB_RESET_PASSWORD_FORM : Form
    {
        public LIB_RESET_PASSWORD_FORM()
        {
            InitializeComponent();
        }

        #region"Form Load"

        private void LIB_RESET_PASSWORD_FORM_Load(object sender, EventArgs e)
        {
            LIB_FORM_ANIMATION.Form_Animation(this);
        }

        private void LIB_RESET_PASSWORD_FORM_MouseDown(object sender, MouseEventArgs e)
        {
            LIB_FORM_ANIMATION.Form_Drag(this, e);
        }

        private void lib_reset_pass_project_title_l_MouseDown(object sender, MouseEventArgs e)
        {
            LIB_FORM_ANIMATION.Form_Drag(this, e);
        }

        #endregion

        private void lib_reset_pass_close_img_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private async void lib_reset_pass_save_btn_Click(object sender, EventArgs e)
        {
            string old_password = lib_reset_pass_old_password_tb.Text.Trim();
            string new_password = lib_reset_pass_new_password_tb.Text.Trim();
            string confirm_password = lib_reset_pass_confirm_password_tb.Text.Trim();

            if (string.IsNullOrEmpty(old_password)||(old_password.Equals("Old Password")))
            {
                MessageBox.Show("Please enter old password.");
            }
            else if (string.IsNullOrEmpty(new_password)||new_password.Equals("New Password"))
            {
                MessageBox.Show("Please enter new password.");
            }
            else if (string.IsNullOrEmpty(confirm_password)||confirm_password.Equals("Confirm Password"))
            {
                MessageBox.Show("Please enter confirm password.");
            }
            else if(!old_password.Equals(LIB_USER_INFO.password))
            {
                MessageBox.Show("Your old password is wrong.");
            }
            else if(!new_password.Equals(confirm_password))
            {
                MessageBox.Show("Your confirm password is wrong.");
            }
            else
            {
                try
                {
                    UpdateUserModel updateUserModel = new UpdateUserModel()
                    {
                        UserName = LIB_USER_INFO.user_name,
                        Password = new_password
                    };

                    await UserProcessor.ModifyUser(LIB_USER_INFO.user_id, updateUserModel);

                    LIB_USER_INFO.password = new_password;

                    MessageBox.Show("Your password has reset successfully!");
                    
                    this.Close();
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

        #region"Setting Tooltip"

        private void lib_reset_pass_old_password_tb_Enter(object sender, EventArgs e)
        {
            if (lib_reset_pass_old_password_tb.Text.Trim().Equals("Old Password"))
            {
                lib_reset_pass_old_password_tb.Text = "";
                lib_reset_pass_old_password_tb.ForeColor = Color.White;
                lib_reset_pass_old_password_tb.PasswordChar = '*';
            }
        }

        private void lib_reset_pass_old_password_tb_Leave(object sender, EventArgs e)
        {
            if (lib_reset_pass_old_password_tb.Text.Trim().Equals(""))
            {
                lib_reset_pass_old_password_tb.Text = "Old Password";
                lib_reset_pass_old_password_tb.ForeColor = Color.DarkGray;
                lib_reset_pass_old_password_tb.PasswordChar = '\0';
            }
        }

        private void lib_reset_pass_new_password_tb_Enter(object sender, EventArgs e)
        {
            if (lib_reset_pass_new_password_tb.Text.Trim().Equals("New Password"))
            {
                lib_reset_pass_new_password_tb.Text = "";
                lib_reset_pass_new_password_tb.ForeColor = Color.White;
                lib_reset_pass_new_password_tb.PasswordChar = '*';
            }
        }

        private void lib_reset_pass_new_password_tb_Leave(object sender, EventArgs e)
        {
            if (lib_reset_pass_new_password_tb.Text.Trim().Equals(""))
            {
                lib_reset_pass_new_password_tb.Text = "New Password";
                lib_reset_pass_new_password_tb.ForeColor = Color.DarkGray;
                lib_reset_pass_new_password_tb.PasswordChar = '\0';
            }
        }

        private void lib_reset_pass_confirm_password_tb_Enter(object sender, EventArgs e)
        {
            if (lib_reset_pass_confirm_password_tb.Text.Trim().Equals("Confirm Password"))
            {
                lib_reset_pass_confirm_password_tb.Text = "";
                lib_reset_pass_confirm_password_tb.ForeColor = Color.White;
                lib_reset_pass_confirm_password_tb.PasswordChar = '*';
            }
        }

        private void lib_reset_pass_confirm_password_tb_Leave(object sender, EventArgs e)
        {
            if (lib_reset_pass_confirm_password_tb.Text.Trim().Equals(""))
            {
                lib_reset_pass_confirm_password_tb.Text = "Confirm Password";
                lib_reset_pass_confirm_password_tb.ForeColor = Color.DarkGray;
                lib_reset_pass_confirm_password_tb.PasswordChar = '\0';
            }
        }

        #endregion
    }
}
