using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VendingMachine
{
    public class CreditListComparer : IEqualityComparer<List<Credit>>
    {
        public bool Equals(List<Credit> x, List<Credit> y)
        {
            return x.SequenceEqual(y);
        }

        public int GetHashCode(List<Credit> x)
        {
            return x.Sum(c => c.Value);
        }
    }
}
