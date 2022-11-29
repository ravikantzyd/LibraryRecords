using Library_Records.Api_Processor;
using Library_Records.Common_Methods;
using Library_Records.Common_Methods.Input_Parameters;
using Library_Records.Models;
using Library_Records.Records.BL_Methods;
using Library_Records.Records.BL_Methods.BL_Methods_Param;
using Library_Records.Setting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library_Records.Records
{
    public partial class LIB_BORROW_BOOK_FORM : Form
    {
        #region"Class Variable Decalration"

        public static string form_state = "Open";

        public static string data_entry_process_status { get; set; } = "";

        #region"Variable of Creating Signature"

        private string signature_points { get; set; } = string.Empty;
        float PointX { get; set; }
        float PointY { get; set; }
        float LastX { get; set; }
        float LastY { get; set; }

        #endregion

        public event EventHandler<LIB_BORROW_BOOK_LOAD_BL_EVENT_ARGS> On_Set_Borrow_Book_Data_Entry_Data;
        public event EventHandler<LIB_BORROW_BOOK_NOTIFY_EVENT_ARGS> On_Notify_Set_Control;

        public Progress<ProgressReport> data_entry_progress { get; } = new Progress<ProgressReport>();
        public CancellationTokenSource Cts { get; set; } = new CancellationTokenSource();

        #endregion

        public LIB_BORROW_BOOK_FORM()
        {
            InitializeComponent();
        }

        public void On_Notify_Get_Control(object sender, EventArgs e)
        {
            LIB_BORROW_BOOK_NOTIFY_EVENT_ARGS event_args = new LIB_BORROW_BOOK_NOTIFY_EVENT_ARGS
            {
                available_book_cb = lib_borrow_book_available_book_cb,
                selected_book_cb = lib_borrow_book_selected_book_cb,
                member_name_cb = lib_borrow_book_member_name_cb
            };

            On_Notify_Set_Control.Invoke(this, event_args);
        }

        #region"Form Refresh"

        private void LIB_BORROW_BOOK_FORM_Load(object sender, EventArgs e)
        {
            LIB_FORM_ANIMATION.Form_Animation(this);
        }

        public void Form_State_Change_Event(object sender, LIB_FORM_STATE_EVENT_ARGS event_args)
        {
            form_state = event_args.form_state;
        }

        public void On_Clear_To_New_Form(object sender, EventArgs event_args)
        {
            Clear_To_New_Form();
            data_entry_progress.ProgressChanged += ReportProgress;
        }

        private void Clear_To_New_Form()
        {
            if (data_entry_process_status.Equals("Cancelled"))
            {
                lib_borrow_book_available_book_cb.Items.Clear();
                lib_borrow_book_available_book_cb.ResetText();
                lib_borrow_book_selected_book_cb.Items.Clear();
                lib_borrow_book_selected_book_cb.ResetText();
                lib_borrow_book_member_name_cb.Items.Clear();
                lib_borrow_book_member_name_cb.ResetText();

                Clear_Form_Data();

                Cts = new CancellationTokenSource();
            }
            else if (data_entry_process_status.Equals(""))
            {
                lib_borrow_book_available_book_cb.Items.Clear();
                lib_borrow_book_available_book_cb.ResetText();
                lib_borrow_book_selected_book_cb.Items.Clear();
                lib_borrow_book_selected_book_cb.ResetText();
                lib_borrow_book_member_name_cb.Items.Clear();
                lib_borrow_book_member_name_cb.ResetText();

                Clear_Form_Data();

                Cts = new CancellationTokenSource();
            }
            else
            {
                Clear_Form_Data();

                Cts = new CancellationTokenSource();
            }
        }

        private async void Clear_Form_Data()
        {
            await Set_Record_No();

            lib_borrow_book_member_name_cb.ResetText();
            lib_borrow_book_available_book_cb.ResetText();
            lib_borrow_book_selected_book_cb.Items.Clear();
            lib_borrow_book_selected_book_cb.ResetText();

            lib_borrow_book_available_book_qty_box_l.Text = String.Empty;

            Clear_Signature();
        }
        
        private void Form_Close()
        {
            form_state = "Close";
            Cts.Cancel();
            this.Hide();
        }

        #endregion

        #region"Data Entry Methods"

        private void ReportProgress(object sender, ProgressReport e)
        {
            lib_borrow_book_loading_progress_box_l.Text = string.Format("{0} %", e.ProgressPercent);
        }

        public void On_Notify_Borrow_Book_For_Set_Data_Entry_Data(object sender, EventArgs args)
        {
            LIB_BORROW_BOOK_LOAD_BL_EVENT_ARGS event_args = new LIB_BORROW_BOOK_LOAD_BL_EVENT_ARGS
            {
                member_name_cb = lib_borrow_book_member_name_cb,
                available_book_cb = lib_borrow_book_available_book_cb,
                selected_book_cb = lib_borrow_book_selected_book_cb,
                record_id_l = lib_borrow_book_record_id_box_l,
                borrow_book_data_entry_process_status = data_entry_process_status
            };

            On_Set_Borrow_Book_Data_Entry_Data?.Invoke(this, event_args);
        }

        public void On_Set_Data_Entry_Process_Status(object sender, string args)
        {
            data_entry_process_status = args;
        }

        private async Task Set_Record_No()
        {
            try
            {
                string date = lib_borrow_book_date_picker.Text.ToString();

                string _date = Convert.ToDateTime(date).ToShortDateString();

                LIB_BORROW_BOOK_BL borrow_book_bl = new LIB_BORROW_BOOK_BL();

                string record_no = await borrow_book_bl.Get_Record_No(_date);                

                lib_borrow_book_record_id_box_l.Text = "R-" + record_no;
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

        #endregion

        #region"Title Bar Panel Event"

        private void lib_borrow_book_title_bar_panel_MouseDown(object sender, MouseEventArgs e)
        {
            LIB_FORM_ANIMATION.Form_Drag(this, e);
        }

        private async void lib_borrow_book_refresh_btn_Click(object sender, EventArgs e)
        {
            Cts.Cancel();
            data_entry_process_status = "Cancelled";
            Clear_To_New_Form();

            LIB_BORROW_BOOK_BL borrow_book_bl = new LIB_BORROW_BOOK_BL();

            On_Set_Borrow_Book_Data_Entry_Data += borrow_book_bl.On_Set_Borrow_Book_Data_Entry_Data;
            borrow_book_bl.On_Get_Borrow_Book_Data_Entry_Data += On_Notify_Borrow_Book_For_Set_Data_Entry_Data;
            borrow_book_bl.On_Set_Borrow_Book_Data_Entry_Process_Status += On_Set_Data_Entry_Process_Status;

            await borrow_book_bl.Load_Borrow_Book_Data_Entry(data_entry_progress, Cts);
        }

        private void lib_borrow_book_minimize_btn_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void lib_borrow_book_close_btn_Click(object sender, EventArgs e)
        {
            Form_Close();
        }

        #endregion

        #region"Tool Bar Panel Event"

        private void lib_borrow_book_clear_btn_Click(object sender, EventArgs e)
        {
            Clear_Form_Data();
        }

        private void lib_borrow_book_cancel_btn_Click(object sender, EventArgs e)
        {
            Form_Close();
        }

        private async void lib_borrow_book_borrow_btn_Click(object sender, EventArgs e)
        {
            if (lib_borrow_book_record_id_box_l.Text.Length < 10)
            {
                MessageBox.Show("You have not a correct record id. You need to refresh.");
            }
            else if (lib_borrow_book_member_name_cb.SelectedItem == null)
            {
                MessageBox.Show("Please select a correct member name.");
            }
            else if (lib_borrow_book_selected_book_cb.Items.Count < 1)
            {
                MessageBox.Show("Please select at least one book.");
            }
            else if (signature_points.Equals(""))
            {
                MessageBox.Show("You need to sign.");
            }
            else
            {
                string borrow_date_str = Convert.ToDateTime(lib_borrow_book_date_picker.Text.Trim())
                                        .ToShortDateString();
                DateTime borrow_date = Convert.ToDateTime(borrow_date_str);
                string record_id = lib_borrow_book_record_id_box_l.Text.Trim();
                string member_name = lib_borrow_book_member_name_cb.Items[
                    lib_borrow_book_member_name_cb.SelectedIndex].ToString();

                try
                {
                    MemberModel member = await MemberProcessor.LoadMemberByName(member_name);

                    if (member != null)
                    {
                        for (int i = 0; i < lib_borrow_book_selected_book_cb.Items.Count; i++)
                        {
                            BookModel book = await BookProcessor.LoadBookByName(
                                lib_borrow_book_selected_book_cb.Items[i].ToString());

                            if (book != null)
                            {
                                CreateRecordModel create_record_model = new CreateRecordModel()
                                {
                                    RecordId = record_id,
                                    MemberId = member.Id,
                                    BookId = book.Id,
                                    BorrowDate = borrow_date,
                                    BorrowSignature = signature_points,
                                    UserId = LIB_USER_INFO.user_id
                                };

                                await RecordProcessor.SetRecord(create_record_model);                                
                            }
                        }

                        LIB_RECORDS_REPORT_GRID_VIEW_DATA.load_status = "Members Added";

                        LIB_RECORDS_REPORT_FORM records_report_form = (LIB_RECORDS_REPORT_FORM)LIB_FORM_STATE.Get_Open_Form("LIB_RECORDS_REPORT_FORM");

                        if (records_report_form != null)
                        {
                            LIB_RECORDS_REPORT_BL records_report_bl = new LIB_RECORDS_REPORT_BL();
                            records_report_form.On_Set_Record_Report_Control += records_report_bl.On_Set_Record_Report_Controls;

                            records_report_form.Set_Record_Report_Controls();

                            await records_report_bl.Load_Record_Gridview_Data(1);                            
                        }

                        LIB_BORROW_BOOK_BL borrow_book_bl = new LIB_BORROW_BOOK_BL();
                        await borrow_book_bl.Set_Record_No(borrow_date_str);
                        
                        MessageBox.Show("Borrow book is successful.");

                        Form_Close();
                    }
                }
                catch (HttpRequestException ex)
                {
                    LIB_ERROR_MESSAGE.HttpRequestExceptionMessage(ex);
                }
                catch(Exception ex)
                {
                    LIB_ERROR_MESSAGE.ExceptionMessage(ex);
                }                            
            }
        }

        #endregion

        private void lib_borrow_book_select_book_btn_Click(object sender, EventArgs e)
        {
            if (lib_borrow_book_available_book_cb.SelectedItem == null)
            {
                MessageBox.Show("Please select correct values.");
            }
            else
            {
                int available_book_qty = Convert.ToInt32(lib_borrow_book_available_book_qty_box_l.Text.Trim());

                string selected_book_name=lib_borrow_book_available_book_cb.Items[
                    lib_borrow_book_available_book_cb.SelectedIndex].ToString();

                if (lib_borrow_book_selected_book_cb.Items.Contains(selected_book_name))
                {
                    MessageBox.Show("This book is already selected.");
                }
                else if (available_book_qty <= 0)
                {
                    MessageBox.Show("This book is not available.");                    
                }
                else
                {
                    lib_borrow_book_selected_book_cb.Items.Add(selected_book_name);
                    lib_borrow_book_selected_book_cb.SelectedIndex = 0;
                }
            }
        }

        private async void lib_borrow_book_date_picker_ValueChanged(object sender, EventArgs e)
        {
            await Set_Record_No();
        }

        private async void lib_borrow_book_available_book_cb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lib_borrow_book_available_book_cb.SelectedItem == null)
            {
                lib_borrow_book_available_book_qty_box_l.Text = "";
            }
            else if (lib_borrow_book_available_book_cb.Text == String.Empty)
            {
                lib_borrow_book_available_book_qty_box_l.Text = "";
            }
            else
            {
                string book_name = lib_borrow_book_available_book_cb.Items[
                    lib_borrow_book_available_book_cb.SelectedIndex].ToString();

                BookModel book = await BookProcessor.LoadBookByName(book_name);

                List<RecordModel> records = await RecordProcessor.LoadRecordByBookId(book.Id);

                if(records != null)
                {
                    List<string> borrow_signs = records.Where(r => r.BorrowSignature != null).Select(s => s.BorrowSignature).ToList();
                    List<string> return_signs = records.Where(r => r.ReturnSignature != null).Select(s => s.ReturnSignature).ToList();

                    int available_book = (book.TotalCount - borrow_signs.Count) + return_signs.Count;

                    lib_borrow_book_available_book_qty_box_l.Text = available_book.ToString();
                }
                else
                {
                    lib_borrow_book_available_book_qty_box_l.Text = book.TotalCount.ToString();
                }
            }
        }

        #region"Create Signature"

        private void lib_borrow_book_signature_box_panel_Paint(object sender, PaintEventArgs e)
        {
            Graphics G = lib_borrow_book_signature_box_panel.CreateGraphics();
            G.DrawLine(Pens.Black, PointX, PointY, LastX, LastY);
            LastX = PointX;
            LastY = PointY;
        }

        private void lib_borrow_book_signature_box_panel_MouseDown(object sender, MouseEventArgs e)
        {
            LastX = e.X;
            LastY = e.Y;
        }

        private void lib_borrow_book_signature_box_panel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                PointX = e.X;
                PointY = e.Y;

                signature_points += $"{PointX},{PointY},{LastX},{LastY}/";

                lib_borrow_book_signature_box_panel_Paint(this, null);
            }
        }

        private void lib_borrow_book_signature_clear_btn_Click(object sender, EventArgs e)
        {
            Clear_Signature();
        }

        private void Clear_Signature()
        {
            PointX = 0;
            PointY = 0;
            LastX = 0;
            LastY = 0;
            signature_points = String.Empty;
            lib_borrow_book_signature_box_panel.Invalidate();
        }

        #endregion

        private void lib_borrow_book_available_book_cb_TextChanged(object sender, EventArgs e)
        {
            string available_book_cb_text = lib_borrow_book_available_book_cb.Text;

            if (available_book_cb_text == String.Empty)
            {
                lib_borrow_book_available_book_qty_box_l.Text = "";
            }
            else if (!lib_borrow_book_available_book_cb.Items.Contains(available_book_cb_text))
            {
                lib_borrow_book_available_book_qty_box_l.Text = "";
            }
        }
    }
}
