using Library_Records.Common_Methods;
using Library_Records.Main;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library_Records.Setting
{
    public partial class LIB_SETTING_FORM : Form
    {
        public LIB_SETTING_FORM()
        {
            InitializeComponent();
        }

        private void lib_setting_change_pass_link_l_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LIB_RESET_PASSWORD_FORM reset_password_form = new LIB_RESET_PASSWORD_FORM();
            reset_password_form.Show();            
        }        
    }
}
