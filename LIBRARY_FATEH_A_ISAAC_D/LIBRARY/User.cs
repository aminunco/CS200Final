using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LIBRARY
{
    public class User
    {
        public string username, password;
        public bool isAdmin;
        public BookList savedBooks;
        public User(string Username, string Password, bool isAdmin)
        {
            savedBooks = new BookList();
            this.username = Username;
            this.password = Password;
            this.isAdmin = isAdmin;
            getSavedBooks();
        }
        private void getSavedBooks()
        {
            try {
                using (StreamReader sr = new StreamReader(@"..\\..\\users\\" + this.username + ".txt"))
                {
                    string line = null;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] bookDetails = line.Split(new string[] { " - " }, StringSplitOptions.None);
                        Book book = new Book();
                        book.bookDetails(bookDetails[0], bookDetails[1], bookDetails[2], bookDetails[3], bookDetails[4], bookDetails[5]);
                        savedBooks.addBookToList(book);
                    }
                }
            }
            catch { }
        }
    }
}
