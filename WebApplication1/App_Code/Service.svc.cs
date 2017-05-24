using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WebApplication1.App_Code
{
        // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service.svc or Service.svc.cs at the Solution Explorer and start debugging.
    public class Service : IService
    {
        IRemBook iRemBook;
        
        public Book BookDetails(string title)
        {
            iRemBook = (IRemBook)Activator.GetObject(typeof(IRemBook), "http://localhost:9000/StoreServer/RemBook.rem");
            return iRemBook.getBookByTitle(title);
        }


        public Order OrderDetails(int orderId)
        {
            iRemBook = (IRemBook)Activator.GetObject(typeof(IRemBook), "http://localhost:9000/StoreServer/RemBook.rem");
            return iRemBook.getOrder(orderId);
        }

        public int BuyBook(string title, string name, string email, string address, int quantity)
        {
            iRemBook = (IRemBook)Activator.GetObject(typeof(IRemBook), "http://localhost:9000/StoreServer/RemBook.rem");
            Book book = iRemBook.getBookByTitle(title);
            Client client = new Client();
            client.Name = name;
            client.email = email;
            client.address = address;
            return iRemBook.sellBook(book, client, quantity);
        }
    }

}
