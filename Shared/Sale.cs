using System;

namespace Shared
{
    [Serializable]
    public class Sale
    {
        public int id { get; set; }
        public Client client { get; set; }
        public Book book { get; set; }
        public int quantity { get; set; }
        public double totalPrice { get; set; }
    }
}
