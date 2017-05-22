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
    public partial class SerachClient : Form
    {
        Form callback;
        IRemClient remClient;

        public SerachClient(Form callback)
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
            Shared.Client clt = remClient.getClient(long.Parse(this.textBox1.Text));
            if (clt != null)
                (new ClientWindow(this, clt)).Show();
            else
                MessageBox.Show("Client not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
