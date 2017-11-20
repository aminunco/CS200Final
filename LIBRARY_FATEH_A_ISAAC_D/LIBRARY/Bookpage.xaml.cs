using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace LIBRARY
{
    /// <summary>
    /// Interaction logic for Bookpage.xaml
    /// </summary>
    public partial class Bookpage : Window
    {
        Homepage homepage;
        Book book;
        User user;
        public Bookpage(Book book, User user)
        {
            this.user = user;
            this.book = book;
            InitializeComponent();
            if (!user.isAdmin)  //if user if admin, the add book will be visible
            {
                deleteButton.Visibility = Visibility.Collapsed;
            }
            populateFields(book);
            //Image photo = new Bitmap(@"");
            //byte[] pic = ImageToByte(photo, System.Drawing.Imaging.ImageFormat.Jpeg);
            //SaveImage(pic);
            //LoadImage();
        }

        private void returnButton_Click(object sender, RoutedEventArgs e)
        {
            homepage = new Homepage(user);
            homepage.Show();
            this.Close();
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            user.savedBooks.addBookToList(book);
            book.saveToShelf(user);
            MessageBox.Show(book.bookTitle + " has been saved to your shelf");
            //Book bookToModify = Book.findBook(@"..\\..\\books.txt", isbnTB.Text);
            //Book.addBook(@"..\\..\\books.txt", bookToModify);
        }

        private void editButton_Click(object sender, RoutedEventArgs e)
        {
            ModifyBook modify = new ModifyBook(user);
            modify.book = book;
            modify.populateFields();
            modify.Show();
            this.Hide();
        }
        public void populateFields(Book book)
        {
            titleTB.Text = book.bookTitle;
            authorTB.Text = book.bookAuthor;
            priceTB.Text = book.bookPrice;
            isbnTB.Text = book.bookISBN;
            genreTB.Text = book.bookGenre; 
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {

            Book.deleteBook(@"..\\..\\books.txt", book); // deleteing book 
            homepage = new Homepage(user);
            homepage.Show();
            this.Close();
        }
    }
}
