using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VendingMachine;
using Xunit;

namespace VendingMachineTests
{
    public class MakeChangeStrategyTests
    {
        [Theory]
        [MemberData(nameof(ChangeWays))]
        public void MakeChange_Should_ReturnAllDistincCombinations(int ammount, List<int> availableCredits, int distinctSolutionCount)
        {
            var makeChangeStrategy = new MakeChangeStrategy();
            var changeCombinations = makeChangeStrategy.MakeChange(ammount, availableCredits);

            Assert.Equal(distinctSolutionCount, changeCombinations.Count());
        }

        public static IEnumerable<object[]> ChangeWays()
        {
            yield return new object[] { 45, new List<int>() { 25, 10, 5 }, 8 };
            yield return new object[] { 17, new List<int>() { 25, 10, 5 }, 0 };
            yield return new object[] { 17, new List<int>() { 25, 10, 1 }, 2 };
        }
    }
}
