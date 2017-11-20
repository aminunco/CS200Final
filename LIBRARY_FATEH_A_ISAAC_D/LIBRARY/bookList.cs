using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LIBRARY
{
    public class BookList
    {
        Library library;
        public List<Book> bookList;
        public BookList()
        {
            bookList = new List<Book>();
            library = Library.Instance;
        }

        public void addBook(Book book)
        {
            addBookToList(book);
            addBookToFile(book);
        }
        public void addBookToList(Book book)
        {
            bookList.Add(book);
        }
        public void addBookToFile(Book book)
        {
            
        }
    }

}
