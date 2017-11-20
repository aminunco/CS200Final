using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LIBRARY
{
    class Login
    {
        public bool isAdmin = false;
        public bool verifyCredentials(string username, string password, Userlist userlist)
        {
            foreach (User temp in userlist.users)
            {
                if (temp.username.Equals(username) && temp.password.Equals(password))
                { 
                    return true;
                }
            }
            foreach (User temp in userlist.admins)
            {
                if (temp.username.Equals(username) && temp.password.Equals(password))
                {
                    isAdmin = true;
                    return true;
                }
            }
            return false;
        }
    }
}
