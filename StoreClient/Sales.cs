using Shared;
using System.Windows.Forms;

namespace StoreClient
{
    public partial class Sales : Form
    {
        Form callback;
        IRemBook remBook;

        public Sales(Form callback)
        {
            InitializeComponent();
            this.callback = callback;

            remBook = (IRemBook)GetRemote.New(typeof(IRemBook));

            int[] keys = remBook.getSalesId();
            Sale sale;

            foreach (int id in keys)
            {
                sale = remBook.getSale(id);
                this.dataGridView1.Rows.Add(sale.id, sale.client.cpf, sale.client.Name, sale.book.title, sale.quantity, sale.totalPrice);
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
