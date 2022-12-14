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
        ClassPagin pc = new ClassPagin();
        Table_Sotrudniki user;
        List<Table_Tovari> listFilter = new List<Table_Tovari>();
        List<Table_Tovari> tovar = ClassBase.Base.Table_Tovari.ToList();
        public PageTovari(Table_Sotrudniki user)
        {
            InitializeComponent();
            listProd.ItemsSource = ClassBase.Base.Table_Tovari.ToList();
            this.user = user;

            List<Table_Providers> providers = ClassBase.Base.Table_Providers.ToList();
            cmbFilterProviders.Items.Add("Любые поставщики");
            for(int i=0; i< providers.Count;i++)
            {
                cmbFilterProviders.Items.Add(providers[i].title);
            }
            cmbFilterProviders.SelectedIndex = 0;
            cmbSort.SelectedIndex = 0;

            pc.CountPage = ClassBase.Base.Table_Tovari.ToList().Count;
            DataContext = pc;
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
            
            tb.Text = string.Format("Продано на сумму: {0:C2}", stoimost);
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            ClassFrame.mainFrame.Navigate(new PageAddUpdate(tovar, user));
        }
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            ClassFrame.mainFrame.Navigate(new PageAdminMenu(user));
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button) sender;
            int index = Convert.ToInt32(btn.Uid);

            Table_Tovari tovar = ClassBase.Base.Table_Tovari.FirstOrDefault(z => z.idTovar == index);

            ClassBase.Base.Table_Tovari.Remove(tovar);
            ClassBase.Base.SaveChanges();

            ClassFrame.mainFrame.Navigate(new PageTovari(user));
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            int index = Convert.ToInt32(btn.Uid);

            Table_Tovari tovar = ClassBase.Base.Table_Tovari.FirstOrDefault(z => z.idTovar == index);

            ClassFrame.mainFrame.Navigate(new PageAddUpdate(tovar, user));
        }

        void Filter()
        {
            List<Table_Tovari> list1 = ClassBase.Base.Table_Tovari.ToList();
            string provider = cmbFilterProviders.SelectedValue.ToString();
            int index = cmbFilterProviders.SelectedIndex;
            List<Table_Postavki> postavki = ClassBase.Base.Table_Postavki.Where(z => z.Table_Providers.title == provider).ToList();
            if(index!=0)
            {
                listFilter = new List<Table_Tovari>();
                foreach (Table_Postavki tp in postavki)
                {
                    foreach(Table_Tovari tovar in list1)
                    {
                        if(tovar.idTovar== tp.idTovar)
                        {
                            listFilter.Add(tovar);
                        }
                    }
                }
            }
            else
            {
                listFilter = ClassBase.Base.Table_Tovari.ToList();
            }

            if(!string.IsNullOrWhiteSpace(tbFilterTovar.Text))
            {
                listFilter = listFilter.Where(z=> z.tovar.ToLower().Contains(tbFilterTovar.Text.ToLower())).ToList();
            }

            if(cbKol0.IsChecked==true)
            {
                listFilter = listFilter.Where(z=> z.kol!=0).ToList();
            }

            switch(cmbSort.SelectedIndex)
            {
                case 1:
                    listFilter.Sort((x,y) => x.tovar.CompareTo(y.tovar));
                    break;
                case 2:
                    listFilter.Sort((x, y) => x.tovar.CompareTo(y.tovar));
                    listFilter.Reverse();
                    break;
                case 3:
                    listFilter.Sort((x, y) => x.count.CompareTo(y.count));
                    break;
                case 4:
                    listFilter.Sort((x,y)=>x.count.CompareTo(y.count));
                    listFilter.Reverse();
                    break;
                case 5:
                    listFilter.Sort((x, y) => x.kol.CompareTo(y.kol));
                    break;
                case 6:
                    listFilter.Sort((x, y) => x.kol.CompareTo(y.kol));
                    listFilter.Reverse();
                    break;
            }

            listProd.ItemsSource = listFilter;
            if (listFilter.Count == 0)
            {
                MessageBox.Show("нет записей");
            }
        }

        private void cbFilterProviders_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Filter();
        }

        private void tbFilterTovar_TextChanged(object sender, TextChangedEventArgs e)
        {
            Filter();
        }

        private void cbKol0_Checked(object sender, RoutedEventArgs e)
        {
            Filter();
        }

        private void GoPage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            TextBlock tb = (TextBlock)sender;

            switch (tb.Uid)  // определяем, куда конкретно было сделано нажатие
            {
                case "prev":
                    pc.CurrentPage--;
                    break;
                case "next":
                    pc.CurrentPage++;
                    break;
                case "firstPage":
                    pc.CurrentPage = 1;
                    break;
                case "lastPage":
                    pc.CurrentPage = pc.CountPages;
                    break;
                default:
                    pc.CurrentPage = Convert.ToInt32(tb.Text);
                    break;
            }
            listProd.ItemsSource = listFilter.Skip(pc.CurrentPage * pc.CountPage - pc.CountPage).Take(pc.CountPage).ToList();  // оображение записей постранично с определенным количеством на каждой странице
        }

        private void txtPageCount_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                pc.CountPage = Convert.ToInt32(txtPageCount.Text); // если в текстовом поле есnь значение, присваиваем его свойству объекта, которое хранит количество записей на странице
            }
            catch
            {
                pc.CountPage = listFilter.Count; // если в текстовом поле значения нет, присваиваем свойству объекта, которое хранит количество записей на странице количество элементов в списке
            }
            pc.Countlist = listFilter.Count;  // присваиваем новое значение свойству, которое в объекте отвечает за общее количество записей
            listProd.ItemsSource = listFilter.Skip(0).Take(pc.CountPage).ToList();  // отображаем первые записи в том количестве, которое равно CountPage
            pc.CurrentPage = 1; // текущая страница - это страница 1
        }
    }
}
