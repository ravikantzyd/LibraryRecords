using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library_Records.Records.BL_Methods.BL_Methods_Param
{
    public class LIB_BORROW_BOOK_LOAD_BL_EVENT_ARGS : EventArgs
    {
        public ComboBox member_name_cb { get; set; } = new ComboBox();
        public ComboBox available_book_cb { get; set; } = new ComboBox();
        public ComboBox selected_book_cb { get; set; } = new ComboBox();       
        public Label record_id_l { get; set; } = new Label();        
        public string borrow_book_data_entry_process_status { get; set; } = "";
    }
}
