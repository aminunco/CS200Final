using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.IO;
using System.Windows;

namespace LIBRARY
{
    public class Book
    {
        public static Book bookOne; //for searching 1st match through fourth
        public static Book bookTwo;
        public static Book bookThree;
        public static Book bookFour;

        public string bookTitle;
        public string bookAuthor;
        public string bookPrice;
        public string bookISBN;
        public string bookGenre;
        public string imagePath;
        ImageSource imageSource;

        public string isbn13 { get; set; }
        public string isbn10 { get; set; }
        public string title { get; set; }
        public string publisher_id { get; set; }
        //public List<object> author_data { get; set; }
        public Dictionary<string, object>[] author_data { get; set; }
        public string[] subject_ids { get; set; }

        public Book() //Constructor is in conflict with WebAPI
        {
            //bookTitle = title;
            //bookAuthor = author;
            //bookPrice = price;
            //bookISBN = isbn;
            //bookGenre = genre;
            //imagePath = path;
            //library.libraryList.Add(this);
        }
        public void bookDetails(string title, string author, string price, string isbn, string genre, string path)
        {
            bookTitle = title;
            bookAuthor = author;
            bookPrice = price;
            bookISBN = isbn;
            bookGenre = genre;
            imagePath = path;
        }
        public void bookDetails(string title, string author, string price, string isbn, string genre)
        {
            bookTitle = title;
            bookAuthor = author;
            bookPrice = price;
            bookISBN = isbn;
            bookGenre = genre;
        }
        public Book(string fileLine)
        {
            string[] bookProperties = fileLine.Split('-'); //its getting arrays of the book properties
            bookTitle = bookProperties[0].Trim();          // and gets rid of the - in the text file
            bookAuthor = bookProperties[1].Trim();         // each different index corresponds to different properties of book
            bookPrice = bookProperties[2].Trim();
            bookISBN = bookProperties[3].Trim();
            bookGenre = bookProperties[4].Trim();
            imagePath = bookProperties[5].Trim();
        }
        public ImageSource BookCover()
        {
            string path = "\\bookimages\\" + imagePath; //relative path to the image
            Uri uri = new Uri(path, UriKind.Relative);
            imageSource = new BitmapImage(uri);
            return imageSource;
        }

        public static void findBook(string filepath, string Searchtext, Homepage page) //takes in file path, seachtext  and form
        {
            int foundcounter = 0; //incremental find counter
            List<string> FileLines = File.ReadLines(filepath).ToList<string>(); // reading the lines of the file into a list
            foreach (string item in FileLines) //goes through each line in file
            {
                if (item.IndexOf(Searchtext, StringComparison.InvariantCultureIgnoreCase) >= 0) //this returns an index of the match without case sens. if nothings found it skips to next line.
                {
                    foundcounter += 1;
                    Book book = new Book(item);  //creating new book object using file information.
                    switch (foundcounter) //if item found then item is placed in lable and image boxe is populated in order it
                    {
                        case 1: //1st item found
                            page.button1.Content = book.bookTitle;//setting found lable to book title....
                            page.image.Source = book.BookCover();//setting image to book cover....
                            bookOne = book;
                            break;
                        case 2://2nd item found.....
                            page.button2.Content = book.bookTitle;
                            page.image1.Source = book.BookCover();
                            bookTwo = book;
                            break;
                        case 3:
                            page.button3.Content = book.bookTitle;
                            page.image2.Source = book.BookCover();
                            bookThree = book;
                            break;
                        case 4:
                            page.button4.Content = book.bookTitle;
                            page.image3.Source = book.BookCover();
                            bookFour = book;
                            break;
                    }
                }
            }
        }
        public static Book findBook(string filepath, string Searchtext) //takes in file path, seachtext  and form
        {
            List<string> FileLines = File.ReadLines(filepath).ToList<string>(); // reading the lines of the file into a list
            foreach (string item in FileLines) //goes through each line in file
            {
                if (item.IndexOf(Searchtext, StringComparison.InvariantCultureIgnoreCase) >= 0) //this returns an index of the match without case sens. if nothings found it skips to next line.
                {
                    return new Book(item); //Returns A New Book Object
                }
            }
            return null;
        }

        public static void deleteBook(string filePath, Book toBeDeleted)
        {
            List<string> FileLines = File.ReadLines(filePath).ToList<string>(); // reading the lines of the file into a list
            List<string> modifiedLines = new List<string>(); //creates a new list for writing back to the file
            foreach (string item in FileLines) //goes through each line in file
            {
                if (item.IndexOf(toBeDeleted.bookISBN, StringComparison.InvariantCultureIgnoreCase) == -1) //this returns an index of the match without case sens. if nothings found it add it back to file.
                {
                    modifiedLines.Add(item); //adds a line to the modified lines 
                }
            }
            StreamWriter fileWriter = new StreamWriter(filePath, false);//opens a new file writer
            foreach (string item in modifiedLines) //looping through new file lines
            {
                fileWriter.WriteLine(item); //writing new lines to the file
            }
            fileWriter.Close(); //closes the writer
            MessageBox.Show("Book Deleted");
        }

        //public static void addBook(string filePath, Book toAdd)
        //{
        //    List<string> FileLines = File.ReadLines(filePath).ToList<string>(); // reading the lines of the file into a list
        //    List<string> modifiedLines = new List<string>(); //creates a new list for writing back to the file
        //    foreach (string item in FileLines) //goes through each line in file
        //    {
        //        if (item.IndexOf(toAdd.bookISBN, StringComparison.InvariantCultureIgnoreCase) >=0) //this returns an index of the match without case sens. if nothings found it add it back to file.
        //        {
        //           string modifiedLine = item + User.loggedInUser.username + ","; //creates a modified line using the matched file line -- appending user name to each book
        //            modifiedLines.Add(modifiedLine); //adds a line to the modified lines 
        //        }
        //        else
        //        {
        //            modifiedLines.Add(item);
        //        }
        //    }
        //    StreamWriter fileWriter = new StreamWriter(filePath, false);//opens a new file writer
        //    foreach (string item in modifiedLines) //looping through new file lines
        //    {
        //        fileWriter.WriteLine(item); //writing new lines to the file
        //    }
        //    fileWriter.Close(); //closes the writer
        //    MessageBox.Show("Book Added");
        //}

        public void saveToShelf(User user)
        {
            using (StreamWriter sw = File.AppendText(@"..\\..\\users\\" + user.username +".txt"))
            {
                sw.WriteLine(this.bookTitle + " - " + this.bookAuthor + " - " + this.bookPrice + " - " + this.bookISBN + " - " + this.bookGenre + " - " + this.imagePath + " - ");
            }
        }
        public void saveToFile()
        {
            using (StreamWriter sw = File.AppendText(@"..\\..\\books.txt"))
            {
                sw.WriteLine(this.bookTitle + " - " + this.bookAuthor + " - " + this.bookPrice + " - " + this.bookISBN + " - " + this.bookGenre + " - " + this.imagePath + " - ");
            }
        }
    }

}
