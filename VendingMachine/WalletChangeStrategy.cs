using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachine
{
    public class WalletChangeStrategy : IWalletChangeStrategy
    {
        public IEnumerable<IEnumerable<Credit>> MakeChange(int ammount, IEnumerable<int> availableCreditValues)
        {
            throw new NotImplementedException();
        }
    }
}
