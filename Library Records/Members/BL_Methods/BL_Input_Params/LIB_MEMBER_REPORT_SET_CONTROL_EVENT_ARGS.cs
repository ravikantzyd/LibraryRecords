using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library_Records.Members.BL_Methods.BL_Input_Params
{
    public class LIB_MEMBER_REPORT_SET_CONTROL_EVENT_ARGS : EventArgs
    {
        public DataGridView grid_view { get; set; }
        public Label grid_view_page_num_l { get; set; }
        public Label total_member_l { get; set; }
        public Label total_member_amount_l { get; set; }
        public Label total_member_equal_l { get; set; }
    }
}
