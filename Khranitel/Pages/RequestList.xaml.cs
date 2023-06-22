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
    /// Логика взаимодействия для RequestList.xaml
    /// </summary>
    public partial class RequestList : Page
    {
        public RequestList()
        {
            InitializeComponent();
        }

        private void loadCbx()
        {

            try
            {
                var items = Db.Type.ToList();
                items.Insert(0, new Models.Type() { Name = "Все"});
                TypeCbx.ItemsSource = items;
                TypeCbx.SelectedIndex =  0;
                var items2 = Db.Status.ToList();
                items2.Insert(0, new Models.Status() { Name = "Все" });
                StatusCbx.ItemsSource = items2;
                StatusCbx.SelectedIndex = 0;
                var divisions = Db.Division.ToList();
                divisions.Insert(0, new Division() { Name = "Все" });
                DivisionCbx.ItemsSource = divisions;
                DivisionCbx.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                Error(ex.Message);
            }
        }

        private void loadData()
        {
            try
            {
                List<Request> requests = Db.Request.ToList();
                if(TypeCbx.SelectedIndex == 1)
                {
                    
                    requests = requests.Where(el => el.ClientRequest.Count() == 0).ToList();
                }
                if (TypeCbx.SelectedIndex == 2)
                {

                    requests = requests.Where(el => el.ClientRequest.Count() != 0).ToList();
                }
                if (StatusCbx.SelectedIndex > 0)
                {
                    var item = StatusCbx.SelectedItem as Status;
                    requests = requests.Where(el => el.StatusId == item.Id).ToList();
                }
                if(DivisionCbx.SelectedIndex > 0)
                {
                    var item = DivisionCbx.SelectedItem as Division;
                    requests = requests.Where(el => el.Employee.DivisionId == item.Id).ToList();
                }
                requestDataGrid.ItemsSource = requests;
            }
            catch (Exception ex)
            {
                Error(ex.Message);
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            loadCbx();
            loadData();
            
        }

        private void TypeCbx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            loadData();
        }

        private void StatusCbx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            loadData();
        }

        private void DivisionCbx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            loadData();
        }
    }
}
