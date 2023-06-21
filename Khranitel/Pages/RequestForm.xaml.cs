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
using System.Windows.Forms;
using System.IO;
using System.Drawing;

namespace Khranitel.Pages
{
    /// <summary>
    /// Логика взаимодействия для RequestForm.xaml
    /// </summary>
    public partial class RequestForm : Page
    {
        private void loadCbx()
        {

            try
            {
                DivisionCbx.ItemsSource = Db.Division.ToList();
                EmployeeCbx.ItemsSource = Db.Employee.ToList();
                TargetCbx.ItemsSource = Db.Target.ToList();
            }
            catch (Exception ex)
            {
                Error(ex.Message);
            }
            
            
        }
        public RequestForm()
        {
            InitializeComponent();
            loadCbx();
            RequestGrid.DataContext = new Request();
            ClientGrid.DataContext = new Client();
            (RequestGrid.DataContext as Request).TypeId = 1;
            (RequestGrid.DataContext as Request).StatusId = 1;
            if(AuthUs != null)
            {
                (RequestGrid.DataContext as Request).UserId = AuthUs.Id;
            }
            

        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            DivisionCbx.SelectedIndex = 0;
            EmployeeCbx.SelectedIndex = 0;
            TargetCbx.SelectedIndex = 0;
            
            FromDp.DisplayDateStart = DateTime.Now.AddDays(1);
            FromDp.DisplayDateEnd = DateTime.Now.AddDays(15);

            FromDp.SelectedDate = DateTime.Now.AddDays(1);
            birthDateDatePicker.SelectedDate = DateTime.Now.AddYears(-16);
            birthDateDatePicker.DisplayDateEnd = DateTime.Now.AddYears(-16);


        }

        private void DivisionCbx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            try
            {
                var item = DivisionCbx.SelectedItem as Division;
                EmployeeCbx.ItemsSource = Db.Employee.Where(el => el.DivisionId == item.Id).ToList();
                EmployeeCbx.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                Error(ex.Message);
            }
        }

        private void FromDp_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            ToDp.SelectedDate = FromDp.SelectedDate;
            ToDp.DisplayDateStart = FromDp.SelectedDate;
            ToDp.DisplayDateEnd = FromDp.SelectedDate.Value.AddDays(15);
        }

        private void DoscBtn_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                
                OpenFileDialog saveFile = new OpenFileDialog();
                saveFile.Filter = "pdf|*.pdf";
                if (saveFile.ShowDialog() == DialogResult.OK)
                {

                    (ClientGrid.DataContext as Client).DocsImg = File.ReadAllBytes(saveFile.FileName);
                }

            }
            catch (Exception ex)
            {
                Error(ex.Message);
            }
        }

        private void PhotoBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog saveFile = new OpenFileDialog();
                saveFile.Filter = "jpg|*.jpg";
                if (saveFile.ShowDialog() == DialogResult.OK)
                {
                    var bit = new Bitmap(saveFile.FileName);

                    if (File.ReadAllBytes(saveFile.FileName).Length <= 8 * 1024 * 1024 * 8 && bit.Width *4 == bit.Height *3)
                    {
                        (ClientGrid.DataContext as Client).Photo = File.ReadAllBytes(saveFile.FileName);
                        ClientImg.Source = new ImageSourceConverter().ConvertFromString(saveFile.FileName) as ImageSource;
                    }
                }
            }
            catch (Exception ex)
            {
                Error(ex.Message);
            }
        }

        private void ClearBtn_Click(object sender, RoutedEventArgs e)
        {

            RequestGrid.DataContext = new Request();
            ClientGrid.DataContext = new Client();
            (RequestGrid.DataContext as Request).TypeId = 1;
            (RequestGrid.DataContext as Request).StatusId = 1;
            if (AuthUs != null)
            {
                (RequestGrid.DataContext as Request).UserId = AuthUs.Id;
            }
            DivisionCbx.SelectedIndex = 0;
            EmployeeCbx.SelectedIndex = 0;
            TargetCbx.SelectedIndex = 0;

            

            FromDp.SelectedDate = DateTime.Now.AddDays(1);
            birthDateDatePicker.SelectedDate = DateTime.Now.AddYears(-16);
            phoneTextBox.Text = "";
            passportNumTextBox.Text = "";
            passportSerialTextBox.Text = "";
        }

        private void OkBtn_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                (ClientGrid.DataContext as Client).PassportSerial = passportSerialTextBox.Text;
                (ClientGrid.DataContext as Client).PassportNum = passportNumTextBox.Text;
                (ClientGrid.DataContext as Client).Phone = phoneTextBox.Text;
                (RequestGrid.DataContext as Request).Client = ClientGrid.DataContext as Client;
                if(emailTextBox.Text.Split('@').Count() == 2 && emailTextBox.Text[0] != '@' && emailTextBox.Text[emailTextBox.Text.Length - 1] != '@')
                {
                    Db.Request.Add(RequestGrid.DataContext as Request);
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
