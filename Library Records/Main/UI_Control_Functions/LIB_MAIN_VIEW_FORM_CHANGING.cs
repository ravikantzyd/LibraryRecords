using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library_Records.Main.UI_Control_Functions
{
    public class LIB_MAIN_VIEW_FORM_CHANGING
    {
        public static void Form_Change(Panel shopfy_main_view_panel,
                                    Form change_form)
        {
            var control_list = shopfy_main_view_panel.Controls.OfType<Form>().ToList();

            if (!control_list.Any(form => form.Name.Equals(change_form.Name)))
            {
                change_form.Dock = DockStyle.Fill;
                change_form.TopLevel = false;
                change_form.TopMost = true;

                shopfy_main_view_panel.Controls.Add(change_form);

                change_form.Show();
                change_form.BringToFront();
            }
            else
            {
                foreach (Form form in control_list)
                {
                    if (form.Name == change_form.Name)
                    {
                        form.BringToFront();
                        form.Show();
                        break;
                    }
                }
            }
        }
    }
}
