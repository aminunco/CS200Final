using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace LIBRARY
{
    class IsbnAPI
    {
        private string key = "ICLJN02J";
        private Book myBook;

        public Book getBook(string isbn)
        {            
            string uri = string.Format(@"http://isbndb.com/api/v2/json/{0}/book/{1}", key, isbn);
            WebClient client = new WebClient();
            string data = client.DownloadString(uri);
            ConvertToObject(data);
            return myBook;
        }

        private void ConvertToObject(string data)
        {
            JObject rawbook = JObject.Parse(data);
            List<JToken> tokens = rawbook["data"].Children().ToList();
            JToken firstToken = tokens.First();
            myBook = firstToken.ToObject<Book>();
        }
    }
}
