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
    /// Логика взаимодействия для PageAdmin.xaml
    /// </summary>
    public partial class PageAdmin : Page
    {
        public PageAdmin()
        {
            InitializeComponent();
        }

        private void btnSelect_Click(object sender, RoutedEventArgs e)
        {
            dgUsers.ItemsSource = ClassBase.Base.Table_Sotrudniki.ToList();
        }

        private void btnSortAsc_Click(object sender, RoutedEventArgs e)
        {
            dgUsers.ItemsSource = ClassBase.Base.Table_Sotrudniki.OrderBy(z=> z.surname).ToList();
        }

        private void btnSortDesc_Click(object sender, RoutedEventArgs e)
        {
            dgUsers.ItemsSource = ClassBase.Base.Table_Sotrudniki.OrderByDescending(z => z.surname).ToList();
        }

        private void btnFiltM_Click(object sender, RoutedEventArgs e)
        {
            dgUsers.ItemsSource = ClassBase.Base.Table_Sotrudniki.Where(z => z.idGender == 1).ToList();
        }

        private void btnFiltW_Click(object sender, RoutedEventArgs e)
        {
            dgUsers.ItemsSource = ClassBase.Base.Table_Sotrudniki.Where(z => z.idGender == 2).ToList();
        }
    }
}
