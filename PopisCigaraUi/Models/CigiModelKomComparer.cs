using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PopisCigaraUi.Models
{
    class CigiModelKomComparer : IEqualityComparer<CigiModel>
    {
        public bool Equals(CigiModel x, CigiModel y)
        {
            if (x == null) return (y == null);
            if (y == null) return false;
            if (x.Barcode != y.Barcode) return false;
            if (x.Kolicina != y.Kolicina) return false;
            return true;
        }

        public int GetHashCode(CigiModel obj)
        {
            throw new NotImplementedException();
        }
    }
}
