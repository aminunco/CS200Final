using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LIBRARY
{
    class Userlist
    {
        public List<User> users;
        public List<User> admins;
        public Userlist()
        {
            users = new List<User>();
            admins = new List<User>();
            populateUsers();
            populateAdmins();
        }
        private void populateUsers()
        {
            string line;

            System.IO.StreamReader SR = new System.IO.StreamReader("..\\..\\users.txt");
            while((line = SR.ReadLine()) != null)
            {
                string[] userInfo = line.Split(new string[] {" - "}, StringSplitOptions.None);
                User user = new User(userInfo[0], userInfo[1],false);
                users.Add(user);
            }
        }
        private void populateAdmins()
        {
            string line;
            System.IO.StreamReader SR = new System.IO.StreamReader("..\\..\\admins.txt");
            while ((line = SR.ReadLine()) != null)
            {
                string[] userInfo = line.Split(new string[] { " - " }, StringSplitOptions.None);
                User user = new User(userInfo[0], userInfo[1], true);
                admins.Add(user);
            }
            SR.Close();
        }
    }

}
