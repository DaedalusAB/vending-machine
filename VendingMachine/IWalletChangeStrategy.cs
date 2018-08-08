using System.Collections.Generic;

namespace VendingMachine
{
    public interface IWalletChangeStrategy
    {
        IEnumerable<IEnumerable<Credit>> MakeChange(int ammount, IEnumerable<int> availableCreditValues);
    }
}