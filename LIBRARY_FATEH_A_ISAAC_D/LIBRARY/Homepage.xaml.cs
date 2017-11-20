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
using System.IO;

namespace LIBRARY
{
    /// <summary>
    /// Interaction logic for Homepage.xaml
    /// </summary>
    public partial class Homepage : Window
    {
        User user;
        Book book;
        public Homepage(User user)
        {        
            InitializeComponent();
            this.user = user;
            if (!user.isAdmin)  //if user is not an admin, hide addbook button
            {
                addbook.Visibility = Visibility.Collapsed;
            }
        }

        private void mybookshelf_Click(object sender, RoutedEventArgs e)
        {
            //take me to bookshelf.xaml 
            Bookshelf Bookshelf = new Bookshelf(user);
            //Bookshelf.Closed += form_Closed;
            Bookshelf.Show();
            this.Hide();                 
        }

        private void form_Closed(object sender, EventArgs e)
        {
            this.Show();
        }

        private void addbook_Click(object sender, RoutedEventArgs e)
        {
            ModifyBook addBookForm = new ModifyBook(user);
            addBookForm.Show();
            this.Hide();

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            //takes the input text from the input textbox next to the search btn
            // as a string and populsate labels and images from the up laoded text files
            string Searchtext = textBox.Text;
            /*
             * MS
             * See my comment in Userlist.cs about file locations
             */
            Book.findBook(@"..\\..\\books.txt", Searchtext, this); //passes form to seach class
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            book = Book.bookOne;
            Bookpage BP = new Bookpage(book, user);
            BP.Show();
            this.Close();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            Bookpage BP = new Bookpage(Book.bookTwo, user);
            BP.Show();
            this.Close();
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            Bookpage BP = new Bookpage(Book.bookThree, user);
            BP.Show();
            this.Close();
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            Bookpage BP = new Bookpage(Book.bookFour, user);
            BP.Show();
            this.Close();
        }

        private void allBooks_Click(object sender, RoutedEventArgs e)
        {
            string details = null;
            //List<string> data = new List<string>();
            foreach (Book book in Library.Instance.libraryList)
            {
                details += book.bookTitle + "\n";
            }
            MessageBox.Show(details);
        }
    }
}
