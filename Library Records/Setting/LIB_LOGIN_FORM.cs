using Library_Records.Api_Common_Methods;
using Library_Records.Api_Processor;
using Library_Records.Common_Methods;
using Library_Records.Main;
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
    public partial class LIB_LOGIN_FORM : Form
    {
        public LIB_LOGIN_FORM()
        {
            InitializeComponent();
        }

        #region"Form Load"

        private void LIB_LOGIN_FORM_Load(object sender, EventArgs e)
        {
            LIB_FORM_ANIMATION.Form_Animation(this);
            ApiHelper.InitializeClient();
        }

        private void LIB_LOGIN_FORM_MouseDown(object sender, MouseEventArgs e)
        {
            LIB_FORM_ANIMATION.Form_Drag(this, e);
        }

        private void lib_login_project_title_l_MouseDown(object sender, MouseEventArgs e)
        {
            LIB_FORM_ANIMATION.Form_Drag(this, e);
        }

        #endregion

        private void lib_login_close_img_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void lib_login_clear_btn_Click(object sender, EventArgs e)
        {            
            lib_login_user_name_tb.Text = "User Name";
            lib_login_user_name_tb.ForeColor = Color.DarkGray;
            lib_login_password_tb.Text = "Password";
            lib_login_password_tb.ForeColor = Color.DarkGray;
            lib_login_password_tb.PasswordChar = '\0';
        }

        private async void lib_login_login_btn_Click(object sender, EventArgs e)
        {
            string user_name = lib_login_user_name_tb.Text.Trim();
            string password = lib_login_password_tb.Text.Trim();

            if (user_name.Equals("") || user_name.Equals("User Name"))
            {
                MessageBox.Show("Please enter user name!");
            }
            else if (password.Equals("") || password.Equals("Password"))
            {
                MessageBox.Show("Please enter correct password!");
            }
            else
            {
                try
                {
                    List<UserModel> users = await UserProcessor.LoadUsers();

                    if ((users != null) && (users.Count != 0))
                    {
                        UserModel user = users.Where(u => (u.UserName == user_name) && (u.Password == password)).FirstOrDefault();

                        if (user != null)
                        {
                            MessageBox.Show(user.UserName + " has logged in successfully!");

                            LIB_USER_INFO.user_id = user.Id;
                            LIB_USER_INFO.user_name = user.UserName;
                            LIB_USER_INFO.password = user.Password;

                            LIB_MAIN_FORM lib_main_form = new LIB_MAIN_FORM();
                            lib_main_form.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Your user name or password is wrong!");
                        }
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

        private void lib_login_forget_pass_link_l_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LIB_FORGET_PASSWORD_FORM lib_forget_password = new LIB_FORGET_PASSWORD_FORM();
            lib_forget_password.Show();
            this.Hide();
        }

        private void lib_login_register_link_l_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LIB_REGISTER_FORM lib_register_form=new LIB_REGISTER_FORM();
            lib_register_form.Show();
            this.Hide();
        }

        #region"Setting Tooltip"

        private void lib_login_user_name_tb_Enter(object sender, EventArgs e)
        {
            if (lib_login_user_name_tb.Text.Equals("User Name"))
            {
                lib_login_user_name_tb.Text = "";
                lib_login_user_name_tb.ForeColor = Color.White;
            }
        }

        private void lib_login_user_name_tb_Leave(object sender, EventArgs e)
        {
            if (lib_login_user_name_tb.Text.Equals(""))
            {
                lib_login_user_name_tb.Text = "User Name";
                lib_login_user_name_tb.ForeColor = Color.DarkGray;
            }
        }

        private void lib_login_password_tb_Enter(object sender, EventArgs e)
        {
            if (lib_login_password_tb.Text.Equals("Password"))
            {
                lib_login_password_tb.Text = "";
                lib_login_password_tb.ForeColor = Color.White;
                lib_login_password_tb.PasswordChar = '*';
            }
        }

        private void lib_login_password_tb_Leave(object sender, EventArgs e)
        {
            if (lib_login_password_tb.Text.Equals(""))
            {
                lib_login_password_tb.Text = "Password";
                lib_login_password_tb.ForeColor = Color.DarkGray;
                lib_login_password_tb.PasswordChar = '\0';
            }
        }

        #endregion
    }
}
