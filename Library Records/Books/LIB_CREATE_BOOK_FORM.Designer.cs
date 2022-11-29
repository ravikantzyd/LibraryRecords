namespace Library_Records.Books
{
    partial class LIB_CREATE_BOOK_FORM
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
            this.lib_create_book_title_bar_panel = new System.Windows.Forms.Panel();
            this.shopfy_create_customer_minimize_btn = new System.Windows.Forms.Button();
            this.lib_create_book_title_l = new System.Windows.Forms.Label();
            this.shopfy_create_customer_close_btn = new System.Windows.Forms.Button();
            this.New_Customer_Grid_BackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.lib_create_book_cancel_btn = new System.Windows.Forms.Button();
            this.lib_create_book_add_btn = new System.Windows.Forms.Button();
            this.lib_create_book_total_tb = new System.Windows.Forms.TextBox();
            this.lib_create_book_book_id_tb = new System.Windows.Forms.TextBox();
            this.lib_create_book_book_id_l = new System.Windows.Forms.Label();
            this.lib_create_book_total_l = new System.Windows.Forms.Label();
            this.lib_create_book_author_name_tb = new System.Windows.Forms.TextBox();
            this.lib_create_book_author_name_l = new System.Windows.Forms.Label();
            this.lib_create_book_book_name_tb = new System.Windows.Forms.TextBox();
            this.lib_create_book_total_star_l = new System.Windows.Forms.Label();
            this.lib_create_book_book_name_l = new System.Windows.Forms.Label();
            this.lib_create_book_author_name_star_l = new System.Windows.Forms.Label();
            this.lib_create_book_book_name_star_l = new System.Windows.Forms.Label();
            this.lib_create_book_book_id_star_l = new System.Windows.Forms.Label();
            this.lib_create_book_category_name_cb = new System.Windows.Forms.ComboBox();
            this.lib_create_book_category_name_l = new System.Windows.Forms.Label();
            this.lib_create_book_category_name_star_l = new System.Windows.Forms.Label();
            this.lib_create_book_title_bar_panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // lib_create_book_title_bar_panel
            // 
            this.lib_create_book_title_bar_panel.BackColor = System.Drawing.Color.DarkGreen;
            this.lib_create_book_title_bar_panel.Controls.Add(this.shopfy_create_customer_minimize_btn);
            this.lib_create_book_title_bar_panel.Controls.Add(this.lib_create_book_title_l);
            this.lib_create_book_title_bar_panel.Controls.Add(this.shopfy_create_customer_close_btn);
            this.lib_create_book_title_bar_panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.lib_create_book_title_bar_panel.Location = new System.Drawing.Point(0, 0);
            this.lib_create_book_title_bar_panel.Name = "lib_create_book_title_bar_panel";
            this.lib_create_book_title_bar_panel.Size = new System.Drawing.Size(460, 33);
            this.lib_create_book_title_bar_panel.TabIndex = 75;
            this.lib_create_book_title_bar_panel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lib_create_book_title_bar_panel_MouseDown);
            // 
            // shopfy_create_customer_minimize_btn
            // 
            this.shopfy_create_customer_minimize_btn.Dock = System.Windows.Forms.DockStyle.Right;
            this.shopfy_create_customer_minimize_btn.FlatAppearance.BorderSize = 0;
            this.shopfy_create_customer_minimize_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.shopfy_create_customer_minimize_btn.Image = global::Library_Records.Properties.Resources.minimize;
            this.shopfy_create_customer_minimize_btn.Location = new System.Drawing.Point(398, 0);
            this.shopfy_create_customer_minimize_btn.Name = "shopfy_create_customer_minimize_btn";
            this.shopfy_create_customer_minimize_btn.Size = new System.Drawing.Size(31, 33);
            this.shopfy_create_customer_minimize_btn.TabIndex = 55;
            this.shopfy_create_customer_minimize_btn.UseVisualStyleBackColor = true;
            this.shopfy_create_customer_minimize_btn.Click += new System.EventHandler(this.shopfy_create_customer_minimize_btn_Click);
            // 
            // lib_create_book_title_l
            // 
            this.lib_create_book_title_l.AutoSize = true;
            this.lib_create_book_title_l.Font = new System.Drawing.Font("Arial Nova Cond", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lib_create_book_title_l.ForeColor = System.Drawing.Color.White;
            this.lib_create_book_title_l.Location = new System.Drawing.Point(5, 6);
            this.lib_create_book_title_l.Name = "lib_create_book_title_l";
            this.lib_create_book_title_l.Size = new System.Drawing.Size(86, 20);
            this.lib_create_book_title_l.TabIndex = 3;
            this.lib_create_book_title_l.Text = "Create Book";
            // 
            // shopfy_create_customer_close_btn
            // 
            this.shopfy_create_customer_close_btn.Dock = System.Windows.Forms.DockStyle.Right;
            this.shopfy_create_customer_close_btn.FlatAppearance.BorderSize = 0;
            this.shopfy_create_customer_close_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.shopfy_create_customer_close_btn.Image = global::Library_Records.Properties.Resources.close;
            this.shopfy_create_customer_close_btn.Location = new System.Drawing.Point(429, 0);
            this.shopfy_create_customer_close_btn.Name = "shopfy_create_customer_close_btn";
            this.shopfy_create_customer_close_btn.Size = new System.Drawing.Size(31, 33);
            this.shopfy_create_customer_close_btn.TabIndex = 2;
            this.shopfy_create_customer_close_btn.UseVisualStyleBackColor = true;
            this.shopfy_create_customer_close_btn.Click += new System.EventHandler(this.shopfy_create_customer_close_btn_Click);
            // 
            // New_Customer_Grid_BackgroundWorker
            // 
            this.New_Customer_Grid_BackgroundWorker.WorkerReportsProgress = true;
            this.New_Customer_Grid_BackgroundWorker.WorkerSupportsCancellation = true;
            // 
            // lib_create_book_cancel_btn
            // 
            this.lib_create_book_cancel_btn.Font = new System.Drawing.Font("Arial Nova Cond", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lib_create_book_cancel_btn.Location = new System.Drawing.Point(132, 285);
            this.lib_create_book_cancel_btn.Name = "lib_create_book_cancel_btn";
            this.lib_create_book_cancel_btn.Size = new System.Drawing.Size(68, 32);
            this.lib_create_book_cancel_btn.TabIndex = 85;
            this.lib_create_book_cancel_btn.Text = "Cancel";
            this.lib_create_book_cancel_btn.UseVisualStyleBackColor = true;
            this.lib_create_book_cancel_btn.Click += new System.EventHandler(this.lib_create_book_cancel_btn_Click);
            // 
            // lib_create_book_add_btn
            // 
            this.lib_create_book_add_btn.Font = new System.Drawing.Font("Arial Nova Cond", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lib_create_book_add_btn.Location = new System.Drawing.Point(253, 285);
            this.lib_create_book_add_btn.Name = "lib_create_book_add_btn";
            this.lib_create_book_add_btn.Size = new System.Drawing.Size(68, 32);
            this.lib_create_book_add_btn.TabIndex = 84;
            this.lib_create_book_add_btn.Text = "Add";
            this.lib_create_book_add_btn.UseVisualStyleBackColor = true;
            this.lib_create_book_add_btn.Click += new System.EventHandler(this.lib_create_book_add_btn_Click);
            // 
            // lib_create_book_total_tb
            // 
            this.lib_create_book_total_tb.Font = new System.Drawing.Font("Arial Nova Cond", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lib_create_book_total_tb.Location = new System.Drawing.Point(177, 235);
            this.lib_create_book_total_tb.Name = "lib_create_book_total_tb";
            this.lib_create_book_total_tb.Size = new System.Drawing.Size(271, 26);
            this.lib_create_book_total_tb.TabIndex = 80;
            // 
            // lib_create_book_book_id_tb
            // 
            this.lib_create_book_book_id_tb.Font = new System.Drawing.Font("Arial Nova Cond", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lib_create_book_book_id_tb.Location = new System.Drawing.Point(177, 50);
            this.lib_create_book_book_id_tb.Name = "lib_create_book_book_id_tb";
            this.lib_create_book_book_id_tb.Size = new System.Drawing.Size(271, 26);
            this.lib_create_book_book_id_tb.TabIndex = 81;
            // 
            // lib_create_book_book_id_l
            // 
            this.lib_create_book_book_id_l.AutoSize = true;
            this.lib_create_book_book_id_l.Font = new System.Drawing.Font("Arial Nova Cond", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lib_create_book_book_id_l.Location = new System.Drawing.Point(6, 53);
            this.lib_create_book_book_id_l.Name = "lib_create_book_book_id_l";
            this.lib_create_book_book_id_l.Size = new System.Drawing.Size(64, 19);
            this.lib_create_book_book_id_l.TabIndex = 76;
            this.lib_create_book_book_id_l.Text = "Book Id :";
            // 
            // lib_create_book_total_l
            // 
            this.lib_create_book_total_l.AutoSize = true;
            this.lib_create_book_total_l.Font = new System.Drawing.Font("Arial Nova Cond", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lib_create_book_total_l.Location = new System.Drawing.Point(6, 238);
            this.lib_create_book_total_l.Name = "lib_create_book_total_l";
            this.lib_create_book_total_l.Size = new System.Drawing.Size(51, 19);
            this.lib_create_book_total_l.TabIndex = 77;
            this.lib_create_book_total_l.Text = "Total : ";
            // 
            // lib_create_book_author_name_tb
            // 
            this.lib_create_book_author_name_tb.Font = new System.Drawing.Font("Arial Nova Cond", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lib_create_book_author_name_tb.Location = new System.Drawing.Point(177, 143);
            this.lib_create_book_author_name_tb.Name = "lib_create_book_author_name_tb";
            this.lib_create_book_author_name_tb.Size = new System.Drawing.Size(271, 26);
            this.lib_create_book_author_name_tb.TabIndex = 82;
            // 
            // lib_create_book_author_name_l
            // 
            this.lib_create_book_author_name_l.AutoSize = true;
            this.lib_create_book_author_name_l.Font = new System.Drawing.Font("Arial Nova Cond", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lib_create_book_author_name_l.Location = new System.Drawing.Point(6, 146);
            this.lib_create_book_author_name_l.Name = "lib_create_book_author_name_l";
            this.lib_create_book_author_name_l.Size = new System.Drawing.Size(97, 19);
            this.lib_create_book_author_name_l.TabIndex = 78;
            this.lib_create_book_author_name_l.Text = "Author Name :";
            // 
            // lib_create_book_book_name_tb
            // 
            this.lib_create_book_book_name_tb.Font = new System.Drawing.Font("Arial Nova Cond", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lib_create_book_book_name_tb.Location = new System.Drawing.Point(177, 96);
            this.lib_create_book_book_name_tb.Name = "lib_create_book_book_name_tb";
            this.lib_create_book_book_name_tb.Size = new System.Drawing.Size(271, 26);
            this.lib_create_book_book_name_tb.TabIndex = 83;
            // 
            // lib_create_book_total_star_l
            // 
            this.lib_create_book_total_star_l.AutoSize = true;
            this.lib_create_book_total_star_l.Font = new System.Drawing.Font("Arial Nova Cond", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lib_create_book_total_star_l.ForeColor = System.Drawing.Color.Red;
            this.lib_create_book_total_star_l.Location = new System.Drawing.Point(148, 235);
            this.lib_create_book_total_star_l.Name = "lib_create_book_total_star_l";
            this.lib_create_book_total_star_l.Size = new System.Drawing.Size(23, 30);
            this.lib_create_book_total_star_l.TabIndex = 86;
            this.lib_create_book_total_star_l.Text = "*";
            // 
            // lib_create_book_book_name_l
            // 
            this.lib_create_book_book_name_l.AutoSize = true;
            this.lib_create_book_book_name_l.Font = new System.Drawing.Font("Arial Nova Cond", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lib_create_book_book_name_l.Location = new System.Drawing.Point(6, 99);
            this.lib_create_book_book_name_l.Name = "lib_create_book_book_name_l";
            this.lib_create_book_book_name_l.Size = new System.Drawing.Size(87, 19);
            this.lib_create_book_book_name_l.TabIndex = 79;
            this.lib_create_book_book_name_l.Text = "Book Name :";
            // 
            // lib_create_book_author_name_star_l
            // 
            this.lib_create_book_author_name_star_l.AutoSize = true;
            this.lib_create_book_author_name_star_l.Font = new System.Drawing.Font("Arial Nova Cond", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lib_create_book_author_name_star_l.ForeColor = System.Drawing.Color.Red;
            this.lib_create_book_author_name_star_l.Location = new System.Drawing.Point(148, 143);
            this.lib_create_book_author_name_star_l.Name = "lib_create_book_author_name_star_l";
            this.lib_create_book_author_name_star_l.Size = new System.Drawing.Size(23, 30);
            this.lib_create_book_author_name_star_l.TabIndex = 87;
            this.lib_create_book_author_name_star_l.Text = "*";
            // 
            // lib_create_book_book_name_star_l
            // 
            this.lib_create_book_book_name_star_l.AutoSize = true;
            this.lib_create_book_book_name_star_l.Font = new System.Drawing.Font("Arial Nova Cond", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lib_create_book_book_name_star_l.ForeColor = System.Drawing.Color.Red;
            this.lib_create_book_book_name_star_l.Location = new System.Drawing.Point(148, 96);
            this.lib_create_book_book_name_star_l.Name = "lib_create_book_book_name_star_l";
            this.lib_create_book_book_name_star_l.Size = new System.Drawing.Size(23, 30);
            this.lib_create_book_book_name_star_l.TabIndex = 88;
            this.lib_create_book_book_name_star_l.Text = "*";
            // 
            // lib_create_book_book_id_star_l
            // 
            this.lib_create_book_book_id_star_l.AutoSize = true;
            this.lib_create_book_book_id_star_l.Font = new System.Drawing.Font("Arial Nova Cond", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lib_create_book_book_id_star_l.ForeColor = System.Drawing.Color.Red;
            this.lib_create_book_book_id_star_l.Location = new System.Drawing.Point(148, 50);
            this.lib_create_book_book_id_star_l.Name = "lib_create_book_book_id_star_l";
            this.lib_create_book_book_id_star_l.Size = new System.Drawing.Size(23, 30);
            this.lib_create_book_book_id_star_l.TabIndex = 89;
            this.lib_create_book_book_id_star_l.Text = "*";
            // 
            // lib_create_book_category_name_cb
            // 
            this.lib_create_book_category_name_cb.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.lib_create_book_category_name_cb.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.lib_create_book_category_name_cb.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lib_create_book_category_name_cb.Font = new System.Drawing.Font("Arial Nova Cond", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lib_create_book_category_name_cb.FormattingEnabled = true;
            this.lib_create_book_category_name_cb.Location = new System.Drawing.Point(177, 188);
            this.lib_create_book_category_name_cb.Name = "lib_create_book_category_name_cb";
            this.lib_create_book_category_name_cb.Size = new System.Drawing.Size(271, 28);
            this.lib_create_book_category_name_cb.TabIndex = 108;
            // 
            // lib_create_book_category_name_l
            // 
            this.lib_create_book_category_name_l.AutoSize = true;
            this.lib_create_book_category_name_l.Font = new System.Drawing.Font("Arial Nova Cond", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lib_create_book_category_name_l.Location = new System.Drawing.Point(6, 192);
            this.lib_create_book_category_name_l.Name = "lib_create_book_category_name_l";
            this.lib_create_book_category_name_l.Size = new System.Drawing.Size(109, 19);
            this.lib_create_book_category_name_l.TabIndex = 109;
            this.lib_create_book_category_name_l.Text = "Category Name :";
            // 
            // lib_create_book_category_name_star_l
            // 
            this.lib_create_book_category_name_star_l.AutoSize = true;
            this.lib_create_book_category_name_star_l.Font = new System.Drawing.Font("Arial Nova Cond", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lib_create_book_category_name_star_l.ForeColor = System.Drawing.Color.Red;
            this.lib_create_book_category_name_star_l.Location = new System.Drawing.Point(148, 192);
            this.lib_create_book_category_name_star_l.Name = "lib_create_book_category_name_star_l";
            this.lib_create_book_category_name_star_l.Size = new System.Drawing.Size(23, 30);
            this.lib_create_book_category_name_star_l.TabIndex = 110;
            this.lib_create_book_category_name_star_l.Text = "*";
            // 
            // LIB_CREATE_BOOK_FORM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.ClientSize = new System.Drawing.Size(460, 327);
            this.Controls.Add(this.lib_create_book_category_name_star_l);
            this.Controls.Add(this.lib_create_book_category_name_l);
            this.Controls.Add(this.lib_create_book_category_name_cb);
            this.Controls.Add(this.lib_create_book_title_bar_panel);
            this.Controls.Add(this.lib_create_book_cancel_btn);
            this.Controls.Add(this.lib_create_book_add_btn);
            this.Controls.Add(this.lib_create_book_total_tb);
            this.Controls.Add(this.lib_create_book_book_id_tb);
            this.Controls.Add(this.lib_create_book_book_id_l);
            this.Controls.Add(this.lib_create_book_total_l);
            this.Controls.Add(this.lib_create_book_author_name_tb);
            this.Controls.Add(this.lib_create_book_author_name_l);
            this.Controls.Add(this.lib_create_book_book_name_tb);
            this.Controls.Add(this.lib_create_book_total_star_l);
            this.Controls.Add(this.lib_create_book_book_name_l);
            this.Controls.Add(this.lib_create_book_author_name_star_l);
            this.Controls.Add(this.lib_create_book_book_name_star_l);
            this.Controls.Add(this.lib_create_book_book_id_star_l);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LIB_CREATE_BOOK_FORM";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LIB_CREATE_BOOK_FORM";
            this.Load += new System.EventHandler(this.LIB_CREATE_BOOK_FORM_Load);
            this.lib_create_book_title_bar_panel.ResumeLayout(false);
            this.lib_create_book_title_bar_panel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel lib_create_book_title_bar_panel;
        private System.Windows.Forms.Button shopfy_create_customer_minimize_btn;
        private System.Windows.Forms.Label lib_create_book_title_l;
        private System.Windows.Forms.Button shopfy_create_customer_close_btn;
        private System.ComponentModel.BackgroundWorker New_Customer_Grid_BackgroundWorker;
        private System.Windows.Forms.Button lib_create_book_cancel_btn;
        private System.Windows.Forms.Button lib_create_book_add_btn;
        private System.Windows.Forms.TextBox lib_create_book_total_tb;
        private System.Windows.Forms.TextBox lib_create_book_book_id_tb;
        private System.Windows.Forms.Label lib_create_book_book_id_l;
        private System.Windows.Forms.Label lib_create_book_total_l;
        private System.Windows.Forms.TextBox lib_create_book_author_name_tb;
        private System.Windows.Forms.Label lib_create_book_author_name_l;
        private System.Windows.Forms.TextBox lib_create_book_book_name_tb;
        private System.Windows.Forms.Label lib_create_book_total_star_l;
        private System.Windows.Forms.Label lib_create_book_book_name_l;
        private System.Windows.Forms.Label lib_create_book_author_name_star_l;
        private System.Windows.Forms.Label lib_create_book_book_name_star_l;
        private System.Windows.Forms.Label lib_create_book_book_id_star_l;
        private System.Windows.Forms.ComboBox lib_create_book_category_name_cb;
        private System.Windows.Forms.Label lib_create_book_category_name_l;
        private System.Windows.Forms.Label lib_create_book_category_name_star_l;
    }
}