﻿using Library_Records.Api_Processor;
using Library_Records.Common_Methods;
using Library_Records.Models;
using Library_Records.Records.BL_Methods;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library_Records.Records
{
    public partial class LIB_BORROW_SIGNATURE_VIEW_FORM : Form
    {
        float PointX;
        float PointY;
        float LastX;
        float LastY;

        DataGridViewRow row;

        public LIB_BORROW_SIGNATURE_VIEW_FORM()
        {
            InitializeComponent();
        }

        private async void LIB_BORROW_SIGNATURE_VIEW_FORM_Load(object sender, EventArgs e)
        {
            LIB_FORM_ANIMATION.Form_Animation(this);

            if (LIB_RECORDS_REPORT_GRID_VIEW_DATA.selected_row_index < 0)
            {
                MessageBox.Show("Please select a correct record!");
            }
            else
            {
                row = LIB_RECORDS_REPORT_GRID_VIEW_DATA.selected_row;

                string record_id = row.Cells[0].Value.ToString();
                string book_name = row.Cells[3].Value.ToString();

                try
                {
                    List<RecordModel> records = await RecordProcessor.LoadRecordByRIDandBookName(record_id, book_name);

                    if (records != null)
                    {
                        string SignaturePoints = records[0].BorrowSignature;

                        for (int i = 0; i < SignaturePoints.Split('/').Length - 1; i++)
                        {
                            string[] SignaturePoint = SignaturePoints.Split('/')[i].Split(',');

                            try
                            {
                                PointX = Convert.ToInt32(SignaturePoint[0]);
                                PointY = Convert.ToInt32(SignaturePoint[1]);
                                LastX = Convert.ToInt32(SignaturePoint[2]);
                                LastY = Convert.ToInt32(SignaturePoint[3]);
                            }
                            catch (Exception)
                            {
                                MessageBox.Show("Array Length : " + SignaturePoints.Split('/').Length +
                                    "\n Error in " + i);
                            }

                            lib_borrow_sign_return_signature_panel_Paint(this, null);
                        }
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

        private void lib_borrow_sign_return_signature_panel_Paint(object sender, PaintEventArgs e)
        {
            Graphics G = lib_borrow_sign_borrow_signature_panel.CreateGraphics();
            G.DrawLine(Pens.Black, PointX, PointY, LastX, LastY);
            LastX = PointX;
            LastY = PointY;
        }

        private void lib_borrow_sign_title_bar_panel_MouseDown(object sender, MouseEventArgs e)
        {
            LIB_FORM_ANIMATION.Form_Drag(this, e);
        }

        private void lib_borrow_sign_close_btn_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
