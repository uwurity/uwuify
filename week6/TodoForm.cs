using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Windows.Forms;
using exercise_6.Abstract;

namespace exercise_6;

public partial class TodoForm : Form
{
    public TodoForm()
    {
        InitializeComponent();
    }

    private const string ApiUrl = "https://jsonplaceholder.typicode.com/todos";

    private async void RefreshButton_Click(object sender, EventArgs e)
    {
        listBox.Items.Clear();
        try
        {
            using var httpClient = new HttpClient();
            var todos = await httpClient.GetFromJsonAsync<List<Todo>>(ApiUrl);
            todos?.ForEach(todo => listBox.Items.Add(todo));
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }
}