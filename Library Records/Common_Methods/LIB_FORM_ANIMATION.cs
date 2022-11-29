using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library_Records.Common_Methods
{
    public class LIB_FORM_ANIMATION
    {
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

        #region"Declaration to drag window from one place to another"

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd,
                         int Msg, int wParam, int lParam);

        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        #endregion

        public static void Form_Animation(Form _form)
        {
            AnimateWindow(_form.Handle, 500, AW_BLEND);
        }

        public static void Form_Drag(Form _form, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(_form.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        public static void Form_Round_Corner(Form _form)
        {
            _form.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, 5, 5, 25, 25));
        }
    }
}
