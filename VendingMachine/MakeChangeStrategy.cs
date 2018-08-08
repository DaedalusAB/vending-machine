using System;
using System.Collections.Generic;
using System.Linq;

namespace VendingMachine
{
    public class MakeChangeStrategy : IMakeChangeStrategy
    {
        public IEnumerable<IEnumerable<Credit>> MakeChange(int ammount, IReadOnlyList<int> availableCreditValues)
        {
            return ammount == 0
                ? new List<List<Credit>>()
                : MakeChange(ammount, 0, availableCreditValues, new Stack<Credit>(), new List<List<Credit>>());
        }

        private List<List<Credit>> MakeChange(int ammount, int index, IReadOnlyList<int> availableCreditValues,
            Stack<Credit> combo, List<List<Credit>> solutions)
        {
            var largestApplicableCreditValue = availableCreditValues.Skip(index).FirstOrDefault(c => c <= ammount);

            combo.Push(new Credit(largestApplicableCreditValue));
            if (ammount == largestApplicableCreditValue)
            {
                var solution = combo.ToList();
                solution.Sort((c1, c2) => c2.Value.CompareTo(c1.Value));
                solutions.Add(solution);
            }
            else
            {
                MakeChange(ammount - largestApplicableCreditValue, index, availableCreditValues, combo, solutions);
            }

            combo.Pop();

            if (index < availableCreditValues.Count - 1)
            {
                MakeChange(ammount, index + 1, availableCreditValues, combo, solutions);
            }

            return solutions;
        }
    }
}
