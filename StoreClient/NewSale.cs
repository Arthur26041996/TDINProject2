using Shared;
using System;
using System.Threading;
using System.Windows.Forms;

namespace StoreClient
{
    public partial class NewSale : Form
    {
        Form callback;
        IRemBook remBook;
        IRemClient remClient;
        Book bk;

        public NewSale(Form callback, Book bk)
        {
            InitializeComponent();
            this.callback = callback;
            remBook = (IRemBook)GetRemote.New(typeof(IRemBook));
            remClient = (IRemClient)GetRemote.New(typeof(IRemClient));
            this.bk = bk;
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
            if (string.IsNullOrEmpty(textBox1.Text))
                MessageBox.Show("Client CPF field cannot be empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                this.label6.Text = (bk.price * Double.Parse(numericUpDown1.Value.ToString())).ToString();

                Client clt = remClient.getClient(long.Parse(textBox1.Text));

                if (clt == null)
                    MessageBox.Show("Client not found!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    if (numericUpDown1.Value > remBook.getBookStock(bk))
                    {
                        DialogResult proceed = MessageBox.Show("Number of copies requested is not available in stock.\nAn order will be created. Proceed?", "Atention", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

                        if (proceed.Equals(DialogResult.Yes))
                        {
                            Thread.Sleep(1000);

                            DialogResult result = MessageBox.Show("Corfirm order?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                            if (result.Equals(DialogResult.Yes))
                            {
                                int id = remBook.orderBook(bk, 10 + int.Parse(numericUpDown1.Value.ToString()));
                                MessageBox.Show("Successfully created order!\nOrder ID: " + id);
                            }
                        }
                    }
                    else
                    {
                        Thread.Sleep(1000);
                        DialogResult proceed = MessageBox.Show("Confirm sale?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (proceed.Equals(DialogResult.Yes))
                        {
                            Sale sl = remBook.sellBook(bk, clt, int.Parse(numericUpDown1.Value.ToString()));

                            this.Enabled = false;
                            (new Receipt(this, sl)).Show();
                        }
                    }             
                }
            }
        }
    }
}
