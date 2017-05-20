using Shared;
using System;
using System.Windows.Forms;

namespace StoreClient
{
    public partial class PasswordRecover : Form
    {
        Form callback;
        IRemObject remObject;

        public PasswordRecover(Form callbackWindow)
        {
            InitializeComponent();
            callback = callbackWindow;
            remObject = (IRemObject)GetRemote.New(typeof(IRemObject));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (newPass.Text.Equals(newPass2.Text))
                {
                    if (remObject.changePassword(nameField.Text, newPass2.Text))
                    {
                        this.Close();
                        callback.Show();
                        callback.Activate();
                        callback.Enabled = true;
                    }
                }
                else
                {
                    MessageBox.Show("Passwords do no match", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message +
                    "\n------------------------------\n" +
                    ex.StackTrace);
                MessageBox.Show("Could not contact the server", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            callback.Show();
            callback.Activate();
            callback.Enabled = true;
        }
    }
}
