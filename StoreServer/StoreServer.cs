using System;
using Shared;
using System.Collections.Generic;
using System.Runtime.Remoting;
using System.Collections.ObjectModel;

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

        public Employee getEmployee(string username)
        {
            foreach (Employee emp in employee)
            {
                if (emp.Username.Equals(username))
                {
                    Console.WriteLine("[getEmployee]: returning user " + username);
                    return emp;
                }
            }
            Console.WriteLine("[getEmployee]: User not found!");
            return null;
        }
    }

    public class RemBook : MarshalByRefObject, IRemBook
    {
        //Dictionary Book key -> int quantityInStock
        Dictionary<Book, int> book;

        public RemBook()
        {
            book = new Dictionary<Book, int>();

            //testing
            addSomeExamples();
        }

        public void addSomeExamples()
        {
            book.Add(new Book(0, "Dom Quixote", "Miguel de Cervantes",
                                "Francisco de Robles", "1605", "Novel", 1, 1), 10);

            book.Add(new Book(1, "Ulysses", "James Joyces",
                                "Sylvia Beach", "1922", "Novel", 1, 1), 10);

            book.Add(new Book(2, "War and Peace", "Leo Tolstoy",
                                "The Russian Messenger", "1869", "Novel", 1, 1), 10);

            book.Add(new Book(3, "The Great Gatsby", "F. Scott Fitzgerald",
                                "Charles Scribner's Sons", "1925", "Novel", 1, 1), 10);

            book.Add(new Book(4, "Pride and Prejudice", "Jane Austen",
                                "T Egerton, Whitehall", "1813", "Novel", 1, 1), 10);

            book.Add(new Book(5, "The Hunger Games, #1", "Suzanne Collins",
                                "Scholastic Press", "2008", "Adventure", 1, 1), 10);

            book.Add(new Book(6, "Harry Potter, #1", "J.K. Rowling",
                                "Arthur A. Levine Books", "1997", "Fantasy", 1, 1), 10);

            book.Add(new Book(7, "Twilight", "Stephenie Meyer",
                                "Litter, Brown and Company", "2005", "Fantasy", 1, 1), 10);

            book.Add(new Book(8, "The Hobbit", "J.R.R. Tolkien",
                                "George Allen & Unwin", "1937", "Fantasy", 1, 1), 10);

            book.Add(new Book(9, "Divergent", "Veronica Roth",
                                "Katherine Tegen Books", "2011", "Science fiction", 1, 1), 10);
        }

        public void addBook(Book key, int value)
        {
            if (book.ContainsKey(key))
            {
                if (value > book[key])
                    book[key] = value;
                else
                    Console.WriteLine("Book already exists and quantity is lower then the current value in stock");
            }
            else
                book.Add(key, value);
        }

        public Book getBook(int id)
        {
            foreach (Book bk in book.Keys)
            {
                if (bk.Id.Equals(id))
                    return bk;
            }
            return null;
        }

        public Book getBookByTitle(string title)
        {
            foreach (Book bk in book.Keys)
            {
                if (bk.Title.Equals(title))
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
                Console.WriteLine("Book: " + key.Id + " - " + key.Title + "\nStock: "+book[key]);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Book not found!");
            }
        }
    }
}
