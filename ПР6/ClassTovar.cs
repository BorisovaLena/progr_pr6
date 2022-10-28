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
                if (kol == 0)
                {
                    return Brushes.Coral;
                }
                else
                {
                    return Brushes.White;
                }
            }

        }
    }
}
