using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Net.Http;
using Newtonsoft.Json;
namespace exercise_6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private const string ApiUrl = "https://jsonplaceholder.typicode.com/todos";
        private async void btn_do_Click(object sender, EventArgs e)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    var res = await httpClient.GetAsync(ApiUrl);
                    res.EnsureSuccessStatusCode();

                    var content = await res.Content.ReadAsStringAsync();
                    var toDoList = JsonConvert.DeserializeObject<List<ToDoItem>>(content);

                    listBox1.Items.Clear();
                    foreach (var item in toDoList)
                    {
                        listBox1.Items.Add($"User:{item.userId} - {item.id} - {item.title}");
                        listBox1.Items.Add(item.completed ? "Completed" : "Incomplete");
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
    
    public class ToDoItem
    {
        public int userId { get; set; }
        public int id { get; set; }
        public string title { get; set; }
        public bool completed { get; set; }
    }
 
}
