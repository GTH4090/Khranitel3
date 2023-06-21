using BCrypt.Net;
using Khranitel.Models;
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

namespace Khranitel.Pages
{
    /// <summary>
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Page
    {
        public Registration()
        {
            InitializeComponent();
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();

        }

        private void RegBtn_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                string ll = "qwertyuiopasdfghjklzxcvbnm";
                string ul = ll.ToUpper();
                string nums = "1234567890";
                string spec = "!@#$%^&*()";
                if (LoginTbx.Text.Split('@').Count() == 2 && LoginTbx.Text[0] != '@' && LoginTbx.Text[LoginTbx.Text.Length - 1] != '@'
                    && PasswordTbx.Password == PasswordTbx.Password && PasswordTbx.Password.Length >= 8 &&
                    PasswordTbx.Password.Intersect(ll).Count() > 0 &&
                    PasswordTbx.Password.Intersect(ul).Count() > 0 &&
                    PasswordTbx.Password.Intersect(nums).Count() > 0 &&
                    PasswordTbx.Password.Intersect(spec).Count() > 0 &&
                    Db.User.FirstOrDefault(el => el.Email == LoginTbx.Text) == null)
                {
                    User user = new User();
                    user.Email = LoginTbx.Text;
                    user.Password = GetHash(PasswordTbx.Password);
                    Db.User.Add(user);
                    Db.SaveChanges();
                    NavigationService.GoBack();
                }
            }
            catch (Exception ex)
            {
                Error(ex.Message);
            }
        }
    }
}
