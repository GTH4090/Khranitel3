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

namespace Khranitel
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BAckBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.GoBack();
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void MainFrame_Navigated(object sender, NavigationEventArgs e)
        {
            TitleLb.Content = (e.Content as Page).Title;
            if(MainFrame.CanGoBack)
            {
                BAckBtn.Visibility = Visibility.Visible;
            }
            else
            {
                BAckBtn.Visibility= Visibility.Collapsed;
            }
        }
    }
}
