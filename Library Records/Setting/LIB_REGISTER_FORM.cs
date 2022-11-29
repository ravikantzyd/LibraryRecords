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
    public partial class LIB_REGISTER_FORM : Form
    {
        public LIB_REGISTER_FORM()
        {
            InitializeComponent();
        }

        private Dictionary<string, string> question_ans { get; set; } = new Dictionary<string, string>();

        #region"Form Load"

        private void LIB_REGISTER_FORM_Load(object sender, EventArgs e)
        {
            LIB_FORM_ANIMATION.Form_Animation(this);
        }

        private void LIB_REGISTER_FORM_MouseDown(object sender, MouseEventArgs e)
        {
            LIB_FORM_ANIMATION.Form_Drag(this, e);
        }

        private void lib_register_project_title_l_MouseDown(object sender, MouseEventArgs e)
        {
            LIB_FORM_ANIMATION.Form_Drag(this, e);
        }

        #endregion

        private void lib_register_close_img_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void lib_register_clear_btn_Click(object sender, EventArgs e)
        {
            lib_register_user_name_tb.Text = "User Name";
            lib_register_user_name_tb.ForeColor = Color.DarkGray;
            lib_register_new_password_tb.Text = "New Password";
            lib_register_new_password_tb.ForeColor = Color.DarkGray;
            lib_register_new_password_tb.PasswordChar = '\0';
            lib_register_confirm_password_tb.Text = "Confirm Password";
            lib_register_confirm_password_tb.ForeColor = Color.DarkGray;
            lib_register_confirm_password_tb.PasswordChar = '\0';

            question_ans.Clear();

            lib_register_security_ques_count_l.Text = "0/2";
        }

        private async void lib_register_sign_up_btn_Click(object sender, EventArgs e)
        {
            string user_name = lib_register_user_name_tb.Text.Trim();
            string new_password = lib_register_new_password_tb.Text.Trim();
            string confirm_password = lib_register_confirm_password_tb.Text.Trim();
            string ques_ans_count = lib_register_security_ques_count_l.Text.Trim();

            if(user_name.Equals("")||user_name.Equals("User Name"))
            {
                MessageBox.Show("Please enter user name!");
            }
            else if(new_password.Equals("")||new_password.Equals("New Password"))
            {
                MessageBox.Show("Please enter new password!");
            }
            else if(confirm_password.Equals("")||confirm_password.Equals("Confirm Password"))
            {
                MessageBox.Show("Please enter confrim password!");
            }
            else if (!new_password.Equals(confirm_password))
            {
                MessageBox.Show("Your confirm password is wrong! Please enter correct password.");
            }
            else if (!ques_ans_count.Equals("2/2"))
            {
                MessageBox.Show("You have to answer at least two questions.");
            }
            else
            {
                try
                {
                    CreateUserModel create_user = new CreateUserModel()
                    {
                        UserName = user_name,
                        Password = new_password
                    };

                    UserModel user = await UserProcessor.SetUser(create_user);

                    if (user != null)
                    {
                        for (int i = 0; i < question_ans.Count; i++)
                        {
                            KeyValuePair<string, string> ques_ans_pair = question_ans.ElementAt(i);

                            CreateSecurityQuestionModel question = new CreateSecurityQuestionModel()
                            {
                                Question = ques_ans_pair.Key.ToString(),
                                Answer = ques_ans_pair.Value.ToString(),
                                UserId = user.Id
                            };

                            SecurityQuestionModel question_model = await SecurityQuestionProcessor.SetSecurityQuestion(question);

                            if (question_model != null)
                            {
                                if (i == question_ans.Count - 1)
                                {
                                    MessageBox.Show("You have successfully registered!");

                                    LIB_LOGIN_FORM log_in_form = new LIB_LOGIN_FORM();
                                    log_in_form.Show();
                                    this.Close();
                                }
                            }
                        }
                    }
                }
                catch (HttpRequestException ex)
                {
                    LIB_ERROR_MESSAGE.HttpRequestExceptionMessage(ex);
                }   
                catch(Exception)
                {
                    MessageBox.Show("You have already registered this user!");
                }
            }                       
        }

        #region"Setting Tooltip"

        private void lib_register_user_name_tb_Enter(object sender, EventArgs e)
        {
            if (lib_register_user_name_tb.Text.Trim().Equals("User Name"))
            {
                lib_register_user_name_tb.Text = "";
                lib_register_user_name_tb.ForeColor = Color.White;
            }
        }

        private void lib_register_user_name_tb_Leave(object sender, EventArgs e)
        {
            if (lib_register_user_name_tb.Text.Trim().Equals(""))
            {
                lib_register_user_name_tb.Text = "User Name";
                lib_register_user_name_tb.ForeColor = Color.DarkGray;
            }
        }

        private void lib_register_new_password_tb_Enter(object sender, EventArgs e)
        {
            if (lib_register_new_password_tb.Text.Trim().Equals("New Password"))
            {
                lib_register_new_password_tb.Text = "";
                lib_register_new_password_tb.ForeColor = Color.White;
                lib_register_new_password_tb.PasswordChar = '*';
            }
        }

        private void lib_register_new_password_tb_Leave(object sender, EventArgs e)
        {
            if (lib_register_new_password_tb.Text.Trim().Equals(""))
            {
                lib_register_new_password_tb.Text = "New Password";
                lib_register_new_password_tb.ForeColor = Color.DarkGray;
                lib_register_new_password_tb.PasswordChar = '\0';
            }
        }

        private void lib_register_confirm_password_tb_Enter(object sender, EventArgs e)
        {
            if (lib_register_confirm_password_tb.Text.Trim().Equals("Confirm Password"))
            {
                lib_register_confirm_password_tb.Text = "";
                lib_register_confirm_password_tb.ForeColor = Color.White;
                lib_register_confirm_password_tb.PasswordChar = '*';
            }
        }

        private void lib_register_confirm_password_tb_Leave(object sender, EventArgs e)
        {
            if (lib_register_confirm_password_tb.Text.Trim().Equals(""))
            {
                lib_register_confirm_password_tb.Text = "Confirm Password";
                lib_register_confirm_password_tb.ForeColor = Color.DarkGray;
                lib_register_confirm_password_tb.PasswordChar = '\0';
            }
        }

        #endregion

        private void lib_register_security_ques_ans_tb_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                string ques_ans = lib_register_security_ques_ans_tb.Text.Trim();

                if(lib_register_security_ques_cb.SelectedItem == null)
                {
                    MessageBox.Show("Please select a correct Security Question!");
                }
                else if (ques_ans.Equals(""))
                {
                    MessageBox.Show("Please answer this question. You cannot keep this blank!");
                }
                else
                {
                    if (question_ans.Count < 2)
                    {
                        string question = lib_register_security_ques_cb.Items[lib_register_security_ques_cb.SelectedIndex].ToString();

                        try
                        {
                            question_ans.Add(question, ques_ans);
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("You have already added this question. Please try another one.");
                            return;
                        }                        

                        lib_register_security_ques_count_l.Text = question_ans.Count + "/2";

                        lib_register_security_ques_ans_tb.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("You have completed security questions. You cannot answer any more!");
                    }
                }
            }
        }

        private void lib_register_security_ques_cb_SelectedIndexChanged(object sender, EventArgs e)
        {
            lib_register_security_ques_ans_tb.Text = "";
        }
    }
}
