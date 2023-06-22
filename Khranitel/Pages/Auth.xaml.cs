﻿using System;
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
            if (Db.Employee.FirstOrDefault(el => el.Code == LoginTbx.Text) != null)
            {
                var item = Db.Employee.FirstOrDefault(el => el.Code == LoginTbx.Text);
                if (item.DepartmentId == 1)
                {
                    NavigationService.Navigate(new MainMenu());
                }
            }
        }

        
    }
}
