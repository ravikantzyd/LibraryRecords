using Library_Records.Main.Input_Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library_Records.Main.UI_Control_Functions
{
    public class LIB_MAIN_MENU_SELECTION
    {
        public static void Sub_Menu_Selection(LIB_MAIN_MENU_SELECTION_PARAM sp,
                                                Button selected_sub_menu_btn)
        {
            sp.nav_panel.Visible = true;
            sp.nav_panel.BringToFront();
            sp.nav_panel.Height = selected_sub_menu_btn.Height;
            sp.nav_panel.Top = selected_sub_menu_btn.Top;
            sp.nav_panel.Left = selected_sub_menu_btn.Left;
            selected_sub_menu_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));

            foreach (Button sub_menu_btn in sp.sub_menu_btn_list)
            {
                if (!sub_menu_btn.Name.Equals(selected_sub_menu_btn.Name))
                {
                    sub_menu_btn.BackColor = System.Drawing.Color.Blue;
                }
            }
        }
    }
}
