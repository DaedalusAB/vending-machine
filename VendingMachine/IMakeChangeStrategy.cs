using System.Collections.Generic;

namespace VendingMachine
{
    public interface IMakeChangeStrategy
    {
        IEnumerable<IEnumerable<Credit>> MakeChange(int ammount, IReadOnlyList<int> availableCreditValues);
    }
}