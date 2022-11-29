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
    public partial class LIB_FORGET_PASSWORD_FORM : Form
    {
        public LIB_FORGET_PASSWORD_FORM()
        {
            InitializeComponent();
        }

        private Dictionary<string, string> question_ans { get; set; } = new Dictionary<string, string>();

        #region"Form Load"

        private void LIB_FORGET_PASSWORD_FORM_Load(object sender, EventArgs e)
        {
            LIB_FORM_ANIMATION.Form_Animation(this);
        }

        private void LIB_FORGET_PASSWORD_FORM_MouseDown(object sender, MouseEventArgs e)
        {
            LIB_FORM_ANIMATION.Form_Drag(this, e);
        }

        private void lib_forget_pass_project_title_l_MouseDown(object sender, MouseEventArgs e)
        {
            LIB_FORM_ANIMATION.Form_Drag(this, e);
        }

        #endregion

        private void lib_forget_pass_close_img_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        
        private async void lib_forget_pass_submit_btn_Click(object sender, EventArgs e)
        {
            string user_name = lib_forget_pass_user_name_tb.Text.Trim();
            string ques_ans_count = lib_forget_pass_security_ques_count_l.Text.Trim();

            if (user_name.Equals("")||user_name.Equals("User Name"))
            {
                MessageBox.Show("Please enter user name!");
            }
            else if(lib_forget_pass_security_ques_cb.Items.Count == 0)
            {
                MessageBox.Show("Please enter correct user name!");
            }
            else if (!ques_ans_count.Equals("2/2"))
            {
                MessageBox.Show("You have to answer all questions!");
            }
            else
            {
                try
                {
                    UserModel user = await UserProcessor.LoadUserByName(user_name);

                    if (user != null)
                    {
                        List<SecurityQuestionModel> questions = await SecurityQuestionProcessor.LoadSecurityQuestionsByUserId(user.Id);

                        if (questions.Count != 0)
                        {
                            int correct_count = 0;

                            foreach (SecurityQuestionModel question in questions)
                            {
                                if (correct_count < 2)
                                {
                                    for (int i = 0; i < question_ans.Count; i++)
                                    {
                                        KeyValuePair<string, string> pair_value = question_ans.ElementAt(i);

                                        if ((question.Question == pair_value.Key) && (question.Answer == pair_value.Value))
                                        {
                                            correct_count++;
                                            break;
                                        }                                        
                                    }
                                }                               
                            }

                            if (correct_count == 2)
                            {
                                MessageBox.Show("Your all answers are correct. Set new password.");

                                LIB_NEW_PASSWORD_FORM new_password_form = new LIB_NEW_PASSWORD_FORM(user.Id);
                                new_password_form.Show();
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("Your information is incorrect. Please try again!");

                                lib_forget_pass_clear_btn_Click(this, EventArgs.Empty);
                            }
                        }
                    }                    
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

        private void lib_forget_pass_user_name_tb_Enter(object sender, EventArgs e)
        {
            if (lib_forget_pass_user_name_tb.Text.Equals("User Name"))
            {
                lib_forget_pass_user_name_tb.Text = "";
                lib_forget_pass_user_name_tb.ForeColor = Color.White;
            }
        }

        private void lib_forget_pass_user_name_tb_Leave(object sender, EventArgs e)
        {
            if (lib_forget_pass_user_name_tb.Text.Equals(""))
            {
                lib_forget_pass_user_name_tb.Text = "User Name";
                lib_forget_pass_user_name_tb.ForeColor = Color.DarkGray;
            }
        }

        #endregion

        private async void lib_forget_pass_user_name_tb_TextChanged(object sender, EventArgs e)
        {
            string user_name = lib_forget_pass_user_name_tb.Text.Trim();

            if ((!user_name.Equals("")) && (!user_name.Equals("User Name")))
            {
                try
                {
                    UserModel user = await UserProcessor.LoadUserByName(user_name);

                    if (user != null)
                    {
                        List<SecurityQuestionModel> questions = await SecurityQuestionProcessor.LoadSecurityQuestionsByUserId(user.Id);

                        if (questions.Count != 0)
                        {
                            foreach (SecurityQuestionModel question in questions)
                            {
                                lib_forget_pass_security_ques_cb.Items.Add(question.Question);
                            }

                            if (lib_forget_pass_security_ques_cb.Items.Count != 0)
                            {
                                lib_forget_pass_security_ques_cb.SelectedIndex = 0;
                            }
                        }
                    }
                    else
                    {
                        lib_forget_pass_security_ques_cb.Items.Clear();
                        lib_forget_pass_security_ques_cb.ResetText();
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
            else
            {
                lib_forget_pass_security_ques_cb.Items.Clear();
                lib_forget_pass_security_ques_cb.ResetText();
            }
        }

        private void lib_forget_pass_clear_btn_Click(object sender, EventArgs e)
        {
            lib_forget_pass_user_name_tb.Text = "User Name";
            lib_forget_pass_user_name_tb.ForeColor = Color.DarkGray;
            lib_forget_pass_security_ques_cb.Items.Clear();
            lib_forget_pass_security_ques_cb.ResetText();
            lib_forget_pass_security_ques_ans_tb.Text = "";
            question_ans.Clear();
            lib_forget_pass_security_ques_count_l.Text = "0/2";
        }

        private void lib_forget_pass_security_ques_cb_SelectedIndexChanged(object sender, EventArgs e)
        {
            lib_forget_pass_security_ques_ans_tb.Text = "";
        }

        private void lib_forget_pass_security_ques_ans_tb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string ques_ans = lib_forget_pass_security_ques_ans_tb.Text.Trim();

                if (lib_forget_pass_security_ques_cb.SelectedItem == null)
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
                        string question = lib_forget_pass_security_ques_cb.Items[lib_forget_pass_security_ques_cb.SelectedIndex].ToString();

                        try
                        {
                            question_ans.Add(question, ques_ans);
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("You have already added this question. Please try another one.");
                            return;
                        }

                        lib_forget_pass_security_ques_count_l.Text = question_ans.Count + "/2";

                        lib_forget_pass_security_ques_ans_tb.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("You have completed security questions. You cannot answer any more!");
                    }
                }
            }
        }
    }
}
