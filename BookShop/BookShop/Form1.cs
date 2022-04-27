using BookClass;
using BookShop;
using BookShop;
namespace BookShop
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        private Shop shop;
        private Book book1;
        private Book book2;

        private void Form1_Load(object sender, EventArgs e)
        {
            //Declaring and instantiating the Shop and Book objects
            shop = new Shop("Ugniaus Knygos BL xD");

            book1 = new Book("C# Programming", "Ugnius Grazulis", 10.5, 3);
            book2 = new Book("Program Design", "Ugnius Grazulis", 9.75, 4);


            shop.AddBook(book1);
            shop.AddBook(book2);

            lblShopName.Text = shop.GetName();
            DisplayBooks(shop);
        }

        private void DisplayBooks(Shop pShop)
        {
            int iIndex;

            // Clear ListBox and Display bookd
            lstBooks.Items.Clear();

            for (iIndex = 0; iIndex < pShop.GetMaxBooks(); iIndex++)
            {
                lstBooks.Items.Add(pShop.GetBook(iIndex));
            }
        }

        private void lstBooks_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstBooks.SelectedIndex > -1)
            { 
                //Gets currently selected books
                Book currentBook = (Book)lstBooks.SelectedItem;
                DisplayDetails(currentBook);
            }
        }

        private void DisplayDetails(Book book)
        {
            lstDetails.Items.Clear();
            lstDetails.Items.Add($"Title: {book.GetTitle()}");
            lstDetails.Items.Add($"Author: {book.GetAuthor()}");
            lstDetails.Items.Add($"Cost: {book.GetCost()}");
            lstDetails.Items.Add($"In Stock: {book.GetQuantity().ToString()}");
        }
    }
}