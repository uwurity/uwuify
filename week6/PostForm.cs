using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Windows.Forms;
using exercise_6.Abstract;

namespace exercise_6;

public partial class PostForm : Form
{
    public PostForm()
    {
        InitializeComponent();
    }

    private const string ApiUrl = "https://jsonplaceholder.typicode.com/posts";

    private async void RefreshButton_Click(object sender, EventArgs e)
    {
        listBox.Items.Clear();
        try
        {
            using var httpClient = new HttpClient();
            var posts = await httpClient.GetFromJsonAsync<List<Post>>(ApiUrl);
            posts?.ForEach(post => listBox.Items.Add(post));
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }
}