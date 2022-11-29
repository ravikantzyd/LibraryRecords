namespace Library_Records.Setting
{
    partial class LIB_SETTING_FORM
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
            this.lib_setting_change_pass_link_l = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // lib_setting_change_pass_link_l
            // 
            this.lib_setting_change_pass_link_l.AutoSize = true;
            this.lib_setting_change_pass_link_l.Font = new System.Drawing.Font("Arial Nova Cond", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lib_setting_change_pass_link_l.LinkColor = System.Drawing.Color.White;
            this.lib_setting_change_pass_link_l.Location = new System.Drawing.Point(509, 272);
            this.lib_setting_change_pass_link_l.Name = "lib_setting_change_pass_link_l";
            this.lib_setting_change_pass_link_l.Size = new System.Drawing.Size(123, 20);
            this.lib_setting_change_pass_link_l.TabIndex = 145;
            this.lib_setting_change_pass_link_l.TabStop = true;
            this.lib_setting_change_pass_link_l.Text = "Change Password";
            this.lib_setting_change_pass_link_l.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lib_setting_change_pass_link_l_LinkClicked);
            // 
            // LIB_SETTING_FORM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1122, 694);
            this.Controls.Add(this.lib_setting_change_pass_link_l);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LIB_SETTING_FORM";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "LIB_SETTING_FORM";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel lib_setting_change_pass_link_l;
    }
}