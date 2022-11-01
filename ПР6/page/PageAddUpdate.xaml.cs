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

namespace ПР6.page
{
    /// <summary>
    /// Логика взаимодействия для PageAddUpdate.xaml
    /// </summary>
    public partial class PageAddUpdate : Page
    {
        public PageAddUpdate()
        {
            InitializeComponent();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            ClassFrame.mainFrame.Navigate(new PageTovari());
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
