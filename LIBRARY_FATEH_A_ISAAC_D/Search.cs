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

public class Search
{
      public void findBook(string filepath, string Searchtext)
    {
        int foundcounter = 0;
        List<string> FileLines = File.ReadLines(filepath).ToList<string>();
        foreach (string item in FileLines)
        {
            if (item.IndexOf(Searchtext, StringComparison.InvariantCultureIgnoreCase) >= 0) //this returns an index of the match without case sens. if nothings found it returns null//
            {
                foundcounter += 1;
                Book book = new Book(item);
                switch (foundcounter)
                {
                    case 1:
                        label1.Content = book.bookTitle;
                        image.Source = book.BookCover();
                        break;
                    case 2:
                        label2.Content = book.bookTitle;
                        image1.Source = book.BookCover();
                        break;
                    case 3:
                        label3.Content = book.bookTitle;
                        image2.Source = book.BookCover();
                        break;
                    case 4:
                        label4.Content = book.bookTitle;
                        image3.Source = book.BookCover();
                        break;
                }
            }
        }

        return "";
    }

}

