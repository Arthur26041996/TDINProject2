using System;

namespace Shared
{
    [Serializable]
    public class Order
    {
        public Order() { }

        public int id { get; set; }
        public Book book { get; set; }
        public int quantity { get; set; }
        public string status { get; set; }
        public DateTime requestDate { get; set; }
        public DateTime replyDate { get; set; }

        public override bool Equals(object obj)
        {
            return id == ((Order)obj).id;
        }
    }
}
