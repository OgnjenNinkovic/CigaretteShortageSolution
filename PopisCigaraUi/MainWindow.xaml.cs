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

namespace PopisCigaraUi
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ExtFiles files = new ExtFiles();        
        List<Cigi> Cigis = new List<Cigi>();
       public List<Cigi> cTemp = new List<Cigi>();


        int finManjak;
        int finVisak;
       


        public MainWindow()
        {        
                   
                  
            InitializeComponent();
          
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
          
            files.createDir();
            files.loadData(listManjak);
            files.addData(Cigis);
            calcList();
            cTemp.Clear();
            foreach (Cigi c in listManjak.Items)
            {
                cTemp.Add(new Cigi(c.Barcode, c.Name, c.Kolicina, c.Cena));
            }

            listCount.Text = listManjak.Items.Count.ToString();

        }

        private void txtBar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                try
                {
                    long barcode = long.Parse(txtBar.Text);
                Cigi bar = null;

                foreach (Cigi c in Cigis)
                {
                    if (c.Barcode == barcode)
                    {
                        bar = c;
                    }
                }
               
                    txtNaziv.Text = bar.Name;
                }
                catch (Exception)
                {
                    txtBar.Text = "";
                }
                   
               
              
                TraversalRequest request = new TraversalRequest(FocusNavigationDirection.Next);
                request.Wrapped = true;
                ((TextBox)sender).MoveFocus(request);
            }
          
        }

        private void txtKol_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtBar.Text.Length > 0 )
            {
                if (e.Key == Key.Enter)
                {
                    if (txtBar.Text != "")
                    {
                        long barcode = long.Parse(txtBar.Text);
                        int kom = int.Parse(txtKol.Text);
                        Cigi bar = null;
                        foreach (Cigi c in Cigis)
                        {
                            if (c.Barcode == barcode)
                            {
                                bar = c;
                            }
                        }

                        bar.Kolicina = kom;
                        if (bar.Kolicina < 0)
                        {
                            listManjak.Items.Add(new Cigi(barcode, bar.Name, bar.Kolicina, bar.Cena));
                        }
                        else if (bar.Kolicina > 0)
                        {
                            listManjak.Items.Add(new Cigi(barcode, bar.Name, bar.Kolicina, bar.Cena));
                        }
                        else
                        {
                            return;
                        }



                        foreach (Cigi c in listManjak.Items)
                        {

                            if (c.Kolicina < 0)
                            {
                                finManjak += c.Kolicina * c.Cena;
                            }
                            else if (c.Kolicina > 0)
                            {
                                finVisak += c.Kolicina * c.Cena;
                            }
                        }
                        listCount.Text = listManjak.Items.Count.ToString();
                        calcList();
                        txtBar.Text = "";
                        txtNaziv.Text = "";
                        txtKol.Text = "";
                        TraversalRequest request = new TraversalRequest(FocusNavigationDirection.Previous);
                        request.Wrapped = true;
                        ((TextBox)sender).MoveFocus(request);
                        files.saveTempList(listManjak);
                        cTemp.Clear();
                        foreach (Cigi c in listManjak.Items)
                        {
                            cTemp.Add(new Cigi(c.Barcode, c.Name, c.Kolicina, c.Cena));
                        }
                    }

                    }
            }
            else
            {
                txtKol.Text = "";
                txtBar.Text = "";
                TraversalRequest request = new TraversalRequest(FocusNavigationDirection.Previous);
                request.Wrapped = true;
                ((TextBox)sender).MoveFocus(request);
            }


        }

        private void btnNoviPopis_Click(object sender, RoutedEventArgs e)
        {
            string thePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + System.IO.Path.DirectorySeparatorChar + "PopisCigara" + System.IO.Path.DirectorySeparatorChar + "Popisi";
            string[] filesDir = Directory.GetFiles(thePath);
            filesLimit(filesDir);


            if (listManjak.Items.Count > 0)
            {
                files.saveList(listManjak);
                File.Delete(files.cigiTempFile);
                listManjak.Items.Clear();
                visakTxt.Text = "";
                manjakTxt.Text = "";
                ukupanManjakTxt.Text = "";
                cTemp.Clear();
            }
          
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete)
            {
               
                if (listManjak.SelectedItems.Count > 0)
                {
                    /*remove selected item
                    listManjak.Items.RemoveAt(listManjak.SelectedIndex);
                    */
                    /* jos jedna vrijanta za brisanje jednog reda
                    //  this.listManjak.Items.Remove(listManjak.SelectedItem);
                    */
                    while (listManjak.SelectedItems.Count > 0)
                    {
                        listManjak.Items.Remove(listManjak.SelectedItem);
                    } // BINGO !!

                    calcList();
                    files.saveTempList(listManjak);
                    listCount.Text = listManjak.Items.Count.ToString();

                }
                
            }
        }

        public void calcList()
        {
            int finManjak = 0;
            int finVisak = 0;
            foreach (Cigi c in listManjak.Items)
            {

                if (c.Kolicina < 0)
                {
                    finManjak += c.Kolicina * c.Cena;
                }
                else if (c.Kolicina > 0)
                {
                    finVisak += c.Kolicina * c.Cena;
                }
            }
            visakTxt.Text = finVisak.ToString();
            manjakTxt.Text = finManjak.ToString();
            Cigi.FinManjak = Int32.Parse(manjakTxt.Text);
            Cigi.FinVisak = Int32.Parse(visakTxt.Text);
            ukupanManjakTxt.Text = Cigi.UkupanManjak;
        }

        private void btnPrint_Click(object sender, RoutedEventArgs e)
        {
            cTemp.Clear();
            foreach (Cigi c in listManjak.Items)
            {
                cTemp.Add(new Cigi(c.Barcode, c.Name, c.Kolicina, c.Cena));
            }



            using (frmPrint frm = new frmPrint( cTemp,DateTime.Now.ToString("dd.MM.yyyy"),Cigi.UkupanManjak,Cigi.FinManjak.ToString(),Cigi.FinVisak.ToString()))
            {
                frm.ShowDialog();
            }
        }

        private void btnBarkodIzvestaj_Click(object sender, RoutedEventArgs e)
        {
            cTemp.Clear();
            foreach (Cigi c in listManjak.Items)
            {
                cTemp.Add(new Cigi(c.Barcode, c.Name, c.Kolicina, c.Cena));
            }


            using (barCodeIzvestaj bar = new barCodeIzvestaj(cTemp,string.Format("{0}",Cigi.FinManjak*-1 + Cigi.FinVisak),DateTime.Now.ToString("dd.MM.yyyy")))
            {
                bar.ShowDialog();
            }

        }

        private void btnAnaliza_Click(object sender, RoutedEventArgs e)
        {
            AnalizaPopisa an = new AnalizaPopisa();
            an.Show();
        }

        private void filesLimit(string[] array)
        {
            Cultur.culturInf();
            string thePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + System.IO.Path.DirectorySeparatorChar + "PopisCigara" + System.IO.Path.DirectorySeparatorChar + "Popisi";
            List<DateTime> dates = new List<DateTime>();
            if(array.Length >= 10)
            {
                foreach (string item in array)
                {
                    dates.Add(DateTime.Parse(System.IO.Path.GetFileNameWithoutExtension(item)));
                }
                dates.Sort();
                File.Delete(thePath + System.IO.Path.DirectorySeparatorChar + dates.ElementAt(0).ToString("dd.MM.yyyy") + ".csv");

            }
        }

        private void label1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Kontrola Cigara\nDeveloped by Ognjen Ninković\nCopyright(C)Ognjen Ninković\nEmail: Oninkovic5@gmail.com",
               "About", MessageBoxButton.OK, MessageBoxImage.Asterisk);
        }
    }
}
