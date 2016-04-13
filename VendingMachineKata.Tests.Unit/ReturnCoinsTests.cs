using System.Linq;
using Xunit;

namespace VendingMachineKata.Tests.Unit
{
    public partial class VendingMachineTests
    {
        public class ReturnCoinsTests
        {
            [Fact]
            public void ReturnCoinPressed_WhenCustomerInsertedCoins_ReturnsCoins_DisplaysInsertCoins()
            {
                var sut = GetDefaultInstance();
                sut.InsertCoin(Coins.Quarter);
                sut.InsertCoin(Coins.Nickel);
                sut.InsertCoin(Coins.Dime);

                sut.ReturnCoins();

                Assert.Contains(Coins.Quarter, sut.CoinReturnSlot);
                Assert.Contains(Coins.Nickel, sut.CoinReturnSlot);
                Assert.Contains(Coins.Dime, sut.CoinReturnSlot);
                Assert.Equal("INSERT COINS", sut.Display);
            }

            [Fact]
            public void ReturnCoinPressed_WhenCustomerInsertsMultipleSimiliarCoins_ReturnsCorrectNumberAndTypeOfCoins_DisplaysInsertCoins()
            {
                var sut = GetDefaultInstance();
                sut.InsertCoin(Coins.Quarter);
                sut.InsertCoin(Coins.Quarter);
                sut.InsertCoin(Coins.Nickel);
                sut.InsertCoin(Coins.Nickel);
                sut.InsertCoin(Coins.Nickel);
                sut.InsertCoin(Coins.Dime);
                sut.InsertCoin(Coins.Dime);

                sut.ReturnCoins();

                Assert.Contains(Coins.Quarter, sut.CoinReturnSlot);
                Assert.Contains(Coins.Nickel, sut.CoinReturnSlot);
                Assert.Contains(Coins.Dime, sut.CoinReturnSlot);
                Assert.Equal(7, sut.CoinReturnSlot.Count());
                Assert.Equal(2, sut.CoinReturnSlot.Count(x => x == Coins.Quarter));
                Assert.Equal(3, sut.CoinReturnSlot.Count(x => x == Coins.Nickel));
                Assert.Equal(2, sut.CoinReturnSlot.Count(x => x == Coins.Dime));
                Assert.Equal("INSERT COINS", sut.Display);
            }
        }
    }
}