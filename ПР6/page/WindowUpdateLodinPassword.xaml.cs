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

namespace ПР6.page
{
    /// <summary>
    /// Логика взаимодействия для WindowUpdateLodinPassword.xaml
    /// </summary>
    public partial class WindowUpdateLodinPassword : Window
    {
        Table_Sotrudniki user;
        public WindowUpdateLodinPassword(Table_Sotrudniki user)
        {
            InitializeComponent();
            this.user = user;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            user.login = Login.Text;
            user.password = Password.Password.GetHashCode();
            ClassBase.Base.SaveChanges();
            MessageBox.Show("Успешное изменение логина и пароля!!!");
            this.Close();
        }
    }
}
