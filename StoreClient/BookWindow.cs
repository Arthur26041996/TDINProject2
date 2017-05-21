using Shared;
using System.Windows.Forms;

namespace StoreClient
{
    public partial class BookWindow : Form
    {
        IRemBook remBook;

        public BookWindow(Book book)
        {
            remBook = (IRemBook)GetRemote.New(typeof(IRemBook));

            InitializeComponent();
            this.label10.Text = book.Id.ToString();
            this.label11.Text = book.Title;
            this.label12.Text = book.Author;
            this.label13.Text = book.Publisher;
            this.label14.Text = book.PubDate;
            this.label15.Text = book.Genre;
            this.label16.Text = book.Volume.ToString();
            this.label17.Text = book.Edition.ToString();
            this.label18.Text = (remBook.getBookStock(book.Id)).ToString();
            this.label20.Text = book.Price.ToString();
        }
    }
}
