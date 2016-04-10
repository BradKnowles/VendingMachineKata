using Xunit;

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
        }
    }
}