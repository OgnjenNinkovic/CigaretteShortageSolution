using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PopisCigaraUi.Models
{
    class CigiModelBarcodeComparer : IEqualityComparer<CigiModel>
    {
        public bool Equals(CigiModel x, CigiModel y)
        {
            if (x == null) return (y == null);
            if (y == null) return false;
            return (x.Barcode == y.Barcode);
        }

        public int GetHashCode(CigiModel obj)
        {
            return obj.Barcode.GetHashCode();
        }
    }
}
