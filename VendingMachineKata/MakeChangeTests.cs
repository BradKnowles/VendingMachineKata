using Xunit;
using Xunit.Sdk;

namespace VendingMachineKata
{
    public partial class VendingMachineTests
    {
        public class MakeChangeTests
        {
            [Fact]
            public void ColaButtonPress_UsingMoreThanCorrectChange_DispensesProduct_ReturnsRemainingAmount()
            {
                var sut = new VendingMachine();
                sut.InsertCoin(Coins.Quarter);
                sut.InsertCoin(Coins.Quarter);
                sut.InsertCoin(Coins.Quarter);
                sut.InsertCoin(Coins.Quarter);
                sut.InsertCoin(Coins.Quarter);
                sut.InsertCoin(Coins.Quarter);
                sut.PushColaButton();

                Assert.Equal("THANK YOU", sut.Display);
                Assert.Equal(Products.Cola, sut.ProductTray);
                Assert.Equal(0.50m, sut.CoinReturnTotal);
                Assert.Equal("INSERT COINS", sut.Display);
                Assert.Equal(0m, sut.Total);
            }

            [Fact]
            public void CandyButtonPress_UsingMoreThanCorrectChange_DispensesProduct_ReturnsRemainingAmount()
            {
                var sut = new VendingMachine();
                sut.InsertCoin(Coins.Quarter);
                sut.InsertCoin(Coins.Quarter);
                sut.InsertCoin(Coins.Quarter);
                sut.InsertCoin(Coins.Quarter);
                sut.PushCandyButton();

                Assert.Equal("THANK YOU", sut.Display);
                Assert.Equal(Products.Candy, sut.ProductTray);
                Assert.Equal(0.35m, sut.CoinReturnTotal);
                Assert.Equal("INSERT COINS", sut.Display);
                Assert.Equal(0m, sut.Total);
            }

            [Fact]
            public void ChipsButtonPress_UsingMoreThanCorrectChange_DispensesProduct_ReturnsRemainingAmount()
            {
                var sut = new VendingMachine();
                sut.InsertCoin(Coins.Quarter);
                sut.InsertCoin(Coins.Dime);
                sut.InsertCoin(Coins.Dime);
                sut.InsertCoin(Coins.Dime);
                sut.PushChipsButton();

                Assert.Equal("THANK YOU", sut.Display);
                Assert.Equal(Products.Chips, sut.ProductTray);
                Assert.Equal(0.05m, sut.CoinReturnTotal);
                Assert.Equal("INSERT COINS", sut.Display);
                Assert.Equal(0m, sut.Total);
            }
        }
    }
}