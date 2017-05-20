using System;
using System.Runtime.Remoting;
using System.Windows.Forms;

namespace StoreClient
{
    class Client
    {
        [STAThread]
        static void Main(string[] args)
        {
            RemotingConfiguration.Configure("StoreClient.exe.config", false);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Login());
        }
    }
}
