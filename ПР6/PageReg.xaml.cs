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
    /// Логика взаимодействия для PageReg.xaml
    /// </summary>
    public partial class PageReg : Page
    {
        public PageReg()
        {
            InitializeComponent();

            regRole.ItemsSource = ClassBase.Base.Table_Roles.ToList();
            regRole.SelectedValuePath = "idRole";
            regRole.DisplayMemberPath = "role";
        }
        private void btnReg_Click(object sender, RoutedEventArgs e)
        {
            int gender = 0;
            if (regMen.IsChecked == true)
            {
                gender = 1;
            }
            if (regWomen.IsChecked == true)
            {
                gender = 2;
            }

            int role = 0;
            switch (regRole.SelectedIndex)
            {
                case 0:
                    role = 1;
                    break;
                case 1:
                    role = 2;
                    break;

            }

            Table_Sotrudniki sotrudnik = new Table_Sotrudniki() { surname = regSurname.Text, name = regName.Text, otchestvo = regOtch.Text, idGender = gender, birthday = (DateTime) regBirthday.SelectedDate, login = regLogin.Text, password = regPassword.GetHashCode(), idRole = role };
            ClassBase.Base.Table_Sotrudniki.Add(sotrudnik);
            ClassBase.Base.SaveChanges();
            Table_Pasporta pasport = new Table_Pasporta() { idSotr = sotrudnik.idSotr, seria = Convert.ToInt32(regSeria.Text), number = Convert.ToInt32(regNumber.Text), vidan = regVidan.Text };
            ClassBase.Base.Table_Pasporta.Add(pasport);
            ClassBase.Base.SaveChanges();

            MessageBox.Show("Пользователь добавлен");
        }
    }
}
