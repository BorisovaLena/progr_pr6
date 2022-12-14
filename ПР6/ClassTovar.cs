using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace ПР6
{
    public partial class Table_Tovari
    {
        public SolidColorBrush KolTovar
        {
            get
            {
                if (kol == 0) //если количество товара равно 0
                {
                    return Brushes.Coral;
                }
                else
                {
                    return Brushes.White;
                }
            }
        }
        public string CountTov
        {
            get
            {
                return string.Format("Цена: {0:C2}", count);
            }
        }
        public string KolTov
        {
            get
            {
                return "Количество: " + kol + " шт";
            }
        }
    }
}
