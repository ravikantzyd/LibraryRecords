using Library_Records.Api_Processor;
using Library_Records.Books.BL_Methods;
using Library_Records.Books.BL_Methods.BL_Input_Params;
using Library_Records.Common_Methods;
using Library_Records.Common_Methods.Input_Parameters;
using Library_Records.Models;
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

namespace Library_Records.Books
{
    public partial class LIB_EDIT_CATEGORY_FORM : Form
    {

        #region"Class Variable Decalration"

        public static string form_state = "Open";
        public static string data_entry_process_status { get; set; } = "";

        public event EventHandler<LIB_EDIT_CATEGORY_LOAD_BL_EVENT_ARGS> On_Set_Edit_Category_Data_Entry_Data;

        public Progress<ProgressReport> data_entry_progress { get; } = new Progress<ProgressReport>();
        public CancellationTokenSource Cts { get; set; } = new CancellationTokenSource();

        #endregion

        public LIB_EDIT_CATEGORY_FORM()
        {
            InitializeComponent();
        }        

        private void LIB_EDIT_CATEGORY_FORM_Load(object sender, EventArgs e)
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
                lib_edit_category_category_id_cb.Items.Clear();
                lib_edit_category_category_id_cb.ResetText();
                lib_edit_category_old_category_name_cb.Items.Clear();
                lib_edit_category_old_category_name_cb.ResetText();
                lib_edit_category_new_category_name_tb.Text = "";

