using System;
using Shared;
using System.Collections.Generic;
using System.Runtime.Remoting;
using System.Net.Mail;

namespace StoreServer
{
    public class StoreServer
    {
        static void Main(string[] args)
        {
            RemotingConfiguration.Configure("StoreServer.exe.config", false);
            Console.WriteLine("Press return to exit");
            Console.ReadLine();
        }
    }

    public class RemObject : MarshalByRefObject, IRemObject
    {

        List<Employee> employee;

        public RemObject()
        {
            employee = new List<Employee>();

            //testing
            employee.Add(new Employee("Arthur", "21", "916502017",
                                      "arthurmattaa@hotmail.com",
                                      "Praca 9 de abril, 49",
                                      "arthur", "arthur"));
        }

        public override object InitializeLifetimeService()
        {
            Console.WriteLine("[RemObject]: InitializeLifeTimeService");
            return null;
        }

        public void addEmployee(string name, string age, string phone, string email, string address, string username, string password)
        {
            foreach (Employee emp in employee)
            {
                if (emp.Username.Equals(username))
                {
                    Console.WriteLine("[addEmployee]: User already exists");
                    return;
                }
            }

            employee.Add(new Employee(name, age, phone, email, address, username, password));
            Console.WriteLine("[addEmployee]: Successfully created user " + username);
        }

        public void removeEmployee(string username)
        {
            foreach (Employee emp in employee)
            {
                if (emp.Username.Equals(username))
                {
                    employee.Remove(emp);
                    Console.WriteLine("[removeEmployee]: Successfully removed user " + username);
                }
            }

            Console.WriteLine("[removeEmployee]: User not found!");
        }

        public void updateEmployee(string name, string age, string phone, string email, string address, string username)
        {
            foreach (Employee emp in employee)
            {
                if (emp.Username.Equals(username))
                {
                    emp.Name = name;
                    emp.Age = age;
                    emp.Phone = phone;
                    emp.Email = email;
                    emp.Address = address;
                    Console.WriteLine("[updateEmployee]: Successfully updated user " + username);
                }
            }
            Console.WriteLine("[updateEmployee]: User not found!");
        }

        public bool changePassword(string username, string newPassword)
        {
            foreach (Employee emp in employee)
            {
                if (emp.Username.Equals(username))
                {
                    emp.Password = newPassword;
                    Console.WriteLine("[changePassword]: Successefully changed password from user " + username);
                    return true;
                }
            }
            Console.WriteLine("[changePassword]: User not found!");
            return false;
        }

        public bool Login(string username, string password)
        {
            foreach (Employee emp in employee)
            {
                if (emp.Username.Equals(username) && emp.Password.Equals(password.GetHashCode().ToString()))
                {
                    Console.WriteLine("[Login]: user " + username + " logged in");
                    return true;
                }
            }
            Console.WriteLine("[Login]: User not found!");
            return false;
        }

        public void Logout(string username)
        {
            Console.WriteLine("[Logout]: user " + username + " logged out");
        }

        public Employee getEmployee(string username)
        {
            foreach (Employee emp in employee)
            {
                if (emp.Username.Equals(username))
                {
                    return emp;
                }
            }
            return null;
        }
    }

    public class RemBook : MarshalByRefObject, IRemBook
    {
        //Dictionary Book key -> int quantityInStock
        Dictionary<Book, int> book;
        List<Order> orders;
        List<Sale> sales;

        public RemBook()
        {
            book = new Dictionary<Book, int>();
            orders = new List<Order>();

            //testing
            addSomeExamples();
        }

        public void addSomeExamples()
        {
            book.Add(new Book()
            {
                id = 0,
                title = "Dom Quixote",
                author = "Miguel de Cervantes",
                publisher = "Francisco de Robles",
                pubDate = "1605",
                genre = "Novel",
                volume = 1,
                edition = 1,
                price = 30.56
            }, 10);

            book.Add(new Book()
            {
                id = 1,
                title = "Ulysses",
                author = "James Joyces",
                publisher = "Sylvia Beach",
                pubDate = "1922",
                genre = "Novel",
                volume = 1,
                edition = 1,
                price = 42.15
            }, 10);

            book.Add(new Book()
            {
                id = 2,
                title = "War and Peace",
                author = "Leo Tolstoy",
                publisher = "The Russian Messenger",
                pubDate = "1869",
                genre = "Novel",
                volume = 1,
                edition = 1,
                price = 25.95
            }, 10);

            

            book.Add(new Book()
            {
                id = 3,
                title = "The Great Gatsby",
                author = "F. Scott Fitzgerald",
                publisher = "Charles Scribner's Sons",
                pubDate = "1925",
                genre = "Novel",
                volume = 1,
                edition = 1,
                price = 12.85
            }, 10);

            book.Add(new Book()
            {
                id = 4,
                title = "Pride and Prejudice",
                author = "Jane Austen",
                publisher = "T Egerton, Whitehall",
                pubDate = "1813",
                genre = "Novel",
                volume = 1,
                edition = 1,
                price = 14.73
            }, 10);

            book.Add(new Book()
            {
                id = 5,
                title = "The Hunger Games, #1",
                author = "Suzanne Collins",
                publisher = "Scholastic Press",
                pubDate = "2008",
                genre = "Adventure",
                volume = 1,
                edition = 1,
                price = 64.22
            }, 10);

            book.Add(new Book()
            {
                id = 6,
                title = "Harry Potter, #1",
                author = "J.K. Rowling",
                publisher = "Arthur A. Levine Books",
                pubDate = "1997",
                genre = "Fantasy",
                volume = 1,
                edition = 1,
                price = 42.56
            }, 10);

            book.Add(new Book()
            {
                id = 7,
                title = "Twilight",
                author = "Stephenie Meyer",
                publisher = "Litter, Brown and Company",
                pubDate = "2005",
                genre = "Fantasy",
                volume = 1,
                edition = 1,
                price = 76.36
            }, 10);

            book.Add(new Book()
            {
                id = 8,
                title = "The Hobbit",
                author = "J.R.R. Tolkien",
                publisher = "George Allen & Unwin",
                pubDate = "1937",
                genre = "Fantasy",
                volume = 1,
                edition = 1,
                price = 48.97
            }, 10);

            book.Add(new Book()
            {
                id = 9,
                title = "Divergent",
                author = "Veronica Roth",
                publisher = "Katherine Tegen Books",
                pubDate = "2011",
                genre = "Science fiction",
                volume = 1,
                edition = 1,
                price = 66.39
            }, 10);
        }

