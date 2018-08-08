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
        [Fact]
        public void Test()
        {
            var makeChangeStrategy = new MakeChangeStrategy();
            var solutions = makeChangeStrategy.MakeChange(45, new List<int>() {25, 10, 5});

            var sb = new StringBuilder();
            foreach (var solution in solutions)
            {
                sb.Append("[");
                foreach (var credit in solution)
                {
                    sb.Append(credit.Value + ", ");
                }
                sb.Append("]\n");
            }

            var stringSolutions = sb.ToString();
        }

        public static IEnumerable<object[]> ChangeWays()
        {
            yield return new object[] { 45, new int[] { 25, 10, 5 }, 8 };
            yield return new object[] { 17, new int[] { 25, 10, 5 }, 0 };
            yield return new object[] { 17, new int[] { 25, 10, 1 }, 2 };
        }
    }
}
