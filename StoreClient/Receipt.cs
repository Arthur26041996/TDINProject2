using Shared;
using System.Windows.Forms;

namespace StoreClient
{
    public partial class Receipt : Form
    {
        Sale sale;
        Form callback;

        public Receipt(Form callback, Sale sale)
        {
            InitializeComponent();
            this.sale = sale;
            this.callback = callback;

            this.label7.Text = sale.client.cpf.ToString();
            this.label8.Text = sale.client.Name;
            this.label9.Text = sale.book.title;
            this.label10.Text = sale.quantity.ToString();
            this.label11.Text = sale.book.price.ToString();
            this.label12.Text = (sale.book.price * sale.quantity).ToString();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            callback.Close();
        }

    }
}
