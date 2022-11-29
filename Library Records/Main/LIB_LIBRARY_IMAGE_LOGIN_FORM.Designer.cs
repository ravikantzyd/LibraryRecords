namespace Library_Records.Main
{
    partial class LIB_LIBRARY_IMAGE_LOGIN_FORM
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
            this.lib_login_login_btn = new System.Windows.Forms.Button();
            this.shopfy_create_customer_close_btn = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lib_login_login_btn
            // 
            this.lib_login_login_btn.BackColor = System.Drawing.Color.Transparent;
            this.lib_login_login_btn.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.lib_login_login_btn.FlatAppearance.BorderSize = 0;
            this.lib_login_login_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lib_login_login_btn.Font = new System.Drawing.Font("Arial Nova Cond", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lib_login_login_btn.ForeColor = System.Drawing.Color.Black;
            this.lib_login_login_btn.Location = new System.Drawing.Point(301, 176);
            this.lib_login_login_btn.Name = "lib_login_login_btn";
            this.lib_login_login_btn.Size = new System.Drawing.Size(190, 60);
            this.lib_login_login_btn.TabIndex = 136;
            this.lib_login_login_btn.Text = "Go to Log in";
            this.lib_login_login_btn.UseVisualStyleBackColor = false;
            this.lib_login_login_btn.Click += new System.EventHandler(this.lib_login_login_btn_Click);
            this.lib_login_login_btn.Paint += new System.Windows.Forms.PaintEventHandler(this.lib_login_login_btn_Paint);
            // 
            // shopfy_create_customer_close_btn
            // 
            this.shopfy_create_customer_close_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.shopfy_create_customer_close_btn.FlatAppearance.BorderSize = 0;
            this.shopfy_create_customer_close_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.shopfy_create_customer_close_btn.Image = global::Library_Records.Properties.Resources.close;
            this.shopfy_create_customer_close_btn.Location = new System.Drawing.Point(769, 0);
            this.shopfy_create_customer_close_btn.Name = "shopfy_create_customer_close_btn";
            this.shopfy_create_customer_close_btn.Size = new System.Drawing.Size(31, 33);
            this.shopfy_create_customer_close_btn.TabIndex = 137;
            this.shopfy_create_customer_close_btn.UseVisualStyleBackColor = false;
            this.shopfy_create_customer_close_btn.Click += new System.EventHandler(this.shopfy_create_customer_close_btn_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Library_Records.Properties.Resources.IMG_9585afb9f6eee2948cc40e7b493eef8e_V;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(800, 328);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            // 
            // LIB_LIBRARY_IMAGE_LOGIN_FORM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 328);
            this.Controls.Add(this.lib_login_login_btn);
            this.Controls.Add(this.shopfy_create_customer_close_btn);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LIB_LIBRARY_IMAGE_LOGIN_FORM";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LIB_LIBRARY_IMAGE_LOGIN_FORM";
            this.Load += new System.EventHandler(this.LIB_LIBRARY_IMAGE_LOGIN_FORM_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button lib_login_login_btn;
        private System.Windows.Forms.Button shopfy_create_customer_close_btn;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}