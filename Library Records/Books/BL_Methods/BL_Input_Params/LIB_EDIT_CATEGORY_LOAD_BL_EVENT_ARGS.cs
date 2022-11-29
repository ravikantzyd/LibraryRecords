using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library_Records.Books.BL_Methods.BL_Input_Params
{
    public class LIB_EDIT_CATEGORY_LOAD_BL_EVENT_ARGS : EventArgs
    {
        public ComboBox category_id_cb { get; set; }
        public ComboBox category_name_cb { get; set; }
        public string edit_category_data_entry_process_status { get; set; }
    }
}
