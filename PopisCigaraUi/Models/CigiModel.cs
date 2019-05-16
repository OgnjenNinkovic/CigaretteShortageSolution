using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace PopisCigaraUi
{
    public class Cultur
    {
        public static void culturInf()
        {
            //add System.Globalization; and System.Threading; using statemant

            CultureInfo culture = (CultureInfo)CultureInfo.CurrentCulture.Clone();
            culture.DateTimeFormat.ShortDatePattern = "dd.MM.yyyy";
            culture.DateTimeFormat.LongTimePattern = "";
            Thread.CurrentThread.CurrentCulture = culture;
        }
    }

   public class CigiModel
    {

        public long Barcode { get; set; }
        public string Name { get; set; }
        public int Kolicina { get; set; }
        public int Cena { get; set; }
        public double UkupanManjakLoad { get; set; }
        public string ListDate { get { return string.Format("Popis: {0}          Ukupno: {1}", Date.ToString("dd.MM.yyyy"), UkupanManjakLoad.ToString()); } }
        public DateTime Date { get; set; }
       
        public static int FinManjak { get; set; }
        public static int FinVisak { get; set; }
        public static string UkupanManjak { get { return string.Format("{0}", (((FinManjak * -1) - FinVisak) * -1).ToString()); } }

        public CigiModel(long barcode, string name, int kolicina, int cena, DateTime date, double ukupanManjakLoad)
        {
            Cultur.culturInf();
            this.Barcode = barcode;
            this.Name = name;
            this.Kolicina = kolicina;
            this.Cena = cena;
            Date = date;
            UkupanManjakLoad = ukupanManjakLoad;
           
        }
    }
}
