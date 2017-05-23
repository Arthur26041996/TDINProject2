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
    public partial class ClientWindow : Form
    {
        Form callback;
        Shared.Client client;

        public ClientWindow(Form callback, Shared.Client client)
        {
            InitializeComponent();
            this.callback = callback;
            this.client = client;
            this.label6.Text = client.cpf.ToString();
            this.label7.Text = client.Name;
            this.label8.Text = client.phone.ToString();
            this.label9.Text = client.email;
            this.label10.Text = client.address;
        }
    }
}
