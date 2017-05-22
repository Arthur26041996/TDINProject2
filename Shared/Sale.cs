using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class Sale
    {
        public int id { get; set; }
        public Client client { get; set; }
        public Book book { get; set; }
        public int quantity { get; set; }
        public double totalPrice { get; set; }
    }
}
