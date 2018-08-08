using System;
using VendingMachine;
using Xunit;

namespace VendingMachineTests
{
    public class CreditTests
    {
        [Fact]
        public void CreateCredit_Should_NotThrow()
        { 
            var credit = new Credit(10);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-10)]
        public void TryToCreateInvalidCredit_Should_Throw(int value)
        {
            Assert.Throws<ArgumentException>(() => new Credit(value));
        }
    }
}