                Cts = new CancellationTokenSource();
            }
            else if (data_entry_process_status.Equals(""))
            {
                lib_edit_category_category_id_cb.Items.Clear();
                lib_edit_category_category_id_cb.ResetText();
                lib_edit_category_old_category_name_cb.Items.Clear();
                lib_edit_category_old_category_name_cb.ResetText();
                lib_edit_category_new_category_name_tb.Text = "";

                Cts = new CancellationTokenSource();
            }
            else
            {
                lib_edit_category_new_category_name_tb.Text = "";

                Cts = new CancellationTokenSource();
            }
        }

        private void Form_Close()
        {
            form_state = "Close";
            Cts.Cancel();
            this.Close();
        }

        #region"Data Entry Methods"

        private void ReportProgress(object sender, ProgressReport e)
        {
            lib_edit_category_loading_progress_value_l.Text = string.Format("{0} %", e.ProgressPercent);
        }

        public void On_Notify_Edit_Category_For_Set_Data_Entry_Data(object sender, EventArgs args)
        {
            LIB_EDIT_CATEGORY_LOAD_BL_EVENT_ARGS event_args = new LIB_EDIT_CATEGORY_LOAD_BL_EVENT_ARGS
            {
                category_id_cb = lib_edit_category_category_id_cb,
                category_name_cb = lib_edit_category_old_category_name_cb,
                edit_category_data_entry_process_status = data_entry_process_status
            };

            On_Set_Edit_Category_Data_Entry_Data?.Invoke(this, event_args);
        }

        public void On_Set_Data_Entry_Process_Status(object sender, string args)
        {
            data_entry_process_status = args;
        }

        #endregion

        #region"Title Bar Panel Event"

        private void lib_edit_category_title_bar_panel_MouseDown(object sender, MouseEventArgs e)
        {
            LIB_FORM_ANIMATION.Form_Drag(this, e);
        }

        private async void lib_edit_category_refresh_btn_Click(object sender, EventArgs e)
        {
            Cts.Cancel();
            data_entry_process_status = "Cancelled";
            Clear_To_New_Form();

            LIB_EDIT_CATEGORY_BL category_bl = new LIB_EDIT_CATEGORY_BL();

            this.On_Set_Edit_Category_Data_Entry_Data += category_bl.On_Set_Edit_Category_Data_Entry_Data;
            category_bl.On_Get_Edit_Category_Data_Entry_Data += this.On_Notify_Edit_Category_For_Set_Data_Entry_Data;
            category_bl.On_Set_Edit_Category_Data_Entry_Process_Status += this.On_Set_Data_Entry_Process_Status;

            await category_bl.Load_Edit_Category_Data_Entry(this.data_entry_progress,
                this.Cts);
        }

        private void lib_edit_category_minimize_btn_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void lib_edit_category_close_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region"Tool Bar Panel Event"

        private void lib_edit_category_cancel_btn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void lib_edit_category_save_btn_Click(object sender, EventArgs e)
        {
            string new_category_name = lib_edit_category_new_category_name_tb.Text.Trim();
            int category_id = 0;

            if (new_category_name.Equals(""))
            {
                MessageBox.Show("Please Fill New Category Name to Update!");
            }
            else if (lib_edit_category_category_id_cb.SelectedItem == null)
            {
                MessageBox.Show("Please select Category Id correct value!");
            }
            else if (lib_edit_category_old_category_name_cb.SelectedItem == null)
            {
                MessageBox.Show("Please select Old Category Name correct value!");
            }
            else
            {
                category_id = Convert.ToInt32(lib_edit_category_category_id_cb.Items[lib_edit_category_category_id_cb.SelectedIndex]);

                UpdateCategoryModel category = new UpdateCategoryModel
                {
                    CategoryName = new_category_name
                };

                try
                {
                    await CategoryProcessor.ModifyCategory(category_id, category);
                    
                    MessageBox.Show("Category Modify Successfull");

                    data_entry_process_status = "";
                    Form_Close();
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
            }
        }

        private async void lib_edit_category_remove_btn_Click(object sender, EventArgs e)
        {
            int category_id = 0;

            if (lib_edit_category_category_id_cb.SelectedItem == null)
            {
                MessageBox.Show("Please select Category Id correct value!");
            }
            else if (lib_edit_category_old_category_name_cb.SelectedItem == null)
            {
                MessageBox.Show("Please select Old Category Name correct value!");
            }
            else
            {
                category_id = Convert.ToInt32(lib_edit_category_category_id_cb.Items[lib_edit_category_category_id_cb.SelectedIndex]);

                DialogResult dr = MessageBox.Show("Are you sure want to delete this Category?", "Warning!", MessageBoxButtons.YesNoCancel,
                        MessageBoxIcon.Warning);

                if (dr == DialogResult.Yes)
                {
                    try
                    {
                        List<BookModel> books = await BookProcessor.LoadBookByCategoryId(category_id);

                        if (books.Count == 0)
                        {
                            CategoryModel category = await CategoryProcessor.LoadCategory(category_id);

                            await CategoryProcessor.DeleteCategory(category_id);
                            
                            MessageBox.Show("Category Delete Successfull");

                            data_entry_process_status = "";
                            Form_Close();
                        }
                        else
                        {
                            MessageBox.Show("You cannot remove this Category \n because some Item data is relating this Category !");
                        }
                    }
                    catch (HttpRequestException ex) { LIB_ERROR_MESSAGE.HttpRequestExceptionMessage(ex); return; }
                    catch (Exception ex) { LIB_ERROR_MESSAGE.ExceptionMessage(ex); return; }
                }
            }
        }

        #endregion

        private async void lib_edit_category_category_id_cb_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(lib_edit_category_category_id_cb.Items[lib_edit_category_category_id_cb.SelectedIndex]);

            CategoryModel category = new CategoryModel();

            try
            {
                category = await CategoryProcessor.LoadCategory(id);
            }
            catch (HttpRequestException ex) { LIB_ERROR_MESSAGE.HttpRequestExceptionMessage(ex); return; }
            catch (Exception ex) { LIB_ERROR_MESSAGE.ExceptionMessage(ex); return; }

            lib_edit_category_old_category_name_cb.SelectedItem = category.CategoryName;
            lib_edit_category_old_category_name_cb.Text = category.CategoryName;
        }

        private async void lib_edit_category_old_category_name_cb_SelectedIndexChanged(object sender, EventArgs e)
        {
            string name = lib_edit_category_old_category_name_cb.Items[lib_edit_category_old_category_name_cb.SelectedIndex].ToString();

            CategoryModel category = new CategoryModel();

            try
            {
                category = await CategoryProcessor.LoadCategoryByName(name);
            }
            catch (HttpRequestException ex) { LIB_ERROR_MESSAGE.HttpRequestExceptionMessage(ex); return; }
            catch (Exception ex) { LIB_ERROR_MESSAGE.ExceptionMessage(ex); return; }

            lib_edit_category_category_id_cb.SelectedItem = category.Id.ToString();
            lib_edit_category_category_id_cb.Text = category.Id.ToString();
        }
    }
}
