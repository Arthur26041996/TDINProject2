using Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StoreClient
{
    public partial class NewClient : Form
    {
        Form callback;
        IRemClient remClient;

        public NewClient(Form callback)
        {
            InitializeComponent();
            this.callback = callback;
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
                string.IsNullOrEmpty(textBox4.Text) ||
                string.IsNullOrEmpty(textBox5.Text))
            {
                MessageBox.Show("Some fields are empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                remClient.addClient(
                    long.Parse(textBox1.Text),
                    textBox2.Text,
                    int.Parse(textBox3.Text),
                    textBox4.Text,
                    textBox5.Text
                    );
                MessageBox.Show("Successfully added client " + textBox2.Text);
                this.Close();
            }
        }
    }
}
