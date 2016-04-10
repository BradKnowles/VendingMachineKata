using Xunit;

namespace VendingMachineKata
{
    public partial class VendingMachineTests
    {
        public class ReturnCoinsTests
        {
            [Fact]
            public void ReturnCoinPressed_WhenCustomerInsertedCoins_ReturnsCoins_DisplaysInsertCoins()
            {
                var sut = new VendingMachine();
                sut.InsertCoin(Coins.Quarter);
                sut.InsertCoin(Coins.Nickel);
                sut.InsertCoin(Coins.Dime);

                sut.ReturnCoins();
                
                Assert.Contains(Coins.Quarter, sut.CoinReturnSlot);
                Assert.Contains(Coins.Nickel, sut.CoinReturnSlot);
                Assert.Contains(Coins.Dime, sut.CoinReturnSlot);
                Assert.Equal("INSERT COINS", sut.Display);

            }
        }
    }
}