        public bool addBook(Book key, int value)
        {
            if (book.ContainsKey(key))
            {
                if (value > book[key])
                {
                    book[key] = value;
                    return true;
                }
                else
                {
                    Console.WriteLine("Book already exists and quantity is lower then the current value in stock");
                    return false;
                }
            }
            else
            {
                book.Add(key, value);
                return true;
            }
        }

        public Book getBook(int id)
        {
            foreach (Book bk in book.Keys)
            {
                if (bk.id.Equals(id))
                    return bk;
            }
            return null;
        }

        public Book getBookByTitle(string title)
        {
            foreach (Book bk in book.Keys)
            {
                if (bk.title.Equals(title))
                    return bk;
            }
            return null;
        }

        public int getBookStock(int id)
        {
            try
            {
                return book[getBook(id)];
            }
            catch (Exception ex)
            {
                Console.WriteLine("Book not found!");
                return -1;
            }
        }

        public List<Book> getAllBooks()
        {
            List<Book> bks = new List<Book>();

            bks.Add(book.GetEnumerator().Current.Key); //Add first element
            while (book.GetEnumerator().MoveNext()) //move to the next element of the dictionary until the end of it
                bks.Add(book.GetEnumerator().Current.Key); //Add the element to the list

            return bks;
        }

        public void updateBookStock(Book key, int value)
        {
            try
            {
                book[key] = value;
                Console.WriteLine("Book: " + key.id + " - " + key.title + "\nStock: "+book[key]);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Book not found!");
            }
        }

        public int orderBook(Book bk, int quantity)
        {
            MessageHandler msgHandler = new MessageHandler();
            int guid = Guid.NewGuid().GetHashCode();        //generates a GUID for the order
            while (true)
            {
                if (guid < 0)
                    guid = Guid.NewGuid().GetHashCode();
                else
                    break;
            }
            string queueName = @".\Private$\TDIN";          //MessageQueue name
            
            Order order = new Order()                       //Create new Order
            {
                id = guid,
                book = bk,
                quantity = quantity,
                status = "Waiting expedition...",
                requestDate = DateTime.Now,
                replyDate = DateTime.MinValue
            };

            msgHandler.sendOrder(queueName, order);         //Send order to Queue
            orders.Add(order);                              //Add Order to the List
            Console.WriteLine("[RemBook]: ORDER REQUEST - ID: " + order.id + " || BOOK NAME: " + order.book.title);
            return order.id;
        }

        public Order getOrder(int orderId)
        {
            try
            {
                return orders.Find(item => item.id.Equals(orderId));
            }
            catch (Exception)
            {
                return null;
            }
        }

        public int[] getOrdersId()
        {
            int[] keys = new int[orders.Count];
            int i = 0;
            foreach(Order od in orders)
            {
                keys[i++] = od.id;
            }

            return keys;
        }

        public List<Order> getAllOrders()
        {
            return orders;
        }

        public void sellBook(Book book, Client client, int quantity)
        {
            int guid = Guid.NewGuid().GetHashCode();        //generates a GUID for the sale
            while (true)
            {
                if (guid < 0)
                    guid = Guid.NewGuid().GetHashCode();
                else
                    break;
            }

            int stock = getBookStock(book.id);
            if (stock < quantity)
            {
                orderBook(book, (10 + quantity));

                MailMessage mail = new MailMessage("sales@bookstore.com", client.email);
                SmtpClient smtpC = new SmtpClient();
                smtpC.Port = 25;
                smtpC.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtpC.Host = "smtp.google.com";
                mail.Subject = "Status of your order:  Waiting expedition...";
                mail.Body = "Hey there! Your orders is waiting expedition";
                smtpC.Send(mail);
            }
            else
            {
                Sale sale = new Sale()
                {
                    id = guid,
                    client = client,
                    book = book,
                    quantity = quantity,
                    totalPrice = (quantity * book.price)
                };

                sales.Add(sale);

                MailMessage mail = new MailMessage("sales@bookstore.com", client.email);
                SmtpClient smtpC = new SmtpClient();
                smtpC.Port = 25;
                smtpC.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtpC.Host = "smtp.google.com";
                mail.Subject = "Status of your order: dispached at " + DateTime.Today.AddDays(1);
                mail.Body = "Hey there! Your order was dispached at " + DateTime.Today.AddDays(1);
                smtpC.Send(mail);
            }
        }
    }
}
