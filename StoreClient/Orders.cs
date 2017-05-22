using Shared;
using System;
using System.Windows.Controls;
using System.Windows.Forms;

namespace StoreClient
{
    public partial class Orders : Form
    {
        Form callback;
        IRemBook remBook;


        public Orders(Form callback)
        {
            InitializeComponent();
            this.callback = callback;
            remBook = (IRemBook)GetRemote.New(typeof(IRemBook));

            int[] keys = remBook.getOrdersId();
            Order order;

            foreach (int id in keys)
            {
                order = remBook.getOrder(id);
                this.dataGridView1.Rows.Add(order.id, order.book.title, order.status, order.requestDate, order.replyDate);
            }
        }



        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            callback.Enabled = true;
            callback.Show();
            callback.Activate();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Order order;
            for(int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                Console.WriteLine(this.dataGridView1.Rows.Count);
                Console.WriteLine(this.dataGridView1.Rows[i]);
                var id = Convert.ToInt32(this.dataGridView1.Rows[i].Cells[0].Value);
                order = remBook.getOrder(id);
                if (order != null)
                {
                    this.dataGridView1.Rows[i].Cells[2].Value = order.status;
                    this.dataGridView1.Rows[i].Cells[3].Value = order.requestDate;
                    this.dataGridView1.Rows[i].Cells[4].Value = order.replyDate;
                }
                else
                    MessageBox.Show("Order not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
