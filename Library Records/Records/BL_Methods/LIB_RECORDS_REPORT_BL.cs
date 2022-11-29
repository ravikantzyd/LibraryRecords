using Library_Records.Api_Processor;
using Library_Records.Common_Methods;
using Library_Records.Models;
using Library_Records.Records.BL_Methods.BL_Methods_Param;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library_Records.Records.BL_Methods
{
    public class LIB_RECORDS_REPORT_BL
    {
        #region"Shopfy Record Report BL Declaration"

        private DataGridView record_report_gv = new DataGridView();
        
        public System.Windows.Forms.Label record_report_gv_page_num_l = new System.Windows.Forms.Label();

        #endregion

        public async Task Load_Record_Gridview_Data(int page_num_param, int record_id = 0, string search_word = "")
        {
            int maxpage = 1;

            try
            {
                if (LIB_RECORDS_REPORT_GRID_VIEW_DATA.load_status.Equals("Records Added"))
                {
                    LIB_RECORDS_REPORT_GRID_VIEW_DATA.record_list =
                        await RecordProcessor.LoadRecordsByDecending();
                }
                else if (LIB_RECORDS_REPORT_GRID_VIEW_DATA.load_status.Equals("Records Search"))
                {
                    LIB_RECORDS_REPORT_GRID_VIEW_DATA.record_list =
                        await RecordProcessor.LoadRecordBySearch(search_word);
                }
                else
                {
                    LIB_RECORDS_REPORT_GRID_VIEW_DATA.record_list =
                        await RecordProcessor.LoadRecords();
                }

                int record_list_count = LIB_RECORDS_REPORT_GRID_VIEW_DATA.record_list.Count;

                if (record_list_count != 0)
                {
                    if (record_list_count < 20)
                    {
                        maxpage = 1;
                    }
                    else
                    {
                        maxpage = record_list_count / 20;

                        if (record_list_count % 20 != 0)
                        {
                            maxpage += 1;
                        }
                    }
                }

                string page_num = page_num_param + "/" + maxpage;

                record_report_gv_page_num_l.Text = page_num;

                await Load_Record_Gridview_Data_By_Page_Num(page_num_param);
            }
            catch (HttpRequestException ex)
            {
                LIB_ERROR_MESSAGE.HttpRequestExceptionMessage(ex);
            }
            catch (Exception ex)
            {
                LIB_ERROR_MESSAGE.ExceptionMessage(ex);
            }            
        }

        public async Task Load_Record_Gridview_Data_By_Page_Num(int page_num)
        {
            List<RecordModel> record_list = LIB_RECORDS_REPORT_GRID_VIEW_DATA.record_list
                .Skip((page_num - 1) * 20).Take(20).ToList();

            record_report_gv.Rows.Clear();
            LIB_RECORDS_REPORT_GRID_VIEW_DATA.selected_row_index = -1;
            LIB_RECORDS_REPORT_GRID_VIEW_DATA.selected_row = null;

            List<DataGridViewRow> dataGridViewRows = new List<DataGridViewRow>();

            for (int i = 0; i < record_list.Count; i++)
            {
                string return_date = "";
                string extended_date = "";

                if (record_list[i].ReturnDate.ToString() == "1/1/0001 12:00:00 AM")
                {
                    return_date = "Not Return";
                }
                else
                {
                    return_date = record_list[i].ReturnDate.ToShortDateString();
                }

                if (record_list[i].DateExtended == 0)
                {
                    extended_date = "Not Extended";
                }
                else
                {
                    extended_date = record_list[i].DateExtended.ToString();
                }

                DataGridViewRow dataGridViewRow = new DataGridViewRow();
                dataGridViewRow.Height = 28;
                dataGridViewRow.Cells.Add(new DataGridViewTextBoxCell());
                dataGridViewRow.Cells[0].Value = record_list[i].RecordId;
                dataGridViewRow.Cells.Add(new DataGridViewTextBoxCell());
                dataGridViewRow.Cells[1].Value = record_list[i].Members.MemberName;
                dataGridViewRow.Cells.Add(new DataGridViewTextBoxCell());
                dataGridViewRow.Cells[2].Value = record_list[i].Members.RNPost;
                dataGridViewRow.Cells.Add(new DataGridViewTextBoxCell());
                dataGridViewRow.Cells[3].Value = record_list[i].Books.BookName;
                dataGridViewRow.Cells.Add(new DataGridViewTextBoxCell());
                dataGridViewRow.Cells[4].Value = record_list[i].Books.Author;
                dataGridViewRow.Cells.Add(new DataGridViewTextBoxCell());
                dataGridViewRow.Cells[5].Value = record_list[i].BorrowDate.ToShortDateString();
                dataGridViewRow.Cells.Add(new DataGridViewTextBoxCell());
                dataGridViewRow.Cells[6].Value = return_date;
                dataGridViewRow.Cells.Add(new DataGridViewTextBoxCell());
                dataGridViewRow.Cells[7].Value = extended_date;

                dataGridViewRows.Add(dataGridViewRow);
            }

            await Task.Run(() => {

                if (record_report_gv.InvokeRequired)
                {
                    record_report_gv.Invoke(new System.Action(() =>
                    {
                        record_report_gv.Rows.AddRange(dataGridViewRows.ToArray());
                    }));
                }

                Thread.Sleep(100);
            });
        }

        public void On_Set_Record_Report_Controls(object sender, LIB_RECORD_REPORT_SET_CONTROL_EVENT_ARGS event_args)
        {
            record_report_gv = event_args.grid_view;
            record_report_gv_page_num_l = event_args.grid_view_page_num_l;            
        }
    }
}
