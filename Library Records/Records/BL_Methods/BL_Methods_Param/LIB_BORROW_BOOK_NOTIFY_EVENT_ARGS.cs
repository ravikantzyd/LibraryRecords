using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library_Records.Records.BL_Methods.BL_Methods_Param
{
    public class LIB_BORROW_BOOK_NOTIFY_EVENT_ARGS : EventArgs
    {
        public ComboBox available_book_cb { get; set; }
        public ComboBox selected_book_cb { get; set; }
        public ComboBox member_name_cb { get; set; }
    }
}
