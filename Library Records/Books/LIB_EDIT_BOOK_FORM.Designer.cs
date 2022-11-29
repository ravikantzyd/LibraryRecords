namespace Library_Records.Books
{
    partial class LIB_EDIT_BOOK_FORM
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lib_edit_book_title_bar_panel = new System.Windows.Forms.Panel();
            this.lib_edit_book_minimize_btn = new System.Windows.Forms.Button();
            this.lib_edit_book_title_l = new System.Windows.Forms.Label();
            this.lib_edit_book_close_btn = new System.Windows.Forms.Button();
            this.lib_edit_book_cancel_btn = new System.Windows.Forms.Button();
            this.lib_edit_book_book_id_l = new System.Windows.Forms.Label();
            this.lib_edit_book_total_l = new System.Windows.Forms.Label();
            this.lib_edit_book_author_name_tb = new System.Windows.Forms.TextBox();
            this.lib_edit_book_author_name_l = new System.Windows.Forms.Label();
            this.lib_edit_book_book_name_tb = new System.Windows.Forms.TextBox();
            this.lib_edit_book_total_star_l = new System.Windows.Forms.Label();
            this.lib_edit_book_book_name_l = new System.Windows.Forms.Label();
            this.lib_edit_book_author_name_star_l = new System.Windows.Forms.Label();
            this.lib_edit_book_book_name_star_l = new System.Windows.Forms.Label();
            this.New_Customer_Grid_BackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.lib_edit_book_book_id_star_l = new System.Windows.Forms.Label();
            this.lib_edit_book_book_id_tb = new System.Windows.Forms.Label();
            this.lib_edit_book_remove_btn = new System.Windows.Forms.Button();
            this.lib_edit_book_save_btn = new System.Windows.Forms.Button();
            this.lib_edit_book_category_name_star_l = new System.Windows.Forms.Label();
            this.lib_edit_book_category_name_l = new System.Windows.Forms.Label();
            this.lib_edit_book_category_name_cb = new System.Windows.Forms.ComboBox();
            this.lib_edit_book_total_tb = new System.Windows.Forms.TextBox();
            this.lib_edit_book_title_bar_panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // lib_edit_book_title_bar_panel
            // 
            this.lib_edit_book_title_bar_panel.BackColor = System.Drawing.Color.DarkGreen;
            this.lib_edit_book_title_bar_panel.Controls.Add(this.lib_edit_book_minimize_btn);
            this.lib_edit_book_title_bar_panel.Controls.Add(this.lib_edit_book_title_l);
            this.lib_edit_book_title_bar_panel.Controls.Add(this.lib_edit_book_close_btn);
            this.lib_edit_book_title_bar_panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.lib_edit_book_title_bar_panel.Location = new System.Drawing.Point(0, 0);
            this.lib_edit_book_title_bar_panel.Name = "lib_edit_book_title_bar_panel";
            this.lib_edit_book_title_bar_panel.Size = new System.Drawing.Size(460, 33);
            this.lib_edit_book_title_bar_panel.TabIndex = 90;
            this.lib_edit_book_title_bar_panel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lib_edit_book_title_bar_panel_MouseDown);
            // 
            // lib_edit_book_minimize_btn
            // 
            this.lib_edit_book_minimize_btn.Dock = System.Windows.Forms.DockStyle.Right;
            this.lib_edit_book_minimize_btn.FlatAppearance.BorderSize = 0;
            this.lib_edit_book_minimize_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lib_edit_book_minimize_btn.Image = global::Library_Records.Properties.Resources.minimize;
            this.lib_edit_book_minimize_btn.Location = new System.Drawing.Point(398, 0);
            this.lib_edit_book_minimize_btn.Name = "lib_edit_book_minimize_btn";
            this.lib_edit_book_minimize_btn.Size = new System.Drawing.Size(31, 33);
            this.lib_edit_book_minimize_btn.TabIndex = 55;
            this.lib_edit_book_minimize_btn.UseVisualStyleBackColor = true;
            this.lib_edit_book_minimize_btn.Click += new System.EventHandler(this.lib_edit_book_minimize_btn_Click);
            // 
            // lib_edit_book_title_l
            // 
            this.lib_edit_book_title_l.AutoSize = true;
            this.lib_edit_book_title_l.Font = new System.Drawing.Font("Arial Nova Cond", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lib_edit_book_title_l.ForeColor = System.Drawing.Color.White;
            this.lib_edit_book_title_l.Location = new System.Drawing.Point(5, 6);
            this.lib_edit_book_title_l.Name = "lib_edit_book_title_l";
            this.lib_edit_book_title_l.Size = new System.Drawing.Size(68, 20);
            this.lib_edit_book_title_l.TabIndex = 3;
            this.lib_edit_book_title_l.Text = "Edit Book";
            // 
            // lib_edit_book_close_btn
            // 
            this.lib_edit_book_close_btn.Dock = System.Windows.Forms.DockStyle.Right;
            this.lib_edit_book_close_btn.FlatAppearance.BorderSize = 0;
            this.lib_edit_book_close_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lib_edit_book_close_btn.Image = global::Library_Records.Properties.Resources.close;
            this.lib_edit_book_close_btn.Location = new System.Drawing.Point(429, 0);
            this.lib_edit_book_close_btn.Name = "lib_edit_book_close_btn";
            this.lib_edit_book_close_btn.Size = new System.Drawing.Size(31, 33);
            this.lib_edit_book_close_btn.TabIndex = 2;
            this.lib_edit_book_close_btn.UseVisualStyleBackColor = true;
            this.lib_edit_book_close_btn.Click += new System.EventHandler(this.lib_edit_book_close_btn_Click);
            // 
            // lib_edit_book_cancel_btn
            // 
            this.lib_edit_book_cancel_btn.Font = new System.Drawing.Font("Arial Nova Cond", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lib_edit_book_cancel_btn.Location = new System.Drawing.Point(10, 288);
            this.lib_edit_book_cancel_btn.Name = "lib_edit_book_cancel_btn";
            this.lib_edit_book_cancel_btn.Size = new System.Drawing.Size(68, 32);
            this.lib_edit_book_cancel_btn.TabIndex = 100;
            this.lib_edit_book_cancel_btn.Text = "Cancel";
            this.lib_edit_book_cancel_btn.UseVisualStyleBackColor = true;
            this.lib_edit_book_cancel_btn.Click += new System.EventHandler(this.lib_edit_book_cancel_btn_Click);
            // 
            // lib_edit_book_book_id_l
            // 
            this.lib_edit_book_book_id_l.AutoSize = true;
            this.lib_edit_book_book_id_l.Font = new System.Drawing.Font("Arial Nova Cond", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lib_edit_book_book_id_l.Location = new System.Drawing.Point(6, 52);
            this.lib_edit_book_book_id_l.Name = "lib_edit_book_book_id_l";
            this.lib_edit_book_book_id_l.Size = new System.Drawing.Size(64, 19);
            this.lib_edit_book_book_id_l.TabIndex = 91;
            this.lib_edit_book_book_id_l.Text = "Book Id :";
            // 
            // lib_edit_book_total_l
            // 
            this.lib_edit_book_total_l.AutoSize = true;
            this.lib_edit_book_total_l.Font = new System.Drawing.Font("Arial Nova Cond", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lib_edit_book_total_l.Location = new System.Drawing.Point(6, 241);
            this.lib_edit_book_total_l.Name = "lib_edit_book_total_l";
            this.lib_edit_book_total_l.Size = new System.Drawing.Size(51, 19);
            this.lib_edit_book_total_l.TabIndex = 92;
            this.lib_edit_book_total_l.Text = "Total : ";
            // 
            // lib_edit_book_author_name_tb
            // 
            this.lib_edit_book_author_name_tb.Font = new System.Drawing.Font("Arial Nova Cond", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lib_edit_book_author_name_tb.Location = new System.Drawing.Point(177, 142);
            this.lib_edit_book_author_name_tb.Name = "lib_edit_book_author_name_tb";
            this.lib_edit_book_author_name_tb.Size = new System.Drawing.Size(271, 26);
            this.lib_edit_book_author_name_tb.TabIndex = 97;
            // 
            // lib_edit_book_author_name_l
            // 
            this.lib_edit_book_author_name_l.AutoSize = true;
            this.lib_edit_book_author_name_l.Font = new System.Drawing.Font("Arial Nova Cond", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lib_edit_book_author_name_l.Location = new System.Drawing.Point(6, 145);
            this.lib_edit_book_author_name_l.Name = "lib_edit_book_author_name_l";
            this.lib_edit_book_author_name_l.Size = new System.Drawing.Size(97, 19);
            this.lib_edit_book_author_name_l.TabIndex = 93;
            this.lib_edit_book_author_name_l.Text = "Author Name :";
            // 
            // lib_edit_book_book_name_tb
            // 
            this.lib_edit_book_book_name_tb.Font = new System.Drawing.Font("Arial Nova Cond", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lib_edit_book_book_name_tb.Location = new System.Drawing.Point(177, 95);
            this.lib_edit_book_book_name_tb.Name = "lib_edit_book_book_name_tb";
            this.lib_edit_book_book_name_tb.Size = new System.Drawing.Size(271, 26);
            this.lib_edit_book_book_name_tb.TabIndex = 98;
            // 
            // lib_edit_book_total_star_l
            // 
            this.lib_edit_book_total_star_l.AutoSize = true;
            this.lib_edit_book_total_star_l.Font = new System.Drawing.Font("Arial Nova Cond", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lib_edit_book_total_star_l.ForeColor = System.Drawing.Color.Red;
            this.lib_edit_book_total_star_l.Location = new System.Drawing.Point(148, 238);
            this.lib_edit_book_total_star_l.Name = "lib_edit_book_total_star_l";
            this.lib_edit_book_total_star_l.Size = new System.Drawing.Size(23, 30);
            this.lib_edit_book_total_star_l.TabIndex = 101;
            this.lib_edit_book_total_star_l.Text = "*";
            // 
            // lib_edit_book_book_name_l
            // 
            this.lib_edit_book_book_name_l.AutoSize = true;
            this.lib_edit_book_book_name_l.Font = new System.Drawing.Font("Arial Nova Cond", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lib_edit_book_book_name_l.Location = new System.Drawing.Point(6, 98);
            this.lib_edit_book_book_name_l.Name = "lib_edit_book_book_name_l";
            this.lib_edit_book_book_name_l.Size = new System.Drawing.Size(87, 19);
            this.lib_edit_book_book_name_l.TabIndex = 94;
            this.lib_edit_book_book_name_l.Text = "Book Name :";
            // 
            // lib_edit_book_author_name_star_l
            // 
            this.lib_edit_book_author_name_star_l.AutoSize = true;
            this.lib_edit_book_author_name_star_l.Font = new System.Drawing.Font("Arial Nova Cond", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lib_edit_book_author_name_star_l.ForeColor = System.Drawing.Color.Red;
            this.lib_edit_book_author_name_star_l.Location = new System.Drawing.Point(148, 142);
            this.lib_edit_book_author_name_star_l.Name = "lib_edit_book_author_name_star_l";
            this.lib_edit_book_author_name_star_l.Size = new System.Drawing.Size(23, 30);
            this.lib_edit_book_author_name_star_l.TabIndex = 102;
            this.lib_edit_book_author_name_star_l.Text = "*";
            // 
            // lib_edit_book_book_name_star_l
            // 
            this.lib_edit_book_book_name_star_l.AutoSize = true;
            this.lib_edit_book_book_name_star_l.Font = new System.Drawing.Font("Arial Nova Cond", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lib_edit_book_book_name_star_l.ForeColor = System.Drawing.Color.Red;
            this.lib_edit_book_book_name_star_l.Location = new System.Drawing.Point(148, 95);
            this.lib_edit_book_book_name_star_l.Name = "lib_edit_book_book_name_star_l";
            this.lib_edit_book_book_name_star_l.Size = new System.Drawing.Size(23, 30);
            this.lib_edit_book_book_name_star_l.TabIndex = 103;
            this.lib_edit_book_book_name_star_l.Text = "*";
            // 
            // New_Customer_Grid_BackgroundWorker
            // 
            this.New_Customer_Grid_BackgroundWorker.WorkerReportsProgress = true;
            this.New_Customer_Grid_BackgroundWorker.WorkerSupportsCancellation = true;
            // 
            // lib_edit_book_book_id_star_l
            // 
            this.lib_edit_book_book_id_star_l.AutoSize = true;
            this.lib_edit_book_book_id_star_l.Font = new System.Drawing.Font("Arial Nova Cond", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lib_edit_book_book_id_star_l.ForeColor = System.Drawing.Color.Red;
            this.lib_edit_book_book_id_star_l.Location = new System.Drawing.Point(148, 49);
            this.lib_edit_book_book_id_star_l.Name = "lib_edit_book_book_id_star_l";
            this.lib_edit_book_book_id_star_l.Size = new System.Drawing.Size(23, 30);
            this.lib_edit_book_book_id_star_l.TabIndex = 104;
            this.lib_edit_book_book_id_star_l.Text = "*";
            // 
            // lib_edit_book_book_id_tb
            // 
            this.lib_edit_book_book_id_tb.BackColor = System.Drawing.Color.White;
            this.lib_edit_book_book_id_tb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lib_edit_book_book_id_tb.Font = new System.Drawing.Font("Arial Nova Cond", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lib_edit_book_book_id_tb.Location = new System.Drawing.Point(177, 49);
            this.lib_edit_book_book_id_tb.Name = "lib_edit_book_book_id_tb";
            this.lib_edit_book_book_id_tb.Size = new System.Drawing.Size(271, 26);
            this.lib_edit_book_book_id_tb.TabIndex = 105;
            this.lib_edit_book_book_id_tb.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lib_edit_book_remove_btn
            // 
            this.lib_edit_book_remove_btn.Font = new System.Drawing.Font("Arial Nova Cond", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lib_edit_book_remove_btn.Location = new System.Drawing.Point(380, 288);
            this.lib_edit_book_remove_btn.Name = "lib_edit_book_remove_btn";
            this.lib_edit_book_remove_btn.Size = new System.Drawing.Size(68, 32);
            this.lib_edit_book_remove_btn.TabIndex = 107;
            this.lib_edit_book_remove_btn.Text = "Remove";
            this.lib_edit_book_remove_btn.UseVisualStyleBackColor = true;
            this.lib_edit_book_remove_btn.Click += new System.EventHandler(this.lib_edit_book_remove_btn_Click);
            // 
            // lib_edit_book_save_btn
            // 
            this.lib_edit_book_save_btn.Font = new System.Drawing.Font("Arial Nova Cond", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lib_edit_book_save_btn.Location = new System.Drawing.Point(177, 288);
            this.lib_edit_book_save_btn.Name = "lib_edit_book_save_btn";
            this.lib_edit_book_save_btn.Size = new System.Drawing.Size(68, 32);
            this.lib_edit_book_save_btn.TabIndex = 106;
            this.lib_edit_book_save_btn.Text = "Save";
            this.lib_edit_book_save_btn.UseVisualStyleBackColor = true;
            this.lib_edit_book_save_btn.Click += new System.EventHandler(this.lib_edit_book_save_btn_Click);
            // 
            // lib_edit_book_category_name_star_l
            // 
            this.lib_edit_book_category_name_star_l.AutoSize = true;
            this.lib_edit_book_category_name_star_l.Font = new System.Drawing.Font("Arial Nova Cond", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lib_edit_book_category_name_star_l.ForeColor = System.Drawing.Color.Red;
            this.lib_edit_book_category_name_star_l.Location = new System.Drawing.Point(148, 192);
            this.lib_edit_book_category_name_star_l.Name = "lib_edit_book_category_name_star_l";
            this.lib_edit_book_category_name_star_l.Size = new System.Drawing.Size(23, 30);
            this.lib_edit_book_category_name_star_l.TabIndex = 113;
            this.lib_edit_book_category_name_star_l.Text = "*";
            // 
            // lib_edit_book_category_name_l
            // 
            this.lib_edit_book_category_name_l.AutoSize = true;
            this.lib_edit_book_category_name_l.Font = new System.Drawing.Font("Arial Nova Cond", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lib_edit_book_category_name_l.Location = new System.Drawing.Point(6, 192);
            this.lib_edit_book_category_name_l.Name = "lib_edit_book_category_name_l";
            this.lib_edit_book_category_name_l.Size = new System.Drawing.Size(109, 19);
            this.lib_edit_book_category_name_l.TabIndex = 112;
            this.lib_edit_book_category_name_l.Text = "Category Name :";
            // 
            // lib_edit_book_category_name_cb
            // 
            this.lib_edit_book_category_name_cb.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.lib_edit_book_category_name_cb.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.lib_edit_book_category_name_cb.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lib_edit_book_category_name_cb.Font = new System.Drawing.Font("Arial Nova Cond", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lib_edit_book_category_name_cb.FormattingEnabled = true;
            this.lib_edit_book_category_name_cb.Location = new System.Drawing.Point(177, 188);
            this.lib_edit_book_category_name_cb.Name = "lib_edit_book_category_name_cb";
            this.lib_edit_book_category_name_cb.Size = new System.Drawing.Size(271, 28);
            this.lib_edit_book_category_name_cb.TabIndex = 111;
            // 
            // lib_edit_book_total_tb
            // 
            this.lib_edit_book_total_tb.Font = new System.Drawing.Font("Arial Nova Cond", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lib_edit_book_total_tb.Location = new System.Drawing.Point(177, 238);
            this.lib_edit_book_total_tb.Name = "lib_edit_book_total_tb";
            this.lib_edit_book_total_tb.Size = new System.Drawing.Size(271, 26);
            this.lib_edit_book_total_tb.TabIndex = 114;
            // 
            // LIB_EDIT_BOOK_FORM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.ClientSize = new System.Drawing.Size(460, 328);
            this.Controls.Add(this.lib_edit_book_total_tb);
            this.Controls.Add(this.lib_edit_book_category_name_star_l);
            this.Controls.Add(this.lib_edit_book_category_name_l);
            this.Controls.Add(this.lib_edit_book_category_name_cb);
            this.Controls.Add(this.lib_edit_book_remove_btn);
            this.Controls.Add(this.lib_edit_book_save_btn);
            this.Controls.Add(this.lib_edit_book_book_id_tb);
            this.Controls.Add(this.lib_edit_book_title_bar_panel);
            this.Controls.Add(this.lib_edit_book_cancel_btn);
            this.Controls.Add(this.lib_edit_book_book_id_l);
            this.Controls.Add(this.lib_edit_book_total_l);
            this.Controls.Add(this.lib_edit_book_author_name_tb);
            this.Controls.Add(this.lib_edit_book_author_name_l);
            this.Controls.Add(this.lib_edit_book_book_name_tb);
            this.Controls.Add(this.lib_edit_book_total_star_l);
            this.Controls.Add(this.lib_edit_book_book_name_l);
            this.Controls.Add(this.lib_edit_book_author_name_star_l);
            this.Controls.Add(this.lib_edit_book_book_name_star_l);
            this.Controls.Add(this.lib_edit_book_book_id_star_l);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LIB_EDIT_BOOK_FORM";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LIB_EDIT_BOOK_FORM";
            this.Load += new System.EventHandler(this.LIB_EDIT_BOOK_FORM_Load);
            this.lib_edit_book_title_bar_panel.ResumeLayout(false);
            this.lib_edit_book_title_bar_panel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel lib_edit_book_title_bar_panel;
        private System.Windows.Forms.Button lib_edit_book_minimize_btn;
        private System.Windows.Forms.Label lib_edit_book_title_l;
        private System.Windows.Forms.Button lib_edit_book_close_btn;
        private System.Windows.Forms.Button lib_edit_book_cancel_btn;
        private System.Windows.Forms.Label lib_edit_book_book_id_l;
        private System.Windows.Forms.Label lib_edit_book_total_l;
        private System.Windows.Forms.TextBox lib_edit_book_author_name_tb;
        private System.Windows.Forms.Label lib_edit_book_author_name_l;
        private System.Windows.Forms.TextBox lib_edit_book_book_name_tb;
        private System.Windows.Forms.Label lib_edit_book_total_star_l;
        private System.Windows.Forms.Label lib_edit_book_book_name_l;
        private System.Windows.Forms.Label lib_edit_book_author_name_star_l;
        private System.Windows.Forms.Label lib_edit_book_book_name_star_l;
        private System.ComponentModel.BackgroundWorker New_Customer_Grid_BackgroundWorker;
        private System.Windows.Forms.Label lib_edit_book_book_id_star_l;
        private System.Windows.Forms.Label lib_edit_book_book_id_tb;
        private System.Windows.Forms.Button lib_edit_book_remove_btn;
        private System.Windows.Forms.Button lib_edit_book_save_btn;
        private System.Windows.Forms.Label lib_edit_book_category_name_star_l;
        private System.Windows.Forms.Label lib_edit_book_category_name_l;
        private System.Windows.Forms.ComboBox lib_edit_book_category_name_cb;
        private System.Windows.Forms.TextBox lib_edit_book_total_tb;
    }
}