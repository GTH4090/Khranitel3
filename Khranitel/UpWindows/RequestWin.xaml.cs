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
using System.Windows.Shapes;
using static Khranitel.Classes.Helper;

namespace Khranitel.UpWindows
{
    /// <summary>
    /// Логика взаимодействия для RequestWin.xaml
    /// </summary>
    public partial class RequestWin : Window
    {
        public RequestWin()
        {
            InitializeComponent();
            ReqWin = this;
        }
    }
}