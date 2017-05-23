using System;
using System.Runtime.Remoting;
using System.Windows.Forms;

namespace Warehouse
{
    static class Client
    {
        [STAThread]
        static void Main()
        {
            RemotingConfiguration.Configure("WarehouseClients.exe.config", false);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Main());
        }
    }
}
