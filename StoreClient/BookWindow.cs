using Shared;
using System.Windows.Forms;

namespace StoreClient
{
    public partial class BookWindow : Form
    {
        public static IRemBook remBook;
        public static Book bk;
        public static Label lbl;

        public BookWindow(Book book)
        {
            remBook = (IRemBook)GetRemote.New(typeof(IRemBook));
            bk = book;

            InitializeComponent();
            this.label10.Text = bk.id.ToString();
            this.label11.Text = bk.title;
            this.label12.Text = bk.author;
            this.label13.Text = bk.publisher;
            this.label14.Text = bk.pubDate;
            this.label15.Text = bk.genre;
            this.label16.Text = bk.volume.ToString();
            this.label17.Text = bk.edition.ToString();
            this.label18.Text = (remBook.getBookStock(bk)).ToString();
            this.label20.Text = bk.price.ToString();
        }
        

        private void button1_Click(object sender, System.EventArgs e)
        {
            int id = remBook.orderBook(bk, 10);
            MessageBox.Show("Book " + bk.id + " ordered!\nOrder ID: " + id.ToString(), "Order", MessageBoxButtons.OK, MessageBoxIcon.None);
        }

        private void button2_Click(object sender, System.EventArgs e)
        {
            (new NewSale(this, bk)).Show();
        }
    }
}
