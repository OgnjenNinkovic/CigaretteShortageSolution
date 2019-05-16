using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace PopisCigaraUi.Models
{
    public class GridViewRowBackgroundConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var item = (ListViewItem)value;
            var listview = ItemsControl.ItemsControlFromItemContainer(item) as ListView;
            int index =
              listview.ItemContainerGenerator.IndexFromContainer(item);            

            if (index % 2 == 0)
            {
                return Brushes.Bisque;
            }
            else
            {
                return Brushes.Beige;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
