using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace PopisCigaraUi.Models
{
   public class BarcodeToBackground : IValueConverter
    {
        public static List<CigiModel> CigiCompare = new List<CigiModel>();
        public static List<CigiModel> CigiByDate = new List<CigiModel>();
        string thePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + System.IO.Path.DirectorySeparatorChar + "PopisCigara" + System.IO.Path.DirectorySeparatorChar + "Popisi";

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            CigiModelBarcodeComparer barcodeComparer = new CigiModelBarcodeComparer();
            CigiModelKomComparer komComparer = new CigiModelKomComparer();
            Cultur.culturInf();

            long barcode = (long)System.Convert.ChangeType(value, typeof(long));
            long listBar = 0;

            foreach (CigiModel cigi in CigiByDate)
            {
                if(!CigiCompare.Contains(cigi,barcodeComparer))
                {
                    listBar = cigi.Barcode;
                }
                if (barcode == listBar)
                    return -1;

                if(!CigiCompare.Contains(cigi, komComparer))
                {
                    listBar = cigi.Barcode;
                    if (barcode == listBar)
                        return +1;
                }
            }
            return 0;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
