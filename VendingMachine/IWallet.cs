using System.Collections.Generic;

namespace VendingMachine
{
    public interface IWallet
    {
        int GetBalance();
        void Add(Credit credit);
        void Add(IEnumerable<Credit> credits);
        IEnumerable<Credit> Take(int ammount);
    }
}
