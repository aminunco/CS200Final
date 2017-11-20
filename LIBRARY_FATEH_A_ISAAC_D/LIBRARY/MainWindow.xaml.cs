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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LIBRARY
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        Userlist userlist;
        Login login;
        Homepage homepage;
        User user;
        public LoginWindow()
        {
            InitializeComponent();
            userlist = new Userlist();
            userInput.Focus();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            login = new Login();
            if (login.verifyCredentials(userInput.Text, passInput.Password, userlist))
            {
                user = new User(userInput.Text, passInput.Password, login.isAdmin);
                homepage = new Homepage(user);
                homepage.Show();
                this.Close();
            }
            else System.Windows.MessageBox.Show("Please enter a valid username and password","Invalid login credentials");
        }
    }
}
