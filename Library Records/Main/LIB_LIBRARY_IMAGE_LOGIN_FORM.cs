using Library_Records.Common_Methods;
using Library_Records.Setting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library_Records.Main
{
    public partial class LIB_LIBRARY_IMAGE_LOGIN_FORM : Form
    {
        public LIB_LIBRARY_IMAGE_LOGIN_FORM()
        {
            InitializeComponent();
        }

        #region"To create round corner window"

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
            (
                int nLeftRect,
                int nTopRect,
                int nRightRect,
                int nBottomRect,
                int nWidthEllipse,
                int nHeightEllipse
            );

        /* Write 'Region code in Shopfy_Main_Form constructor' */
        //Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));

        #endregion

        private void LIB_LIBRARY_IMAGE_LOGIN_FORM_Load(object sender, EventArgs e)
        {
            LIB_FORM_ANIMATION.Form_Animation(this);
        }

        private void shopfy_create_customer_close_btn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            LIB_FORM_ANIMATION.Form_Drag(this, e);            
        }

        private void lib_login_login_btn_Click(object sender, EventArgs e)
        {
            LIB_LOGIN_FORM log_in = new LIB_LOGIN_FORM();
            log_in.Show();
            this.Hide();
        }

        private void lib_login_login_btn_Paint(object sender, PaintEventArgs e)
        {
            lib_login_login_btn.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, 190,60, 50, 50));
        }
    }
}
