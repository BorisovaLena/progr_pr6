using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
             if (Surname.Text == "" || Name.Text == "" || Otch.Text == "" || Birthday.IsEnabled == false || Seria.Text == "" || Number.Text == "" || Vidan.Text == "")
            {
                MessageBox.Show("Введите все данные!");
            }
            else
            {
                Regex r1 = new Regex("^[0-9]{4}$");
                Regex r2 = new Regex("^[0-9]{6}$");
                if (r1.IsMatch(Seria.Text) == false)
                {
                    MessageBox.Show("Серия паспорта может состоять только из 4 цифр!");
                }
                else if (r2.IsMatch(Number.Text) == false)
                {
                    MessageBox.Show("Номер паспорта может состоять только из 6 цифр!");
                }
                else
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
    }
}
