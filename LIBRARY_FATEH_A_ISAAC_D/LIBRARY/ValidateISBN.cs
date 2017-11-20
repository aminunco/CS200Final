using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LIBRARY
{
    class ValidateISBN
    {
        string isbn;
        List<int> numbers;

        public ValidateISBN(string isbn)
        {
            this.isbn = isbn;
        }
        public Boolean isValid()
        {
            if (isbn.Length == 10 || isbn.Length == 13)
            {
                try
                {
                    Int32.Parse(isbn);
                    return true;
                }
                catch
                {
                    return false;
                }

            }
            else return false;
        }
    }
}
