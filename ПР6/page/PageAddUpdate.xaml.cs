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
        public PageAddUpdate(Table_Tovari tovar)
        {
            InitializeComponent();
            fillingLists();
            TOVAR = tovar;
            add = false;
            AUdate.SelectedDate = ClassBase.Base.Table_Postavki.FirstOrDefault(z => z.idTovar == tovar.idTovar).date;
            AUtovar.Text = tovar.tovar;
            AUkol.Text = Convert.ToString(tovar.kol);
            AUcount.Text = Convert.ToString(tovar.count);
            List<Table_Postavki> TP= ClassBase.Base.Table_Postavki.Where(z => z.idTovar == tovar.idTovar).ToList();
            
            foreach(Table_Providers provider in lbProviders.Items)
            {
                if(TP.FirstOrDefault(z=> z.idProvider == provider.idProvider)!=null)
                {
                    lbProviders.SelectedItems.Add(provider);
                }
            }
        }
        public void fillingLists()
        {
            lbProviders.ItemsSource = ClassBase.Base.Table_Providers.ToList();
            lbProviders.SelectedValuePath = "idProvider";
            lbProviders.DisplayMemberPath = "title";
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

            if(add == true)
            {
                ClassBase.Base.Table_Tovari.Add(TOVAR);
            }

            if (lbProviders.SelectedValue == null)
            {
                Table_Providers provider = new Table_Providers()
                {
                    title = AUprovider.Text,
                    predstavitel = AUpredstavitel.Text,
                    phoneNumber = AUnumber.Text
                };
                if (add == true)
                {
                    ClassBase.Base.Table_Tovari.Add(TOVAR);
                }

                Table_Postavki postavka = new Table_Postavki()
                {
                    date = Convert.ToDateTime(AUdate.SelectedDate),
                    idTovar = TOVAR.idTovar,
                    idProvider = provider.idProvider,
                    kol = Convert.ToInt32(AUkol.Text),
                    count = Convert.ToInt32(AUcount.Text),
                    stoimost = TOVAR.count * TOVAR.kol
                };

                if (add == true)
                {
                    ClassBase.Base.Table_Tovari.Add(TOVAR);
                }
            }
            else
            {
                List<Table_Postavki> TP = ClassBase.Base.Table_Postavki.Where(z => TOVAR.idTovar == z.idTovar).ToList();

                if (TP.Count > 0)
                {
                    foreach (Table_Postavki p in TP)
                    {
                        ClassBase.Base.Table_Postavki.Remove(p);
                    }
                }

                foreach (Table_Providers p in lbProviders.SelectedItems)
                {
                    Table_Postavki postavka = new Table_Postavki()
                    {
                        date = Convert.ToDateTime(AUdate.SelectedDate),
                        idTovar = TOVAR.idTovar,
                        idProvider = p.idProvider,
                        kol = Convert.ToInt32(AUkol.Text),
                        count = Convert.ToInt32(AUcount.Text),
                        stoimost = TOVAR.count * TOVAR.kol
                    };
                    ClassBase.Base.Table_Postavki.Add(postavka);
                }
               
                if (add == true)
                {
                    ClassBase.Base.Table_Tovari.Add(TOVAR);
                }
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
