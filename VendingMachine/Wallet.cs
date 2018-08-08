using System;
using System.Collections.Generic;
using System.Linq;


namespace VendingMachine
{
    public class Wallet : IWallet
    {
        private readonly List<Credit> _credits;
        private readonly IMakeChangeStrategy _makeChangeStrategy;
        
        public Wallet(IMakeChangeStrategy makeChangeStrategy)
        {
            _credits = new List<Credit>();
            _makeChangeStrategy = makeChangeStrategy;
        }

        public int GetBalance() =>
            _credits.Sum(c => c.Value);
        
        public void Add(Credit credit) =>
            _credits.Add(credit);
        
        public void Add(IEnumerable<Credit> credits) =>
            _credits.AddRange(credits);
        
        public IEnumerable<Credit> Take(int ammount)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<int> AvailableCoinValues =>
            _credits.Distinct().Select(c => c.Value);
    }
}
