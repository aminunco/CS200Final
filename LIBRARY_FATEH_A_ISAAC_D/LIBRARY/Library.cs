using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LIBRARY
{
    class Library
    {
        private static Library library;
        public List<Book> libraryList {get; private set;}
        
        private Library()
        {
            populateLibrary();
        }
        public void populateLibrary()
        {
            libraryList = new List<Book>();
            string line;
            
            System.IO.StreamReader SR = new System.IO.StreamReader("..\\..\\books.txt");
            while ((line = SR.ReadLine()) != null)
            {
                string[] bookDetails = line.Split(new string[] { " - " }, StringSplitOptions.None);
                Book book = new Book();
                book.bookDetails(bookDetails[0], bookDetails[1], bookDetails[2], bookDetails[3], bookDetails[4], bookDetails[5]);
                libraryList.Add(book);
            }
            SR.Close();
        }
        public static Library Instance
        {
            get
            {
                if (library == null)
                {
                    library = new Library();
                }
                return library;
            }
        }
    }
}
