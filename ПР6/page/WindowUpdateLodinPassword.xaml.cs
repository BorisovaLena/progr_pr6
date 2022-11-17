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
            Regex r5 = new Regex("(?=.*[A-Z])");
            Regex r6 = new Regex("[a-z].*[a-z].*[a-z]");
            Regex r7 = new Regex("\\d.*\\d");
            Regex r8 = new Regex("[!@#$%^&*()_+=]");
            Regex r9 = new Regex("(.+){8,}");
            if (r5.IsMatch(Password.Password) == true)
            {
                if (r6.IsMatch(Password.Password) == true)
                {
                    if (r7.IsMatch(Password.Password) == true)
                    {
                        if (r8.IsMatch(Password.Password) == true)
                        {
                            if (r9.IsMatch(Password.Password) == true)
                            {
                                Table_Sotrudniki sotr = ClassBase.Base.Table_Sotrudniki.FirstOrDefault(x => x.login == Login.Text);
                                if (sotr == null)
                                {
                                    user.login = Login.Text;
                                    user.password = Password.Password.GetHashCode();
                                    ClassBase.Base.SaveChanges();
                                    MessageBox.Show("Успешное изменение логина и пароля!!!");
                                    this.Close();
                                }
                                else
                                {
                                    MessageBox.Show("Данный логин существует!");
                                }
                            }
                            else { MessageBox.Show("Общая длина пароля не менее 8 символов!"); }
                        }
                        else { MessageBox.Show("Пароль должен содержать не менее 1 спец. символа!"); }
                    }
                    else { MessageBox.Show("Пароль должен содержать не менее 2 цифры!"); }
                }
                else { MessageBox.Show("Пароль должен содержать не менее 3 строчных латинских символов!"); }
            }
            else { MessageBox.Show("Пароль должен содержать не менее 1 заглавного латинского символа!"); }
        }
    }
}
