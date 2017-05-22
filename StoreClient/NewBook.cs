using Shared;
using System;
using System.Windows.Forms;

namespace StoreClient
{
    public partial class NewBook : Form
    {
        Form callback;
        IRemBook remBook;

        public NewBook(Form callback)
        {

            remBook = (IRemBook)GetRemote.New(typeof(IRemBook));
            InitializeComponent();
            this.callback = callback;
            this.textBox1.KeyPress += TextBox1_KeyPress;
            this.textBox7.KeyPress += TextBox7_KeyPress;
            this.textBox8.KeyPress += TextBox8_KeyPress;
            this.textBox9.KeyPress += TextBox9_KeyPress;
            this.textBox10.KeyPress += TextBox10_KeyPress;
        }

        private void TextBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void TextBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void TextBox9_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void TextBox10_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
                e.Handled = true;

            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
                e.Handled = true;
        }

        private void TextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
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
            callback.Enabled = true;
            callback.Show();
            callback.Activate();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) ||
                string.IsNullOrEmpty(textBox2.Text) ||
                string.IsNullOrEmpty(textBox3.Text) ||
                string.IsNullOrEmpty(textBox4.Text) ||
                string.IsNullOrEmpty(textBox5.Text) ||
                string.IsNullOrEmpty(textBox6.Text) ||
                string.IsNullOrEmpty(textBox7.Text) ||
                string.IsNullOrEmpty(textBox8.Text) ||
                string.IsNullOrEmpty(textBox9.Text) ||
                string.IsNullOrEmpty(textBox10.Text)
                )
            {
                MessageBox.Show("Some fields are empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Book bk = new Book() { id = int.Parse(textBox1.Text),
                    title = textBox2.Text,
                    author = textBox3.Text,
                    publisher = textBox4.Text,
                    pubDate = textBox5.Text,
                    genre = textBox6.Text,
                    volume = int.Parse(textBox7.Text),
                    edition = int.Parse(textBox8.Text),
                    price = double.Parse(textBox10.Text)
                };

                if (remBook.addBook(bk, int.Parse(textBox9.Text)))
                {
                    MessageBox.Show("Successfully added book " + textBox2.Text, "Success!", MessageBoxButtons.OK, MessageBoxIcon.None);
                    this.Close();
                    callback.Enabled = true;
                }
                else
                    MessageBox.Show("Fail to add new book", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
