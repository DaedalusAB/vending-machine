using System.Collections.Generic;

namespace VendingMachine
{
    public interface IWalletChangeStrategy
    {
        IEnumerable<Credit> Take(int ammount);
    }
}