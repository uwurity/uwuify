using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using Newtonsoft.Json;
namespace exercise_6
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        private const string ApiUrl = "https://jsonplaceholder.typicode.com/posts";
        private async void btn_do_Click(object sender, EventArgs e)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    var res = await httpClient.GetAsync(ApiUrl);
                    res.EnsureSuccessStatusCode();

                    var content = await res.Content.ReadAsStringAsync();
                    var photoList = JsonConvert.DeserializeObject<List<PhotoItem>>(content);

                    listBox1.Items.Clear();
                    foreach (var item in photoList)
                    {
                        listBox1.Items.Add($" User:{item.userId} - {item.id} - {item.title}");
                        listBox1.Items.Add($"{item.body}");
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
 
    class PhotoItem
    {
        public int userId { get; set; }
        public int id { get; set; }
        public string title { get; set; }
        public string body { get; set; }
    }
}

