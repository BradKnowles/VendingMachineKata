using Xunit;

namespace VendingMachineKata
{
    public class VendingMachineTests
    {
        public class AcceptCoins
        {
            [Fact]
            public void InsertCoin_InsertValidCoin_UpdatesTotalReturnsTotalForDisplay()
            {
                var validCoin = new Coin();
                var sut = new VendingMachine();
                var results = sut.InsertCoin(validCoin);

                Assert.Equal("$0.05", result);
            }
        }

    }
}