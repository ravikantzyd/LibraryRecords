using Library_Records.Books;
using Library_Records.Common_Methods;
using Library_Records.Main.Input_Parameters;
using Library_Records.Main.UI_Control_Functions;
using Library_Records.Members;
using Library_Records.Records;
using Library_Records.Setting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library_Records.Main
{
    public partial class LIB_MAIN_FORM : Form
    {
        #region"Menu Data Declaration"

        public List<Button> lib_menu_btn_list { get; set; } = new List<Button>();

        private void Lib_Menu_Btn_List_Item_Added()
        {
            lib_menu_btn_list.Add(lib_main_form_records_menu_btn);
            lib_menu_btn_list.Add(lib_main_form_members_menu_btn);
            lib_menu_btn_list.Add(lib_main_form_books_menu_btn);
            lib_menu_btn_list.Add(lib_main_form_setting_menu_btn);
            lib_menu_btn_list.Add(lib_main_form_log_out_menu_btn);
            lib_menu_btn_list.Add(lib_main_form_home_menu_btn);
        }

        #endregion

        public LIB_MAIN_FORM()
        {
            InitializeComponent();
            Lib_Menu_Btn_List_Item_Added();
        }
        
        private async void LIB_MAIN_FORM_Load(object sender, EventArgs e)
        {
            #region"Setting Form Size"

            Left = Top = 0;
            Width = Screen.PrimaryScreen.WorkingArea.Width;
            Height = Screen.PrimaryScreen.WorkingArea.Height;

            #endregion

            Lib_Main_View_Logo_Form_Change(this, EventArgs.Empty);
        }

        #region"Menu Operation Methods"

        private void Lib_Main_View_Logo_Form_Change(object sender, EventArgs e)
        {
            LIB_MAIN_VIEW_FORM_CHANGING.Form_Change(lib_main_form_main_view_panel,
                new LIB_MAIN_LOGO_FORM());
        }

        private LIB_MAIN_MENU_SELECTION_PARAM Get_Menu_Selection_Parameter()
        {
            LIB_MAIN_MENU_SELECTION_PARAM smp = new LIB_MAIN_MENU_SELECTION_PARAM();

            smp.sub_menu_btn_list = lib_menu_btn_list;
            smp.nav_panel = lib_main_form_lib_menu_nav_panel;

            return smp;
        }


        #endregion

        #region"Menu Click Actions"

        private void lib_main_form_records_menu_btn_Click(object sender, EventArgs e)
        {
            LIB_MAIN_MENU_SELECTION.Sub_Menu_Selection(Get_Menu_Selection_Parameter(),
               lib_main_form_records_menu_btn);

            LIB_MAIN_VIEW_FORM_CHANGING.Form_Change(lib_main_form_main_view_panel,
                new LIB_RECORDS_REPORT_FORM());
        }

        private void lib_main_form_members_menu_btn_Click(object sender, EventArgs e)
        {
            LIB_MAIN_MENU_SELECTION.Sub_Menu_Selection(Get_Menu_Selection_Parameter(),
               lib_main_form_members_menu_btn);

            LIB_MAIN_VIEW_FORM_CHANGING.Form_Change(lib_main_form_main_view_panel,
                new LIB_MEMBER_REPORT_FORM());
        }

        private void lib_main_form_books_menu_btn_Click(object sender, EventArgs e)
        {
            LIB_MAIN_MENU_SELECTION.Sub_Menu_Selection(Get_Menu_Selection_Parameter(),
                lib_main_form_books_menu_btn);

            LIB_MAIN_VIEW_FORM_CHANGING.Form_Change(lib_main_form_main_view_panel,
                new LIB_BOOK_REPORT_FORM());
        }

        private void lib_main_form_setting_menu_btn_Click(object sender, EventArgs e)
        {
            LIB_MAIN_MENU_SELECTION.Sub_Menu_Selection(Get_Menu_Selection_Parameter(),
               lib_main_form_setting_menu_btn);

            LIB_MAIN_VIEW_FORM_CHANGING.Form_Change(lib_main_form_main_view_panel,
                new LIB_SETTING_FORM());
        }

        private void lib_main_form_log_out_menu_btn_Click(object sender, EventArgs e)
        {
            LIB_MAIN_MENU_SELECTION.Sub_Menu_Selection(Get_Menu_Selection_Parameter(),
               lib_main_form_log_out_menu_btn);

            LIB_LOGIN_FORM log_in_form = new LIB_LOGIN_FORM();
            log_in_form.Show();

            Form main_form = LIB_FORM_STATE.Get_Open_Form("LIB_MAIN_FORM");
            main_form.Hide();
        }

        private void lib_main_form_home_menu_btn_Click(object sender, EventArgs e)
        {
            LIB_MAIN_MENU_SELECTION.Sub_Menu_Selection(Get_Menu_Selection_Parameter(),
               lib_main_form_home_menu_btn);

            LIB_LIBRARY_IMAGE_LOGIN_FORM log_in_form = new LIB_LIBRARY_IMAGE_LOGIN_FORM();
            log_in_form.Show();

            Form main_form = LIB_FORM_STATE.Get_Open_Form("LIB_MAIN_FORM");
            main_form.Hide();
        }

        #endregion

        #region"Control Box Event"

        private void lib_main_form_minimize_btn_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void lib_main_form_close_btn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        #endregion        
    }
}
