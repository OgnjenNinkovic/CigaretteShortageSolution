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
using System.Windows.Shapes;
using PopisCigaraUi.Models;

namespace PopisCigaraUi
{
    /// <summary>
    /// Interaction logic for AnalizaPopisa.xaml
    /// </summary>
    public partial class AnalizaPopisa : Window
    {
        public List<CigiModel> cigis { get; set; }
        public List<CigiModel> CigisList { get; set; }
        public string date;
        public AnalizaPopisa()
        {
            InitializeComponent();
            cigis = new List<CigiModel>();
            CigisList = new List<CigiModel>();
            populateData(cigis);
        }

      

   

        private void winAnaliza_Loaded(object sender, RoutedEventArgs e)
        {
            Cultur.culturInf();
            listView.Items.Clear();
            BarcodeToBackground.CigiByDate.Clear();
            BarcodeToBackground.CigiCompare.Clear();
            List<DateTime> dates = new List<DateTime>();
            listTransfer(CigisList);
            foreach (CigiModel item in cigis)
            {
                dates.Add(item.Date);
            }
            dates.Sort();
            IEnumerable<DateTime> dateQuery = dates
                .Distinct();
            foreach (var item in dateQuery)
            {
                ComboBoxDate.Items.Add(item.ToString());
            }


            var cigiviewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("cigiviewSource")));
            cigiviewSource.Source =
                from cigi in CigisList
                orderby cigi.Date, cigi.UkupanManjakLoad, cigi.Barcode, cigi.Name, cigi.Cena,cigi.Kolicina
                select cigi;

        }

        private void populateData(List<CigiModel> cigare)
        {

            string thePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + System.IO.Path.DirectorySeparatorChar + "PopisCigara" + System.IO.Path.DirectorySeparatorChar + "Popisi";



            string[] filesDir = Directory.GetFiles(thePath);
            if (filesDir.Length > 0)
            {
                string[] fileContent = null;
                foreach (string s in filesDir)
                {
                    Cultur.culturInf();
                    fileContent = File.ReadAllLines(thePath + System.IO.Path.DirectorySeparatorChar + System.IO.Path.GetFileName(s));
                    Array.Sort(fileContent);
                    string[] row;
                    foreach (string m in fileContent)
                    {                    
                        row = m.Split(',');
                        cigare.Add(new CigiModel(long.Parse(row[0]), row[1], int.Parse(row[2]), int.Parse(row[3]), DateTime.Parse(row[4]), double.Parse(row[5])));
                    }

                }

            }



        }

        private void ComboBoxDate_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            date = ComboBoxDate.SelectedValue.ToString();
            CigisList.Clear();
            BarcodeToBackground.CigiCompare.Clear();
            BarcodeToBackground.CigiByDate.Clear();

            foreach (CigiModel cigi in cigis)
            {
                if (cigi.Date == DateTime.Parse(date))
                {
                    BarcodeToBackground.CigiCompare.Add(cigi);
                }

                if (cigi.Date >= DateTime.Parse(date))
                {
                    BarcodeToBackground.CigiByDate.Add(cigi);
                    CigisList.Add(cigi);
                        
                }
            }
            var cigiviewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("cigiviewSource")));
            cigiviewSource.Source =
                from cigi in CigisList
                orderby cigi.Date, cigi.UkupanManjakLoad, cigi.Barcode, cigi.Name, cigi.Cena, cigi.Kolicina
                select cigi;
        }

        private void listTransfer(List<CigiModel> list)
        {
            foreach (CigiModel item in cigis)
            {
                list.Add(item);
            }
        }
    }


   
}
