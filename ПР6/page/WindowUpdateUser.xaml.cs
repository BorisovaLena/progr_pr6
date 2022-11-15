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
using System.Windows.Shapes;

namespace ПР6
{
    /// <summary>
    /// Логика взаимодействия для WindowUpdateUser.xaml
    /// </summary>
    public partial class WindowUpdateUser : Window
    {
        Table_Sotrudniki user;
        public WindowUpdateUser(Table_Sotrudniki user)
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

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            user.surname = Surname.Text;
            user.name = Name.Text;
            user.otchestvo = Otch.Text;
            user.birthday = Convert.ToDateTime(Birthday.SelectedDate);
            user.Table_Pasporta.seria = Convert.ToInt32(Seria.Text);
            user.Table_Pasporta.number = Convert.ToInt32(Number.Text);
            user.Table_Pasporta.vidan = Vidan.Text;
            ClassBase.Base.SaveChanges();
            MessageBox.Show("Успешное изменение данных!!!");
            this.Close();
        }
    }
}
