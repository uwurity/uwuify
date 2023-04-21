using System;
using System.Windows.Forms;

namespace exercise_6;

public partial class MainForm : Form
{
    public MainForm()
    {
        InitializeComponent();
    }

    private void TodoButton_Click(object sender, EventArgs e)
    {
        var todoForm = new TodoForm();
        todoForm.ShowDialog();
    }

    private void PostButton_Click(object sender, EventArgs e)
    {
        var postForm = new PostForm();
        postForm.ShowDialog();
    }
}