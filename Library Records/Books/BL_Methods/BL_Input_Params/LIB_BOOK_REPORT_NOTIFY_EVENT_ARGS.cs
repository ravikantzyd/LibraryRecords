using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library_Records.Books.BL_Methods.BL_Input_Params
{
    public class LIB_BOOK_REPORT_NOTIFY_EVENT_ARGS : EventArgs
    {
        public ComboBox general_search_cb { get; set; }
    }
}
