using Library_Records.Api_Processor;
using Library_Records.Books.BL_Methods.BL_Input_Params;
using Library_Records.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library_Records.Books.BL_Methods
{
    public class LIB_BOOK_REPORT_BL
    {
        #region"Library Book Report BL Declaration"

        private DataGridView book_report_gv = new DataGridView();
        private ComboBox book_report_general_search_cb = new ComboBox();
        public System.Windows.Forms.Label total_book_amount_l { get; set; } = new System.Windows.Forms.Label();
        public System.Windows.Forms.Label total_book_equal_l { get; set; } = new System.Windows.Forms.Label();
        private System.Windows.Forms.Label total_book_l = new System.Windows.Forms.Label();
        public System.Windows.Forms.Label book_report_gv_page_num_l = new System.Windows.Forms.Label();

        #endregion

        public async Task Load_Book_Gridview_Data(int page_num_param, int book_id = 0, string search_word="")
        {
            int maxpage = 1;
            total_book_l.Visible = true;
            total_book_equal_l.Visible = true;
            total_book_amount_l.Visible = true;

            if (LIB_BOOK_REPORT_GRID_VIEW_DATA.load_status.Equals("Books Added"))
            {
                LIB_BOOK_REPORT_GRID_VIEW_DATA.book_list =
                    await BookProcessor.LoadBooksByDecending();
            }
            else if (LIB_BOOK_REPORT_GRID_VIEW_DATA.load_status.Equals("Books Search"))
            {                
                total_book_equal_l.Visible = false;
                total_book_amount_l.Visible = false;
                total_book_l.Visible = false;

                LIB_BOOK_REPORT_GRID_VIEW_DATA.book_list =
                    await BookProcessor.LoadBookBySearch(search_word);
            }
            else
            {
                LIB_BOOK_REPORT_GRID_VIEW_DATA.book_list =
                    await BookProcessor.LoadBooks();
            }

            int book_list_count = LIB_BOOK_REPORT_GRID_VIEW_DATA.book_list.Count;

            if (book_list_count != 0)
            {
                if (book_list_count < 20)
                {
                    maxpage = 1;
                }
                else
                {
                    maxpage = book_list_count / 20;

                    if (book_list_count % 20 != 0)
                    {
                        maxpage += 1;
                    }
                }
            }

            string page_num = page_num_param + "/" + maxpage;

            book_report_gv_page_num_l.Text = page_num;
            total_book_amount_l.Text = LIB_BOOK_REPORT_GRID_VIEW_DATA.book_list.Sum(s => s.TotalCount).ToString();

            await Load_Book_Gridview_Data_By_Page_Num(page_num_param);
        }

        public async Task Load_Book_Gridview_Data_By_Page_Num(int page_num)
        {
            List<BookModel> book_list = LIB_BOOK_REPORT_GRID_VIEW_DATA.book_list
                .Skip((page_num - 1) * 20).Take(20).ToList();

            book_report_gv.Rows.Clear();
            LIB_BOOK_REPORT_GRID_VIEW_DATA.selected_row_index = -1;
            LIB_BOOK_REPORT_GRID_VIEW_DATA.selected_row = null;

            List<DataGridViewRow> dataGridViewRows = new List<DataGridViewRow>();

            for (int i = 0; i < book_list.Count; i++)
            {
                DataGridViewRow dataGridViewRow = new DataGridViewRow();
                dataGridViewRow.Height = 28;
                dataGridViewRow.Cells.Add(new DataGridViewTextBoxCell());
                dataGridViewRow.Cells[0].Value = book_list[i].BookId;
                dataGridViewRow.Cells.Add(new DataGridViewTextBoxCell());
                dataGridViewRow.Cells[1].Value = book_list[i].BookName;
                dataGridViewRow.Cells.Add(new DataGridViewTextBoxCell());
                dataGridViewRow.Cells[2].Value = book_list[i].Author;
                dataGridViewRow.Cells.Add(new DataGridViewTextBoxCell());
                dataGridViewRow.Cells[3].Value = book_list[i].Categories.CategoryName;
                dataGridViewRow.Cells.Add(new DataGridViewTextBoxCell());
                dataGridViewRow.Cells[4].Value = book_list[i].TotalCount;

                dataGridViewRows.Add(dataGridViewRow);
            }

            await Task.Run(() => {

                if (book_report_gv.InvokeRequired)
                {
                    book_report_gv.Invoke(new System.Action(() =>
                    {
                        book_report_gv.Rows.AddRange(dataGridViewRows.ToArray());
                    }));
                }

                Thread.Sleep(100);
            });
        }
        
        public void On_Set_Book_Report_Controls(object sender, LIB_BOOK_REPORT_SET_CONTROL_EVENT_ARGS event_args)
        {
            book_report_gv = event_args.grid_view;
            book_report_gv_page_num_l = event_args.grid_view_page_num_l;
            total_book_l = event_args.total_book_l;
            total_book_amount_l = event_args.total_book_amount_l;
            total_book_equal_l = event_args.total_book_equal_l;
        }
    }
}
