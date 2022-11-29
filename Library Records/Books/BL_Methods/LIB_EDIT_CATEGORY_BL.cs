using Library_Records.Api_Processor;
using Library_Records.Books.BL_Methods.BL_Input_Params;
using Library_Records.Common_Methods;
using Library_Records.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library_Records.Books.BL_Methods
{
    public class LIB_EDIT_CATEGORY_BL
    {
        #region"Shopfy Edit Category Declaration"

        private ComboBox edit_category_id_cb = new ComboBox();
        private ComboBox edit_category_name_cb = new ComboBox();

        private string edit_category_data_entry_process_status = "";

        public event EventHandler On_Get_Edit_Category_Data_Entry_Data;
        public event EventHandler<string> On_Set_Edit_Category_Data_Entry_Process_Status;

        #endregion

        public async Task Load_Edit_Category_Data_Entry(IProgress<ProgressReport> progress, CancellationTokenSource cts)
        {
            On_Get_Edit_Category_Data_Entry_Data?.Invoke(this, EventArgs.Empty);

            edit_category_data_entry_process_status = "Running";
            On_Set_Edit_Category_Data_Entry_Process_Status?.Invoke(this, edit_category_data_entry_process_status);

            int maxpage = 0;

            ProgressReport report = new ProgressReport();

            List<CategoryModel> categories = new List<CategoryModel>();

            try
            {
                categories = await CategoryProcessor.LoadCategories();
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

            List<string> category_ids = categories.Select(category => Convert.ToString(category.Id)).ToList();
            List<string> category_names = categories.Select(category => category.CategoryName).ToList();

            if (category_ids.Count != 0)
            {
                if (category_ids.Count < 100)
                {
                    maxpage = 1;
                }
                else
                {
                    maxpage = category_ids.Count / 100;

                    if (category_ids.Count % 100 != 0)
                    {
                        maxpage += 1;
                    }
                }
            }

            for (int i = 1; i <= maxpage; i++)
            {
                string[] category_id_part = category_ids.Skip((i - 1) * 100).Take(100).ToArray();
                string[] category_name_part = category_names.Skip((i - 1) * 100).Take(100).ToArray();

                edit_category_data_entry_process_status = "Running";
                On_Set_Edit_Category_Data_Entry_Process_Status?.Invoke(this, edit_category_data_entry_process_status);

                try
                {
                    cts.Token.ThrowIfCancellationRequested();
                }
                catch (Exception)
                {
                    edit_category_data_entry_process_status = "Cancelled";
                    On_Set_Edit_Category_Data_Entry_Process_Status?.Invoke(this, edit_category_data_entry_process_status);

                    break;
                }

                await Task.Run(() =>
                {
                    Edit_Category_Data_Entry_Cb_Items_Added(category_id_part, category_name_part);

                    Thread.Sleep(100);
                    report.ProgressPercent = ((i * 100) / maxpage);
                    progress.Report(report);
                });
            }

            if (edit_category_data_entry_process_status.Equals("Cancelled"))
            {
                On_Set_Edit_Category_Data_Entry_Process_Status?.Invoke(this, edit_category_data_entry_process_status);
            }
            else
            {
                edit_category_data_entry_process_status = "Completed";
                On_Set_Edit_Category_Data_Entry_Process_Status?.Invoke(this, edit_category_data_entry_process_status);

                edit_category_id_cb.SelectedIndex = 0;
                edit_category_name_cb.SelectedIndex = 0;
            }
        }

        private void Edit_Category_Data_Entry_Cb_Items_Added(string[] category_id_list, string[] category_name_list)
        {
            if (edit_category_id_cb.InvokeRequired)
            {
                edit_category_id_cb.Invoke(new System.Action(() =>
                {
                    edit_category_id_cb.Items.AddRange(category_id_list);
                }));
            }

            if (edit_category_name_cb.InvokeRequired)
            {
                edit_category_name_cb.Invoke(new System.Action(() =>
                {
                    edit_category_name_cb.Items.AddRange(category_name_list);
                }));
            }
        }

        public void On_Set_Edit_Category_Data_Entry_Data(object sender, LIB_EDIT_CATEGORY_LOAD_BL_EVENT_ARGS event_args)
        {
            edit_category_id_cb = event_args.category_id_cb;
            edit_category_name_cb = event_args.category_name_cb;
            edit_category_data_entry_process_status = event_args.edit_category_data_entry_process_status;
        }
    }
}
