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
    public class LIB_BORROW_BOOK_BL
    {
        #region"LIB Borrow Book Declaration"

        private ComboBox member_name_cb = new ComboBox();
        private ComboBox available_book_cb = new ComboBox();
        private ComboBox selected_book_cb = new ComboBox();
        private Label record_id_l = new Label();
        
        private string borrow_book_data_entry_process_status = "";

        public event EventHandler On_Get_Borrow_Book_Data_Entry_Data;
        public event EventHandler<string> On_Set_Borrow_Book_Data_Entry_Process_Status;

        #endregion

        public async Task Load_Borrow_Book_Data_Entry(IProgress<ProgressReport> progress, CancellationTokenSource cts)
        {
            On_Get_Borrow_Book_Data_Entry_Data?.Invoke(this, EventArgs.Empty);

            borrow_book_data_entry_process_status = "Running";
            On_Set_Borrow_Book_Data_Entry_Process_Status?.Invoke(this, borrow_book_data_entry_process_status);

            int member_maxpage = 0;
            int book_maxpage = 0;

            ProgressReport report = new ProgressReport();

            List<MemberModel> members = new List<MemberModel>();
            List<BookModel> books = new List<BookModel>();

            try
            {
                members = await MemberProcessor.LoadMembers();
                books = await BookProcessor.LoadBooks();
            }
            catch (HttpRequestException ex)
            {
                LIB_ERROR_MESSAGE.HttpRequestExceptionMessage(ex);
                return;
            }
            catch (Exception ex)
            {
                LIB_ERROR_MESSAGE.ExceptionMessage(ex);
                return;
            }

            List<string> member_names = members.Select(x => x.MemberName).ToList();
            List<string> book_names = books.Select(x => x.BookName).ToList();

            if (member_names.Count != 0)
            {
                if (member_names.Count < 100)
                {
                    member_maxpage = 1;
                }
                else
                {
                    member_maxpage = member_names.Count / 100;

                    if (member_names.Count % 100 != 0)
                    {
                        member_maxpage += 1;
                    }
                }
            }

            if (book_names.Count != 0)
            {
                if (book_names.Count < 100)
                {
                    book_maxpage = 1;
                }
                else
                {
                    book_maxpage = book_names.Count / 100;

                    if (book_names.Count % 100 != 0)
                    {
                        book_maxpage += 1;
                    }
                }
            }

            for (int i = 1; i <= member_maxpage; i++)
            {
                string[] member_name_part = member_names.Skip((i - 1) * 100).Take(100).ToArray();
                    
                borrow_book_data_entry_process_status = "Running";
                On_Set_Borrow_Book_Data_Entry_Process_Status?.Invoke(this, borrow_book_data_entry_process_status);

                try
                {
                    cts.Token.ThrowIfCancellationRequested();
                }
                catch (Exception)
                {
                    borrow_book_data_entry_process_status = "Cancelled";
                    On_Set_Borrow_Book_Data_Entry_Process_Status?.Invoke(this, borrow_book_data_entry_process_status);

                    break;
                }

                await Task.Run(() =>
                {
                    Borrow_Book_Data_Entry_Cb_Members_Added(member_name_part);

                    Thread.Sleep(100);
                    report.ProgressPercent = ((i * 100) / member_maxpage);
                    progress.Report(report);
                });
            }

            for (int i = 1; i <= book_maxpage; i++)
            {
                string[] book_name_part = book_names.Skip((i - 1) * 100).Take(100).ToArray();

                borrow_book_data_entry_process_status = "Running";
                On_Set_Borrow_Book_Data_Entry_Process_Status?.Invoke(this, borrow_book_data_entry_process_status);

                try
                {
                    cts.Token.ThrowIfCancellationRequested();
                }
                catch (Exception)
                {
                    borrow_book_data_entry_process_status = "Cancelled";
                    On_Set_Borrow_Book_Data_Entry_Process_Status?.Invoke(this, borrow_book_data_entry_process_status);

                    break;
                }

                await Task.Run(() =>
                {
                    Borrow_Book_Data_Entry_Cb_Books_Added(book_name_part);

                    Thread.Sleep(100);
                    report.ProgressPercent = ((i * 100) / member_maxpage);
                    progress.Report(report);
                });
            }

            if (borrow_book_data_entry_process_status.Equals("Cancelled"))
            {
                On_Set_Borrow_Book_Data_Entry_Process_Status?.Invoke(this, borrow_book_data_entry_process_status);
            }
            else
            {
                borrow_book_data_entry_process_status = "Completed";
                On_Set_Borrow_Book_Data_Entry_Process_Status?.Invoke(this, borrow_book_data_entry_process_status);                
            }
        }
                
        private void Borrow_Book_Data_Entry_Cb_Members_Added(string[] member_name_list)
        {
            if (member_name_cb.InvokeRequired)
            {
                member_name_cb.Invoke(new System.Action(() =>
                {
                    member_name_cb.Items.AddRange(member_name_list);
                }));
            }            
        }

        private void Borrow_Book_Data_Entry_Cb_Books_Added(string[] book_name_list)
        {
            if (available_book_cb.InvokeRequired)
            {
                available_book_cb.Invoke(new System.Action(() =>
                {
                    available_book_cb.Items.AddRange(book_name_list);
                }));
            }
        }

        public async Task<string> Get_Record_No(string date)
        {
            string voucher_no = "";

            string[] dateArr = date.Split('/');

            if (Convert.ToInt32(dateArr[0]) < 10)
            {
                dateArr[0] = "0" + dateArr[0];
            }

            if (Convert.ToInt32(dateArr[1]) < 10)
            {
                dateArr[1] = "0" + dateArr[1];
            }

            string voucher_date = dateArr[0] + dateArr[1] + dateArr[2];

            try
            {
                List<RecordNoModel> voucher_nos = await RecordNoProcessor.LoadRecordNosByDate(date);

                if (voucher_nos.Count == 0)
                {
                    voucher_no = voucher_date + Get_Formatted_Num_For_Record_No(1);
                }
                else
                {
                    RecordNoModel voucher_no_model = voucher_nos.Where(q => q.Number == voucher_nos.Max(num => num.Number)).FirstOrDefault();

                    voucher_no = voucher_date + Get_Formatted_Num_For_Record_No(voucher_no_model.Number + 1);
                }
            }
            catch (HttpRequestException ex)
            {
                LIB_ERROR_MESSAGE.HttpRequestExceptionMessage(ex);
            }
            catch (Exception ex)
            {
                LIB_ERROR_MESSAGE.ExceptionMessage(ex);
            }

            return voucher_no;
        }

        public async Task Set_Record_No(string date)
        {
            int number = 0;

            string voucher_date = date.Replace("/", "");

            try
            {
                List<RecordNoModel> voucher_nos = await RecordNoProcessor.LoadRecordNosByDate(date);

                if (voucher_nos.Count == 0)
                {
                    number = 1;
                }
                else
                {
                    RecordNoModel voucher_no_model = voucher_nos.Where(q => q.Number == voucher_nos.Max(num => num.Number)).FirstOrDefault();

                    number = voucher_no_model.Number + 1;
                }

                CreateRecordNoModel voucher_no = new CreateRecordNoModel
                {
                    Date = date,
                    Number = number
                };

                await RecordNoProcessor.SetRecordNo(voucher_no);
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

        private string Get_Formatted_Num_For_Record_No(int num)
        {
            string formated_num = "000";

            if (num >= 1 && num < 10)
            {
                formated_num = "00" + num;
            }
            else if (num >= 10 && num < 100)
            {
                formated_num = "0" + num;
            }
            else if (num >= 100 && num < 100)
            {
                formated_num = num.ToString();
            }
            else
            {
                formated_num = num.ToString();
            }

            return formated_num;
        }

        public void On_Set_Borrow_Book_Data_Entry_Data(object sender, LIB_BORROW_BOOK_LOAD_BL_EVENT_ARGS event_args)
        {
            member_name_cb = event_args.member_name_cb;
            available_book_cb = event_args.available_book_cb;
            selected_book_cb = event_args.selected_book_cb;
            record_id_l = event_args.record_id_l;
            borrow_book_data_entry_process_status = event_args.borrow_book_data_entry_process_status;
        }
    }
}
