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

        void showImage(byte[] Barray, System.Windows.Controls.Image img)
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
            List<Photos> photos = ClassBase.Base.Photos.Where(z => z.idSotr == user.idSotr).ToList(); 
            if (photos.Count != 0) 
            {
                byte[] Bar = photos[photos.Count - 1].binaryPath;
                showImage(Bar, photoUser);
            }
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

        private void addPhoto_Click(object sender, RoutedEventArgs e) //добавление картинки
        {
            Photos photo = new Photos();
            try
            {
                photo.idSotr = user.idSotr;
                OpenFileDialog OFD = new OpenFileDialog();
                OFD.ShowDialog();
                string path = OFD.FileName;
                System.Drawing.Image SDI = System.Drawing.Image.FromFile(path);
                ImageConverter IC = new ImageConverter();
                byte[] Barray = (byte[])IC.ConvertTo(SDI, typeof(byte[]));
                photo.binaryPath = Barray;
                ClassBase.Base.Photos.Add(photo);
                ClassBase.Base.SaveChanges();
                MessageBox.Show("Успешное добавление фото!!!");
                ClassFrame.mainFrame.Navigate(new PageUser(user));
            }
            catch
            {
                MessageBox.Show("Косяк!");
            }
        }

        private void addPhotos_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog OFD = new OpenFileDialog();
                OFD.Multiselect = true;
                if (OFD.ShowDialog() == true)
                {
                    foreach (string file in OFD.FileNames)
                    {
                        Photos photo = new Photos();
                        photo.idSotr = user.idSotr;
                        string path = file;
                        System.Drawing.Image SDI = System.Drawing.Image.FromFile(file);
                        ImageConverter IC = new ImageConverter();
                        byte[] Barray = (byte[])IC.ConvertTo(SDI, typeof(byte[]));
                        photo.binaryPath = Barray;
                        ClassBase.Base.Photos.Add(photo);
                    }
                    ClassBase.Base.SaveChanges();
                    MessageBox.Show("Успешное добавление фото!!!");
                }
            }
            catch
            {
                MessageBox.Show("Косяк!");
            }
        }
        int n = 0;

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            List<Photos> u = ClassBase.Base.Photos.Where(x => x.idSotr == user.idSotr).ToList();
            n++;
            if (u != null)
            {

                byte[] Bar = u[n].binaryPath;
                showImage(Bar, imPhoto);
            }
            if (n == u.Count - 1)
            {
                n = -1;
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            List<Photos> u = ClassBase.Base.Photos.Where(x => x.idSotr == user.idSotr).ToList();
            if (u != null)
            {
                if (n == 0)
                {
                    n = u.Count;
                }
                if(n==-1)
                {
                    n=u.Count-1;
                }
                n--;
                byte[] Bar = u[n].binaryPath;
                BitmapImage BI = new BitmapImage();
                showImage(Bar, imPhoto);
            }
        }

        private void btnAddPhotoOld_Click(object sender, RoutedEventArgs e)
        {
            List<Photos> u = ClassBase.Base.Photos.Where(x => x.idSotr == user.idSotr).ToList();
            byte[] Bar = u[n].binaryPath;
            showImage(Bar, photoUser);
        }

        private void btnUpdatePhoto_Click(object sender, RoutedEventArgs e)
        {
            gallery.Visibility = Visibility.Visible;
            List<Photos> u = ClassBase.Base.Photos.Where(x => x.idSotr == user.idSotr).ToList();
            if (u != null)
            {
                byte[] Bar = u[n].binaryPath;
                showImage(Bar, imPhoto);
            }
        }
    }
}
