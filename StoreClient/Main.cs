using Shared;
using System;
using System.Windows.Forms;

namespace StoreClient
{
    public partial class Main : Form
    {
        Form callback;
        IRemObject remObject;
        string name;

        public Main(Form callback, string name)
        {
            InitializeComponent();
            this.callback = callback;
            this.name = name;
            this.label2.Text = "Welcome, " + name;
            this.remObject = (IRemObject)GetRemote.New(typeof(IRemObject));
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            remObject.Logout(name);
            callback.Show();
            callback.Activate();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            (new Search(this)).Show();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Enabled = false;
            (new PasswordRecover(this)).Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            (new NewBook(this)).Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            (new Orders(this)).Show();
        }
    }
}
