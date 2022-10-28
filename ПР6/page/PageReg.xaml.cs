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
            if(regSurname.Text =="" || regName.Text == "" || regOtch.Text == "" || regBirthday.IsEnabled == false || regSeria.Text =="" ||regNumber.Text =="" || regVidan.Text == "" || regLogin.Text =="" || regPassword.Password == "")
            {
                if(regMen.IsChecked == false && regWomen.IsChecked == false)
                {
                    MessageBox.Show("Введите все данные!");
                }
                else
                {
                    MessageBox.Show("Введите все данные!");
                } 
            }
            else
            {
                Regex r1 = new Regex("^[0-9]{4}$");
                Regex r2 = new Regex("^[0-9]{6}$");
                if(r1.IsMatch(regSeria.Text)==false)
                {
                    MessageBox.Show("Серия паспорта может состоять только из 4 цифр!");
                }
                else if(r2.IsMatch(regNumber.Text) == false)
                {
                    MessageBox.Show("Номер паспорта может состоять только из 6 цифр!");
                }
                else
                {
                    Regex r5 = new Regex("(?=.*[A-Z])");
                    Regex r6 = new Regex("[a-z].*[a-z].*[a-z]");
                    Regex r7 = new Regex("\\d.*\\d");
                    Regex r8 = new Regex("[!@#$%^&*()_+=]");
                    Regex r9 = new Regex("(.+){8,}");
                    if (r5.IsMatch(regPassword.Password) == true)
                    {
                        if (r6.IsMatch(regPassword.Password) == true)
                        {
                            if (r7.IsMatch(regPassword.Password) == true)
                            {
                                if (r8.IsMatch(regPassword.Password) == true)
                                {
                                    if (r9.IsMatch(regPassword.Password) == true)
                                    {
                                        int p = regPassword.Password.GetHashCode();
                                        Table_Sotrudniki sotr = ClassBase.Base.Table_Sotrudniki.FirstOrDefault(x => x.login == regLogin.Text );
                                        if (sotr == null)
                                        {
                                            Table_Sotrudniki sotrudnik = new Table_Sotrudniki() { surname = regSurname.Text, name = regName.Text, otchestvo = regOtch.Text, idGender = gender, birthday = (DateTime)regBirthday.SelectedDate, login = regLogin.Text, password = regPassword.Password.GetHashCode(), idRole = 1 };
                                            ClassBase.Base.Table_Sotrudniki.Add(sotrudnik);
                                            ClassBase.Base.SaveChanges();
                                            Table_Pasporta pasport = new Table_Pasporta() { idSotr = sotrudnik.idSotr, seria = Convert.ToInt32(regSeria.Text), number = Convert.ToInt32(regNumber.Text), vidan = regVidan.Text };
                                            ClassBase.Base.Table_Pasporta.Add(pasport);
                                            ClassBase.Base.SaveChanges();
                                            MessageBox.Show("Успешная регистрация!");                                          
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
    }
}
