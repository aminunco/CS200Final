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
    /// Interaction logic for ModifyBook.xaml
    /// </summary>
    public partial class ModifyBook : Window
    {
        public Book book;
        private string imgPath;
        User user;
        public object record { get; private set; }

        public ModifyBook(User user)
        {
            this.user = user;
            InitializeComponent();

        }

        private void selectImgButton_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog fileSearch = new Microsoft.Win32.OpenFileDialog();
            fileSearch.DefaultExt = ".jpg";
            Nullable<bool> result = fileSearch.ShowDialog();

            if (result == true)
            {
                string[] temp = fileSearch.FileName.Split('\\');
                imgPath = temp[temp.Length - 1];
                MessageBox.Show(fileSearch.FileName);
            }
        }

        private void addBookButton_Click(object sender, RoutedEventArgs e)
        {
            Book book = new Book();
            book.bookDetails(title.Text, author.Text, price.Text, ISBN.Text, genre.Text);
            Library.Instance.libraryList.Add(book);
            book.saveToFile();
            MessageBox.Show(book.bookTitle + " has been added to the library");
            this.Close();
            Homepage homepage = new Homepage(user);
            homepage.Show();
        }

        private void searchISBN_Button_Click(object sender, RoutedEventArgs e)
        {
            string isbn = ISBN.Text.Trim();
            ValidateISBN validateISBN = new ValidateISBN(isbn);
            if (!string.IsNullOrWhiteSpace(isbn) && validateISBN.isValid())
            {
                Book book;
                IsbnAPI API = new IsbnAPI();
                try
                {
                    book = API.getBook(isbn);
                    title.Text = book.title;
                    author.Text = Convert.ToString(book.author_data[0]["name"]);
                    genre.Text = book.subject_ids[0];
                }
                catch
                {
                    System.Windows.MessageBox.Show("The ISBN you entered does not exist in the database", "Invalid ISBN");
                }
            }
            else System.Windows.MessageBox.Show("Please enter a valid ISBN", "Invalid ISBN");
        }
        public void populateFields()
        {
            title.Text = book.bookTitle;
            author.Text = book.bookAuthor;
            price.Text = book.bookPrice;
            ISBN.Text = book.bookISBN;
            genre.Text = book.bookGenre;
            string record = (title.Text + " - " + author.Text + " - " + price.Text + " - " + ISBN.Text + " - " + genre.Text + " - ");
        }

        private void homepage_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            Homepage homepage = new Homepage(user);
            homepage.Show();
        }

        private void update_Click(object sender, RoutedEventArgs e)
        {
            string title1  = title.Text;
            string author1 = author.Text;
            string price1 = price.Text;
            string ISBN1 = ISBN.Text;
            string genre1 = genre.Text;
            string imgPath1 = imgPath;
            string record = (title1 + " - " + author1 + " - " + price1 + " - " + ISBN1 + " - " + genre1 + " - " + imgPath1);
            string original = (book.bookTitle + " - " + book.bookAuthor + " - " + book.bookPrice + " - " + book.bookISBN + " - " + book.bookGenre + " - " + book.imagePath + " - ");
            string[] fileData = File.ReadAllLines(@"..\\..\\books.txt");
            bool recordExists = false;
            //find matching "record" 
            foreach (string d in fileData)
            {
                if (record.Equals(d))
                { //get new values for the text fields
                    recordExists = true;
                    MessageBox.Show("No changes were made, yo.");
                }                          
            }
            //concatenate them into a new record
            if (!recordExists) {
                File.Delete(@"..\\..\\books.txt");
                //write new line to file with "appendtext"
                using (StreamWriter sw = File.AppendText(@"..\\..\\books.txt")) { 
                    foreach(string line in fileData)
                    {
                        if (!line.Equals(original))
                        {
                            sw.WriteLine(line);
                        }      
                    }
                    sw.WriteLine(record);
                }
                MessageBox.Show("Book updated");
            }
        }
    }
}
