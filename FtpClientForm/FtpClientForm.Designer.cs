using System.Drawing;
using System.Windows.Forms;

namespace FtpClientForm;

partial class FtpClientForm
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
        host = new TextBox();
        username = new TextBox();
        password = new MaskedTextBox();
        fileView = new ListView();
        number = new ColumnHeader();
        name = new ColumnHeader();
        type = new ColumnHeader();
        size = new ColumnHeader();
        modifiedTime = new ColumnHeader();
        checksum = new ColumnHeader();
        hostLabel = new Label();
        usernameLabel = new Label();
        passwordLabel = new Label();
        remoteSiteLabel = new Label();
        connectBtn = new Button();
        uploadBtn = new Button();
        downloadBtn = new Button();
        uploadOnlyFolders = new CheckBox();
        SuspendLayout();
        // 
        // host
        // 
        host.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        host.Location = new Point(132, 12);
        host.Name = "host";
        host.PlaceholderText = "localhost";
        host.Size = new Size(549, 27);
        host.TabIndex = 0;
        // 
        // username
        // 
        username.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        username.Location = new Point(132, 45);
        username.Name = "username";
        username.PlaceholderText = "anonymous";
        username.Size = new Size(549, 27);
        username.TabIndex = 1;
        // 
        // password
        // 
        password.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        password.Location = new Point(132, 78);
        password.Name = "password";
        password.PasswordChar = '*';
        password.Size = new Size(549, 27);
        password.TabIndex = 2;
        // 
        // fileView
        // 
        fileView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        fileView.Columns.AddRange(new ColumnHeader[] { number, name, type, size, modifiedTime, checksum });
        fileView.Enabled = false;
        fileView.FullRowSelect = true;
        fileView.Location = new Point(12, 192);
        fileView.Name = "fileView";
        fileView.Size = new Size(669, 246);
        fileView.TabIndex = 3;
        fileView.UseCompatibleStateImageBehavior = false;
        fileView.View = View.Details;
        fileView.SelectedIndexChanged += fileView_SelectedIndexChanged;
        // 
        // number
        // 
        number.Text = "#";
        // 
        // name
        // 
        name.Text = "Name";
        // 
        // type
        // 
        type.Text = "Type";
        // 
        // size
        // 
        size.Text = "Size";
        // 
        // modifiedTime
        // 
        modifiedTime.Text = "Modified Time";
        // 
        // checksum
        // 
        checksum.Text = "Checksum";
        // 
        // hostLabel
        // 
        hostLabel.AutoSize = true;
        hostLabel.Location = new Point(12, 15);
        hostLabel.Name = "hostLabel";
        hostLabel.Size = new Size(93, 20);
        hostLabel.TabIndex = 4;
        hostLabel.Text = "IP FTP Server";
        // 
        // usernameLabel
        // 
        usernameLabel.AutoSize = true;
        usernameLabel.Location = new Point(12, 48);
        usernameLabel.Name = "usernameLabel";
        usernameLabel.Size = new Size(75, 20);
        usernameLabel.TabIndex = 5;
        usernameLabel.Text = "Username";
        // 
        // passwordLabel
        // 
        passwordLabel.AutoSize = true;
        passwordLabel.Location = new Point(12, 81);
        passwordLabel.Name = "passwordLabel";
        passwordLabel.Size = new Size(70, 20);
        passwordLabel.TabIndex = 6;
        passwordLabel.Text = "Password";
        // 
        // remoteSiteLabel
        // 
        remoteSiteLabel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
        remoteSiteLabel.AutoSize = true;
        remoteSiteLabel.Location = new Point(12, 159);
        remoteSiteLabel.Name = "remoteSiteLabel";
        remoteSiteLabel.Size = new Size(90, 20);
        remoteSiteLabel.TabIndex = 7;
        remoteSiteLabel.Text = "Remote Site";
        // 
        // connectBtn
        // 
        connectBtn.Location = new Point(12, 116);
        connectBtn.Name = "connectBtn";
        connectBtn.Size = new Size(94, 29);
        connectBtn.TabIndex = 8;
        connectBtn.Text = "Connect";
        connectBtn.UseVisualStyleBackColor = true;
        connectBtn.Click += connectBtn_Click;
        // 
        // uploadBtn
        // 
        uploadBtn.Anchor = AnchorStyles.Right;
        uploadBtn.Enabled = false;
        uploadBtn.Location = new Point(699, 274);
        uploadBtn.Name = "uploadBtn";
        uploadBtn.Size = new Size(111, 29);
        uploadBtn.TabIndex = 9;
        uploadBtn.Text = "Upload";
        uploadBtn.UseVisualStyleBackColor = true;
        uploadBtn.Click += uploadBtn_Click;
        // 
        // downloadBtn
        // 
        downloadBtn.Anchor = AnchorStyles.Right;
        downloadBtn.Enabled = false;
        downloadBtn.Location = new Point(699, 344);
        downloadBtn.Name = "downloadBtn";
        downloadBtn.Size = new Size(111, 29);
        downloadBtn.TabIndex = 10;
        downloadBtn.Text = "Download";
        downloadBtn.UseVisualStyleBackColor = true;
        downloadBtn.Click += downloadBtn_Click;
        // 
        // uploadOnlyFolders
        // 
        uploadOnlyFolders.Anchor = AnchorStyles.Right;
        uploadOnlyFolders.AutoSize = true;
        uploadOnlyFolders.Location = new Point(699, 244);
        uploadOnlyFolders.Name = "uploadOnlyFolders";
        uploadOnlyFolders.Size = new Size(111, 24);
        uploadOnlyFolders.TabIndex = 11;
        uploadOnlyFolders.Text = "Only folders";
        uploadOnlyFolders.TextAlign = ContentAlignment.MiddleCenter;
        uploadOnlyFolders.UseVisualStyleBackColor = true;
        // 
        // FtpClientForm
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(822, 450);
        Controls.Add(uploadOnlyFolders);
        Controls.Add(downloadBtn);
        Controls.Add(uploadBtn);
        Controls.Add(connectBtn);
        Controls.Add(remoteSiteLabel);
        Controls.Add(passwordLabel);
        Controls.Add(usernameLabel);
        Controls.Add(hostLabel);
        Controls.Add(fileView);
        Controls.Add(password);
        Controls.Add(username);
        Controls.Add(host);
        MinimumSize = new Size(818, 497);
        Name = "FtpClientForm";
        Text = "Form1";
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private TextBox host;
    private TextBox username;
    private MaskedTextBox password;
    private ListView fileView;
    private Label hostLabel;
    private Label usernameLabel;
    private Label passwordLabel;
    private Label remoteSiteLabel;
    private Button connectBtn;
    private Button uploadBtn;
    private Button downloadBtn;
    private ColumnHeader number;
    private ColumnHeader name;
    private ColumnHeader type;
    private ColumnHeader checksum;
    private ColumnHeader modifiedTime;
    private ColumnHeader size;
    private CheckBox uploadOnlyFolders;
}