using Khranitel.Models;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static Khranitel.Classes.Helper;

namespace Khranitel.UpWindows
{
    /// <summary>
    /// Логика взаимодействия для GroupRequestWin.xaml
    /// </summary>
    public partial class GroupRequestWin : Window
    {
        public GroupRequestWin()
        {
            InitializeComponent();
            loadCbx();
            RequestGrid.DataContext = new Request();
            ClientGrid.DataContext = new Client();
            (RequestGrid.DataContext as Request).TypeId = 1;
            (RequestGrid.DataContext as Request).StatusId = 1;
            if (AuthUs != null)
            {
                (RequestGrid.DataContext as Request).UserId = AuthUs.Id;
            }
        }
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
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
                if (saveFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {

                    (ClientGrid.DataContext as Client).DocsImg = File.ReadAllBytes(saveFile.FileName);
                }

            }
            catch (Exception ex)
            {
                Error(ex.Message);
            }
        }

        private void ClearBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
            GroupRequestWin groupRequest = new GroupRequestWin();
            groupRequest.ShowDialog();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            if(emailTextBox.Text.Split('@').Count() == 2 && emailTextBox.Text[0] != '@' 
                && emailTextBox.Text[emailTextBox.Text.Length - 1] != '@' && (ClientGrid.DataContext as Client).DocsImg != null)
            {
                ClientRequest clientReq = new ClientRequest();
                (ClientGrid.DataContext as Client).Phone = phoneTextBox.Text;
                (ClientGrid.DataContext as Client).PassportSerial = passportSerialTextBox.Text;
                (ClientGrid.DataContext as Client).PassportNum = passportNumTextBox.Text;
                
                clientReq.Client = ClientGrid.DataContext as Client;
                clientReq.Request = RequestGrid.DataContext as Request;
                List<Client> clients = ClientsDg.Items.Cast<Client>().ToList();
                clients.Add(ClientGrid.DataContext as Client);
                ClientsDg.ItemsSource = clients;
                Db.ClientRequest.Add(clientReq);
                ClientGrid.DataContext = new Client();
                phoneTextBox.Text = "";
                passportNumTextBox.Text = "";
                passportSerialTextBox.Text = "";
                birthDateDatePicker.SelectedDate = DateTime.Now.AddYears(-16);
            }
            
        }

        private void OkBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                (ClientGrid.DataContext as Client).PassportSerial = passportSerialTextBox.Text;
                (ClientGrid.DataContext as Client).PassportNum = passportNumTextBox.Text;
                (ClientGrid.DataContext as Client).Phone = phoneTextBox.Text;
                (RequestGrid.DataContext as Request).Client = ClientGrid.DataContext as Client;
                if (emailTextBox.Text.Split('@').Count() == 2 && emailTextBox.Text[0] != '@' && emailTextBox.Text[emailTextBox.Text.Length - 1] != '@')
                {
                    Db.Request.Add(RequestGrid.DataContext as Request);
                    Db.SaveChanges();
                    Close();
                }
                    
               
            }
            catch (Exception ex)
            {
                Error(ex.Message);
            }
        }
    }
}
