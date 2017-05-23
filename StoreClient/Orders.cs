using Shared;
using System.Windows.Forms;

namespace StoreClient
{
    public partial class Orders : Form
    {
        Form callback;
        public static IRemBook remBook;


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
    }
}
