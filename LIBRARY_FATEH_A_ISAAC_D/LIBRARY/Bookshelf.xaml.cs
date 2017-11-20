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
    /// Interaction logic for Bookshelf.xaml
    /// </summary>
    
    public partial class Bookshelf : Window
    {
        BookList list;
        User user;
        public Bookshelf(User user)
        {
            this.user = user;
            this.list = user.savedBooks;           
            InitializeComponent();
            populateForm();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Homepage homepage = new Homepage(user);
            homepage.Show();
            this.Close();
        }
        private void populateForm()
        {
            switch (user.savedBooks.bookList.Count)
            {
                case 1:
                    button1.Content = user.savedBooks.bookList[0].bookTitle;
                    image.Source = user.savedBooks.bookList[0].BookCover();
                    break;
                case 2:
                    button1.Content = user.savedBooks.bookList[0].bookTitle;
                    image.Source = user.savedBooks.bookList[0].BookCover();
                    button2.Content = user.savedBooks.bookList[1].bookTitle;
                    image1.Source = user.savedBooks.bookList[1].BookCover();
                    break;
                case 3:
                    button1.Content = user.savedBooks.bookList[0].bookTitle;
                    image.Source = user.savedBooks.bookList[0].BookCover();
                    button2.Content = user.savedBooks.bookList[1].bookTitle;
                    image1.Source = user.savedBooks.bookList[1].BookCover();
                    button3.Content = user.savedBooks.bookList[2].bookTitle;
                    image2.Source = user.savedBooks.bookList[2].BookCover();
                    break;
                case 4:
                    button1.Content = user.savedBooks.bookList[0].bookTitle;
                    image.Source = user.savedBooks.bookList[0].BookCover();
                    button2.Content = user.savedBooks.bookList[1].bookTitle;
                    image1.Source = user.savedBooks.bookList[1].BookCover();
                    button3.Content = user.savedBooks.bookList[2].bookTitle;
                    image2.Source = user.savedBooks.bookList[2].BookCover();
                    button4.Content = user.savedBooks.bookList[3].bookTitle;
                    image3.Source = user.savedBooks.bookList[3].BookCover();
                    break;
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {

        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {

        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {

        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
