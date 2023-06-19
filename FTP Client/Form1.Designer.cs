namespace FTP_Client
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txt_ip = new TextBox();
            txt_username = new TextBox();
            txt_password = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            btn_upload = new Button();
            btn_download = new Button();
            SuspendLayout();
            // 
            // txt_ip
            // 
            txt_ip.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            txt_ip.Location = new Point(214, 95);
            txt_ip.Name = "txt_ip";
            txt_ip.Size = new Size(340, 27);
            txt_ip.TabIndex = 0;
            // 
            // txt_username
            // 
            txt_username.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            txt_username.Location = new Point(214, 178);
            txt_username.Name = "txt_username";
            txt_username.Size = new Size(340, 27);
            txt_username.TabIndex = 1;
            // 
            // txt_password
            // 
            txt_password.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            txt_password.Location = new Point(214, 260);
            txt_password.Name = "txt_password";
            txt_password.Size = new Size(340, 27);
            txt_password.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(111, 95);
            label1.Name = "label1";
            label1.Size = new Size(80, 20);
            label1.TabIndex = 3;
            label1.Text = "FTP Server:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(128, 178);
            label2.Name = "label2";
            label2.Size = new Size(78, 20);
            label2.TabIndex = 4;
            label2.Text = "Username:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(128, 260);
            label3.Name = "label3";
            label3.Size = new Size(73, 20);
            label3.TabIndex = 5;
            label3.Text = "Password:";
            // 
            // btn_upload
            // 
            btn_upload.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btn_upload.Location = new Point(198, 339);
            btn_upload.Name = "btn_upload";
            btn_upload.Size = new Size(152, 41);
            btn_upload.TabIndex = 6;
            btn_upload.Text = "Upload";
            btn_upload.UseVisualStyleBackColor = true;
            btn_upload.Click += btn_upload_Click;
            // 
            // btn_download
            // 
            btn_download.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btn_download.Location = new Point(422, 339);
            btn_download.Name = "btn_download";
            btn_download.Size = new Size(152, 41);
            btn_download.TabIndex = 7;
            btn_download.Text = "Download";
            btn_download.UseVisualStyleBackColor = true;
            btn_download.Click += btn_download_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btn_download);
            Controls.Add(btn_upload);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txt_password);
            Controls.Add(txt_username);
            Controls.Add(txt_ip);
            Name = "Form1";
            Text = "FTP Client";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txt_ip;
        private TextBox txt_username;
        private TextBox txt_password;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button btn_upload;
        private Button btn_download;
    }
}