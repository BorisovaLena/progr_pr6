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
    /// Логика взаимодействия для PageTovari.xaml
    /// </summary>
    public partial class PageTovari : Page
    {
        List<Table_Tovari> tovar = ClassBase.Base.Table_Tovari.ToList();
        
        public PageTovari()
        {
            InitializeComponent();
            listProd.ItemsSource = ClassBase.Base.Table_Tovari.ToList();
        }

      
        private void tbProviders_Loaded(object sender, RoutedEventArgs e)
        {
            TextBlock tb = (TextBlock)sender;
            int index = Convert.ToInt32(tb.Uid);
            List<Table_Postavki> providers = ClassBase.Base.Table_Postavki.Where(z => z.idTovar == index).ToList();
            string str = "";
            foreach (Table_Postavki tp in providers)
            {
                str += tp.Table_Providers.title + ", ";
            }

            tb.Text = "Поставщики: " + str.Substring(0, str.Length - 2);
        }

        private void tbStoimost_Loaded(object sender, RoutedEventArgs e)
        {
            TextBlock tb = (TextBlock)sender;
            int index = Convert.ToInt32(tb.Uid);
            List<Table_Pokupki> tp = ClassBase.Base.Table_Pokupki.Where(z => z.idTovar == index).ToList();
            double stoimost = 0;
            foreach (Table_Pokupki tpoc in tp)
            {
                stoimost += Convert.ToDouble(tpoc.stoimost);
            }
            tb.Text = "Было продано товара на сумму: " + stoimost.ToString() + " руб.";
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            ClassFrame.mainFrame.Navigate(new PageAddUpdate());
        }
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            ClassFrame.mainFrame.Navigate(new PageAdminMenu());
        }
    }
}
