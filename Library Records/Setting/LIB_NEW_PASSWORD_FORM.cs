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
    public partial class LIB_NEW_PASSWORD_FORM : Form
    {
        public int user_id { get; set; } = 0;

        public LIB_NEW_PASSWORD_FORM(int _user_id)
        {
            InitializeComponent();
            user_id = _user_id;
        }

        #region"Form Load"

        private void LIB_NEW_PASSWORD_FORM_Load(object sender, EventArgs e)
        {
            LIB_FORM_ANIMATION.Form_Animation(this);
        }        

        private void LIB_NEW_PASSWORD_FORM_MouseDown(object sender, MouseEventArgs e)
        {
            LIB_FORM_ANIMATION.Form_Drag(this, e);
        }

        private void lib_new_pass_project_title_l_MouseDown(object sender, MouseEventArgs e)
        {
            LIB_FORM_ANIMATION.Form_Drag(this, e);
        }

        #endregion

        private void lib_new_pass_close_img_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private async void lib_new_pass_save_btn_Click(object sender, EventArgs e)
        {
            string new_password = lib_new_pass_new_password_tb.Text.Trim();
            string confirm_password = lib_new_pass_confirm_password_tb.Text.Trim();
            
            if(new_password.Equals("")||new_password.Equals("New Password"))
            {
                MessageBox.Show("Please enter new password.");
            }     
            else if(confirm_password.Equals("")||confirm_password.Equals("Confirm Password"))
            {
                MessageBox.Show("Please enter confirm password.");
            }
            else if (new_password != confirm_password)
            {
                MessageBox.Show("Your confirm is wrong. Please enter correct password.");
            }
            else
            {
                try
                {
                    UserModel user = await UserProcessor.LoadUser(user_id);

                    if (user != null)
                    {
                        UpdateUserModel updateUserModel = new UpdateUserModel()
                        {
                            UserName = user.UserName,
                            Password = new_password
                        };

                        await UserProcessor.ModifyUser(user_id, updateUserModel);

                        LIB_USER_INFO.password = new_password;

                        MessageBox.Show("Password changed successfull!");

                        LIB_LOGIN_FORM log_in_form = new LIB_LOGIN_FORM();
                        log_in_form.Show();
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

        #region"Setting Tooltip"

        private void lib_new_pass_new_password_tb_Enter(object sender, EventArgs e)
        {
            if (lib_new_pass_new_password_tb.Text.Trim().Equals("New Password"))
            {
                lib_new_pass_new_password_tb.Text = "";
                lib_new_pass_new_password_tb.ForeColor = Color.White;
                lib_new_pass_new_password_tb.PasswordChar = '*';
            }
        }

        private void lib_new_pass_new_password_tb_Leave(object sender, EventArgs e)
        {
            if (lib_new_pass_new_password_tb.Text.Trim().Equals(""))
            {
                lib_new_pass_new_password_tb.Text = "New Password";
                lib_new_pass_new_password_tb.ForeColor = Color.DarkGray;
                lib_new_pass_new_password_tb.PasswordChar = '\0';
            }
        }

        private void lib_new_pass_confirm_password_tb_Enter(object sender, EventArgs e)
        {
            if (lib_new_pass_confirm_password_tb.Text.Trim().Equals("Confirm Password"))
            {
                lib_new_pass_confirm_password_tb.Text = "";
                lib_new_pass_confirm_password_tb.ForeColor = Color.White;
                lib_new_pass_confirm_password_tb.PasswordChar = '*';
            }
        }

        private void lib_new_pass_confirm_password_tb_Leave(object sender, EventArgs e)
        {
            if (lib_new_pass_confirm_password_tb.Text.Trim().Equals(""))
            {
                lib_new_pass_confirm_password_tb.Text = "Confirm Password";
                lib_new_pass_confirm_password_tb.ForeColor = Color.DarkGray;
                lib_new_pass_confirm_password_tb.PasswordChar = '\0';
            }
        }

        #endregion

        private void lib_new_pass_clear_btn_Click(object sender, EventArgs e)
        {
            lib_new_pass_new_password_tb.Text = "New Password";
            lib_new_pass_new_password_tb.ForeColor = Color.DarkGray;
            lib_new_pass_new_password_tb.PasswordChar = '\0';
            lib_new_pass_confirm_password_tb.Text = "Confirm Password";
            lib_new_pass_confirm_password_tb.ForeColor = Color.DarkGray;
            lib_new_pass_confirm_password_tb.PasswordChar = '\0';
        }
    }
}
