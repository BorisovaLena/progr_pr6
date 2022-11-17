using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Drawing;
using ПР6.page;

namespace ПР6
{
    /// <summary>
    /// Логика взаимодействия для PageUser.xaml
    /// </summary>
    public partial class PageUser : Page
    {
        Table_Sotrudniki user;

        public object OpenFileDialoge { get; private set; }

        void showImage(byte[] Barray, Image img)
        {
            BitmapImage BI = new BitmapImage();
            using (MemoryStream m = new MemoryStream(Barray))
            {
                BI.BeginInit();
                BI.StreamSource = m;
                BI.CacheOption = BitmapCacheOption.OnLoad;
                BI.EndInit();
            }
            img.Source = BI;
            img.Stretch = Stretch.Uniform;
        }

        public PageUser(Table_Sotrudniki user)
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

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            WindowUpdateUser window = new WindowUpdateUser(user);
            window.ShowDialog();
            ClassFrame.mainFrame.Navigate(new PageUser(user));
        }

        private void btnLogPas_Click(object sender, RoutedEventArgs e)
        {
            WindowUpdateLodinPassword window = new WindowUpdateLodinPassword(user);
            window.ShowDialog();
            ClassFrame.mainFrame.Navigate(new PageUser(user));
        }

        private void addPhoto_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Photos photo = new Photos();
                photo.idSotr = user.idSotr;
                OpenFileDialog OFD = new OpenFileDialog();
                OFD.ShowDialog();
                string path = OFD.FileName;
                System.Drawing.Image SDI = System.Drawing.Image.FromFile(path);
                ImageConverter IC = new ImageConverter();
            }
            catch
            {

            }
            
            
        }
    }
}
