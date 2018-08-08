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
        public void AddCretisToWallet_Should_IncreaseBallance(IEnumerable<Credit> credits)
        {
            var creditsList = credits.ToList();     //  TODO: possible multiple enumeration of IEnumerable - cool? not cool?
            var wallet = new Wallet(null);
            var totalCreditValue = creditsList.Sum(c => c.Value);
            wallet.Add(creditsList);

            Assert.Equal(totalCreditValue, wallet.GetBalance());
        }

        public static IEnumerable<object[]> InputCredits()
        {
            yield return new object[] { new List<Credit>() { new Credit(10) } };
            yield return new object[] { new List<Credit>() { new Credit(10), new Credit(20) } };
        }
    }
}
