using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sample.WinformClient.TaskAsynchronousProgramming
{
    public partial class Home : Form
    {
        /// <summary>
        /// visit:https://docs.microsoft.com/zh-cn/dotnet/csharp/programming-guide/concepts/async/task-asynchronous-programming-model
        /// </summary>
        public Home()
        {
            InitializeComponent();
        }

        private void BtnAccessWebAsync_Click(object sender, EventArgs e)
        {
            
        }
        async Task<int> AccessTheWebAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                Task<string> getStringTask = client.GetStringAsync("https://docs.microsoft.com");
                DoIndependentWork();
                string urlContents = await getStringTask;
                return urlContents.Length;
            }
        }

        private void DoIndependentWork()
        {

        }
    }
}
