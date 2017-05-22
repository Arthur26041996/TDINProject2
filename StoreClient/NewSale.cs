using Shared;
using System;
using System.Windows.Forms;

namespace StoreClient
{
    public partial class NewSale : Form
    {
        Form callback;
        IRemBook remBook;
        IRemClient remClient;

        public NewSale(Form callback)
        {
            InitializeComponent();
            this.callback = callback;
            remBook = (IRemBook)GetRemote.New(typeof(IRemBook));
            remClient = (IRemClient)GetRemote.New(typeof(IRemClient));
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            callback.Enabled = true;
            callback.Show();
            callback.Activate();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) ||
                string.IsNullOrEmpty(textBox2.Text) ||
                string.IsNullOrEmpty(textBox3.Text) ||
                string.IsNullOrEmpty(textBox4.Text)
                )
            {
                MessageBox.Show("Some fields are empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Shared.Client clt = remClient.getClient(long.Parse(textBox1.Text));
                Shared.Book bk = remBook.getBookByTitle(textBox2.Text);


                remBook.sellBook(bk, clt, int.Parse(textBox3.Text));
                
            }
        }
    }
}
