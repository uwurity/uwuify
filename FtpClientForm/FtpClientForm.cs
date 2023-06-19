using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using FluentFTP;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace FtpClientForm;

public partial class FtpClientForm : Form
{
    private AsyncFtpClient? _ftpClient;

    public FtpClientForm()
    {
        InitializeComponent();
        host.Text = host.PlaceholderText;
        username.Text = username.PlaceholderText;
    }

    private void connectBtn_Click(object? sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(host.Text)
            || string.IsNullOrWhiteSpace(username.Text))
        {
            MessageBox.Show("Invalid FTP parameter(s)!", "Notice");
            return;
        }

        connectBtn.Text = "Connecting...";
        connectBtn.Enabled = false;

        Task.Run(() => Invoke(ConnectAsync));
    }

    private async Task ConnectAsync()
    {
        try
        {
            _ftpClient = new(host.Text, username.Text, password.Text);
            _ftpClient.Config.ValidateAnyCertificate = true;
            // https://github.com/robinrodricks/FluentFTP/issues/122#issuecomment-357035727
            await _ftpClient.AutoConnect();
            connectBtn.Text = "Connected";
            await RefreshFileView();
        }
        catch (Exception e)
        {
            MessageBox.Show($"Cannot connect to FTP server! Error: {e.Message}", "Notice");
            connectBtn.Text = "Connect";
            connectBtn.Enabled = true;
        }
    }

    private async Task RefreshFileView()
    {
        if (_ftpClient == null) return;

        fileView.Enabled = false;
        uploadBtn.Enabled = false;

        fileView.Items.Clear();

        var index = 0;
        foreach (var item in await _ftpClient.GetListing("/"))
        {
            if (_ftpClient == null) return;

            FtpHash? hash = null;
            long? fileSize = null;

            // if this is a file
            if (item.Type is FtpObjectType.File)
            {
                // get the file size
                fileSize = item.Size;
                // calculate a hash for the file on the server side (default algorithm)
                try
                {
                    hash = await _ftpClient.GetChecksum(item.FullName);
                }
                catch
                {
                    // ignored
                }
            }

            // get modified date/time of the file or folder
            var time = item.Modified;

            var fileItem = new ListViewItem { Text = $"{++index}", };

            fileItem.SubItems.Add(new ListViewItem.ListViewSubItem { Text = item.FullName, });
            fileItem.SubItems.Add(new ListViewItem.ListViewSubItem
                { Text = item.Type is FtpObjectType.File ? "file" : "dir", });
            fileItem.SubItems.Add(new ListViewItem.ListViewSubItem { Text = fileSize != null ? $"{fileSize}" : "", });
            fileItem.SubItems.Add(new ListViewItem.ListViewSubItem { Text = $"{time}", });
            fileItem.SubItems.Add(new ListViewItem.ListViewSubItem { Text = hash != null ? $"{hash}" : "", });

            fileView.Items.Add(fileItem);
        }

        fileView.Enabled = true;
        fileView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);

        uploadBtn.Enabled = true;
    }

    private void uploadBtn_Click(object? sender, EventArgs e)
    {
        var ofd = new CommonOpenFileDialog
        {
            InitialDirectory = @"C:/Users",
            Multiselect = true,
        };
        ofd.IsFolderPicker = uploadOnlyFolders.Checked;
        if (ofd.ShowDialog() is not CommonFileDialogResult.Ok) return;
        uploadBtn.Text = "Uploading...";
        uploadBtn.Enabled = false;
        Task.Run(() => Invoke(UploadAsync, ofd));
    }

    private async Task UploadAsync(object? ofdObj)
    {
        if (_ftpClient != null && ofdObj is CommonOpenFileDialog ofd)
        {
            try
            {
                if (uploadOnlyFolders.Checked)
                    foreach (var localDir in ofd.FileNames)
                        await _ftpClient.UploadDirectory(localDir, Path.Combine("/", Path.GetFileName(localDir)));
                else
                    await _ftpClient.UploadFiles(ofd.FileNames, "/", errorHandling: FtpError.Throw);
                await RefreshFileView();
            }
            catch (Exception e)
            {
                MessageBox.Show($"Upload file(s) failed. Error: {e.Message}", "Notice");
            }
        }

        uploadBtn.Text = "Upload";
        uploadBtn.Enabled = true;
    }

    private void downloadBtn_Click(object? sender, EventArgs e)
    {
        var ofd = new CommonOpenFileDialog
        {
            InitialDirectory = @"C:/Users",
            IsFolderPicker = true,
        };
        if (ofd.ShowDialog() is not CommonFileDialogResult.Ok) return;
        downloadBtn.Text = "Downloading...";
        downloadBtn.Enabled = false;
        Task.Run(() => Invoke(DownloadAsync, ofd));
    }

    private async Task DownloadAsync(object? ofdObj)
    {
        if (_ftpClient != null && ofdObj is CommonOpenFileDialog ofd)
        {
            var localDir = ofd.FileName;

            var fileGroups = fileView.SelectedItems
                .Cast<ListViewItem>()
                .Select(item => (Type: item.SubItems[type.DisplayIndex].Text,
                    Name: item.SubItems[name.DisplayIndex].Text))
                .GroupBy(item => item.Type);

            try
            {
                foreach (var fileGroup in fileGroups)
                {
                    var remoteFiles = fileGroup.Select(item => item.Name);
                    switch (fileGroup.Key)
                    {
                        case "file":
                            await _ftpClient.DownloadFiles(localDir, remoteFiles, errorHandling: FtpError.Throw);
                            break;
                        case "dir":
                            foreach (var remoteFolder in remoteFiles)
                                await _ftpClient.DownloadDirectory(Path.Combine(localDir, remoteFolder), remoteFolder);
                            break;
                    }
                }

                await RefreshFileView();

                Process.Start(new ProcessStartInfo()
                {
                    FileName = localDir,
                    UseShellExecute = true,
                    Verb = "open"
                });
            }
            catch (Exception e)
            {
                MessageBox.Show($"Download file(s) failed. Error: {e.Message}", "Notice");
            }
        }

        downloadBtn.Text = "Download";
        downloadBtn.Enabled = true;
    }

    private void fileView_SelectedIndexChanged(object? sender, EventArgs e)
        => downloadBtn.Enabled = fileView.SelectedItems.Count > 0;
}