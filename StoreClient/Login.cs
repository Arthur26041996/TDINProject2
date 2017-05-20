using System;
using System.Windows.Forms;
using Shared;

namespace StoreClient
{
    public partial class Login : Form
    {
        IRemObject remObject;

        public Login()
        {
            remObject = (IRemObject)GetRemote.New(typeof(IRemObject));
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(nameField.Text))
                {
                    MessageBox.Show("Field Name cannot be empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    nameField.Focus();
                }
                else if (string.IsNullOrEmpty(passwordField.Text))
                {
                    MessageBox.Show("Field Password cannot be empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    passwordField.Focus();
                }
                else if (remObject.Login(nameField.Text, passwordField.Text))
                {
                    string name = (remObject.getEmployee(nameField.Text)).Name;
                    nameField.Clear();
                    passwordField.Clear();
                    this.Hide();
                    (new Main(this, name)).Show();
                }
                else
                {
                    MessageBox.Show("Invalid username or password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message+
                    "\n-------------------------------\n"+
                    ex.StackTrace);
                MessageBox.Show("Error contacting the server", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void CloseWindow(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            nameField.Text = "";
            passwordField.Text = "";
            (new PasswordRecover(this)).Show();
        }
    }
}
