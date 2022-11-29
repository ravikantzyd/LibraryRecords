using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library_Records.Records.BL_Methods.BL_Methods_Param
{
    public class LIB_RECORD_REPORT_SET_CONTROL_EVENT_ARGS : EventArgs
    {
        public DataGridView grid_view { get; set; }
        public Label grid_view_page_num_l { get; set; }        
    }
}
