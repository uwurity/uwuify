using System;
using System.Windows.Forms;

namespace FtpClientForm;

internal static class Program
{
    [STAThread]
    private static void Main()
    {
        ApplicationConfiguration.Initialize();
        Application.Run(new FtpClientForm());
    }
}