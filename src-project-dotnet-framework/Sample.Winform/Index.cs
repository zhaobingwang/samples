using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sample.Winform
{
    public partial class Index : Form
    {
        public Index()
        {
            InitializeComponent();
        }

        Order order = new Order();
        private void btnMemoryLeak_Click(object sender, EventArgs e)
        {
            
            order.CalculateQuantityEvents += Order_CalculateQuantityEvents;
            order.Add(1);
            order.Add(2);
            order.Add(3);
        }

        private void Order_CalculateQuantityEvents(int obj)
        {

            label1.Text += order.Count.ToString();
        }

        private void Index_Load(object sender, EventArgs e)
        {
            label1.Text = "";
        }
    }

    class Order
    {
        public string ProductName { get; set; }
        public int Count { get; set; }

        public int Add(int count)
        {
            Count += count;
            this.calculateQuantityEvents(count);
            return Count;
        }

        private Action<int> calculateQuantityEvents;
        public event Action<int> CalculateQuantityEvents
        {
            add
            {
                calculateQuantityEvents = value;
            }
            remove
            {
                if (calculateQuantityEvents != null)
                    calculateQuantityEvents -= value;
            }
        }
    }
}
