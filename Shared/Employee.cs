using System;

namespace Shared
{
    [Serializable]
    public class Employee
    {
        string name;
        string age;
        string phone;
        string email;
        string address;
        string username;
        string password;

        public Employee(string name, string age, string phone, string email, string address, string username, string password)
        {
            this.name = name;
            this.age = age;
            this.phone = phone;
            this.email = email;
            this.address = address;
            this.username = username;
            this.password = password.GetHashCode().ToString();
        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public string Age
        {
            get
            {
                return age;
            }

            set
            {
                age = value;
            }
        }

        public string Phone
        {
            get
            {
                return phone;
            }

            set
            {
                phone = value;
            }
        }

        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                email = value;
            }
        }

        public string Address
        {
            get
            {
                return address;
            }

            set
            {
                address = value;
            }
        }

        public string Username
        {
            get
            {
                return username;
            }

            set
            {
                username = value;
            }
        }

        public string Password
        {
            get
            {
                return password;
            }

            set
            {
                password = value.GetHashCode().ToString();
            }
        }
    }
}
