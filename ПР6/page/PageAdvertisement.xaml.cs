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
using System.Windows.Media.Animation;

namespace ПР6.page
{
    /// <summary>
    /// Логика взаимодействия для PageAdvertisement.xaml
    /// </summary>
    public partial class PageAdvertisement : Page
    {
        public PageAdvertisement()
        {
            InitializeComponent();

            DoubleAnimation FS = new DoubleAnimation(); //анимация на размер шрифта
            FS.From = 30;
            FS.To = 40;
            FS.Duration = TimeSpan.FromSeconds(5);
            FS.RepeatBehavior = RepeatBehavior.Forever;
            FS.AutoReverse = true;
            tbSlogan.BeginAnimation(FontSizeProperty, FS);

            DoubleAnimation IW = new DoubleAnimation(); //анимация на ширину картинки
            IW.From = 350;
            IW.To = 400;
            IW.Duration = TimeSpan.FromSeconds(2);
            IW.RepeatBehavior = RepeatBehavior.Forever;
            IW.AutoReverse = true;
            image.BeginAnimation(WidthProperty, IW);

            DoubleAnimation IH = new DoubleAnimation(); //анимация на длину картинки
            IH.From = 200;
            IH.To = 250;
            IH.Duration = TimeSpan.FromSeconds(2);
            IH.RepeatBehavior = RepeatBehavior.Forever;
            IH.AutoReverse = true;
            image.BeginAnimation(HeightProperty, IH);

            ThicknessAnimation MA = new ThicknessAnimation(); // анимация границ кнопки
            MA.From = new Thickness(50, 50, 50, 50);
            MA.To = new Thickness(0, 0, 0, 0);
            MA.Duration = TimeSpan.FromSeconds(3);
            MA.RepeatBehavior = RepeatBehavior.Forever;
            MA.AutoReverse = true;
            btn.BeginAnimation(MarginProperty, MA);

            ColorAnimation BA = new ColorAnimation();
            ColorConverter CC = new ColorConverter(); // создание объекта для конвертации кода в цвет
            Color Cstart = (Color)CC.ConvertFrom("#F679FF"); // присваивание начального цвета эл-ту
            btn.Background = new SolidColorBrush(Cstart); // закрашивание эл-та сплошным цветом
            BA.From = Cstart; // начальное значение свойства
            BA.To = (Color)CC.ConvertFrom("#EAFF73"); // конечное значение свойства
            BA.Duration = TimeSpan.FromSeconds(3);
            BA.AutoReverse = true;
            BA.RepeatBehavior = RepeatBehavior.Forever;
            btn.Background.BeginAnimation(SolidColorBrush.ColorProperty, BA);

        }
    }
}
