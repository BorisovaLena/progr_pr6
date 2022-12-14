
//Логин администратора: admin
//Пароль администратора: admin
//Логин пользователя: Белкина
//Пароль пользователя: QWERtyu123!

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

namespace ПР6
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ClassFrame.mainFrame = frMain;
            ClassFrame.mainFrame.Navigate(new PageMain());
            ClassBase.Base = new Entities();
        }

        private void btnAuto_Click(object sender, RoutedEventArgs e)
        {
            ClassFrame.mainFrame.Navigate(new PageAuto());
        }

        private void btnReg_Click(object sender, RoutedEventArgs e)
        {
            ClassFrame.mainFrame.Navigate(new PageReg());
        }

        private void btnRecl_Click(object sender, RoutedEventArgs e)
        {
            ClassFrame.mainFrame.Navigate(new page.PageAdvertisement());
        }
    }
}
