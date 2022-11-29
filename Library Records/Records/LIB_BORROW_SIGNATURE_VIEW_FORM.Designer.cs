namespace Library_Records.Records
{
    partial class LIB_BORROW_SIGNATURE_VIEW_FORM
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
            this.lib_borrow_sign_title_bar_panel = new System.Windows.Forms.Panel();
            this.lib_borrow_sign_title_l = new System.Windows.Forms.Label();
            this.lib_borrow_sign_borrow_signature_panel = new System.Windows.Forms.Panel();
            this.lib_borrow_sign_close_btn = new System.Windows.Forms.Button();
            this.lib_borrow_sign_title_bar_panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // lib_borrow_sign_title_bar_panel
            // 
            this.lib_borrow_sign_title_bar_panel.BackColor = System.Drawing.Color.DarkGreen;
            this.lib_borrow_sign_title_bar_panel.Controls.Add(this.lib_borrow_sign_title_l);
            this.lib_borrow_sign_title_bar_panel.Controls.Add(this.lib_borrow_sign_close_btn);
            this.lib_borrow_sign_title_bar_panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.lib_borrow_sign_title_bar_panel.Location = new System.Drawing.Point(0, 0);
            this.lib_borrow_sign_title_bar_panel.Name = "lib_borrow_sign_title_bar_panel";
            this.lib_borrow_sign_title_bar_panel.Size = new System.Drawing.Size(295, 33);
            this.lib_borrow_sign_title_bar_panel.TabIndex = 66;
            this.lib_borrow_sign_title_bar_panel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lib_borrow_sign_title_bar_panel_MouseDown);
            // 
            // lib_borrow_sign_title_l
            // 
            this.lib_borrow_sign_title_l.AutoSize = true;
            this.lib_borrow_sign_title_l.Font = new System.Drawing.Font("Arial Nova Cond", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lib_borrow_sign_title_l.ForeColor = System.Drawing.Color.White;
            this.lib_borrow_sign_title_l.Location = new System.Drawing.Point(5, 6);
            this.lib_borrow_sign_title_l.Name = "lib_borrow_sign_title_l";
            this.lib_borrow_sign_title_l.Size = new System.Drawing.Size(119, 20);
            this.lib_borrow_sign_title_l.TabIndex = 3;
            this.lib_borrow_sign_title_l.Text = "Borrow Signature";
            // 
            // lib_borrow_sign_borrow_signature_panel
            // 
            this.lib_borrow_sign_borrow_signature_panel.BackColor = System.Drawing.Color.White;
            this.lib_borrow_sign_borrow_signature_panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lib_borrow_sign_borrow_signature_panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lib_borrow_sign_borrow_signature_panel.Location = new System.Drawing.Point(0, 33);
            this.lib_borrow_sign_borrow_signature_panel.Name = "lib_borrow_sign_borrow_signature_panel";
            this.lib_borrow_sign_borrow_signature_panel.Size = new System.Drawing.Size(295, 153);
            this.lib_borrow_sign_borrow_signature_panel.TabIndex = 128;
            this.lib_borrow_sign_borrow_signature_panel.Paint += new System.Windows.Forms.PaintEventHandler(this.lib_borrow_sign_return_signature_panel_Paint);
            // 
            // lib_borrow_sign_close_btn
            // 
            this.lib_borrow_sign_close_btn.Dock = System.Windows.Forms.DockStyle.Right;
            this.lib_borrow_sign_close_btn.FlatAppearance.BorderSize = 0;
            this.lib_borrow_sign_close_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lib_borrow_sign_close_btn.Image = global::Library_Records.Properties.Resources.close;
            this.lib_borrow_sign_close_btn.Location = new System.Drawing.Point(264, 0);
            this.lib_borrow_sign_close_btn.Name = "lib_borrow_sign_close_btn";
            this.lib_borrow_sign_close_btn.Size = new System.Drawing.Size(31, 33);
            this.lib_borrow_sign_close_btn.TabIndex = 2;
            this.lib_borrow_sign_close_btn.UseVisualStyleBackColor = true;
            this.lib_borrow_sign_close_btn.Click += new System.EventHandler(this.lib_borrow_sign_close_btn_Click);
            // 
            // LIB_BORROW_SIGNATURE_VIEW_FORM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.ClientSize = new System.Drawing.Size(295, 186);
            this.Controls.Add(this.lib_borrow_sign_borrow_signature_panel);
            this.Controls.Add(this.lib_borrow_sign_title_bar_panel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LIB_BORROW_SIGNATURE_VIEW_FORM";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LIB_BORROW_SIGNATURE_VIEW_FORM";
            this.Load += new System.EventHandler(this.LIB_BORROW_SIGNATURE_VIEW_FORM_Load);
            this.lib_borrow_sign_title_bar_panel.ResumeLayout(false);
            this.lib_borrow_sign_title_bar_panel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel lib_borrow_sign_title_bar_panel;
        private System.Windows.Forms.Label lib_borrow_sign_title_l;
        private System.Windows.Forms.Button lib_borrow_sign_close_btn;
        private System.Windows.Forms.Panel lib_borrow_sign_borrow_signature_panel;
    }
}