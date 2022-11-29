using Library_Records.Common_Methods.Input_Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library_Records.Common_Methods
{
    public class LIB_FORM_STATE
    {
        #region"Declaration for Form animation effects"

        const int AW_SLIDE = 0X40000;
        const int AW_HOR_POSITIVE = 0X1;
        const int AW_HOR_NEGATIVE = 0X2;
        const int AW_VER_NEGATIVE = 0X8;
        const int AW_VER_POSITIVE = 0X4;
        const int AW_BLEND = 0X80000;
        const int AW_CENTER = 0x00000010;
        const int AW_ACTIVATE = 0x00020000;

        [DllImport("user32")]

        static extern bool AnimateWindow(IntPtr hwnd, int time, int flags);

        #endregion

        public event EventHandler<LIB_FORM_STATE_EVENT_ARGS> form_state_change;

        public void Show(LIB_FORM_STATE_PARAM form_param)
        {
            bool IsOpen = false;

            foreach (Form _form in System.Windows.Forms.Application.OpenForms)
            {
                if (_form.Text == form_param.form.Text)
                {
                    if (form_param.form_state.Equals("Open"))
                    {
                        if (_form.WindowState == FormWindowState.Minimized)
                        {
                            _form.WindowState = FormWindowState.Normal;
                        }

                        IsOpen = true;
                        _form.BringToFront();

                        AnimateWindow(_form.Handle, 500, AW_BLEND);
                        _form.Show();

                        break;
                    }

                    if (form_param.form_state.Equals("Close"))
                    {
                        IsOpen = true;
                        _form.BringToFront();

                        LIB_FORM_STATE_EVENT_ARGS event_args = new LIB_FORM_STATE_EVENT_ARGS()
                        {
                            form_state = "Open"
                        };

                        form_state_change?.Invoke(this, event_args);

                        AnimateWindow(_form.Handle, 500, AW_BLEND);

                        _form.Show();

                        break;
                    }

                    if (form_param.form_state.Equals(String.Empty))
                    {
                        if (_form.WindowState == FormWindowState.Minimized)
                        {
                            _form.WindowState = FormWindowState.Normal;
                        }

                        IsOpen = true;
                        _form.BringToFront();

                        AnimateWindow(_form.Handle, 500, AW_BLEND);
                        _form.Show();

                        break;
                    }
                }
            }

            if (IsOpen == false)
            {
                form_param.form.Show();
            }
        }

        public static Form Get_Open_Form(string form_name)
        {
            Form need_form = null;

            foreach (Form form in System.Windows.Forms.Application.OpenForms)
            {
                if (form.Name == form_name)
                {
                    need_form = form;
                    break;
                }
            }

            return need_form;
        }
    }
}
