using Shared;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Warehouse
{
    public partial class Main : Form
    {
        IRemWH remWh;

        public Main()
        {
            InitializeComponent();
            List<Order> orders;
            remWh = (IRemWH)GetRemote.New(typeof(IRemWH));
            string queueName = @".\Private$\TDIN";
            orders = remWh.getOrdes(queueName);

            foreach (Order od in orders)
            {
                this.dataGridView1.Rows.Add(od.id, od.book.title, od.quantity, od.requestDate);
            }
        }
    }
}
