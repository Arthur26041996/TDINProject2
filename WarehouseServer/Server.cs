using Shared;
using System;
using System.Runtime.Remoting;

namespace WarehouseServer
{
    class Server
    {
        static void Main(string[] args)
        {
            RemotingConfiguration.Configure("WarehouseServer.exe.config", false);
            Console.WriteLine("Press return to exit");
            Console.ReadLine();
        }
    }

    public class RemObjectWH : MarshalByRefObject, IRemObjectWH
    {

    }
}
