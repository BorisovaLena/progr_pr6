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
using ПР6.page;

namespace ПР6
{
    /// <summary>
    /// Логика взаимодействия для PageAdminMenu.xaml
    /// </summary>
    public partial class PageAdminMenu : Page
    {
        Table_Sotrudniki user;
        public PageAdminMenu(Table_Sotrudniki user)
        {
            InitializeComponent();
            this.user = user;
            Surname.Text = user.surname;
            Name.Text = user.name;
            Otch.Text = user.otchestvo;
            Birthday.SelectedDate = user.birthday;
            Seria.Text = Convert.ToString(user.Table_Pasporta.seria);
            Number.Text = Convert.ToString(user.Table_Pasporta.number);
            Vidan.Text = user.Table_Pasporta.vidan;
        }

        private void btnSelectUser_Click(object sender, RoutedEventArgs e)
        {
            ClassFrame.mainFrame.Navigate(new PageAdmin(user));
        }

        private void btnSelectTovar_Click(object sender, RoutedEventArgs e)
        {
            ClassFrame.mainFrame.Navigate(new PageTovari(user));
        }

        //private void btnLC_Click(object sender, RoutedEventArgs e)
        //{
        //    ClassFrame.mainFrame.Navigate(new PageAdmin(user));
        //}

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            WindowUpdateUser window = new WindowUpdateUser(user);
            window.ShowDialog();
            ClassFrame.mainFrame.Navigate(new PageAdminMenu(user));
        }

        private void btnLogPas_Click(object sender, RoutedEventArgs e)
        {
            WindowUpdateLodinPassword window = new WindowUpdateLodinPassword(user);
            window.ShowDialog();
            ClassFrame.mainFrame.Navigate(new PageAdminMenu(user));
        }
    }
}
