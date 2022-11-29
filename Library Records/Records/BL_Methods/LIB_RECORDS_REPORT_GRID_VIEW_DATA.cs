using Library_Records.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library_Records.Records.BL_Methods
{
    public class LIB_RECORDS_REPORT_GRID_VIEW_DATA
    {
        public static string load_status { get; set; } = "";
        public static List<RecordModel> record_list { get; set; } = null;
        public static int selected_row_index { get; set; } = -1;
        public static DataGridViewRow selected_row { get; set; } = null;
    }
}
