using Shared;
using System;
using System.Globalization;
using System.Windows.Forms;

namespace StoreClient
{
    public partial class Search : Form
    {
        Form callback;
        IRemBook remBook;

        public Search(Form callback)
        {
            remBook = (IRemBook)GetRemote.New(typeof(IRemBook));

            InitializeComponent();
            this.callback = callback;
            this.radioButton1.Checked = true;
            this.textBox1.Enabled = true;
            this.textBox2.Enabled = false;
            this.textBox1.Focus();
            this.textBox1.KeyPress += TextBox1_KeyPress;
        }

        private void TextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            this.textBox2.Text = "";
            this.textBox1.Enabled = true;
            this.textBox2.Enabled = false;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            this.textBox1.Text = "";
            this.textBox1.Enabled = false;
            this.textBox2.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            callback.Show();
            callback.Activate();
            callback.Enabled = true;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            callback.Show();
            callback.Activate();
            callback.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((radioButton1.Checked && string.IsNullOrEmpty(textBox1.Text))
                || (radioButton2.Checked && string.IsNullOrEmpty(textBox2.Text)))
            {
                MessageBox.Show("TextBox is empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (radioButton1.Checked)
            {
                Book bk = remBook.getBook(int.Parse(textBox1.Text));
                if (bk != null)
                    (new BookWindow(bk)).Show();
                else
                    MessageBox.Show("Book not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (radioButton2.Checked)
            {
                Book bk = remBook.getBookByTitle(textBox2.Text);
                if (bk != null)
                    (new BookWindow(bk)).Show();
                else
                    MessageBox.Show("Book not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
    }
}
