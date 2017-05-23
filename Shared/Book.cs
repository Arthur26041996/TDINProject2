using System;

namespace Shared
{
    [Serializable]
    public class Book
    {
        public int id { get; set; }
        public string title { get; set; }
        public string author { get; set; }
        public string publisher { get; set; }
        public string pubDate { get; set; }
        public string genre { get; set; }
        public int volume { get; set; }
        public int edition { get; set; }
        public double price { get; set; }
    }
}
