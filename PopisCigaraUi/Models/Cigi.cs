using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PopisCigaraUi
{
   public class Cigi
    {
        public long Barcode { get; set; }
        public string Name { get; set; }
        public int Kolicina { get; set; }
        public int Cena { get; set; }
        public string nazGrupa { get; set; }


        public   static int FinManjak { get; set; }
      public  static int FinVisak { get; set; }
      public  static string UkupanManjak { get { return string.Format("{0}", (((FinManjak * -1) - FinVisak) * -1).ToString()); } }

        public Cigi(long barcode, string name, int kolicina, int cena)
        {
            this.Barcode = barcode;
            this.Name = name;
            this.Kolicina = kolicina;
            this.Cena = cena;
         
          

        }

        public Cigi(long barcode, string name, int kolicina, int cena,string nazgrupa)
        {
            this.Barcode = barcode;
            this.Name = name;
            this.Kolicina = kolicina;
            this.Cena = cena;
            this.nazGrupa = nazgrupa;



        }

    }
}
