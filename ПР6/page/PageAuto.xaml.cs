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
    /// Логика взаимодействия для PageAuto.xaml
    /// </summary>
    public partial class PageAuto : Page
    {
        public PageAuto()
        {
            InitializeComponent();
        }

        private void btn_Auto_Click(object sender, RoutedEventArgs e)
        {
            int p = autoPassword.Password.GetHashCode();
            Table_Sotrudniki sotr = ClassBase.Base.Table_Sotrudniki.FirstOrDefault(z => z.login == autoLogin.Text && z.password == p); 
            if (sotr == null)
            {
                MessageBox.Show("Такого пользователя нет");
            }
            else
            {
                switch (sotr.idRole)
                {
                    case 2:
                        MessageBox.Show("Здравствуйте, администратор!");
                        ClassFrame.mainFrame.Navigate(new PageAdminMenu());
                        break;
                    case 1:
                        MessageBox.Show("Здравствуйте, пользователь!");
                        ClassFrame.mainFrame.Navigate(new PageUser(sotr));
                        break;
                    default:
                        
                        break;
                }
            }
        }
    }
}
