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
using static Khranitel.Classes.Helper;
using Khranitel.Models;
using BCrypt.Net;

namespace Khranitel.Pages
{
    /// <summary>
    /// Логика взаимодействия для Auth.xaml
    /// </summary>
    public partial class Auth : Page
    {
        public Auth()
        {
            InitializeComponent();
        }

        private void AuthBtn_Click(object sender, RoutedEventArgs e)
        {
            if (Db.User.FirstOrDefault(el => el.Email == LoginTbx.Text) != null)
            {
                var item = Db.User.FirstOrDefault(el => el.Email == LoginTbx.Text);
                if (GetHash(PasswordTbx.Password) == item.Password)
                {
                    AuthUs = item;
                    NavigationService.Navigate(new MainMenu());
                }
            }
        }

        private void RegBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Registration());
        }
    }
}
