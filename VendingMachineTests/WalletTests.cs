using System.Collections.Generic;
using System.Linq;
using VendingMachine;
using Xunit;

namespace VendingMachineTests
{
    public class WalletTests
    {
        [Fact]
        public void CreateEmptyWallet_Should_HaveBalanceZero()
        {
            var wallet = new Wallet(null);
            Assert.Equal(0, wallet.GetBalance());
        }

        [Theory]
        [InlineData(10)]
        public void AddCreditToWallet_Should_IncreaseBalance(int creditValue)
        {
            var wallet = new Wallet(null);
            var credit = new Credit(creditValue);
            wallet.Add(credit);

            Assert.Equal(credit.Value, wallet.GetBalance());
        }

        [Theory]
        [MemberData(nameof(InputCredits))]
        public void AddCredtisToWallet_Should_IncreaseBallance(List<Credit> credits)
        {
            var wallet = new Wallet(null);
            var totalCreditValue = credits.Sum(c => c.Value);
            wallet.Add(credits);

            Assert.Equal(totalCreditValue, wallet.GetBalance());
        }

        [Fact]
        public void AvailableCreditValues_Should_ReturnAllDistinctCoinValuesTheWalletContains()
        {
            var wallet = new Wallet(null);
            wallet.Add(new List<Credit>() { new Credit(10), new Credit(10), new Credit(50), new Credit(100) });

            var availableCoinValues = wallet.AvailableCoinValues.ToList();

            Assert.Contains(10, availableCoinValues);
            Assert.Contains(50, availableCoinValues);
            Assert.Contains(100, availableCoinValues);
        }

        public static IEnumerable<object[]> InputCredits()
        {
            yield return new object[] { new List<Credit>() { new Credit(10) } };
            yield return new object[] { new List<Credit>() { new Credit(10), new Credit(20) } };
        }
    }
}
