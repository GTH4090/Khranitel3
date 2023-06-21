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
    /// Логика взаимодействия для RequestList.xaml
    /// </summary>
    public partial class RequestList : Page
    {
        public RequestList()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

            try
            {
                requestDataGrid.ItemsSource = Db.Request.ToList();
            }
            catch (Exception ex)
            {
                Error(ex.Message);
            }
        }
    }
}
