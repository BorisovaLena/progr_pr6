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
        Table_Tovari TOVAR;
        bool add;
        public PageAddUpdate()
        {
            InitializeComponent();
            fillingLists();
            add = true;
        }

        public void fillingLists()
        {
            cmbProvider.ItemsSource = ClassBase.Base.Table_Providers.ToList();
            cmbProvider.SelectedValuePath = "idProvider";
            cmbProvider.DisplayMemberPath = "title";
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            ClassFrame.mainFrame.Navigate(new PageTovari());
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {

            if (add==true)
            {
                TOVAR = new Table_Tovari();
            }

            TOVAR.tovar = AUtovar.Text;
            TOVAR.count = Convert.ToDouble(AUcount.Text);
            TOVAR.kol = Convert.ToInt32(AUkol.Text);
            ClassBase.Base.Table_Tovari.Add(TOVAR);

            if (cmbProvider.SelectedValue == null)
            {
                Table_Providers provider = new Table_Providers()
                {
                    title = AUprovider.Text,
                    predstavitel = AUpredstavitel.Text,
                    phoneNumber = AUnumber.Text
                };
                ClassBase.Base.Table_Providers.Add(provider);

                Table_Postavki postavka = new Table_Postavki()
                {
                    date = Convert.ToDateTime(AUdate.SelectedDate),
                    idTovar = TOVAR.idTovar,
                    idProvider = provider.idProvider,
                    kol = Convert.ToInt32(AUkol.Text),
                    count = Convert.ToInt32(AUcount.Text),
                    stoimost = TOVAR.count * TOVAR.kol
                };
                ClassBase.Base.Table_Postavki.Add(postavka);
            }
            else
            {
                Table_Postavki postavka = new Table_Postavki()
                {
                    date = Convert.ToDateTime(AUdate.SelectedDate),
                    idTovar = TOVAR.idTovar,
                    idProvider = cmbProvider.SelectedIndex+1,
                    kol = Convert.ToInt32(AUkol.Text),
                    count = Convert.ToInt32(AUcount.Text),
                    stoimost = TOVAR.count * TOVAR.kol
                };
                ClassBase.Base.Table_Postavki.Add(postavka);
            }
            ClassBase.Base.SaveChanges();
            MessageBox.Show("Успешное добавление записи!!!");
            ClassFrame.mainFrame.Navigate(new PageTovari());
        }

        private void btnAddProvider_Click(object sender, RoutedEventArgs e)
        {
            spNewProvider.Visibility = Visibility.Visible;
        }
    }
}
