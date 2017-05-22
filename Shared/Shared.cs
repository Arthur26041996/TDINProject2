using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting;

namespace Shared
{
    public interface IRemObject
    {
        void addEmployee(string name, string age, string phone, string email, string address, string username, string password);
        void removeEmployee(string username);
        void updateEmployee(string name, string age, string phone, string email, string address, string username);
        bool changePassword(string username, string newPassword);
        bool Login(string username, string password);
        void Logout(string username);
        Employee getEmployee(string username);
    }

    public interface IRemBook
    {
        bool addBook(Book key, int value);
        Book getBook(int id);
        Book getBookByTitle(string title);
        int getBookStock(int id);
        List<Book> getAllBooks();
        void updateBookStock(Book key, int value);
        int orderBook(Book bk, int quantity);
        Order getOrder(int orderId);
        int[] getOrdersId();
        List<Order> getAllOrders();
    }

    public interface IRemObjectWH
    {

    }

    public class GetRemote
    {
        private static IDictionary wellKnownTypes;

        public static object New(Type type)
        {
            if (wellKnownTypes == null)
                InitTypeCache();
            WellKnownClientTypeEntry entry = (WellKnownClientTypeEntry)wellKnownTypes[type];
            if (entry == null)
                throw new RemotingException("Type not found!");
            return Activator.GetObject(type, entry.ObjectUrl);
        }

        public static void InitTypeCache()
        {
            Hashtable types = new Hashtable();
            foreach (WellKnownClientTypeEntry entry in RemotingConfiguration.GetRegisteredWellKnownClientTypes())
            {
                if (entry.ObjectType == null)
                    throw new RemotingException("A configured type could not be found!");
                types.Add(entry.ObjectType, entry);
            }
            wellKnownTypes = types;
        }
    }
}
